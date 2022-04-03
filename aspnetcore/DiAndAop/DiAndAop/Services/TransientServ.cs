namespace DiAndAop.Services
{
    public class TransientServ
    {
        void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y; y = temp;
        }
    }
}
