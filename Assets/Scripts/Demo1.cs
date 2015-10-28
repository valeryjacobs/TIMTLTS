using UnityEngine;
using System.Collections;

public class Demo1 : MonoBehaviour
{
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;
    public GameObject R5;
    public GameObject R6;

    public GameObject Heart;
    public TextMesh RateText;

    public SignalRController SignalRController;

    Vector3 newPos;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       // light.range = Mathf.PingPong(Time.time * speed, maxDist);
       

           


        if (SignalRController.HeartRates == null) return;

        if (SignalRController.HeartRates.Count > 0)
        {

            RateText.text = SignalRController.HeartRates[0].ToString();
            Heart.transform.localScale = new Vector3(0.19f, 0.19f,0.19f + 0.08f * (Mathf.PingPong(Time.time * ((float)SignalRController.HeartRates[0] / 60f), 0.5f)));

            newPos = new Vector3(R1.transform.localPosition.x, -5 + (((float)SignalRController.HeartRates[0] / 200f) * 3), R1.transform.localPosition.z);
            R1.transform.localPosition = newPos;
        }

        if (SignalRController.HeartRates.Count > 1)
        {
            newPos = new Vector3(R2.transform.localPosition.x, -5 + (((float)SignalRController.HeartRates[1] / 200f) * 3), R2.transform.localPosition.z);
            R2.transform.localPosition = newPos;
        }

        if (SignalRController.HeartRates.Count > 2)
        {
            newPos = new Vector3(R3.transform.localPosition.x, -5 + (((float)SignalRController.HeartRates[2] / 200f) * 3), R3.transform.localPosition.z);
            R3.transform.localPosition = newPos;
        }

        if (SignalRController.HeartRates.Count > 3)
        {
            newPos = new Vector3(R4.transform.localPosition.x, -5 + (((float)SignalRController.HeartRates[3] / 200f) * 3), R4.transform.localPosition.z);
            R4.transform.localPosition = newPos;
        }

        if (SignalRController.HeartRates.Count > 4)
        {
            newPos = new Vector3(R5.transform.localPosition.x, -5 + (((float)SignalRController.HeartRates[4] / 200f) * 3), R5.transform.localPosition.z);
            R5.transform.localPosition = newPos;
       
        }

        if (SignalRController.HeartRates.Count > 5)
        {
            newPos = new Vector3(R6.transform.localPosition.x, -5 + (((float)SignalRController.HeartRates[5] / 200f) * 3), R6.transform.localPosition.z);
            R6.transform.localPosition = newPos;

        }




    }
}
