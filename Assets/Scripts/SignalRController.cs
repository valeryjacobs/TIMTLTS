using SignalR.Client._20.Hubs;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SignalRController : MonoBehaviour
{

    public bool useSignalR = true;
    public string signalRUrl = "http://localhost:5225/";

    public Message ActionTrigger;

    private HubConnection _hubConnection = null;
    private IHubProxy _hubProxy;
    private Subscription _subscription;

    private Main _main;
    public Camera Cam;
    public List<int> HeartRates;

    void Start()
    {
        Debug.Log("Starting signalr class");
        HeartRates = new List<int>();

        if (useSignalR)
            StartSignalR();

        _main = GetComponent<Main>();

    }

    void Update()
    {
        if (ActionTrigger != null)
        {

            switch (ActionTrigger.Action)
            {
                case "Animate":
                    _main.PlayAnimation(ActionTrigger.Value);

                    break;
                case "Demo":
                    _main.SetupDemo(ActionTrigger.Value);
                    break;
                case "UpdateData":
                    HeartRates.Insert(0,int.Parse(ActionTrigger.Value));
                    if (HeartRates.Count > 6)
                    {
                        HeartRates.RemoveAt(6);
                    }
                    break;
                default:
                    break;
            }
            ActionTrigger = null;
        }
    }



    void StartSignalR()
    {
        if (_hubConnection == null)
        {
            _hubConnection = new HubConnection(signalRUrl);

            _hubProxy = _hubConnection.CreateProxy("MyHub");
            _subscription = _hubProxy.Subscribe("executeCommand");
            _subscription.Data += data =>
            {
                Debug.Log(data[0].ToString());

                var message = Newtonsoft.Json.JsonConvert.DeserializeObject<Message>(data[0].ToString());

                ActionTrigger = message;
            };
            try
            {
                _hubConnection.Start();
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            Debug.Log("Signalr already connected...");
        }

    }

    private void Test()
    {

    }

    public void Send(string action, string value)
    {
        if (!useSignalR)
            return;

        var message = new Message { Source = "Unity", Action = "NextSlide", Value = "" };

        _hubProxy.Invoke("Send", Newtonsoft.Json.JsonConvert.SerializeObject(message));
    }

}

public class Message
{
    public string Source { get; set; }
    public string Action { get; set; }
    public string Value { get; set; }
}

