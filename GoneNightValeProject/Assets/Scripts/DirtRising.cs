using UnityEngine;
using System.Collections;

public class DirtRising : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.up * 0.014f * Time.deltaTime;
	}
}
