using System.Net.Sockets;
using System.Net;
using System.Threading;
using System;
namespace 多线程;

public class PortScan{
    //存放1-1024端口的开放状态
    private static bool[] isOpen = new bool[1025];
    private static IPAddress ipAddr = IPAddress.Parse("42.192.93.88");//Dns.GetHostEntry ("www.baidu.com").AddressList[0];
    private static AutoResetEvent autoResetEvent = new(false);
    public static void Run(){
        ThreadPool.SetMaxThreads(Environment.ProcessorCount*4,Environment.ProcessorCount);
        for (int port = 1; port < 1025;++port){
            int temp = port;
            ThreadPool.QueueUserWorkItem(_ => Work(temp));
        }
        autoResetEvent.WaitOne();
        for (int port = 1; port < 1025;++port){
            if(isOpen[port]){
                Console.WriteLine($"{ipAddr}的{port}端口开放");
            }
        }
    }

    static void Work(int port){
        Console.WriteLine($"开始{port}端口");
        try{
            var tcpClient = new TcpClient();
            tcpClient.Connect(ipAddr, port);
            isOpen[port] = true;
        }catch{

        }
        if(port==1024){
            autoResetEvent.Set();
        }
    }
}