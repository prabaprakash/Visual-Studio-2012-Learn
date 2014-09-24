using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Visualization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Visual3 : Page
    {
        private int pixelWidth = 12000;
        private int pixelHeight = 8000;
        private WriteableBitmap graphBitmap = null;
        public Visual3()
        {
            this.InitializeComponent();

            this.Loaded += RoutedEventHandler;
            //int dataSize = bytesPerPixel * pixelWidth * pixelHeight;
            //data = new byte[dataSize];
            //graphBitmap = new WriteableBitmap(pixelWidth, pixelHeight);
        }

        public Task a;
        private void RoutedEventHandler(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource ct=new CancellationTokenSource();
            CancellationToken t = ct.Token;
            a = Task.Run(() => ffff());
            a.Wait(t);

        }

        private void ffff()
        {
            for (int i = 0; i < 200; i++)
            {
                different.Text = i.ToString();
            }
        }


        //private void plotButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Random rand = new Random();
        //    redValue = (byte)rand.Next(0xFF);
        //    greenValue = (byte)rand.Next(0xFF);
        //    blueValue = (byte)rand.Next(0xFF);
        //    Stopwatch watch = Stopwatch.StartNew();
        //    generateGraphData(data);
        //    duration.Text = string.Format("Duration (ms): {0}", watch.ElapsedMilliseconds);
        //    Stream pixelStream = graphBitmap.PixelBuffer.AsStream();
        //    pixelStream.Seek(0, SeekOrigin.Begin);
        //    pixelStream.Write(data, 0, data.Length);
        //    graphBitmap.Invalidate();
        //    graphImage.Source = graphBitmap;
        //}
        //private void generateGraphData(byte[] data)
        //{
        //    int a = pixelWidth / 2;
        //    int b = a * a;
        //    int c = pixelHeight / 2;
        //    for (int x = 0; x < a; x++)
        //    {
        //        int s = x * x;
        //        double p = Math.Sqrt(b - s);
        //        for (double i = -p; i < p; i += 3)
        //        {
        //            double r = Math.Sqrt(s + i * i) / a;
        //            double q = (r - 1) * Math.Sin(24 * r);
        //            double y = i / 3 + (q * c);
        //            plotXY(data, (int)(-x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
        //            plotXY(data, (int)(x + (pixelWidth / 2)), (int)(y + (pixelHeight / 2)));
        //        }
        //    }
        //}
        //private void plotXY(byte[] data, int x, int y)
        //{
        //    int pixelIndex = (x + y * pixelWidth) * bytesPerPixel;
        //    data[pixelIndex] = blueValue;
        //    data[pixelIndex + 1] = greenValue;
        //    data[pixelIndex + 2] = redValue;
        //    data[pixelIndex + 3] = 0xBF;
        //}

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
