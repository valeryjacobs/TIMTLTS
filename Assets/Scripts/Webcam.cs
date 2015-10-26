using UnityEngine;
using System.Collections;
using System;

public class Webcam : MonoBehaviour
{

    WebCamTexture webcam;
    // Use this for initialization
    void Start()
    {
        webcam = new WebCamTexture("Microsoft LifeCam Rear");//"Microsoft LifeCam HD-6000");// "Microsoft LifeCam Front");

        Renderer rend = GetComponent<Renderer>();

        rend.material.mainTexture = webcam;

        try
        {
            webcam.Play();
        }
        catch (Exception e)
        {
            webcam.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
