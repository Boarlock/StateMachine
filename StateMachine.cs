
namespace SMachine
{
    public class StateMachine {

        private readonly Dictionary<string, State> states = [];
        public State? CurrentState { get; private set; }

        private readonly struct TransitionRequest
        {
            public State Next { get; }
            public BaseContext? Context { get; }

            internal TransitionRequest(State next, BaseContext? context)
            {
                Next = next;
                Context = context;
            }
        }

        private readonly Queue<TransitionRequest> transitionQueue = new();
        private bool isProcessingLifecycle;

        public State? CreateState(
            string name) {

            State state = new(this);

            if (string.IsNullOrWhiteSpace(name) ||
                !states.TryAdd(name, state))
                return null;

            return state;
        }

        // Starting when one is already started will return false, will
        // be documented. Entering on sub states has been resolved.
        public bool StartState(
            State next, 
            bool enabled = true) {

            if (next.Machine != this)
                throw new ArgumentException("Illegal Argument: State Machine on paramater doesn't match instance.", nameof(next));

            if (CurrentState != null)
                return false;

            CurrentState = next;
            CurrentState.SetEnabled(enabled);
            return true;
        }

        public bool StartState(
            string name, 
            bool enabled = true) {

            if (!states.TryGetValue(name, out State? sub) ||
                CurrentState != null)
                return false;

            CurrentState = sub;
            CurrentState.SetEnabled(enabled);
            return true;
        }

        // Starting a state needs an anti-method. This is different from enabling false as the state lifetime is reset.
        // Will be documented this isn't the 'traditional' way to stop updates.
        public void StopState()
        {
            isProcessingLifecycle = true;

            try
            {
                CurrentState?.Exit();
                CurrentState = null;
                transitionQueue.Clear();
            }
            finally
            {
                isProcessingLifecycle = false;
            }
        }

        // Transitioning into a disabled state is allowed, will be documented.
        // Recursion access is removed, will be documented.
        public void TransitionState(
            State next, 
            BaseContext? data = null) {

            if (next.Machine != this)
                throw new ArgumentException("State belongs to a different state machine.", nameof(next));

            if (CurrentState is null)
                throw new InvalidOperationException("Cannot transition when no state is active.");

            if (next == CurrentState)
                return;

            if (isProcessingLifecycle)
            {
                transitionQueue.Enqueue(new TransitionRequest(next, data));
                return;
            }

            ExecuteTransition(next, data);
            ProcessTransitions();
        }

        public void TransitionState(
            State next, 
            Func<bool> predicate, 
            BaseContext? data = null) {

            if (predicate == null || !predicate())
                return;

            TransitionState(next, data);
        }

        private void ExecuteTransition(
            State next,
            BaseContext? data = null)
        {
            isProcessingLifecycle = true;

            try
            {
                if (data is null)
                {
                    CurrentState?.Exit();
                    CurrentState = next;
                    CurrentState.Enter();
                }
                else
                {
                    CurrentState?.Exit(data);
                    CurrentState = next;
                    CurrentState.Enter(data);
                }
            }
            finally
            {
                isProcessingLifecycle = false;
            }
        }

        public bool TryGetState(string name, out State? state) 
            => states.TryGetValue(name, out state);

        public State GetState(string name) => states[name];

        public void Update(BaseContext? data = null) {

            if (CurrentState is null)
                return;

            isProcessingLifecycle = true;

            try
            {
                if (data is null)
                    CurrentState?.Update();
                else
                    CurrentState?.Update(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        // Update-Transition recursive entry is handled on the substate class level.
        // Frontslash '/' cannot be used in SubState names in this version, will be documented.
        public void IndependentUpdate(
            string name,
            BaseContext? data = null)
        {
            if (CurrentState is null ||
                string.IsNullOrWhiteSpace(name))
                return;

            string[] names = name.Split('/');

            if (!CurrentState.TryGetSub(names[0], out SubState? sub))
                return;

            for (int i = 1; i < names.Length; i++)
            {
                if (!sub!.TryGetSub(names[i], out sub))
                    return;
            }

            isProcessingLifecycle = true;

            try
            {
                if (data is null)
                    sub?.UpdateIndependent();
                else
                    sub?.UpdateIndependent(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        private void ProcessTransitions()
        {
            while (transitionQueue.TryDequeue(out TransitionRequest req))
            {
                if (req.Next == CurrentState) 
                    continue;

                ExecuteTransition(req.Next, req.Context);
            }
        }
    }
}
