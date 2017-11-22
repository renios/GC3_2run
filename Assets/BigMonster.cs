using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigMonster : MonoBehaviour {

	public float appearDelay = 3;

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(appearDelay);
		transform.DOLocalMoveX(-10f, 3f).SetEase(Ease.Linear);
	}
	
	// Update is called once per frame
	void Update () {
		 		
	}
}
