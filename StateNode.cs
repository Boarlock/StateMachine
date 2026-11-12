using System.Runtime.CompilerServices;

namespace SMachine
{
    public readonly record struct EnumKey(
        RuntimeTypeHandle TypeHandle, 
        ulong Value) {
        public static EnumKey Create<TEnum>(TEnum value) 
            where TEnum : struct, Enum {

            // Unsafe.As converts the enum to its underlying integral type with zero boxing
            ulong rawValue = Unsafe.SizeOf<TEnum>() switch {

                1 => Unsafe.As<TEnum, byte>(ref value),
                2 => Unsafe.As<TEnum, ushort>(ref value),
                4 => Unsafe.As<TEnum, uint>(ref value),
                8 => Unsafe.As<TEnum, ulong>(ref value),
                _ => throw new NotSupportedException()
            };

            return new EnumKey(typeof(TEnum).TypeHandle, rawValue);
        }
    }

    public abstract class StateNode<TChild> where TChild : State {

        public StateMachine Machine { get; private protected set; } = null!;

        public TChild? CurrentState { get; private protected set; }

        private protected readonly Dictionary<EnumKey, TChild> states = new();

        private protected record struct TransitionRequest(TChild Next, BaseContext? Context);
        private protected readonly Queue<TransitionRequest> transitionQueue = new();
        internal int lifecycleDepth = 0;

        private protected virtual bool IsEnabled => true;
        private protected virtual bool PropagatesUpdate => true;

        private protected virtual void RaiseUpdate(BaseContext? data, bool independent) { }
        private protected virtual bool CheckNonMatch(TChild next) => false; 

        private protected TChild CreateChild<TKey>(
            TKey key,
            Func<TChild> factory)
            where TKey : struct, Enum {

            var enumKey = EnumKey.Create(key);
            TChild state = factory();

            if (!states.TryAdd(enumKey, state))
                throw new InvalidOperationException("Invalid Operation: Cannot create new substate when it already exists in this context.");

            return state;
        }

        public bool TryGetState<TKey>(TKey key, out TChild? state) where TKey : struct, Enum
            => states.TryGetValue(EnumKey.Create(key), out state);
        public TChild GetState<TKey>(TKey key) where TKey : struct, Enum
            => states[EnumKey.Create(key)];

        // Enter update begins whether Enabled is on or off, Enabled effects Updates
        public bool StartState(
            TChild next,
            BaseContext? ctx = null,
            bool enabled = true) {

            if (next.Machine != Machine)
                throw new ArgumentException("Illegal Argument: State Machine on paramater doesn't match instance.", nameof(next));

            if (CheckNonMatch(next))
                throw new ArgumentException("Illegal Argument: State belongs to a different parent.", nameof(next));

            if (CurrentState != null)
                return false;

            CurrentState = next;
            CurrentState.SetEnabled(enabled);
            CurrentState.Enter(ctx);
            return true;
        }

        public bool StartState<TKey>(
            TKey key,
            BaseContext? ctx = null,
            bool enabled = true)
            where TKey : struct, Enum {

            if (!states.TryGetValue(EnumKey.Create(key), out TChild? sub) ||
                CurrentState != null)
                return false;

            CurrentState = sub;
            CurrentState.SetEnabled(enabled);
            CurrentState.Enter(ctx);
            return true;
        }

        public void StopState() {

            lifecycleDepth++;

            try {

                CurrentState?.Exit(null);
                CurrentState = null;
                transitionQueue.Clear();
            }
            finally {

                lifecycleDepth--;
            }
        }

        public bool TransitionState(
            TChild next,
            BaseContext? data = null) {

            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            if (next.Machine != Machine)
                throw new ArgumentException("Illegal Argument: State Machine on paramater doesn't match instance.", nameof(next));

            if (CheckNonMatch(next))
                throw new ArgumentException("Illegal Argument: State belongs to a different parent.", nameof(next));

            if (next == CurrentState)
                return false;

            if (lifecycleDepth > 0) {

                // Enqueing a transition is the same as success, only time it's prevented from
                // executing is if StopState() is called during transition which is deliberate.
                transitionQueue.Enqueue(new TransitionRequest(next, data));
                return true;
            }

            ExecuteTransition(next, data);
            ProcessTransitions();
            return true;
        }

        public void TransitionState(
            TChild next,
            Func<bool> predicate,
            BaseContext? data = null) {

            ArgumentNullException.ThrowIfNull(predicate, nameof(predicate));

            if (!predicate() ||
                next == CurrentState)
                return;

            TransitionState(next, data);
        }

        private void ExecuteTransition(
            TChild next,
            BaseContext? data = null) {

            lifecycleDepth++;

            try {

                if (data is null) {

                    CurrentState?.Exit(null);
                    CurrentState = next;
                    CurrentState.Enter(null);
                }
                else {

                    CurrentState?.Exit(data);
                    CurrentState = next;
                    CurrentState.Enter(data);
                }
            }
            finally {

                lifecycleDepth--;
            }
        }

        internal void ProcessTransitions() {

            if (CurrentState is null) {

                transitionQueue.Clear();
                return;
            }

            while (transitionQueue.TryDequeue(out TransitionRequest req)) {

                if (req.Next == CurrentState)
                    continue;

                ExecuteTransition(req.Next, req.Context);
            }
        }

        internal void UpdateInternal(
            BaseContext? data, 
            bool independent = false) {

            lifecycleDepth++;

            try {

                if (IsEnabled)
                    RaiseUpdate(data, independent);

                if (PropagatesUpdate)
                    CurrentState?.UpdateInternal(data);
            }
            finally {

                lifecycleDepth--;
            }

            ProcessTransitions();
        }
    }
}
