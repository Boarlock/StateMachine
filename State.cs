
namespace SMachine
{
    public class State
    {
        // Enabled is publically accessible through the setter.
        public bool Enabled { get; private set; }
        public void SetEnabled(bool enabled) => Enabled = enabled;

        protected readonly Dictionary<string, SubState> substates = [];
        public StateMachine Machine { get; }
        public SubState? CurrentSub { get; private set; }

        private readonly struct TransitionRequest
        {
            public SubState Next { get; }
            public BaseContext? Context { get; }

            internal TransitionRequest(SubState next, BaseContext? context)
            {
                Next = next;
                Context = context;
            }
        }

        private readonly Queue<TransitionRequest> transitionQueue = new();
        protected bool isProcessingLifecycle;

        internal State(
            StateMachine machine, 
            bool enabled = true) {

            ArgumentNullException.ThrowIfNull(machine);
            Machine = machine;
            Enabled = enabled;
        }

        internal void Enter(BaseContext data) {

            isProcessingLifecycle = true;

            try
            {
                OnEnterContext?.Invoke(data);
                CurrentSub?.Enter(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal void Enter() {

            isProcessingLifecycle = true;

            try
            {
                OnEnter?.Invoke();
                CurrentSub?.Enter();
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        // Enabled behavior has evolved to only apply to that specific state,
        // propogation controls updates downwards to sub states.
        internal virtual void Update(BaseContext data) {

            isProcessingLifecycle = true;

            try
            {
                if (Enabled)
                    InvokeContextUpdate(data);

                CurrentSub?.Update(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal virtual void Update() {

            isProcessingLifecycle = true;

            try
            {
                if (Enabled)
                    InvokeUpdate();

                CurrentSub?.Update();
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal void Exit(BaseContext data) {

            isProcessingLifecycle = true;

            try
            {
                CurrentSub?.Exit(data);
                OnExitContext?.Invoke(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal void Exit() {

            isProcessingLifecycle = true;

            try
            {
                CurrentSub?.Exit();
                OnExit?.Invoke();
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        public event Action<BaseContext>? OnEnterContext;
        public event Action? OnEnter;

        protected void InvokeContextUpdate(BaseContext data) => OnUpdateContext?.Invoke(data);
        protected void InvokeUpdate() => OnUpdate?.Invoke();
        public event Action<BaseContext>? OnUpdateContext;
        public event Action? OnUpdate;

        public event Action<BaseContext>? OnExitContext;
        public event Action? OnExit;

        // Updated name validation
        public SubState? CreateSubState(
            string name,
            bool propagation = true) {

            SubState sub = new(
                    Machine,
                    this,
                    propagation);

            if (string.IsNullOrWhiteSpace(name) ||
                name.Contains('/') ||
                !substates.TryAdd(name, sub))
                return null;

            return sub;
        }

        public bool StartSubState(
            SubState next, 
            bool enabled = true) {

            if (next.Parent != this)
                throw new ArgumentException("Illegal Argument: State Parent on paramater doesn't match instance.", nameof(next));

            if (CurrentSub != null)
                return false;

            CurrentSub = next;
            CurrentSub.SetEnabled(enabled);
            return true;
        }

        public bool StartSubState(
            string name, 
            bool enabled = true) {

            if (!substates.TryGetValue(name, out SubState? sub) ||
                CurrentSub != null)
                return false;

            CurrentSub = sub;
            CurrentSub.SetEnabled(enabled);
            return true;
        }

        public void StopSubState()
        {
            isProcessingLifecycle = true;

            try
            {
                CurrentSub?.Exit();
                CurrentSub = null;
                transitionQueue.Clear();
            }
            finally
            {
                isProcessingLifecycle = false;
            }
        }

        public void TransitionSubState(
            SubState next,
            BaseContext? data = null) {

            if (next.Parent != this)
                throw new ArgumentException("State belongs to a different state machine.", nameof(next));

            if (CurrentSub is null)
                throw new InvalidOperationException("Cannot transition when no state is active.");

            if (next == CurrentSub)
                return;

            if (isProcessingLifecycle)
            {
                transitionQueue.Enqueue(new TransitionRequest(next, data));
                return;
            }

            ExecuteTransition(next, data);
            ProcessTransitions();
        }

        public void TransitionSubState(
            SubState next,
            Func<bool> predicate,
            BaseContext? data = null) {

            if (predicate == null || 
                !predicate() ||
                next == CurrentSub)
                return;

            TransitionSubState(next, data);
        }

        private void ExecuteTransition(
            SubState next,
            BaseContext? data = null)
        {
            isProcessingLifecycle = true;

            try
            {
                if (data is null)
                {
                    CurrentSub?.Exit();
                    CurrentSub = next;
                    CurrentSub.Enter();
                }
                else
                {
                    CurrentSub?.Exit(data);
                    CurrentSub = next;
                    CurrentSub.Enter(data);
                }
            }
            finally
            {
                isProcessingLifecycle = false;
            }
        }

        public bool TryGetSub(string name, out SubState? sub)
            => substates.TryGetValue(name, out sub);

        public SubState GetSub(string name) => substates[name];

        protected void ProcessTransitions()
        {
            while (transitionQueue.TryDequeue(out TransitionRequest req))
            {
                if (req.Next == CurrentSub) 
                    continue;

                ExecuteTransition(req.Next, req.Context);
            }
        }
    }
}
