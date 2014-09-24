using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        //Method 1
        //private static void Main(string[] args)
        //{

        //    Func<string, int> method = work;
        //    IAsyncResult iAsyncResult = method.BeginInvoke("hello", null, null);
        //   Console.WriteLine(method.EndInvoke(iAsyncResult));
        //    Console.Read();

        //}
        //static int work(string s)
        //{
        //    return s.Length;
        //}
        //Method 2
        //private static void Main(string[] args)
        //{

        //    Func<string, int> method = work;

        //    AsyncCallback asyncCallback = AsyncCallback;

        //    IAsyncResult iAsyncResult = method.BeginInvoke("hello", asyncCallback, method);

        //    //Console.WriteLine(method.EndInvoke(iAsyncResult));
        //    Console.Read();

        //}
        //static int work(string s)
        //{
        //    return s.Length;
        //}
       
        //private static void AsyncCallback(IAsyncResult ar)
        //{
        //    Func<string, int> method =(Func<string,int>) ar.AsyncState;

        //    Console.WriteLine(method.EndInvoke(ar));
        //}
        //Method 3
        private static void Main(string[] args)
        {

         
           

            for (int i = 0; i < 50; i++)
            {

                System.Threading.ThreadPool.QueueUserWorkItem(targert, i);

            }

            //Console.WriteLine(method.EndInvoke(iAsyncResult));
            Console.Read();

        }

        private static void targert(object state)
        {
            Console.WriteLine((int)state);
        }

      


        
    }
}
