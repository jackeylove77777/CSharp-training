namespace DiAndAop.Generics
{
    public interface IBaseService<T> where T : class
    {
        void PrintT(T param);
    }
}
