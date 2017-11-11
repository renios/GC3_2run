using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {

    public Rigidbody2D player1Rigidbody;
    public Rigidbody2D player2Rigidbody;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player1Rigidbody.gravityScale = player1Rigidbody.gravityScale * -1;
            player2Rigidbody.gravityScale = player2Rigidbody.gravityScale * -1;
        }
	}
}
