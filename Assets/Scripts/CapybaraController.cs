using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class CapybaraController : MonoBehaviour {

    public GameObject[] capybaras;

    /*Animator ani;
    HeadLookController hlc;
    GameObject initLookTarget;*/
    public GameObject leftHand;
    public GameObject leftHandTarget;
    public GameObject rightHand;
    public GameObject rightHandTarget;

    LeapServiceProvider m_Provider;

    // Use this for initialization
    void Start () {
        foreach(GameObject capybara in capybaras)
        {
            /*ani = capybara.GetComponent<Animator>();
            hlc = capybara.GetComponent<HeadLookController>();
            hlc.target_obj = initLookTarget;*/
            
            //GameObject head = this.gameObject.transform.Find("Root/Pelvis/Spine.1/Spine.2/Neck.1/Neck.2/Head").gameObject;
            GameObject head = capybara.transform.Find("Root/Pelvis/Spine.1/Spine.2/Neck.1/Neck.2/Head").gameObject;
            GameObject initLookTarget = new GameObject("InitLookTarget");
            initLookTarget.transform.position = head.transform.position + head.transform.up;
            initLookTarget.transform.parent = head.transform;
            capybara.GetComponent<HeadLookController>().target_obj = initLookTarget;
            //hlc.target_position = initLookTarget.transform.position;
        }

        m_Provider = GameObject.Find("LeapHandController").GetComponent<LeapServiceProvider>();
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
            Frame frame = m_Provider.CurrentFrame;

            // 左手を取得する
            Hand hands = null;
            foreach (Hand hand in frame.Hands)
            {
                if (hand.IsLeft)
                {
                    hands = hand;
                    break;
                }
            }

            if (hands == null)
            {
                return;
            }

            leftHandTarget.transform.position = new Vector3(hands.PalmPosition.x, hands.PalmPosition.y, hands.PalmPosition.z);

            foreach (GameObject capybara in capybaras)
            {
                /*hlc.target_obj = leftHandTarget;
                //hlc.target_position = new Vector3(hands.PalmPosition.x, hands.PalmPosition.y, hands.PalmPosition.z);
                ani.SetBool("look", true);*/
                capybara.GetComponent<HeadLookController>().target_obj = leftHandTarget;
                capybara.GetComponent<Animator>().SetBool("look", true);
            }
                

        }
        else if (rightHand.activeSelf)
        {
            Frame frame = m_Provider.CurrentFrame;

            // 右手を取得する
            Hand hands = null;
            foreach (Hand hand in frame.Hands)
            {
                if (hand.IsRight)
                {
                    hands = hand;
                    break;
                }
            }

            if (hands == null)
            {
                return;
            }

            
            rightHandTarget.transform.position = new Vector3(hands.PalmPosition.x, hands.PalmPosition.y, hands.PalmPosition.z);

            foreach (GameObject capybara in capybaras)
            {
                /*//hlc.target_position = new Vector3(hands.PalmPosition.x, hands.PalmPosition.y, hands.PalmPosition.z);
                hlc.target_obj = rightHandTarget;
                ani.SetBool("look", true);*/
                capybara.GetComponent<HeadLookController>().target_obj = rightHandTarget;
                capybara.GetComponent<Animator>().SetBool("look", true);
            }

        }
        else
        {
            foreach (GameObject capybara in capybaras)
            {
                /*hlc.target_obj = initLookTarget;
                //hlc.target_position = initLookTarget.transform.position;
                ani.SetBool("look", false);*/
                capybara.GetComponent<HeadLookController>().target_obj = capybara.transform.Find("Root/Pelvis/Spine.1/Spine.2/Neck.1/Neck.2/Head/InitLookTarget").gameObject;
                capybara.GetComponent<Animator>().SetBool("look", false);
            }

        }
    }
}
