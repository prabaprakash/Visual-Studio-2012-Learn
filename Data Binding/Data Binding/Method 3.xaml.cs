using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Data_Binding
{
    /// <summary>
    /// Interaction logic for Method_3.xaml
    /// </summary>
    public partial class Method_3 : Window
    {
        public Method_3()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }
        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.grid.ItemsSource = GridData.GetData();
        }

        public class GridData
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public bool Male { get; set; }

            public static ObservableCollection<GridData> GetData()
            {
                ObservableCollection<GridData> data =new ObservableCollection<GridData>();


                data.Add(new GridData()
                    {
                        Name = "John Doe",
                        Age = 30,
                        Male = true
                    });
                data.Add(new GridData()
                    {
                        Name = "Jane Doe",
                        Age = 32,
                        Male = false
                    });
                data.Add(new GridData()
                    {
                        Name = "Jason Smith",
                        Age = 54,
                        Male = true
                    });
                data.Add(new GridData()
                    {
                        Name = "Kayli Jayne",
                        Age = 25,
                        Male = false
                    });
                return data;
            }
        }
    }}
