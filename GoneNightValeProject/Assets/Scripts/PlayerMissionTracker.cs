using UnityEngine;
using System.Collections;

public class PlayerMissionTracker : MonoBehaviour {

	private GameObject truckMissionSite;
	private GameObject radio;
	private int theMission = 1;

	// Use this for initialization
	void Start () {
		truckMissionSite = GameObject.Find ("TrucksMissionSite");
		radio = GameObject.Find ("Radio");

		Debug.Log (truckMissionSite);
		Debug.Log (radio);
	}
	
	// Update is called once per frame
	void Update () {
		if (theMission == 1) {
			if (Vector3.Distance (transform.position, truckMissionSite.transform.position) < 50f) {
				theMission = 2;
				Debug.Log ("At Trucks Mission");
				radio.audio.clip = radio.GetComponent<Radio>().moveCrates;
				radio.audio.Play ();

			}
		}
	}

}
