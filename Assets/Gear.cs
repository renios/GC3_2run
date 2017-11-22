using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

	public float originspeed;
	public float speed;

	// Use this for initialization
	void Start () {
		speed = originspeed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.Euler(0,0,speed);
	}
}
