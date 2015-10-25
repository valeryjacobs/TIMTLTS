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
        private Subscription _subscription;
        public MainPage()
        {
            this.InitializeComponent();

            Init();
        }

        private async void Init()
        {
            hubConnection = new HubConnection("http://localhost:5225");

            proxy = hubConnection.CreateHubProxy("MyHub");
            //_subscription = proxy.Subscribe("addMessage");

            //_subscription.Received += _subscription_Received;

            await hubConnection.Start();


            // proxy.On("UpdateStockPrice", stock => Debug );

            proxy.On<string,object >("addMessage", (source, payload) =>
            {
                Debug.WriteLine(source + " : " + payload);
            });
        }

        private void _subscription_Received(IList<Newtonsoft.Json.Linq.JToken> obj)
        {
            var x = obj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var json = "{" + string.Format("\"action\": \"{0}\", \"value\": {1}", "methodName", "messageContent") + "}";
            proxy.Invoke("Send", "RemoteClient", json);
        }
    }
}
