namespace SMachine
{
    public partial class StateMachine : StateNode<State> {

        public void IndependentUpdate<T1>(
            T1 k1, BaseContext? data = null)
            where T1 : struct, Enum 
        {

            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;

            s0.lifecycleDepth++;
            try 
            {
                // Level 1: k1 under s0
                if (!s0.TryGetState(k1, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally 
            {
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2>(
            T1 k1, T2 k2, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum 
        {

            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;

            s0.lifecycleDepth++;
            try 
            {
                // Level 1: k1 under s0
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                // Level 2: k2 under s1 (the target)
                if (!s1.TryGetState(k2, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally 
            {
                if (s1 is not null) 
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }

                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3>(
            T1 k1, T2 k2, T3 k3, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4>(
            T1 k1, T2 k2, T3 k3, T4 k4, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, T14 k14, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum where T14 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;
            State? s13 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? n13) || n13 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                s13 = n13;
                s13.lifecycleDepth++;
                if (!s13.TryGetState(k14, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k14}' at depth 13.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s13 is not null)
                {
                    s13.lifecycleDepth--;
                    s13.ProcessTransitions();
                }
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, T14 k14, T15 k15, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum where T14 : struct, Enum where T15 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;
            State? s13 = null;
            State? s14 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? n13) || n13 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                s13 = n13;
                s13.lifecycleDepth++;
                if (!s13.TryGetState(k14, out SubState? n14) || n14 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k14}' at depth 13.");
                s14 = n14;
                s14.lifecycleDepth++;
                if (!s14.TryGetState(k15, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k15}' at depth 14.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s14 is not null)
                {
                    s14.lifecycleDepth--;
                    s14.ProcessTransitions();
                }
                if (s13 is not null)
                {
                    s13.lifecycleDepth--;
                    s13.ProcessTransitions();
                }
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, T14 k14, T15 k15, T16 k16, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum where T14 : struct, Enum where T15 : struct, Enum where T16 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;
            State? s13 = null;
            State? s14 = null;
            State? s15 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? n13) || n13 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                s13 = n13;
                s13.lifecycleDepth++;
                if (!s13.TryGetState(k14, out SubState? n14) || n14 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k14}' at depth 13.");
                s14 = n14;
                s14.lifecycleDepth++;
                if (!s14.TryGetState(k15, out SubState? n15) || n15 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k15}' at depth 14.");
                s15 = n15;
                s15.lifecycleDepth++;
                if (!s15.TryGetState(k16, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k16}' at depth 15.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s15 is not null)
                {
                    s15.lifecycleDepth--;
                    s15.ProcessTransitions();
                }
                if (s14 is not null)
                {
                    s14.lifecycleDepth--;
                    s14.ProcessTransitions();
                }
                if (s13 is not null)
                {
                    s13.lifecycleDepth--;
                    s13.ProcessTransitions();
                }
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, T14 k14, T15 k15, T16 k16, T17 k17, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum where T14 : struct, Enum where T15 : struct, Enum where T16 : struct, Enum where T17 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;
            State? s13 = null;
            State? s14 = null;
            State? s15 = null;
            State? s16 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? n13) || n13 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                s13 = n13;
                s13.lifecycleDepth++;
                if (!s13.TryGetState(k14, out SubState? n14) || n14 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k14}' at depth 13.");
                s14 = n14;
                s14.lifecycleDepth++;
                if (!s14.TryGetState(k15, out SubState? n15) || n15 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k15}' at depth 14.");
                s15 = n15;
                s15.lifecycleDepth++;
                if (!s15.TryGetState(k16, out SubState? n16) || n16 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k16}' at depth 15.");
                s16 = n16;
                s16.lifecycleDepth++;
                if (!s16.TryGetState(k17, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k17}' at depth 16.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s16 is not null)
                {
                    s16.lifecycleDepth--;
                    s16.ProcessTransitions();
                }
                if (s15 is not null)
                {
                    s15.lifecycleDepth--;
                    s15.ProcessTransitions();
                }
                if (s14 is not null)
                {
                    s14.lifecycleDepth--;
                    s14.ProcessTransitions();
                }
                if (s13 is not null)
                {
                    s13.lifecycleDepth--;
                    s13.ProcessTransitions();
                }
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, T14 k14, T15 k15, T16 k16, T17 k17, T18 k18, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum where T14 : struct, Enum where T15 : struct, Enum where T16 : struct, Enum where T17 : struct, Enum where T18 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;
            State? s13 = null;
            State? s14 = null;
            State? s15 = null;
            State? s16 = null;
            State? s17 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? n13) || n13 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                s13 = n13;
                s13.lifecycleDepth++;
                if (!s13.TryGetState(k14, out SubState? n14) || n14 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k14}' at depth 13.");
                s14 = n14;
                s14.lifecycleDepth++;
                if (!s14.TryGetState(k15, out SubState? n15) || n15 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k15}' at depth 14.");
                s15 = n15;
                s15.lifecycleDepth++;
                if (!s15.TryGetState(k16, out SubState? n16) || n16 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k16}' at depth 15.");
                s16 = n16;
                s16.lifecycleDepth++;
                if (!s16.TryGetState(k17, out SubState? n17) || n17 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k17}' at depth 16.");
                s17 = n17;
                s17.lifecycleDepth++;
                if (!s17.TryGetState(k18, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k18}' at depth 17.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s17 is not null)
                {
                    s17.lifecycleDepth--;
                    s17.ProcessTransitions();
                }
                if (s16 is not null)
                {
                    s16.lifecycleDepth--;
                    s16.ProcessTransitions();
                }
                if (s15 is not null)
                {
                    s15.lifecycleDepth--;
                    s15.ProcessTransitions();
                }
                if (s14 is not null)
                {
                    s14.lifecycleDepth--;
                    s14.ProcessTransitions();
                }
                if (s13 is not null)
                {
                    s13.lifecycleDepth--;
                    s13.ProcessTransitions();
                }
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }

        public void IndependentUpdate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
            T1 k1, T2 k2, T3 k3, T4 k4, T5 k5, T6 k6, T7 k7, T8 k8, T9 k9, T10 k10, T11 k11, T12 k12, T13 k13, T14 k14, T15 k15, T16 k16, T17 k17, T18 k18, T19 k19, BaseContext? data = null)
            where T1 : struct, Enum where T2 : struct, Enum where T3 : struct, Enum where T4 : struct, Enum where T5 : struct, Enum where T6 : struct, Enum where T7 : struct, Enum where T8 : struct, Enum where T9 : struct, Enum where T10 : struct, Enum where T11 : struct, Enum where T12 : struct, Enum where T13 : struct, Enum where T14 : struct, Enum where T15 : struct, Enum where T16 : struct, Enum where T17 : struct, Enum where T18 : struct, Enum where T19 : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(CurrentState, nameof(CurrentState));

            State s0 = CurrentState;
            State? s1 = null;
            State? s2 = null;
            State? s3 = null;
            State? s4 = null;
            State? s5 = null;
            State? s6 = null;
            State? s7 = null;
            State? s8 = null;
            State? s9 = null;
            State? s10 = null;
            State? s11 = null;
            State? s12 = null;
            State? s13 = null;
            State? s14 = null;
            State? s15 = null;
            State? s16 = null;
            State? s17 = null;
            State? s18 = null;

            s0.lifecycleDepth++;
            try
            {
                if (!s0.TryGetState(k1, out SubState? n1) || n1 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k1}' at depth 0.");
                s1 = n1;
                s1.lifecycleDepth++;
                if (!s1.TryGetState(k2, out SubState? n2) || n2 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k2}' at depth 1.");
                s2 = n2;
                s2.lifecycleDepth++;
                if (!s2.TryGetState(k3, out SubState? n3) || n3 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k3}' at depth 2.");
                s3 = n3;
                s3.lifecycleDepth++;
                if (!s3.TryGetState(k4, out SubState? n4) || n4 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k4}' at depth 3.");
                s4 = n4;
                s4.lifecycleDepth++;
                if (!s4.TryGetState(k5, out SubState? n5) || n5 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k5}' at depth 4.");
                s5 = n5;
                s5.lifecycleDepth++;
                if (!s5.TryGetState(k6, out SubState? n6) || n6 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k6}' at depth 5.");
                s6 = n6;
                s6.lifecycleDepth++;
                if (!s6.TryGetState(k7, out SubState? n7) || n7 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k7}' at depth 6.");
                s7 = n7;
                s7.lifecycleDepth++;
                if (!s7.TryGetState(k8, out SubState? n8) || n8 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k8}' at depth 7.");
                s8 = n8;
                s8.lifecycleDepth++;
                if (!s8.TryGetState(k9, out SubState? n9) || n9 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k9}' at depth 8.");
                s9 = n9;
                s9.lifecycleDepth++;
                if (!s9.TryGetState(k10, out SubState? n10) || n10 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k10}' at depth 9.");
                s10 = n10;
                s10.lifecycleDepth++;
                if (!s10.TryGetState(k11, out SubState? n11) || n11 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k11}' at depth 10.");
                s11 = n11;
                s11.lifecycleDepth++;
                if (!s11.TryGetState(k12, out SubState? n12) || n12 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k12}' at depth 11.");
                s12 = n12;
                s12.lifecycleDepth++;
                if (!s12.TryGetState(k13, out SubState? n13) || n13 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k13}' at depth 12.");
                s13 = n13;
                s13.lifecycleDepth++;
                if (!s13.TryGetState(k14, out SubState? n14) || n14 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k14}' at depth 13.");
                s14 = n14;
                s14.lifecycleDepth++;
                if (!s14.TryGetState(k15, out SubState? n15) || n15 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k15}' at depth 14.");
                s15 = n15;
                s15.lifecycleDepth++;
                if (!s15.TryGetState(k16, out SubState? n16) || n16 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k16}' at depth 15.");
                s16 = n16;
                s16.lifecycleDepth++;
                if (!s16.TryGetState(k17, out SubState? n17) || n17 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k17}' at depth 16.");
                s17 = n17;
                s17.lifecycleDepth++;
                if (!s17.TryGetState(k18, out SubState? n18) || n18 is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k18}' at depth 17.");
                s18 = n18;
                s18.lifecycleDepth++;
                if (!s18.TryGetState(k19, out SubState? target) || target is null)
                    throw new ArgumentException($"Illegal Argument: No substate found for key '{k19}' at depth 18.");
                if (target.Enabled)
                    target.UpdateInternal(data, true);
            }
            finally
            {
                if (s18 is not null)
                {
                    s18.lifecycleDepth--;
                    s18.ProcessTransitions();
                }
                if (s17 is not null)
                {
                    s17.lifecycleDepth--;
                    s17.ProcessTransitions();
                }
                if (s16 is not null)
                {
                    s16.lifecycleDepth--;
                    s16.ProcessTransitions();
                }
                if (s15 is not null)
                {
                    s15.lifecycleDepth--;
                    s15.ProcessTransitions();
                }
                if (s14 is not null)
                {
                    s14.lifecycleDepth--;
                    s14.ProcessTransitions();
                }
                if (s13 is not null)
                {
                    s13.lifecycleDepth--;
                    s13.ProcessTransitions();
                }
                if (s12 is not null)
                {
                    s12.lifecycleDepth--;
                    s12.ProcessTransitions();
                }
                if (s11 is not null)
                {
                    s11.lifecycleDepth--;
                    s11.ProcessTransitions();
                }
                if (s10 is not null)
                {
                    s10.lifecycleDepth--;
                    s10.ProcessTransitions();
                }
                if (s9 is not null)
                {
                    s9.lifecycleDepth--;
                    s9.ProcessTransitions();
                }
                if (s8 is not null)
                {
                    s8.lifecycleDepth--;
                    s8.ProcessTransitions();
                }
                if (s7 is not null)
                {
                    s7.lifecycleDepth--;
                    s7.ProcessTransitions();
                }
                if (s6 is not null)
                {
                    s6.lifecycleDepth--;
                    s6.ProcessTransitions();
                }
                if (s5 is not null)
                {
                    s5.lifecycleDepth--;
                    s5.ProcessTransitions();
                }
                if (s4 is not null)
                {
                    s4.lifecycleDepth--;
                    s4.ProcessTransitions();
                }
                if (s3 is not null)
                {
                    s3.lifecycleDepth--;
                    s3.ProcessTransitions();
                }
                if (s2 is not null)
                {
                    s2.lifecycleDepth--;
                    s2.ProcessTransitions();
                }
                if (s1 is not null)
                {
                    s1.lifecycleDepth--;
                    s1.ProcessTransitions();
                }
                s0.lifecycleDepth--;
                s0.ProcessTransitions();
            }
        }
    }
}