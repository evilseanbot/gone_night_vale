using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

	public AudioClip moveCrates;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("r")) {
			AudioSource bgMusic = GameObject.Find("Main Camera").audio;
			GameObject.Find ("TrucksMissionMarker").renderer.enabled = true;
			bgMusic.volume = 0.25f;
			audio.Play ();
			Invoke ("restoreBgMusic", 15f);
		}
	
	}

	void restoreBgMusic() {
		AudioSource bgMusic = GameObject.Find("Main Camera").audio;
		bgMusic.volume = 1;
		GameObject.Find ("TrucksMissionMarker").renderer.enabled = false;
	}
}
