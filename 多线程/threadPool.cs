namespace 多线程;

class threadPool{
    static object locker = new();
    static List<int> ticketing = new();

    internal static void Run(){
        ticketing.AddRange(myRange(1, 100));
        for (int i = 0; i < 5;++i){
            ThreadPool.QueueUserWorkItem(Work, i);
        }
        Thread.Sleep(3000);
        //ThreadPool管理的线程全都是后台线程，且不能isBackgroud属性更改为前台线程。
        //所以让主线程休眠三秒等待所有的线程池线程
    }
    static void Work(object i){
        while(true){
            lock(locker){
                Console.WriteLine($"{i}号黄牛正在抢票");
                if(ticketing.Count<=0){
                    Console.WriteLine("票已卖完");
                    break;
                }
                int ticket = ticketing[new Random().Next(ticketing.Count)];
                Console.WriteLine($"{i}号黄牛抢到了{ticket}号票");
                ticketing.Remove(ticket);
            }
        }
    }

    static IEnumerable<int> myRange(int min,int max){
        int res = min-1;
        while(++res<=max){
            yield return res;
        }
    }
}