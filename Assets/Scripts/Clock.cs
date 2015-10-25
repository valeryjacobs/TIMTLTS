using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var textM = GetComponent<TextMesh>();
		textM.text = DateTime.Now.TimeOfDay.Minutes + ":" + DateTime.Now.TimeOfDay.Seconds;
	}
}
