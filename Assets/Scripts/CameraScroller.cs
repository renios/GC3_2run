using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScroller : MonoBehaviour {
	
	public float scrollSpeed;
	float distanceCoef = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * scrollSpeed * Time.deltaTime * (1 + distanceCoef);

		distanceCoef = (Camera.main.transform.position.x / 100) / 10f;

		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("Title");
		}
	}
}
