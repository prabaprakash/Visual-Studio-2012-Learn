using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Serialization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += MainPage_SizeChanged;
        }

        public void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ApplicationViewState Aps = ApplicationView.Value;
            VisualStateManager.GoToState(this, Aps.ToString(), false);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        #region Class
        public class MyClass
        {
            public int _id;
            public String _name;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public String Name
            {
                get { return _name; }
                set { _name = value; }
            }


        }
        #endregion

        #region JsonSerialization , Linq
        private async void button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Write
                {
                    List<MyClass> ls = new List<MyClass>()
                        {
                            new MyClass
                                {
                                    _id = 1108,
                                    _name = "Praba",

                                },
                            new MyClass
                                {
                                    _id = 1133,
                                    _name = "Sam",

                                },
                            new MyClass
                                {
                                    _id = 3,
                                    _name = "Praveen",

                                }
                        };


                    string g = JsonConvert.SerializeObject(ls, Formatting.Indented);
                    // var h = JsonConvert.DeserializeObject<MyClass>(g);

                    StorageFile cFile =
                        await
                        ApplicationData.Current.LocalFolder.CreateFileAsync("jsonFile.txt",
                                                                            CreationCollisionOption.OpenIfExists);
                    using (var sWriter = new StreamWriter(await cFile.OpenStreamForWriteAsync()))
                    {
                        sWriter.Write(g);
                        await sWriter.FlushAsync();
                    }
                }
                //Read
                {
                    var rFile = await ApplicationData.Current.LocalFolder.GetFileAsync("jsonFile.txt");
                    String fString = null;
                    using (var sReader = new StreamReader(await rFile.OpenStreamForReadAsync()))
                    {
                        fString = await sReader.ReadToEndAsync();
                    }

                    if (fString != null)
                    {
                        var ls2 = JsonConvert.DeserializeObject<List<MyClass>>(fString);
                        txt.Text = "";

                        //Linq

                        var query = from x in ls2 where x.Name.Equals("Praba") select x;

                        //
                        foreach (var d in query)
                        {
                            Debug.WriteLine(d.Id + "\n" + d.Name + "\n");
                            txt.Text += d.Id + "\n" + d.Name + "\n";

                        }
                        Debug.WriteLine("Well !!!... Its Working......");
                       // new MessageDialog(ls2.ToString()).ShowAsync();
                    }
                  
                }
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }

        }
        #endregion
       
        #region DataContractSerializer
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //Write
                {
                    MyClass my = new MyClass()
                        {
                            _id = 1108,
                            _name = "Praba"
                        };
                    var dcs = new DataContractSerializer(typeof(MyClass));


                    StorageFile sfileread =
                        await
                        ApplicationData.Current.LocalFolder.CreateFileAsync("DataContract.xml",
                                                                            CreationCollisionOption.ReplaceExisting);
                    using (Stream sw = await sfileread.OpenStreamForWriteAsync())
                    {
                        dcs.WriteObject(sw, my);
                       sw.Dispose();
                    }
                }
                //Read
                {
                    MyClass m;
                    var dc= new DataContractSerializer(typeof(MyClass));
                    StorageFile sfilewrite = await ApplicationData.Current.LocalFolder.GetFileAsync("DataContract.xml");
                    using (Stream sr = await sfilewrite.OpenStreamForReadAsync())
                    {
                        m = (MyClass) dc.ReadObject(sr);
                        //sr.Dispose();
                    }
                    txt.Text = "";
                    txt.Text = m.Name + m.Id;
                }
            }
            catch(Exception ex)
            {
                new MessageDialog(ex.Message).ShowAsync();
            }
        }
        #endregion

        #region DataContract XmlWriter
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                //Write
                {
                    List<MyClass> my = new List<MyClass>()
                        {
                            new MyClass()
                                {
                                    _id = 1108,
                                    _name = "Praba"
                                },
                                new MyClass()
                                    {
                                        _id = 1133,
                                        _name = "praveen"
                                    }
                        };
                    var dcs = new DataContractSerializer(typeof(List<MyClass>));


                    StorageFile sf =
                        await
                        ApplicationData.Current.LocalFolder.CreateFileAsync("DataContractwithxml.xml",
                                                                            CreationCollisionOption.ReplaceExisting);

                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings()
                    {
                        Indent = true,
                        ConformanceLevel = ConformanceLevel.Auto
                    };


                    using (XmlWriter xmlWriter = XmlWriter.Create(await sf.OpenStreamForWriteAsync(), xmlWriterSettings)
                        )
                    {
                        dcs.WriteObject(xmlWriter, my);
                
                        xmlWriter.Dispose();
                    }
                   
                }
               
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.Message+ex.StackTrace).ShowAsync();
            }
        }
        #endregion

        #region DataContract XmlReader
        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                //Read
                {
                    List<MyClass> m;
                    var dcsr = new DataContractSerializer(typeof (List<MyClass>));
                    StorageFile sfileread =
                        await ApplicationData.Current.LocalFolder.GetFileAsync("DataContractwithxml.xml");
                    XmlReaderSettings xmlReaderSettings = new XmlReaderSettings()
                        {
                            ConformanceLevel = ConformanceLevel.Auto
                        };

                    using (
                        XmlReader xmlReader = XmlReader.Create(await sfileread.OpenStreamForReadAsync(),
                                                               xmlReaderSettings))
                    {
                        m = (List<MyClass>) dcsr.ReadObject(xmlReader);
                        xmlReader.Dispose();
                    }
                    txt.Text = "";
                    foreach (var myClass in m)
                    {
                        txt.Text += myClass.Name+"\t"+ myClass.Id+"\n";
                    }

                }
            }
            catch(Exception ex)
            {
                new MessageDialog("Wait For 2 Sec To Write Process To Complete").ShowAsync();
            }
        }
        #endregion

        #region Xml Serializer
        public async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                MyClass mc = new MyClass()
                    {
                        _id = 1108,
                        _name = "Praba"
                    };
         
            var xml=new XmlSerializer(typeof (MyClass));
                StorageFile sf =
                    await
                    ApplicationData.Current.LocalFolder.CreateFileAsync("xml.xml",
                                                                        CreationCollisionOption.ReplaceExisting);
                using (Stream streamwriter=await sf.OpenStreamForWriteAsync())
                {
                    xml.Serialize(streamwriter,mc);
                }
                using (Stream streamreader=await sf.OpenStreamForReadAsync())
                {
                    mc = (MyClass)xml.Deserialize(streamreader);
                }
                txt.Text = mc.Name + mc.Id;
            }
            catch (Exception ex)
            {

                new MessageDialog(ex.Message+ex.StackTrace.ToString()).ShowAsync();
                Debug.WriteLine(ex.Message+ex.StackTrace.ToString());
            }
        }
        #endregion

        #region DataContract StorageStream/IinputStream
        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                //Write
                {
                    List<MyClass> ls = new List<MyClass>()
                        {
                            new MyClass
                                {
                                    _id = 1108,
                                    _name = "Praba",

                                },
                            new MyClass
                                {
                                    _id = 1133,
                                    _name = "Sam",

                                },
                            new MyClass
                                {
                                    _id = 3,
                                    _name = "Praveen",

                                }
                        };
                    var dcs = new DataContractSerializer(typeof(List<MyClass>));


                    StorageFile sfileread =
                        await
                        ApplicationData.Current.LocalFolder.CreateFileAsync("StorageStream.xml",
                                                                            CreationCollisionOption.ReplaceExisting);
                    using (StorageStreamTransaction sw = await sfileread.OpenTransactedWriteAsync())
                    {
                        dcs.WriteObject(sw.Stream.AsStreamForWrite(),ls);
                        await sw.CommitAsync();

                    }
                }
                //Read
                {
                    List<MyClass> m;
                    var dc = new DataContractSerializer(typeof(List<MyClass>));
                    StorageFile sfilewrite = await ApplicationData.Current.LocalFolder.GetFileAsync("StorageStream.xml");
                    using (IInputStream sr = await sfilewrite.OpenSequentialReadAsync())
                    {
                        m = (List<MyClass>)dc.ReadObject(sr.AsStreamForRead());
                        //sr.Dispose();
                    }
                    txt.Text = "";
                    foreach (var myClass in m)
                    {
                        txt.Text+= myClass.Name+"\t" + myClass.Id+"\n";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                new MessageDialog(ex.StackTrace+ex.Message).ShowAsync();
            }
        }
        #endregion

    }
}
