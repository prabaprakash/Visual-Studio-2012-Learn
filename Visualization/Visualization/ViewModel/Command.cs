using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace Visualization
{
   public class Command : ICommand
   {
       public Action methodtoExecute = null;
       
       public Func<bool> methodtodetectcanexecute = null;

       private DispatcherTimer canExecuteChangedEventTimer = null;

       public Command(Action methodtoExecute, Func<bool> methodtodetectcanexecute)
       {
           this.methodtoExecute = methodtoExecute;
           this.methodtodetectcanexecute = methodtodetectcanexecute;
           this.canExecuteChangedEventTimer = new DispatcherTimer();
           this.canExecuteChangedEventTimer.Tick +=canExecuteChangedEventTimer_Tick;
           this.canExecuteChangedEventTimer.Interval =new TimeSpan(0, 0, 1);
           this.canExecuteChangedEventTimer.Start();
       }
       public void Execute(object parameter)
       {
           this.methodtoExecute();
       }
       public bool CanExecute(object parameter)
       {
           if (this.methodtodetectcanexecute==null)
           {
               return true;
           }
           else
           {
               return this.methodtodetectcanexecute();
           }
       }


       public event EventHandler CanExecuteChanged;

       public void canExecuteChangedEventTimer_Tick(object sender, object e)
       {
           if (this.CanExecuteChanged != null)
           {
               this.CanExecuteChanged(this, EventArgs.Empty);
           }
       }
   }
}
