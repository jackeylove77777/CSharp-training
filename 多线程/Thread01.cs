#nullable disable
namespace 多线程;
class Thread01{

    public static void Run(){
        for (int i = 0; i < 5;++i){
            new Thread(new ParameterizedThreadStart(Work)).Start(i);
        }
    }
    static void Work(object id){
        Thread.Sleep(new Random().Next(1, 10) * 1000);
        Console.WriteLine($"操作完成:{id}");
    }
}