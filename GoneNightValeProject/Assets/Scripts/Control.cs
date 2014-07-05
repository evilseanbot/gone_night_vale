using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public bool inCar = false;
	public bool carryingCrate = false;
	public bool noCarCinematic = false;

	public bool crateInTrunk = false;

	private float vel;
	private GameObject car;
	private GameObject crate;
	private GameObject trunk;

	private float accel = 0.01f;

	// Use this for initialization
	void Start () {
		car = GameObject.Find ("Car");
		crate = GameObject.Find ("Crate");
		trunk = GameObject.Find ("Trunk");
	}
	
	// Update is called once per frame
	void Update () {
		if (inCar) {

			transform.position = car.transform.position;

		    if (Input.GetKey ("w")) {
				vel += accel;
			} 
			if (Input.GetKey ("s")) {
				vel -= (accel/2);
			} 

			
			if (Input.GetKey ("d")) {
				car.transform.Rotate (Vector3.up * 1f);
				transform.Rotate (Vector3.up * 1f);
			}
			if (Input.GetKey ("a")) {
				car.transform.Rotate (Vector3.up * -1f);
				transform.Rotate (Vector3.up * -1f);
			}

			if (Input.GetMouseButtonDown (0)) {
				exitCar ();
			}
		}
		else {
			Vector3 newPos = transform.position;
			if (Input.GetKey ("w")) {
				newPos += (transform.forward * 0.05f);

				//rigidbody.MovePosition (transform.position + (transform.forward * 0.05f));
			} 
			if (Input.GetKey ("s")) {
				newPos += (transform.forward * -0.05f);
			} 
			if (Input.GetKey ("d")) {
				newPos += (transform.right * 0.05f);
			}
			if (Input.GetKey ("a")) {
				newPos += (transform.right * -0.05f);
			}

			rigidbody.MovePosition (newPos);
			
			if (Input.GetMouseButtonDown (0)) {
				if (GameObject.Find ("Crate") != null) {
					if (Vector3.Distance (crate.transform.position, transform.position) < 2f && !carryingCrate) {
						carryingCrate = true;
					}

					else if (carryingCrate) {
						if (Vector3.Distance (crate.transform.position, trunk.transform.position) < 2f) {
							crateInTrunk = true;
							Destroy (crate);
						}
						
						carryingCrate = false;
					}
				}


				if (Vector3.Distance (car.transform.position, transform.position) < 2f && !carryingCrate && !noCarCinematic) {
					enterCar();
				}
			}
		}


		//car.transform.position += -car.transform.forward * vel;
		car.rigidbody.MovePosition (car.transform.position - (car.transform.forward * vel));;
		if (inCar) {
			transform.position = car.transform.position;
			vel = vel * 0.99f;
		} else {
			vel = vel * 0.9f;
		}
			
		if (carryingCrate) {
			Vector3 cratePos = transform.position + (transform.forward * 0.75f) + (transform.up * 0.25f);
			crate.transform.position = cratePos;
			crate.transform.rotation = transform.rotation;
		}

	}

	void enterCar() {
		inCar = true;
		transform.position = car.transform.position; 
		rigidbody.isKinematic = true;
		GetComponent<CapsuleCollider>().enabled = false;
		GameObject.Find ("FlashLight").light.enabled = false;
		GameObject.Find ("InteriorCarLight").light.enabled = false;
		//GameObject.Find ("LeftTailLight").light.enabled = false;
		//GameObject.Find ("RightTailLight").light.enabled = false;
	}

	void exitCar() {
		inCar = false;
		Vector3 outOfCar = car.transform.right * 2f;
		transform.position = car.transform.position + outOfCar; 
		rigidbody.isKinematic = false;
		GetComponent<CapsuleCollider>().enabled = true;

		GameObject.Find ("FlashLight").light.enabled = true;
		GameObject.Find ("InteriorCarLight").light.enabled = true;
		//GameObject.Find ("LeftTailLight").light.enabled = true;
		//GameObject.Find ("RightTailLight").light.enabled = true;
	}

}
