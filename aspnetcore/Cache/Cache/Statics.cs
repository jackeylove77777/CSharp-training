
using System.Timers;

namespace Cache
{
    public static class Statics
    {
        public static int num = 1;
        public static System.Timers.Timer timer=new System.Timers.Timer(1000)
        {
            Enabled = true,
            AutoReset = true,
        };
        public static void OnTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            num++;
        }
    }
}
