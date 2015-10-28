using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    Animator anim;
    public GameObject Demo1;
    public GameObject Demo2;
    public GameObject Demo3;

    void Start()
    {
        Application.runInBackground = true;
        anim = GetComponent<Animator>();
        anim.StopPlayback();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("test", "message x");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.Play("Full2Perspective", 0);

            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("Animate", "Initiate3DDimension");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.Play("Slide2Table", 0);
            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("Animate", "SlidePosToTable");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.Play("Table2Clock", 0);
            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("Animate", "TableToClock");
        }
    }

    public void PlayAnimation(string animationName)
    {
        anim.Play(animationName, 0);
    }

    public void SetupDemo(string demoName)
    {
        switch (demoName)
        {
            case "Demo1":
                Demo1.SetActive(true);
                Demo2.SetActive(false);
                Demo3.SetActive(false);
                break;
            case "Demo2":
                Demo1.SetActive(false);
                Demo2.SetActive(true);
                Demo3.SetActive(false);
                break;
            case "Demo3":
                Demo1.SetActive(false);
                Demo2.SetActive(false);
                Demo3.SetActive(true);
                break;
        }
        
    }
}
