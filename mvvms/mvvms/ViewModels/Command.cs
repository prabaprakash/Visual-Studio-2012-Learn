using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace mvvms.ViewModels
{
    class Command :ICommand
    {
        public Action methodtoexecute=null;

        public Func<bool> methodtodetectexecute=null;

        public DispatcherTimer timer;
         public Command(Action methodtoexecute, Func<bool> methodtodetectexecute)
        {
            this.methodtoexecute = methodtoexecute;
            this.methodtodetectexecute = methodtodetectexecute;
            timer.Interval=new TimeSpan(0,0,0,1);
            timer.Start();
            timer.Tick += timer_Tick;
        }

         
        public void Execute(object parameter)
        {
            methodtoexecute();
        }
        public bool CanExecute(object parameter)
        {
            if (methodtodetectexecute==null)
            {
                return true;
            }
            else
            {
                return methodtodetectexecute();
            }
        }

        public event EventHandler CanExecuteChanged;
        void timer_Tick(object sender, object e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this,EventArgs.Empty);
            }
        }
       
    }
}
