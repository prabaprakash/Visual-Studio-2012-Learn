using System;

namespace CSharp
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;

    using Amib.Threading;
    
    public class Program
    {
        // Method 1

        //public  static void Main(string[] args)
        //  {
        //      Task<int> task = ComplexCalculationAsync();
        //      var awaiter = task.GetAwaiter();
        //      awaiter.OnCompleted(() => // Continuation
        //      {
        //          int result = awaiter.GetResult();
        //          Console.WriteLine(result); // 116
        //      });

        //      Console.WriteLine("gg");
        //      Console.ReadLine();
        //  }

        //  static Task<int> ComplexCalculationAsync()
        //  {
        //      return Task.Run(() =>
        //             {
        //                 double x = 2;
        //                 for (int i = 1; i < 100000000; i++)
        //                     x += Math.Sqrt(x) / i;
        //                 return (int)x;
        //             });
        //  }

        // Method 2

        //public static async void Main(string[] args)
        //{
        //    //Task<int> task = ComplexCalculationAsync();
        //    //var awaiter = task.GetAwaiter();
        //    //awaiter.OnCompleted(() => // Continuation
        //    //{
        //    int result = await ComplexCalculationAsync();
        //        Console.WriteLine(result); // 116
        //    //});
        //    Test();
        //    Console.WriteLine("gg");
        //    Console.ReadLine();
        //}
        //public static async void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int result = await ComplexCalculationAsync();
        //        Console.WriteLine(result);
        //    }
        //}
        //static Task<int> ComplexCalculationAsync()
        //{
        //    return Task.Run(() =>
        //    {
        //        double x = 2;
        //        for (int i = 1; i < 100000000; i++)
        //            x += Math.Sqrt(x) / i;
        //        return (int)x;
        //    });
        //}

        // Method 3

        //public static void Main(String[] args)
        //{
        // var it=GoingTo().GetAwaiter();

        //    it.OnCompleted(() => Console.WriteLine("hELLO"));
        // Console.WriteLine("Task Going");
        // Console.ReadLine();

        //}

        // public static async Task GoingTo()
        // {
        //     var ut = To().GetAwaiter();
        //     ut.OnCompleted(()=>Console.WriteLine("Go"));
        //     //await To();
        //     Console.WriteLine("GoingTo");
        // }
        // public static async Task To()
        // {
        //    // await Task.Delay(5000);
        //     Console.WriteLine((await KiloMeter()).ToString());

        // }

        // private static async Task<int> KiloMeter()
        // {
        //     await Task.Delay(6000);
        //     int c = 21*2;
        //     return (int) c;
        // }
        //Method 4 Delegates
        //    public static void Main()
        //    {
        //        var employees = new List<Employee>
        //            {
        //                new Employee
        //                    {
        //                        Id = 1,
        //                        Name = "sam",
        //                        Experience = 6,
        //                        Salary = 5000
        //                    },

        //                new Employee
        //                    {
        //                        Id = 1,
        //                        Name = "b",
        //                        Experience = 6,
        //                        Salary = 6
        //                    }
        //            };

        //    Employee.eEmployee(employees);
        //        Console.ReadLine();
        //    }

        //}

        //public delegate void deletes(Employee employee);

        //public class Employee
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public int Experience { get; set; }
        //    public int Salary { get; set; }

        //    public static void eEmployee(List<Employee> employees)
        //    {
        //        foreach (var employee in employees)
        //        {
        //           deletes nd=new deletes(checking);
        //            nd(employee);
        //        }
        //    }
        //    public static void checking(Employee employee)
        //    {
        //        if (employee.Experience > 5)
        //        {
        //            Console.WriteLine(employee.Name);
        //        }
        //    }
        //}
        //Method 6 Delegate in Class
        //public delegate bool DelegateChecking(CSharp.Employee employee);
        //public static void Main()
        //    {
        //        var employees = new List<Employee>
        //            {
        //                new Employee
        //                    {
        //                        Id = 1,
        //                        Name = "Sam",
        //                        Experience = 6,
        //                        Salary = 5000
        //                    },

        //                new Employee
        //                    {
        //                        Id = 1,
        //                        Name = "Praba",
        //                        Experience = 6,
        //                        Salary = 5000
        //                    }
        //            };
        //    DelegateChecking delegateChecking=new DelegateChecking(checkmethod);

        //    Employee.eEmployee(employees,delegateChecking);
        //        Console.ReadLine();
        //    }
        //    public static bool checkmethod(Employee employee)
        //    {
        //        if (employee.Experience>5)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        //public class Employee
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public int Experience { get; set; }
        //    public int Salary { get; set; }

        //    public static void eEmployee(List<CSharp.Employee> employees,Program.DelegateChecking checking)
        //    {
        //        foreach (var employee in employees)
        //        {
        //            if (checking(employee))
        //            {
        //                Console.WriteLine(employee.Name);
        //            }
        //        }
        //    }
        //Method 7 Generics
        // public static void Main(String[] args)
        // {
        //    bool e=Method<String,int>("a",2,2);
        //     if (e==true)
        //     {
        //         Console.WriteLine("a equal b");
        //     }
        //     else
        //     {
        //         Console.WriteLine("a not equals b");
        //     }
        //     Console.ReadLine();
        //   var f=  generic<int>.generi(1, 1);
        //     if (f == true)
        //     {
        //         Console.WriteLine("a equal b");
        //     }
        //     else
        //     {
        //         Console.WriteLine("a not equals b");
        //     }
        //     Console.ReadLine();
        // }
        //    public static bool Method<f,g>(f a, g b,g c)
        //    {
        //        return b.Equals(c);
        //    }
        //}
        //public class generic<g>
        //{
        //public static bool generi(g v1,g v2)
        //{
        //    return v1.Equals(v2);
        //}

        //Method 8 Enum

        //public static void Main(String[] Args)
        //{
        //    short[] f = (short[])Enum.GetValues(typeof(MyEnum));

        //    foreach (int g in f)
        //    {
        //        Console.WriteLine(g);
        //    }
        //    String[] fs = (String[])Enum.GetNames(typeof(MyEnum));

        //    foreach (String gs in fs)
        //    {
        //        Console.WriteLine(gs);
        //    }
        //    Console.WriteLine(Enum.GetName(typeof(MyEnum), 10));
        //    Console.ReadLine();
        //}

        //public enum MyEnum : short
        //{
        //    unknown = 10,
        //    male = 5,
        //    femal = 58
        //}

        //Method 9 TcpClient,Listener Parallel.For

        public static void Main(string[] args)
        {
        //    // Socket s=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);


        string s = "172.16.40.1";
        //    //    IPAddress ip = IPAddress.Parse("172.16.20.1");
         //   int count = 0;
            //    TcpListener tc=new TcpListener(8080);
            //    tc.Start();
            //var  awai = tc.AcceptTcpClientAsync().GetAwaiter();
            //    awai.OnCompleted(() =>
            //        {
            //            Console.WriteLine("well well is perfect");
            //        });
            //    Console.WriteLine("Hello");
            //    Console.WriteLine("jolly jolly");
            //    tcp.Connect(ip,8080);


            //List<double> d=new List<double>();
            //Parallel.For(
            //    9000,
            //    9500,
            //    i =>
            //    {
            //        try
            //        {

            //            TcpClient tcp = new TcpClient();
            //            tcp.Connect(s, i);

            //            Console.WriteLine(i);
            //            tcp.Close();


            //        }
            //        catch
            //        {
            //            count = count + 1;
            //        }
            //    });



            //foreach (var d1 in d)
            //{
            //    Console.WriteLine(d1);
            //}
          
          GetValue(s);
           Console.WriteLine("Please Wait");
            Console.Read();
        }

        private static  void GetValue(string s)
        {
           // int count;
            int j, k;
           Console.WriteLine("Enter From Port Number");
            j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the To Port Number");
            k = Convert.ToInt32(Console.ReadLine());
            for (int i = j; i < k; i++)
            {
            //         await Task.Factory.StartNew(async () =>
            //             {
            //                 try
            //                 {
            //                     Console.WriteLine("In Progess .: {0}",i);
            //                     TcpClient tcp = new TcpClient();
            //                     await  tcp.ConnectAsync(s, i);

            //                     Console.WriteLine(i);
            //                     tcp.Close();
            //                 }
            //                 catch
            //                 {
            //                     Console.WriteLine("Failed .: {0}" , i);
            //                 }
            //             });
             var  f=ThreadPool.QueueUserWorkItem(GetValue, i);
               
             
            }
    
        }

       
        private static async void GetValue(object state)
        {
           
            try
            {
               Console.WriteLine("{0} in  Progess", state);
                TcpClient tcp = new TcpClient();
                await tcp.ConnectAsync("172.16.20.1",(int)state);  
                Console.WriteLine("Opened -----------------------> "+state);
                tcp.Close();
            }
            catch
            {
             //  Console.WriteLine("Failed .: {0}", state);
            }
        }
        //private static void getip(object state)
        //{
        //    try
        //    {
        //        Ping ping = new Ping();
        //       // IPAddress s = new IPAddress((long)state);
        //        PingReply sReply = ping.Send((string)state);
        //        if (sReply.Status == IPStatus.Success)
        //        {
        //            Console.WriteLine((string)state);
        //        }


        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}
        // Method 10 Ping
        //public static void Main(String[] args)
        //{
        //    Ping ping = new Ping();

        //    for (int i = 0; i < 255; i++)
        //    {
        //        //int i = 0;
        //        for (int j = 0; j < 20; j++)
        //        {
        //            //var t =Task.Run(
        //            //     () =>
        //            //         {
        //            PingReply pingReply = ping.Send(IPAddress.Parse(String.Format("172.16.{0}.{1}", i, j)));
        //            if (pingReply.Status == IPStatus.Success)
        //            {
        //                Console.WriteLine("172.16.{0}.{1} is Succed", i, j);
        //            }
        //            else
        //            {
        //                Console.WriteLine("172.16.{0}.{1} is Failed", i, j);
        //            }
        //            //});
        //            //ThreadPool.QueueUserWorkItem(ff);
        //        }
        //    }
        //    Console.Read();
        //}


            //Parallel.For(
            //    0,
            //    255,
            //    i =>
            //        {
            //            Parallel.For(
            //                0,
            //                254, async j =>
            //                    {
            //                       await Task.Run(
            //                            () =>
            //                                {
            //                                    PingReply pingReply =
            //                                        ping.Send(IPAddress.Parse(String.Format("172.16.{0}.{1}", i, j)));
            //                                    if (pingReply.Status == IPStatus.Success)
            //                                    {
            //                                        Console.WriteLine(String.Format("172.16.{0}.{1} is Succed", i, j));
            //                                    }
            //                                    else
            //                                    {
            //                                        Console.WriteLine(String.Format("172.16.{0}.{1} is Failed", i, j));
            //                                    }
            //                                });
            //                    });

            //        });


            //for (int i = 0; i < 255; i++)
            //{
            //    for (int j = 0; j < 254; j++)
            //    {
            //        WaitCallback ff = delegate(object state)
            //        {
            //            PingReply pingReply = ping.Send(IPAddress.Parse(String.Format("172.16.{0}.{1}", i, j)));
            //            if (pingReply.Status == IPStatus.Success)
            //            {
            //                Console.WriteLine("172.16.{0}.{1} is Succed", i, j);
            //            }
            //            else
            //            {
            //                Console.WriteLine("172.16.{0}.{1} is Failed", i, j);
            //            }
            //        };
            //        ThreadPool.QueueUserWorkItem(ff);
            //    }
            //}

          //method 11
//        using System.Net.NetworkInformation;
//using System.Net;

//The actual method to get the first open port from the system is as follows:
//Collapse | Copy Code

//private string GetOpenPort()
//{
//  int PortStartIndex = 1000;
//  int PortEndIndex = 2000;
//  IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
//  IPEndPoint[] tcpEndPoints = properties.GetActiveTcpListeners();
 
//  List<int> usedPorts = tcpEndPoints.Select(p => p.Port).ToList<int>();
//  int unusedPort = 0;
 
//  for (int port = PortStartIndex; port < PortEndIndex; port++)
//  {
//     if (!usedPorts.Contains(port))
//     {
//        unusedPort = port;
//        break;
//     }
//  }
//  return unusedPort.ToString();
//}
        
    }
}