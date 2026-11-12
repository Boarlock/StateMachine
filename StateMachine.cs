using System.Diagnostics.CodeAnalysis;

namespace SMachine
{
    public partial class StateMachine : StateNode<State> {

        public StateMachine() { Machine = this; }

        public State CreateState<TKey>(TKey key) where TKey : struct, Enum
            => CreateChild(key, () => new State(Machine));

        public bool TryCreateState<TKey>(
            TKey key,
            [NotNullWhen(true)] out State? state)
            where TKey : struct, Enum {

            if (states.ContainsKey(EnumKey.Create(key))) {

                state = null;
                return false;
            }

            state = CreateState(key);
            return true;
        }

        public void Update(BaseContext? data = null) {

            if (CurrentState is null)
                return;

            UpdateInternal(data);
        }
    }
}
