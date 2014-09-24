using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Visualization
{
    
    class ViewModel:INotifyPropertyChanged
    {
        private  List<Customer> customers;

        private int currentcustomer;

        public Command NextCustomer { get; private set; }

        public Command PreviousCustomer { get; private set; }

        public ViewModel()
        {
            this.currentcustomer = 0;

            

            this.customers = new List<Customer>
                {
              new Customer
                        {
                            _name = "praba",
                            _course = "ms"
                        },
              new Customer
                        {
                            _name = "sam",
                            _course = "mss"
                        },
              new Customer
                        {
                          _name = "praveen",
                          _course = "bca"
                        },
              new Customer
                        {
                            _name = "mugesh",
                            _course = "msse"
                        },
                };
            this.IsAtStart = true;

            this.IsAtEnd = false;

            this.NextCustomer = new Command(this.Next, () =>
            {
                return this.customers.Count > 0 && !this.IsAtEnd;
            });

            this.PreviousCustomer = new Command(this.Previous, () =>
            {
                return this.customers.Count > 0 && !this.IsAtStart;
            });
        }

        public Customer Current
        {
            get { return this.customers[currentcustomer]; }
        }

        private bool _isAtStart;
        public bool IsAtStart
        {
            get { return this._isAtStart; }
            set
            {
                this._isAtStart = value;
                this.OnPropertyChanged("IsAtStart");
            }
        }

        private bool _isAtEnd;
        public bool IsAtEnd
        {
            get { return this._isAtEnd; }
            set
            {
                this._isAtEnd = value;
                this.OnPropertyChanged("IsAtEnd");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
            }
        }
       
        private void Next()
        {
            if (this.customers.Count - 1 > this.currentcustomer)
            {
                this.currentcustomer++;
                this.OnPropertyChanged("Current");
                this.IsAtStart = false;
                this.IsAtEnd = (this.customers.Count - 1 == this.currentcustomer);
            }
        }
        private void Previous()
        {
            if (this.currentcustomer > 0)
            {
                this.currentcustomer--;
                this.OnPropertyChanged("Current");
                this.IsAtEnd = false;
                this.IsAtStart = (this.currentcustomer == 0);
            }
        }
    }
}
