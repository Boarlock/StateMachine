
namespace SMachine
{
    public abstract record class BaseContext;

    public sealed record class Context<
        T1>(T1 Data1) : BaseContext;

    public sealed record class Context<
        T1, T2>(T1 Data1, T2 Data2) : BaseContext;

    public sealed record class Context<
        T1, T2, T3>(T1 Data1, T2 Data2, T3 Data3) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4>(T1 Data1, T2 Data2, T3 Data3, T4 Data4) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4, T5>(T1 Data1, T2 Data2, T3 Data3, T4 Data4, T5 Data5) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4, T5, T6>(T1 Data1, T2 Data2, T3 Data3, T4 Data4, T5 Data5, T6 Data6) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4, T5, T6, T7>(T1 Data1, T2 Data2, T3 Data3, T4 Data4, T5 Data5, T6 Data6, T7 Data7) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4, T5, T6, T7, T8>(T1 Data1, T2 Data2, T3 Data3, T4 Data4, T5 Data5, T6 Data6, T7 Data7, T8 Data8) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 Data1, T2 Data2, T3 Data3, T4 Data4, T5 Data5, T6 Data6, T7 Data7, T8 Data8, T9 Data9) : BaseContext;

    public sealed record class Context<
        T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 Data1, T2 Data2, T3 Data3, T4 Data4, T5 Data5, T6 Data6, T7 Data7, T8 Data8, T9 Data9, T10 Data10) : BaseContext;

}