using System;
using System.ComponentModel;

namespace MVVM.Model
{
    internal class Student : INotifyPropertyChanged
    {
        
        public String _course;
        public String _name;

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public String Course
        {
            get { return _course; }
            set
            {
                _course = value;
                OnPropertyChanged("Course");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}