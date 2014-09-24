using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace MVVM.ViewModel
{
  public  class Converter :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int _value = System.Convert.ToInt32(value);
            String _grade = String.Empty;
            if (_value < 50)
                return _grade = "F";
            else if (_value >= 50 && _value < 60)
                 _grade = "E";
            else if (_value >= 60 && _value < 70)
                 _grade = "D";
            else if (_value >= 70 && _value < 80)
                _grade = "C";
            else if (_value >= 80 && _value < 90)
                 _grade = "B";
            else if (_value >= 90 && _value <= 100)
            
            {_grade = "A";}

            return _grade;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //if (language.Equals("A"))
            //{
            //    value = 100;
            //}
            //return value;
            throw new NotImplementedException();
        }
    }
}
