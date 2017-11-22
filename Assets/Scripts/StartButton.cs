using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(ChangeSize());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Stage");
    }

	IEnumerator ChangeSize() {
		Tween tween;
		Vector3 scale = GetComponent<RectTransform>().localScale;
		while (true) {
			tween = GetComponent<RectTransform>().DOScale(scale * 1.1f, 1f);
			yield return tween.WaitForCompletion();
			tween = GetComponent<RectTransform>().DOScale(scale * 0.9f, 1f);
			yield return tween.WaitForCompletion();
		}
	}
}
