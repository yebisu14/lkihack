﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Quit() {
  #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
  #elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
  #endif
}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetKey(KeyCode.Escape)) Quit();

		
	}
}
