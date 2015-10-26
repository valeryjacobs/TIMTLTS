using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    Animator anim;

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
            
            anim.SetTrigger("Move1");

            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("test", "message x");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.Play("Initiate3DDimension", 0);

            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("Animate", "Initiate3DDimension");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.Play("SlidePosToTable", 0);
            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("Animate", "SlidePosToTable");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.Play("TableToClock", 0);
            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("Animate", "TableToClock");
        }
    }
}
