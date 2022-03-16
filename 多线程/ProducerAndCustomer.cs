namespace 多线程;

public class ProducerAndCustomer{
    static Queue<int> products = new();
    static int productId = 1;
    static Random random = new ();
    public static void Run(){
        for (int i = 1; i <= 5;++i){
            ThreadPool.QueueUserWorkItem(Produce, i);
            ThreadPool.QueueUserWorkItem(Custom, i);
        }
        Thread.Sleep(30000);
    }

    static void Produce(object producerId){
        while(productId<100){
            lock(products){
                Console.WriteLine($"{producerId}号生产者正在生产 {productId}号产品");
                products.Enqueue(productId++);
            }
            Thread.Sleep(random.Next(500));
        }
    }
    static void Custom(object customerId){
        while(true){
            lock(products){
                //products.Count为零时分为两种情况，一是未达到生产的限额（productId=100），二是已达到限额且消费者消费完了产品
                //第一种情况，消费者应继续等待，而第二种消费者线程应该退出
                if(products.Count<=0&&productId>=100){
                    Console.WriteLine($"{customerId}号消费退出消费");
                    break;
                }
                else if(products.Count<=0){
                    Console.WriteLine($"{customerId}号消费者正在等待");
                }else{
                    Console.WriteLine($"{customerId}号消费者正在消费{products.Dequeue()}号产品");
                }
            }
            Thread.Sleep(random.Next(500));
        }
    }
}