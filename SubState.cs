
namespace SMachine
{
    public class SubState : State {
        internal SubState(
            StateMachine machine,
            State parent,
            bool Propagation = true)
            : base(machine) {

            Parent = parent;
            UpdatePropagation = Propagation;
        }

        public State Parent { get; }
        public bool UpdatePropagation { get; protected set; }

        public event Action<BaseContext>? OnIndependentUpdateContext;
        public event Action? OnIndependentUpdate;

        internal override void Update(BaseContext data) {

            isProcessingLifecycle = true;

            try
            {
                if (Enabled)
                    InvokeContextUpdate(data);

                if (UpdatePropagation)
                    CurrentSub?.Update(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal override void Update() {

            isProcessingLifecycle = true;

            try
            {
                if (Enabled)
                    InvokeUpdate();

                if (UpdatePropagation)
                    CurrentSub?.Update();
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal void UpdateIndependent(BaseContext data) {

            isProcessingLifecycle = true;

            try
            {
                if (Enabled)
                    OnIndependentUpdateContext?.Invoke(data);

                if (CurrentSub is not null &&
                    CurrentSub.UpdatePropagation)
                    CurrentSub.Update(data);
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }

        internal void UpdateIndependent() {

            isProcessingLifecycle = true;

            try
            {
                if (Enabled)
                    OnIndependentUpdate?.Invoke();

                if (CurrentSub is not null &&
                    CurrentSub.UpdatePropagation)
                    CurrentSub.Update();
            }
            finally
            {
                isProcessingLifecycle = false;
            }

            ProcessTransitions();
        }
    }
}
