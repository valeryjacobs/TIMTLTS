using UnityEngine;
using System.Collections;

public class Webcam : MonoBehaviour {

    WebCamTexture webcam;
	// Use this for initialization
	void Start () {
        webcam = new WebCamTexture("Microsoft LifeCam Front");

        Renderer rend = GetComponent<Renderer>();

        rend.material.mainTexture = webcam;

        webcam.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
