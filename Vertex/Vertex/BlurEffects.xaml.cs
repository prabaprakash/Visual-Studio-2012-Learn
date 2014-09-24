using System.Windows;

namespace Vertex
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var max = slider.Maximum;
            finalimage.Opacity = slider.Value / max;
            startimage.Opacity = 1 - finalimage.Opacity;
            StartImageBlur.Radius = finalimage.Opacity * 20;
            EndImageBlur.Radius = startimage.Opacity * 20;
        }
    }
}
