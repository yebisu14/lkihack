using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapybaraController : MonoBehaviour {

    Animator ani;
    HeadLookController hlc;
    GameObject initLookTarget;
    public GameObject leftHand;
    public GameObject rightHand;
    bool targetFlag = false;

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        hlc = GetComponent<HeadLookController>();
        //initLookTarget = this.gameObject.transform.Find("Root/Pelvis/Spine.1/Spine.2/Neck.1/Neck.2/Head").gameObject;
        //initLookTargetPosition = initLookTarget.transform.position + this.gameObject.transform.forward;7
        GameObject head = this.gameObject.transform.Find("Root/Pelvis/Spine.1/Spine.2/Neck.1/Neck.2/Head").gameObject;
        initLookTarget = new GameObject("Empty Game Object");
        initLookTarget.transform.position = head.transform.position + head.transform.up;
        initLookTarget.transform.parent = head.transform;
        hlc.target_obj = initLookTarget;
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            if(!ani.GetBool("attack"))
                ani.SetBool("attack", true);

        }else
        {
            ani.SetBool("attack", false);
        }*/
        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            if (ani.GetBool("look"))
                hlc.target_obj = initLookTarget;
            else
                hlc.target_obj = lookTarget;
            ani.SetBool("look", !ani.GetBool("look"));
        }*/
        if (leftHand.activeSelf)
        {
            hlc.target_obj = leftHand;
            //hlc.target_position = leftHand.transform.position;
            ani.SetBool("look", true);
        }
        else if (rightHand.activeSelf)
        {
            hlc.target_obj = rightHand;
            //hlc.target_position = rightHand.transform.position;
            ani.SetBool("look", true);
        }
        else
        {
            hlc.target_obj = initLookTarget;
            //hlc.target_position = initLookTargetPosition;
            ani.SetBool("look", false);
        }
    }
}
