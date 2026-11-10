
namespace SMachine
{
    public abstract class BaseContext { }

    public class Context<
        T1> 
        : BaseContext {
        public T1 Data1 { get; }

        public Context(
            T1 data1) {

            Data1 = data1;
        }
    }
    public class Context<
        T1, 
        T2> 
        : Context<
            T1> {
        public T2 Data2 { get; }

        public Context(
            T1 data1,
            T2 data2) 
            : base(
                  data1) {

            Data2 = data2;
        }
    }
    public class Context<
        T1, 
        T2, 
        T3> 
        : Context<
            T1, 
            T2> {
        public T3 Data3 { get; }

        public Context(
            T1 data1, 
            T2 data2,
            T3 data3) 
            : base(
                  data1, 
                  data2) {

            Data3 = data3;
        }
    }
    public class Context<
        T1, 
        T2, 
        T3,
        T4> 
        : Context<
            T1, 
            T2,
            T3> {
        public T4 Data4 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4)
            : base(
                  data1, 
                  data2, 
                  data3) {

            Data4 = data4;
        }
    }
    public class Context<
        T1,
        T2,
        T3,
        T4,
        T5>
        : Context<
            T1,
            T2,
            T3,
            T4> {
        public T5 Data5 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4,
            T5 data5)
            : base(
                  data1,
                  data2,
                  data3,
                  data4) {

            Data5 = data5;
        }
    }
    public class Context<
        T1,
        T2,
        T3,
        T4,
        T5,
        T6>
        : Context<
            T1,
            T2,
            T3,
            T4,
            T5> {
        public T6 Data6 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4,
            T5 data5,
            T6 data6)
            : base(
                  data1,
                  data2,
                  data3,
                  data4,
                  data5) {

            Data6 = data6;
        }
    }
    public class Context<
        T1,
        T2,
        T3,
        T4,
        T5,
        T6,
        T7>
        : Context<
            T1,
            T2,
            T3,
            T4,
            T5,
            T6> {
        public T7 Data7 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4,
            T5 data5,
            T6 data6,
            T7 data7)
            : base(
                  data1,
                  data2,
                  data3,
                  data4,
                  data5,
                  data6) {

            Data7 = data7;
        }
    }
    public class Context<
        T1,
        T2,
        T3,
        T4,
        T5,
        T6,
        T7,
        T8>
        : Context<
            T1,
            T2,
            T3,
            T4,
            T5,
            T6,
            T7> {
        public T8 Data8 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4,
            T5 data5,
            T6 data6,
            T7 data7,
            T8 data8)
            : base(
                  data1,
                  data2,
                  data3,
                  data4,
                  data5,
                  data6,
                  data7) {

            Data8 = data8;
        }
    }
    public class Context<
        T1,
        T2,
        T3,
        T4,
        T5,
        T6,
        T7,
        T8,
        T9>
        : Context<
            T1,
            T2,
            T3,
            T4,
            T5,
            T6,
            T7,
            T8> {
        public T9 Data9 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4,
            T5 data5,
            T6 data6,
            T7 data7,
            T8 data8,
            T9 data9)
            : base(
                  data1,
                  data2,
                  data3,
                  data4,
                  data5,
                  data6,
                  data7,
                  data8) {

            Data9 = data9;
        }
    }
    public class Context<
        T1,
        T2,
        T3,
        T4,
        T5,
        T6,
        T7,
        T8,
        T9,
        T10>
        : Context<
            T1,
            T2,
            T3,
            T4,
            T5,
            T6,
            T7,
            T8,
            T9> {
        public T10 Data10 { get; }

        public Context(
            T1 data1,
            T2 data2,
            T3 data3,
            T4 data4,
            T5 data5,
            T6 data6,
            T7 data7,
            T8 data8,
            T9 data9,
            T10 data10)
            : base(
                  data1,
                  data2,
                  data3,
                  data4,
                  data5,
                  data6,
                  data7,
                  data8,
                  data9) {

            Data10 = data10;
        }
    }
}
