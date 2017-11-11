using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterAi : MonoBehaviour {

    public float mon_movePower = 1f;
    Vector3 movement;
    int movementFlag = 0; // 0 : stop / 1 : left / 2 : right
	// Use this for initialization
	void Start () {
        StartCoroutine("ChangeMovement");
	}

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);
        yield return new WaitForSeconds(3f);
        Debug.Log(movementFlag);
        StartCoroutine("ChangeMovement");

    }

    // Update is called once per frame
     void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * mon_movePower * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
}

