using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour {

	public Sprite gameStart;
	public Sprite gameOver;

	public bool isOver;

	// Use this for initialization
	void Start () {
		isOver = false;
		PrintGameStartText();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void PrintGameStartText() {
		transform.localScale = new Vector3(1,1,1);
		GetComponent<Image>().sprite = gameStart;
		transform.DOScale(new Vector3(0,0,0), 1f);
	}

	public void PrintGameOverText() {
		if (isOver) return;

		isOver = true;

		GetComponent<Image>().sprite = gameOver;
		transform.DOScale(new Vector3(1.5f,1.5f,1), 1f);
	}
}
