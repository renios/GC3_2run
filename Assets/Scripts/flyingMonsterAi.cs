using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingMonsterAi : MonoBehaviour {

    public float mon_movePower = 1f;
    Vector3 movement;
    int movementFlag = 0; // 0 : stop / 1 : left / 2 : right
                          // Use this for initialization
    
	void Start () {
       
	}
    void Update()
    {
        if (FindObjectOfType<TimeManager>().timeSkillCheck == 1)
        {
            movementFlag = 0;
        }
        else if (FindObjectOfType<TimeManager>().timeSkillCheck == 0)
        {
            movementFlag = Random.Range(1, 3);

        }
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
            moveVelocity = Vector3.up;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.down;
            //transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += moveVelocity * mon_movePower * Time.deltaTime;
        //Debug.Log(movementFlag);
    }
    void OnTriggerEnter(Collider other)
    {
        
    }
}

