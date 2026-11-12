
namespace SMachine
{
    public sealed class SubState : State {
        internal SubState(
            StateMachine machine,
            State parent,
            bool propagation = true)
            : base(machine) {

            Parent = parent;
            UpdatePropagation = propagation;
        }

        public State Parent { get; }
        public bool UpdatePropagation { get; }
        private protected override bool PropagatesUpdate => UpdatePropagation;

        public event Action<BaseContext>? OnIndependentUpdateContext;
        public event Action? OnIndependentUpdate;

        private protected override void RaiseUpdate(
            BaseContext? data, 
            bool independent) {

            if (independent) {

                if (data is null) 
                    OnIndependentUpdate?.Invoke();
                else 
                    OnIndependentUpdateContext?.Invoke(data);
            }
            else {

                base.RaiseUpdate(data, independent);
            }
        }
    }
}
