using UnityEngine;
using System.Collections;

public class DontFallOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < 0) {
			transform.position += Vector3.up * 1f; 
		}
	
	}
}
