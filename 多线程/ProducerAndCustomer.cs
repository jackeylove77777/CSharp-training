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
        Thread.Sleep(50000);
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
        while(productId<100){
            lock(products){
                if(products.Count<=0){
                    Console.WriteLine($"{customerId}号消费者正在等待");
                }else{
                    Console.WriteLine($"{customerId}号消费者正在消费{products.Dequeue()}号产品");
                }
            }
            Thread.Sleep(random.Next(500));
        }
    }
}