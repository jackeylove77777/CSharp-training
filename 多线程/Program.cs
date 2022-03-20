using System;
using 多线程;

#region Thread01
//Thread01.Run();
#endregion

#region ThreadPool
//threadPool.Run();
#endregion

#region ProducerAndCustomer
//ProducerAndCustomer.Run();
#endregion

#region Big Data
//SimulateBigData.Run();
#endregion

#region Big Data
var startTime = DateTime.Now;
PortScan.Run();
var endTime = DateTime.Now;
Console.WriteLine(endTime.Subtract(startTime));
#endregion
