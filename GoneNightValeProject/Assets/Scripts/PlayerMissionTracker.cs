using UnityEngine;
using System.Collections;

public class PlayerMissionTracker : MonoBehaviour {

	private GameObject truckMissionSite;
	private GameObject homeMissionSite;
	private GameObject scrubMissionSite;

	private GameObject radio;
	private int mission = 1;
	private GameObject player;

	// Mission 1: Opening Story.
	// Mission 2: The opening story is currently playing.
	// Mission 3: You need to go to the wastes
	// Mission 4: Describing what you do at the wastes.
	// Mission 5: Description of crate taking is playing.
	// Mission 6: Description of crate taking is played. Take the crate.
	// Mission 7: You need to put the crate in your trunk.
	// Mission 8: You head home.
	// Mission 9: You get home, getting home is currently playing.
	// Mission 10: You turn on the ignition.
	// Mission 11: The radio comes alive.

	// Mission 13: You listen about the radio.
	// Mission 14: You head out to the wastes.
	// Mission 10: You go out for a drive
	// Mission 11: Describing how all shit is breaking loose.
	// Mission 12: And now, the Weather.

	// Use this for initialization
	void Start () {
		truckMissionSite = GameObject.Find ("TrucksMissionSite");
		homeMissionSite = GameObject.Find ("HomeMissionSite");
		scrubMissionSite = GameObject.Find ("ScrubMissionSite");

		radio = GameObject.Find ("Radio");
		player = GameObject.Find ("First Person Controller");
	}
	
	// Update is called once per frame
	void Update () {
		if (mission == 1) {
			mission = 2;
			radio.audio.clip = radio.GetComponent<Radio>().opening;
			radio.audio.Play();
			Invoke ("highlightTrucksMission", radio.audio.clip.length);
		}

		if (mission == 3) {
			if (Vector3.Distance (transform.position, truckMissionSite.transform.position) < 50f) {
				mission = 4;
				radio.audio.clip = radio.GetComponent<Radio>().moveCrates;
				radio.audio.Play ();
				Invoke ("highlightFirstTimeTakeCrateMission", radio.audio.clip.length);
			}
		}

		if (mission == 6) {
			if (player.GetComponent<Control>().carryingCrate) {
				highlightPutTrunkMission ();
			}
		}

		if (mission == 7) {
			if (player.GetComponent<Control>().crateInTrunk) {
				highlightDriveHomeMission ();
			}
		}

		if (mission == 8) {
			if (Vector3.Distance (transform.position, homeMissionSite.transform.position) < 50f) {
				mission = 9;
				radio.audio.clip = radio.GetComponent<Radio>().gotHome;
				radio.audio.Play ();
				Invoke ("highlightTurnIgnitionMission", radio.audio.clip.length);
			}
		}

		if (mission == 10) {
			if (player.GetComponent<Control>().inCar) {
				mission = 11;
				radio.audio.clip = radio.GetComponent<Radio>().radioComesAlive;
				radio.audio.Play ();
				Invoke ("highlightScrubLandsMission", radio.audio.clip.length);
			}
		}

		if (mission == 12) {
			if (Vector3.Distance (transform.position, scrubMissionSite.transform.position) < 50f) {
				highlightGetOutMission ();
			}
		}

		if (mission == 13) {
			if (!player.GetComponent<Control>().inCar) {
				mission = 14;
				radio.audio.clip = radio.GetComponent<Radio>().lookBack;
				radio.audio.Play ();
				Invoke ("playPunishMission", radio.audio.clip.length);
			}
		}


		if (Input.GetKey ("r")) {
			if (mission == 3) {
				highlightTrucksMission ();
			}
			if (mission == 6) {
				highlightTakeCrateMission ();
			}
			if (mission == 7) {
				highlightPutTrunkMission ();
			}
			if (mission == 8) {
				highlightDriveHomeMission ();
			}
			if (mission == 10) {
				highlightTurnIgnitionMission ();
			}
			if (mission == 12) {
				highlightScrubLandsMission ();
			}
			if (mission == 13) {
				highlightGetOutMission ();
			}

		}

	}

	void highlightTrucksMission () {
		mission = 3;
		AudioSource bgMusic = GameObject.Find("Main Camera").audio;
		GameObject.Find ("TrucksMissionMarker").renderer.enabled = true;
		//bgMusic.volume = 0.25f;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().newJob;
		radio.audio.Play ();
		Invoke ("restoreBgMusic", 15f);
		Invoke ("turnOffMarkers", radio.audio.clip.length);
	}

	void highlightFirstTimeTakeCrateMission () {
		mission = 5;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().takeCrate;
		radio.audio.Play ();
		Invoke ("listenedToCrateTalk", radio.audio.clip.length);
	}

	void listenedToCrateTalk() {
		mission = 6;
	}

	void highlightTakeCrateMission () {
		mission = 6;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().takeCrate;
		radio.audio.Play ();
	}

	void highlightPutTrunkMission () {
		mission = 7;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().putTrunk;
		radio.audio.Play ();
	}

	void highlightDriveHomeMission () {
		mission = 8;
		GameObject.Find ("HomeMissionMarker").renderer.enabled = true;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().driveHome;
		radio.audio.Play ();
		Invoke ("turnOffMarkers", radio.audio.clip.length);
	}

	void highlightTurnIgnitionMission () {
		mission = 10;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().turnIgnition;
		radio.audio.Play ();
	}

	void highlightScrubLandsMission () {
		mission = 12;
		GameObject.Find ("ScrubMissionMarker").renderer.enabled = true;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().scrubLands;
		radio.audio.Play ();
		Invoke ("turnOffMarkers", radio.audio.clip.length);
	}

	void highlightGetOutMission() {
		mission = 13;
		radio.audio.clip = radio.GetComponent<Radio>().getOut;
		radio.audio.Play ();
	}

	void playPunishMission () {
		//mission = 5;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().punish;
		radio.audio.Play ();
		Invoke ("playEndingMission", radio.audio.clip.length);
	}

	void playEndingMission () {
		//mission = 5;
		radio.audio.clip = radio.audio.clip = radio.GetComponent<Radio>().ending;
		radio.audio.Play ();
	}



	void restoreBgMusic() {
		AudioSource bgMusic = GameObject.Find("Main Camera").audio;
		//bgMusic.volume = 1;
		GameObject.Find ("TrucksMissionMarker").renderer.enabled = false;
	}

	void turnOffMarkers() {
		GameObject.Find ("TrucksMissionMarker").renderer.enabled = false;
		GameObject.Find ("HomeMissionMarker").renderer.enabled = false;
		GameObject.Find ("ScrubMissionMarker").renderer.enabled = false;

	}
}
