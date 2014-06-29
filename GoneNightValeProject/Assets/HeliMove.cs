using UnityEngine;
using System.Collections;

public class HeliMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float speed = -0.3f;
		transform.position += transform.forward * speed;
	}
}
