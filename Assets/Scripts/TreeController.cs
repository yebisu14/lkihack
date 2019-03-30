using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public GameObject[] trees;

    int season = 0;


	// Use this for initialization
	void Start () {
        for(int i = 1; i < trees.Length; i++)
        {
            trees[i].SetActive(false);
        }
        StartCoroutine(Season());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Season()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            season++;
            if (season >= trees.Length)
                season = 0;
            for (int i = 0; i < trees.Length; i++)
            {
                if (i == season)
                    trees[i].SetActive(true);
                else
                    trees[i].SetActive(false);
            }
        }

    }
}
