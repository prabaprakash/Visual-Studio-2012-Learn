using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate bool hide(int s);
namespace ConsoleApplication1
{
    using System.Collections;
    using System.Threading;

    class Program
    {
        private static void Main(string[] args)
        {
            //Task task = new Task(() => Console.WriteLine("Task in C#"),TaskCreationOptions.None);
            //task.Start();
            //task.Wait();
            //Console.ReadLine();

            //Task<string> task=new Task<string>(()=>"Welcome",TaskCreationOptions.None);
            //task.Start();
            //Console.WriteLine(task.Result);
            //Console.ReadLine();

            Task<string> d = Task.Run(
                () =>
                    {
                        Task.Delay(333333);
                    for (int i = 0; i <byte.MaxValue; i++);
                    return "heelo";
                });
            Console.WriteLine(d.Result);
            if (d.IsCompleted)
            {
                Console.WriteLine("hello" + d.Status.ToString());
            }
            if (d.IsCanceled)
            {
                Console.WriteLine(d.Status.ToString());
            }
           // hide dh=new hide(praba);
            foreach (int i in Enumerable.Range(1,100))
            {
              
                    don(praba,i);
               
                
            }
       //     for (int i = 0; i < 100; i++)
       //     {


                
       //         ThreadPool.QueueUserWorkItem(go, i);
              
       //     }
       //     Console.ReadLine();
        }

       //static void go(object state)
       // {
       //     Console.WriteLine("hide"+state);
       // }

        private static bool praba(int s)
        {
            bool f = new bool();
            f=false;
            if (s % 2 == 0)
            {
                f = true;
            }
            return f;

        }
        public static void don(hide dh, int d)
        {
           if(dh.Invoke(d))
            Console.WriteLine(d);
        }
    }
}
