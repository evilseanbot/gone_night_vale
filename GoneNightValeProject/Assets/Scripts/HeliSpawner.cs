using UnityEngine;
using System.Collections;

public class HeliSpawner : MonoBehaviour {

	public GameObject heli;
	private float timeTillNextHeli = 0;
	public float timeBetweenHelis = 4f;
	
	// Update is called once per frame
	void Update () {
	    if (timeTillNextHeli < Time.time) {
			timeTillNextHeli = Time.time + timeBetweenHelis;
			Vector3 heliPos = transform.position + new Vector3(0, 0, Random.Range (-250f, 250f) + Random.Range (-250F, 250F));
			Quaternion heliRot = transform.rotation * Quaternion.Euler (0, Random.Range (-45f, 45f) + Random.Range (-45f, 45f), 0);
			Instantiate (heli, heliPos, heliRot);
		}
	}
}
