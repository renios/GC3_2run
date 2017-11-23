﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleImage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (GetComponent<Image>().enabled)
				FindObjectOfType<AudioSource>().Play();
			GetComponent<Image>().enabled = false;
		}
	}
}
