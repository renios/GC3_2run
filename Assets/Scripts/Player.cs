using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text hpText; 
    public int playerHealth = 5;
    bool immuned = false;

    public float speed = 10f;
    public const float moveSpeed = 5.0f;
    public float jumpSpeed = 5f;
    private Rigidbody2D rigid;

    Vector3 movement;
    bool isGround = false;

    // player1 controller
    KeyCode p1LeftButton = KeyCode.A;
    KeyCode p1RightButton = KeyCode.D;
    KeyCode p1JumpButton = KeyCode.W;
    KeyCode p1SkillButton = KeyCode.LeftShift;

    // player2 controller
    KeyCode p2LeftButton = KeyCode.LeftArrow;
    KeyCode p2RightButton = KeyCode.RightArrow;
    KeyCode p2JumpButton = KeyCode.UpArrow;
    KeyCode p2SkillButton = KeyCode.Space;

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
            distanceX = -1 * Time.deltaTime * moveSpeed;
        }
        if ((Input.GetKey(p1RightButton) && tag == "Player1") ||
            (Input.GetKey(p2RightButton) && tag == "Player2"))
        {
            distanceX = 1.8f * Time.deltaTime * moveSpeed;
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
            if (rigid.gravityScale < 0) {
                jumpVelocity *= -1;
            }
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "big_Monster") {
            Damaged(5);
        }

        if (immuned) {
            return;
        }

        if (other.gameObject.tag == "monster") {
            Damaged(1);
        }
    }

    void Damaged(int damage) {
        StartCoroutine(Immune());
        playerHealth -= damage;
        if (playerHealth < 0)
            playerHealth = 0;
        hpText.text = "x " + playerHealth;

        if ((playerHealth <= 0) && (!FindObjectOfType<TextManager>().isOver)) {
            FindObjectOfType<TextManager>().PrintGameOverText();
        }
    }

    IEnumerator Immune () {
        immuned = true;
        for (int i = 0; i < 4; i++) {
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.3f);
            yield return new WaitForSeconds(0.125f);
            GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            yield return new WaitForSeconds(0.125f);
        }
        immuned = false;
    }
}
