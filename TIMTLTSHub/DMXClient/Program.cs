using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DMXClient
{
    class Program
    {
        private static HubConnection qmhubConnection;
        private static IHubProxy qmproxy;
        private static float rate = 70;

        static void Main(string[] args)
        {
            qmhubConnection = new HubConnection("http://quantifymewebhub.azurewebsites.net/");
            qmproxy = qmhubConnection.CreateHubProxy("QuantifyMeHub");
            qmhubConnection.Start();


            OpenDMX.start();
            if (OpenDMX.status == FT_STATUS.FT_DEVICE_NOT_FOUND)
            {
                Console.WriteLine("No Enttec USB Device Found");
                Console.ReadLine();
            }

            OpenDMX.setDmxValue(0, 254);

            qmproxy.On<string, string>("send", (name, data) =>
            {

                rate = float.Parse(data);
            });


            while (true)
            {
                Console.WriteLine("Found DMX on USB");
                OpenDMX.setDmxValue(1, 254);
                OpenDMX.setDmxValue(2, 254);
                OpenDMX.setDmxValue(3, 0);
                OpenDMX.setDmxValue(4, 0);
                OpenDMX.writeData();

                Thread.Sleep(100);
                OpenDMX.setDmxValue(1, 255);
                OpenDMX.setDmxValue(2, 0);
                OpenDMX.setDmxValue(3, 0);
                OpenDMX.setDmxValue(4, 255);

                OpenDMX.writeData();


                Thread.Sleep((int)Math.Round(1000f * (60f / rate), 0));

                //find and connect to devive (first found if multiple)



            }









        }

    }

}

