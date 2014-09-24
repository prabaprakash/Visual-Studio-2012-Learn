using System.Collections.Generic;
using System.ComponentModel;
using MVVM.Model;

namespace MVVM.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public List<Student> studentlist;

        public int Currentstudent;

        
        private bool _atstart;

        public bool AtStart
        {
            get { return _atstart; }
            set
            {
                _atstart = value;
                OnPropertyChanged("AtStart");
            }
        }

        private bool _atend;

        public bool AtEnd
        {
            get { return _atend; }
            set
            {
                _atend = value;
                OnPropertyChanged("AtEnd");
            }
        }

        public Command NextStudent
        {
            get; private set;
        }
        public Command PreviousStudent
        {
            get; private set;
        }
        public ViewModel()
        {
            Currentstudent = 0;

            AtStart = true;

            AtEnd = false;

            studentlist = new List<Student>
                {
                    new Student
                        {
                            Name = "praba",
                            Course = "msse"
                        },
                    new Student()
                        {
                            Name = "sam",
                            Course = "msse"
                        },
                        new Student()
                            {
                                Name = "praveen",
                                Course = "bca"
                            }
                };
            this.NextStudent=new Command(Next,()=>
                {
                    return (studentlist.Count > 0 && !this.AtEnd);
                });
          this.PreviousStudent=new Command(Previous,() =>
              {
                  return (studentlist.Count > 0 && !this.AtStart);
              });
        }
        public Student Current
        {
            get { return studentlist[Currentstudent]; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public void Next()
        {
            if (studentlist.Count - 1 > Currentstudent)
            {
                Currentstudent++;
                this.OnPropertyChanged("Current");
                
                AtStart = false;
                AtEnd = (studentlist.Count - 1 == Currentstudent);

            }
        }
        public void Previous()
        {
            if(Currentstudent>0)
            {
                Currentstudent--;
                OnPropertyChanged("Current");
               AtEnd = false;
                AtStart = (Currentstudent == 0);
            }
        }
    }
}
