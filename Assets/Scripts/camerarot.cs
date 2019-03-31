using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerarot : MonoBehaviour {

	// Use this for initialization

	public float rot = 0.2f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, rot, 0f));
	}
}
