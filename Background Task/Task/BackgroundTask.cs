using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.ApplicationModel.Background;

namespace Task
{
    public sealed class BackgroundTask:IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            XmlDocument xc = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            XmlNodeList xnl = xc.GetElementsByTagName("text");
            xnl[0].InnerText = "hello";
            var s=new ToastNotification(xc);
            s.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
           ToastNotificationManager.CreateToastNotifier().Show(s);
        }
    }
}
