using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour {

	public AudioClip opening;
	public AudioClip newJob;
	public AudioClip moveCrates;
	public AudioClip takeCrate;
	public AudioClip putTrunk;
	public AudioClip driveHome;
	public AudioClip gotHome;
	public AudioClip turnIgnition;
	public AudioClip radioComesAlive;
	public AudioClip scrubLands;
	public AudioClip lookBack;
	public AudioClip punish;
	public AudioClip ending;
	public AudioClip getOut;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void restoreBgMusic() {
		AudioSource bgMusic = GameObject.Find("Main Camera").audio;
		bgMusic.volume = 1;
		GameObject.Find ("TrucksMissionMarker").renderer.enabled = false;
	}
}
