using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10f;
    public const float moveSpeed = 5.0f;
    public float jumpSpeed = 5f;
    private Rigidbody2D rigid;

    Vector3 movement;
    bool isGround = false;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            Jumpcontrol();
        }
    }

    private void FixedUpdate()
    {
        
        MoveControl();

    }

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

    void MoveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        this.gameObject.transform.Translate(distanceX, 0, 0);

    }

    void Jumpcontrol ()
    {
        if (!isGround) return;

        else if(isGround)
        {
            rigid.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
        

    }

}
