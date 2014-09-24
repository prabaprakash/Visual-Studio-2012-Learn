using System.Windows;

namespace Vertex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var max = slider.Maximum;
            finalimage.Opacity =slider.Value / max;
            startimage.Opacity = 1 - finalimage.Opacity;
           
        }

       
    }
}
