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
        static void Main(string[] args)
        {
            var connection = new HubConnection("http://localhost:5225/");
            //Make proxy to hub based on hub name on server
            var myHub = connection.CreateHubProxy("MyHub");
            //Start connection

            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");


                    try
                    {
                        OpenDMX.start();                                            //find and connect to devive (first found if multiple)
                        if (OpenDMX.status == FT_STATUS.FT_DEVICE_NOT_FOUND)
                        {
                            Console.WriteLine("No Enttec USB Device Found");
                        }
                        else if (OpenDMX.status == FT_STATUS.FT_OK)
                        {
                            Console.WriteLine("Found DMX on USB");

                            OpenDMX.setDmxValue(1, 254);

                            OpenDMX.writeData();
                            while (true)
                            {
                                OpenDMX.setDmxValue(4, 254);

                                OpenDMX.writeData();

                                Thread.Sleep(200);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error Opening Device");
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp);
                        Console.WriteLine("Error Connecting to Enttec USB Device");

                    }



                }

            }).Wait();

            //myHub.Invoke<string>("Send", "HELLO World ").ContinueWith(task =>
            //{
            //    if (task.IsFaulted)
            //    {
            //        Console.WriteLine("There was an error calling send: {0}",
            //                          task.Exception.GetBaseException());
            //    }
            //    else
            //    {
            //        Console.WriteLine(task.Result);
            //    }
            //});

            myHub.On<string>("addMessage", param =>
            {
                Console.WriteLine(param);
            });

            //   myHub.Invoke<string>("DoSomething", "I'm doing something!!!").Wait();


            Console.Read();
            connection.Stop();
        }

    }

}

