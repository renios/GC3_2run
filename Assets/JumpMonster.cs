using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMonster : MonoBehaviour {

	bool isGround = false;
	private Rigidbody2D rigid;
	public float jumpSpeed;

	void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGround) return;

        else if(isGround)
        {
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
            if (rigid.gravityScale < 0) {
                jumpVelocity *= -1;
            }
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
	}
}
