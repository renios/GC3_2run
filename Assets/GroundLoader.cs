using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLoader : MonoBehaviour {

	public Transform player1;
	public Transform player2;

	public List<GameObject> Grounds;

	int playerSector = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Max(player1.position.x, player2.position.x) > playerSector * 20 - 5) {
			playerSector += 1;

			int groundIndex;
			if (Random.Range(0, 4) == 0) {
				groundIndex = 1;
			}
			else {
				groundIndex = Random.Range(2, Grounds.Count);
			}

			Instantiate(Grounds[groundIndex], Vector3.right * playerSector * 20, Quaternion.identity);
		}
	}
}
