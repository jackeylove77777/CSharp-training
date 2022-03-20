#nullable disable
namespace 多线程;
/// <summry>
/// 生成1千万个数据，并找出其中的最大值
/// </summry>
public class SimulateBigData{
    private static object locker = new();
    private static int[] data = new int[1000_0000];
    private static int maxValue = int.MinValue;
    private static int count = 0;
    private static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
    public static void Run(){
        for (int i = 0; i < 10;++i){
            int temp = i;
            ThreadPool.QueueUserWorkItem((_)=>generateData(temp));
        }
        autoResetEvent.WaitOne();//阻塞主线程直到所有数据生成完毕
        count = 0;
        for (int i = 0; i < 10;++i){
            int temp = i;
            ThreadPool.QueueUserWorkItem((_)=>findMaxVal(temp));
        }
        autoResetEvent.WaitOne();//阻塞主线程直到找到最大的数据
        Console.WriteLine($"最大的数据是{maxValue}");
    }


    static void generateData(int index){
        var random = new Random();
        Console.WriteLine($"正在生成{index*100_0000} - {(index+1)*100_0000}之间的数据");
        for (int i = index * 100_0000; i < (index + 1) * 100_0000 ;++i){
            data[i] = random.Next(int.MinValue, int.MaxValue);
        }
        lock(locker){
            count++;
            //当count为10，所有数据生成完毕，给主线程发送信号取消阻塞
            if(count == 10)autoResetEvent.Set();
        }
    }

    static void findMaxVal(int index){
        int tempMax = int.MinValue;
        for (int i = index * 100_0000; i < (index + 1) * 100_0000 ;++i){
            if(data[i]>tempMax)tempMax = data[i];
        }
        lock(locker){
            if(tempMax>maxValue)maxValue = tempMax;
            count++;
            //当count为10，已经找到最大的数据，给主线程发送信号取消阻塞
            if(count == 10)autoResetEvent.Set();
        }    
    }

}