using System;
using MVVM.Model;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MVVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += (a, b) =>
                {
                    
                    ApplicationViewState d = ApplicationView.Value;
                    VisualStateManager.GoToState(this, d.ToString(), false);
                };

            //Student n = new Student
            //    {
            //        Name = "praba",
            //        Course = "mse"
            //    };
            //grid1.DataContext = n;
          MVVM.ViewModel.ViewModel viewModel=new ViewModel.ViewModel();

            viewModel.PropertyChanged += StudentPropertyChanged;
            grid1.DataContext = viewModel;
          

        }

        private  void StudentPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
      //   new MessageDialog("PropertyChanged In Student.Cs").ShowAsync();
        }

       

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Slider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {

        }

        

      
      
    }
}
