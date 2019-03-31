using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingCapybara : MonoBehaviour {

    public GameObject suika;
    CapybaraController cc;

	// Use this for initialization
	void Start () {
        cc = GameObject.FindObjectOfType<CapybaraController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!cc.looking)
            transform.RotateAround(suika.transform.position, Vector3.up, -5);

    }
}
