using System.Diagnostics.CodeAnalysis;

namespace SMachine
{
    public class State : StateNode<SubState>
    {
        public bool Enabled { get; private set; }
        private protected override bool IsEnabled => Enabled;
        public void SetEnabled(bool enabled) => Enabled = enabled;

        private protected override bool CheckNonMatch(SubState next) => next.Parent != this;

        internal State(
            StateMachine machine, 
            bool enabled = true) {

            ArgumentNullException.ThrowIfNull(machine, nameof(machine));

            Machine = machine;
            Enabled = enabled;
        }

        internal void Enter(BaseContext? data) {

            lifecycleDepth++;

            try {

                if (data is null) {

                    OnEnter?.Invoke();
                    CurrentState?.Enter(null);
                }
                else {

                    OnEnterContext?.Invoke(data);
                    CurrentState?.Enter(data);
                }
            }
            finally {

                lifecycleDepth--;
            }

            ProcessTransitions();
        }

        private protected override void RaiseUpdate(
            BaseContext? data, 
            bool independent) {

            if (data is null)
                OnUpdate?.Invoke();
            else
                OnUpdateContext?.Invoke(data);
        }

        internal void Exit(BaseContext? data) {

            lifecycleDepth++;

            try {

                if (data is null) {

                    CurrentState?.Exit(null);
                    OnExit?.Invoke();
                }
                else {

                    CurrentState?.Exit(data);
                    OnExitContext?.Invoke(data);
                }
            }
            finally {

                lifecycleDepth--;
            }

            ProcessTransitions();
        }

        public event Action<BaseContext>? OnEnterContext;
        public event Action? OnEnter;

        public event Action<BaseContext>? OnUpdateContext;
        public event Action? OnUpdate;

        public event Action<BaseContext>? OnExitContext;
        public event Action? OnExit;

        public SubState CreateState<TKey>(TKey key, bool propagation = true) where TKey : struct, Enum
            => CreateChild(key, () => new SubState(Machine, this, propagation));

        public bool TryCreateState<TKey>(
            TKey key,
            [NotNullWhen(true)] out SubState? state)
            where TKey : struct, Enum {

            if (states.ContainsKey(EnumKey.Create(key))) {

                state = null;
                return false;
            }

            state = CreateState(key);
            return true;
        }
    }
}
