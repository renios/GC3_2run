using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed = 10f;
    public const float moveSpeed = 5.0f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;

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
        Jumpcontrol();
        MoveControl();

    }

    void MoveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        this.gameObject.transform.Translate(distanceX, 0, 0);

    }

    void Jumpcontrol()
    {
        if (!isJumping) return;


        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    

}
