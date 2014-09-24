using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Smart_Thread.Views
{
    using System.Diagnostics;
    using System.Net.Sockets;
    using System.Threading;
   
    using Amib.Threading;

    /// <summary>
    /// Interaction logic for Homee.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        SmartThreadPool smart;

        private Thread sThread;
        private  void StartThread_OnClick(object sender, RoutedEventArgs e)
        {
           
            STPStartInfo startInfo = new STPStartInfo()
                                       {
                                           MinWorkerThreads = 10,
                                           MaxWorkerThreads = 50,
                                           IdleTimeout = 4*1000,
                                           EnableLocalPerformanceCounters = true
                                       };
            smart = new SmartThreadPool(startInfo);
            smart.Start();

            WorkItemCallback workItem = this.DoWork;
            IWorkItemsGroup itemsGroup = smart;
            for (int i = 1000; i < 56500; i++)
            {
                itemsGroup.QueueWorkItem(workItem, i, WorkItemPriority.Normal);
            }

          //sThread = new Thread(this.Mytask){IsBackground = true};
          //  sThread.Start();
         
            
            
        }

        //private void Mytask()
        //{
        //    WorkItemCallback workItem = this.DoWork;
        //    IWorkItemsGroup itemsGroup = smart;
        //    for (int i = 1000; i < 56500; i++)
        //    {
        //        itemsGroup.QueueWorkItem(workItem, i, WorkItemPriority.Normal);
        //    }
        //}

        private object DoWork(object state)
        {
            Debug.WriteLine((int)state);
            return null;
        }

        //private async void target(int obj)
        //{
          
        //    try
        //    {
             
        //        var tcp = new TcpClient();
        //        await tcp.ConnectAsync("172.16.20.1", obj);

        //       Debug.WriteLine(obj);
        //        tcp.Close();


        //    }
        //    catch
        //    {

        //    }
         
           
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // sThread.Suspend();
        }

      
    }
}
