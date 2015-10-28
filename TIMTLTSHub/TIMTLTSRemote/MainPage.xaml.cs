using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TIMTLTSRemote
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private HubConnection hubConnection;
        private IHubProxy proxy;
        private HubConnection qmhubConnection;
        private IHubProxy qmproxy;

        public MainPage()
        {
            this.InitializeComponent();

            Init();
        }

        private async void Init()
        {
            hubConnection = new HubConnection("http://localhost:5225");
            proxy = hubConnection.CreateHubProxy("MyHub");
            await hubConnection.Start();

            proxy.On<string>("executeCommand", (data) =>
            {
                Debug.WriteLine(data);
               // var message = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(data.ToString());
            });

            qmhubConnection = new HubConnection("http://quantifymewebhub.azurewebsites.net/");
            qmproxy = qmhubConnection.CreateHubProxy("QuantifyMeHub");
            await qmhubConnection.Start();

            qmproxy.On<string,string>("send", (name, data) =>
            {
                Debug.WriteLine(data);
                var message = new Message { Source = "RemoteUWP", Action = "UpdateData", Value = data };

                proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));

            });
        }

        private void _subscription_Received(IList<Newtonsoft.Json.Linq.JToken> obj)
        {
            var x = obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Animate", Value = "Full2Perspective" };
            
            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Slide2Table_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Animate", Value = "Slide2Table" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Table2Clock_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Animate", Value = "Table2Clock" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Table2Demo_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Animate", Value = "Table2Demo" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Slide2Demo_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Animate", Value = "Slide2Demo" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Table2Slide_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Animate", Value = "Table2Slide" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Demo1_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Demo", Value = "Demo1" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Demo2_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Demo", Value = "Demo2" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void Demo3_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "Demo", Value = "Demo3" };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }

        private void submitRate_Click(object sender, RoutedEventArgs e)
        {
            var message = new Message { Source = "RemoteUWP", Action = "UpdateData", Value = rate.Text };

            proxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
        }
    }

    public class Message
    {
        public string Source { get; set; }
        public string Action { get; set; }
        public string Value { get; set; }
    }
}
