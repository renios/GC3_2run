using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public int player1Health = 5;
    public Text hptext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hptext.text = "x " + player1Health;
        
	}

     void OnCollisionEnter2D(Collision2D other)
    {
<<<<<<< HEAD
        if (other.gameObject.tag == "monster")
            player1Health = player1Health--;
        if (other.gameObject.tag == "big_Monster")
            player1Health = 0;
        if (other.gameObject.tag == "Heart")
            player1Health = player1Health++;
=======
        if (other.gameObject.tag == "monster") player1Health = player1Health - 1;
        if (other.gameObject.tag == "big_Monster") player1Health = 0;
        if (other.gameObject.tag == "spikes") player1Health = player1Health - 1;
>>>>>>> cb64176298005b50d24b4fb3f7dcc8a79e8ea7a9
    }
}
