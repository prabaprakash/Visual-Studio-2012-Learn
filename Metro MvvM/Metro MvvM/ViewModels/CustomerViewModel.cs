using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Metro_MvvM.Commands;
using Metro_MvvM.Models;

namespace Metro_MvvM.ViewModels
{
    public class CustomerViewModel:INotifyPropertyChanged
    {
        private Customer _Customer;
     
        public CustomerViewModel()
        {
            _Customer = new Customer
            {
                _name = "welcome",

            };
            //UpdateCommand = new CustomerUpdateCommand(() =>
            //    {
            //_Customer = new Customer
            //{
            //    _name = "Praba",

            //};
            //OnPropertyChanged("Customer");
            //    },
            //    () => true);
        }
        public Customer Customer
        {
            get { return _Customer; }
            set { _Customer = value;
                
            }
        }

        public CustomerUpdateCommand _Update;
        public CustomerUpdateCommand UpdateCommand1
        {
            get
            {
                _Update = new CustomerUpdateCommand(() =>
                {
                    _Customer = new Customer
                    {
                        _name = "Praba",

                    };
                    OnPropertyChanged("Customer");
                },
                    () => true);
                return _Update;
            }
            
        }
        public CustomerUpdateCommand UpdateCommand2
        {
            get
            {
                _Update = new CustomerUpdateCommand(() =>
                {
                    _Customer = new Customer
                    {
                        _name = "Sam",

                    };
                    OnPropertyChanged("Customer");
                },
                    () => true);
                return _Update;
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
           if (PropertyChanged != null)
           {
               PropertyChanged(this,new PropertyChangedEventArgs(propertyname));
           }
        }
    }
}
