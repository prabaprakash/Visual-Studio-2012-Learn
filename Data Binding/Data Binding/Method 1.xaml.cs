using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Data_Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(pageload);
        }

        private void pageload(object sender, RoutedEventArgs e)
        {
            book b = new book
                {
                    Title = "dai",
                    ISBN = "di"
                };
            this.LayoutRoot.DataContext = b;
        }

        public class book : INotifyPropertyChanged
        {
            public string _title;
            public string _isbn;
            public string Title
            {
                get { return _title; }

                set

                {
                    _title = value;
                    FirePropertyChanged("Title");
                }
       
            }

            public string ISBN {  get { return _isbn; }

                set

                {
                    
                    _isbn= value;
                    FirePropertyChanged("ISBN");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void FirePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,new PropertyChangedEventArgs(property));
                }
            }
        }

        private void Ls1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
