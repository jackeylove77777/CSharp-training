namespace DiAndAop.Generics
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public void PrintT(T param)
        {
            Console.WriteLine(param.ToString());
        }
    }
}
