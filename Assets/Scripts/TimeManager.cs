using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public int timeSkillCheck = 0; // 0 : 움직임, 1 : 멈춤
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeSkillCheck == 0) {
                timeSkillCheck = 1;
            }
            else if (timeSkillCheck == 1)
            {
                timeSkillCheck = 0;
            }
            Debug.Log(timeSkillCheck);
        }
      
        
	}
}
