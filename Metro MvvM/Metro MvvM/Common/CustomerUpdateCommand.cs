using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Metro_MvvM.ViewModels;

namespace Metro_MvvM.Commands
{
    public class CustomerUpdateCommand : ICommand
    {
        public Func<bool> func;

        public Action Methodtoexecute = null;

        public CustomerUpdateCommand(Action methodtoexecute,Func<bool> func)
        {
            //this._CustomerViewModel = _customerViewModel;
            this.func = func;
            this.Methodtoexecute = methodtoexecute;
          // CanExecuteEventChangedTimer_Tick();

        }

        public bool CanExecute(object parameter)
        {
          
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.Methodtoexecute();
        }

        public void CanExecuteEventChangedTimer_Tick()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }

}
