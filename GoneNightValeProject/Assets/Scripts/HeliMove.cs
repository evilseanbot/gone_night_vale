using UnityEngine;
using System.Collections;

public class HeliMove : MonoBehaviour {

	private float timeTillDrop;
	public bool jumper = true;

	// Use this for initialization
	void Start () {
		timeTillDrop = Time.time + 15f;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = -0.3f;
		transform.position += transform.forward * speed;

		if (jumper) {
			if (Time.time < timeTillDrop) {
				if (transform.position.y < 15) {
					transform.position += transform.up * 0.1f;
				}
			} else {
				transform.position += -transform.up * 0.1f;

				if (transform.position.y < 0) {
					gameObject.SetActive (false);
				}
			}
		}
	}
}
