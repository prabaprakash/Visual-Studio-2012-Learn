using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Visualization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            this.SizeChanged += (a, b) =>
                {
                    ApplicationViewState d = ApplicationView.Value;
                    VisualStateManager.GoToState(this, d.ToString(), false);
                };
            //List<Test> h = new List<Test>();
            //h.Add(
            //Customer g = new Customer
            //    {
            //        Name = "Praba",
            //        Course = "Ms"
            //    };

    //);
            ViewModel viewModel=new ViewModel();
            this.DataContext =viewModel;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        
             
        }

       
    }
}
