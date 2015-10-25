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
            anim.Play("Move1", 0);

            var signalRController = GetComponent<SignalRController>();
            signalRController.Send("test", "message x");
        }
    }
}
