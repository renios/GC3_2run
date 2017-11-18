using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour
{
    public int player2Health = 5;
    public Text hptext02;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hptext02.text = "x " + player2Health;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "monster") player2Health = player2Health - 1;
        if (other.gameObject.tag == "big_Monster") player2Health = 0;
        if (other.gameObject.tag == "spikes") player2Health = player2Health - 1;
    }
}
