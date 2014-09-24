using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Background_Task
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            BackgroundExecutionManager.GetAccessStatus();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               BackgroundExecutionManager.RequestAccessAsync();
                //var btb = new BackgroundTaskBuilder();
                //btb.Name = "tileupdater";
                //btb.TaskEntryPoint = "Task.BackgroundTask";
                //btb.SetTrigger(new SystemTrigger(SystemTriggerType.UserPresent,false));

                //BackgroundTaskRegistration bt = btb.Register();
                //bt.Progress += bt_Progress;
                //bt.Completed += bt_Completed;


                var btb = new BackgroundTaskBuilder();

                btb.Name = "tileupdater";
                btb.TaskEntryPoint = "Task.BackgroundTask";

                SystemCondition userCondition = new SystemCondition(SystemConditionType.UserPresent);

                btb.AddCondition(userCondition);
              
                btb.SetTrigger(new TimeTrigger(15, false));

                BackgroundTaskRegistration bt = btb.Register();
                bt.Progress += bt_Progress;
                bt.Completed += bt_Completed;

                //                TimeTrigger hourlyTrigger = new TimeTrigger(60, false);

                //SystemCondition st=new SystemCondition(SystemConditionType.UserPresent);

            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message + ex.StackTrace).ShowAsync();
            }

        }

        public void bt_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
          
        }

        public void bt_Progress(BackgroundTaskRegistration sender, BackgroundTaskProgressEventArgs args)
        {
           
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt.Text = "";
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                txt.Text += task.Value.Name+"\n";
                task.Value.Unregister(true);
            }
        }

    }
}
