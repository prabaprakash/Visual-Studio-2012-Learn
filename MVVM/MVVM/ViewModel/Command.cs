using System;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace MVVM.ViewModel
{
    class Command:ICommand
    {
        public Action MethodToExecute = null;

        public Func<bool> MethodToDetectCanExceute = null;

        public DispatcherTimer CanExecuteEventChangedTimer=null;

        public Command(Action MethodToExecute, Func<bool> MethodToDetectCanExecute)
        {
            this.MethodToExecute = MethodToExecute;
            this.MethodToDetectCanExceute = MethodToDetectCanExecute;

            this.CanExecuteEventChangedTimer=new DispatcherTimer();
            CanExecuteEventChangedTimer.Interval=new TimeSpan(0,0,0,1);
            CanExecuteEventChangedTimer.Start();
            CanExecuteEventChangedTimer.Tick += CanExecuteEventChangedTimer_Tick;

        }

      

        public void Execute(object parameter)
        {
            this.MethodToExecute();
        }

        public bool CanExecute(object parameter)
        {
            if (MethodToDetectCanExceute==null)
            {
                return true;
            }
            else
            {
                return this.MethodToDetectCanExceute();
            }
        }

        public event EventHandler CanExecuteChanged;

        void CanExecuteEventChangedTimer_Tick(object sender, object e)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
