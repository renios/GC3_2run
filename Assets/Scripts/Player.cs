using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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

        if (Input.GetKeyDown(p1SkillButton) && tag == "Player1")
        {
            Player1Skill();
        } 
        if (Input.GetKeyDown(p2SkillButton) && tag == "Player2" && !isPlayer2SkillActive)
        {
            StartCoroutine(Player2Skill());
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Coin") {
            FindObjectOfType<ScoreManager>().AddScore(10);
            Destroy(other.gameObject);
        }

        if (immuned) {
            return;
        }

        if (other.tag == "monster") {
            Damaged(1);
            Destroy(other.gameObject);
        }
    }

    void Player1Skill() {
        List<Player> players = FindObjectsOfType<Player>().ToList();  
        foreach (var player in players) {
            player.GetComponent<Rigidbody2D>().gravityScale *= -1;
            player.transform.rotation *= Quaternion.Euler(180,0,0);
        }
    }

    bool isPlayer2SkillActive = false;

    IEnumerator Player2Skill() {
        isPlayer2SkillActive = true;

        List<GameObject> monsters = GameObject.FindGameObjectsWithTag("monster").ToList();  
        foreach (var monster in monsters) {
            if (monster.GetComponent<Rigidbody2D>() != null) {
               monster.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
               monster.GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }

        List<GameObject> gears = GameObject.FindGameObjectsWithTag("Gear").ToList();
        foreach (var gear in gears) {
            gear.GetComponent<Gear>().speed = 0;
            gear.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        yield return new WaitForSeconds(3);

        foreach (var monster in monsters) {
            if (monster == null) continue;
            if (monster.GetComponent<Rigidbody2D>() != null) {
                monster.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                monster.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        foreach (var gear in gears) {
            gear.GetComponent<Gear>().speed = gear.GetComponent<Gear>().originspeed;
            gear.GetComponent<SpriteRenderer>().color = Color.white;
        }

        yield return new WaitForSeconds(1);

        isPlayer2SkillActive = false;
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
            distanceX = 1.5f * Time.deltaTime * moveSpeed;
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
        if (other.gameObject.tag == "spikes")
        {
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
