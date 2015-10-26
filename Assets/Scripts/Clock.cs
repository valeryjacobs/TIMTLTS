using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour
{

    public int EndHours;
    public int EndMinutes;
    private DateTime EndTime;
    // Use this for initialization
    void Start()
    {

        EndTime = DateTime.Now;
        TimeSpan ts = new TimeSpan(EndHours, EndMinutes, 0);
        EndTime = EndTime.Date + ts;
    }

    // Update is called once per frame
    void Update()
    {

        var duration = EndTime - System.DateTime.Now;
        var textM = GetComponent<TextMesh>();
        if (duration.Minutes < 0 || duration.Seconds < 0)
        {
            textM.text = "00:00";
        }
        else
        {
            textM.text = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);
        }

    }
}
