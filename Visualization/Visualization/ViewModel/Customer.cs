using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualization
{
   public class Customer :INotifyPropertyChanged
   {
       public String _name;
       public String _course;
       public String Name
       {
           get { return _name; }
           set
           {
              _name = value;
              this.onpropertychanged("Name");
           }
       }

       public String Course {
           get
           { return _course;}

        set 
        {
            _course= value;
           this.onpropertychanged("Course");
        }
       }
        
     
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void onpropertychanged(String PropertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
