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

    // player1 controller
    public KeyCode p1LeftButton;
    public KeyCode p1RightButton;
    public KeyCode p1JumpButton;
    public KeyCode p1SkillButton;

    // player2 controller
    public KeyCode p2LeftButton;
    public KeyCode p2RightButton;
    public KeyCode p2JumpButton;
    public KeyCode p2SkillButton;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(p1JumpButton) && tag == "Player1") ||
            (Input.GetKeyDown(p2JumpButton) && tag == "Player2"))
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
        // float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float distanceX = 0;

        if ((Input.GetKey(p1LeftButton) && tag == "Player1") ||
            (Input.GetKey(p2LeftButton) && tag == "Player2"))
        {
            distanceX = -1 * Time.deltaTime * moveSpeed;;
        }
        if ((Input.GetKey(p1RightButton) && tag == "Player1") ||
            (Input.GetKey(p2RightButton) && tag == "Player2"))
        {
            distanceX = Time.deltaTime * moveSpeed;;
        } 

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
