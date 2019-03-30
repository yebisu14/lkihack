using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCode : MonoBehaviour {

    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update () {
        int MoveRandomInt = Mathf.FloorToInt(Random.Range(0,7));
        animator.SetInteger("Random",MoveRandomInt);
		int MoveRandomInt2 = Mathf.FloorToInt(Random.Range(0,2));
        animator.SetInteger("Random2",MoveRandomInt2);
		int MoveRandomInt3 = Mathf.FloorToInt(Random.Range(0,3));
        animator.SetInteger("Random3",MoveRandomInt3);
    }
}
