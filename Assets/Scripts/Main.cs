using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    Animator anim;

    int move1Hash = Animator.StringToHash("Move1");
    int move2Hash = Animator.StringToHash("Move2");

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.StopPlayback();
    }

    // Update is called once per frame
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
