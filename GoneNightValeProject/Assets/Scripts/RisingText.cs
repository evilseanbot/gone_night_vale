using UnityEngine;
using System.Collections;

public class RisingText : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.up * 0.005f * Time.deltaTime;
	
	}
}
