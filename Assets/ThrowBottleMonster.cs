using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBottleMonster : MonoBehaviour {

	public GameObject bottle;

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			GameObject newBottle = Instantiate(bottle, transform.position, Quaternion.identity) as GameObject;
			newBottle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			Vector2 velocity = Vector2.left * Random.Range(1f, 10f);
			newBottle.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Impulse);
			yield return new WaitForSeconds(0.5f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
