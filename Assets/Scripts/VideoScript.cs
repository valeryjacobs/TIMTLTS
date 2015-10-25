using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class VideoScript : MonoBehaviour {

	public MovieTexture movie;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.mainTexture = movie as MovieTexture;
		movie.Play();
	}
	

}
