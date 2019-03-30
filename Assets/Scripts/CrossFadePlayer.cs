using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFadePlayer : MonoBehaviour {

    float countTime;
    RotationCamera rotationCamera;

    [SerializeField]
    private AudioSource[] _audios;


    void Start ()
    {
        _audios[0].volume = 0f;
        _audios[1].volume = 0f;
        _audios[2].volume = 0f;
        _audios[3].volume = 0f;

        _audios[0].Play();
        _audios[1].Play();
        _audios[2].Play();
        _audios[3].Play();

        rotationCamera = GetComponent<RotationCamera>();
    }
	
	void Update ()
    {
        float theta = rotationCamera.Theta;
        if (theta <= 2)
        {
            _audios[0].volume = 1f - (8 + theta)/10f;
            _audios[1].volume = (8 + theta) / 10f;
        }
        else if (352 < theta)
        {
            _audios[0].volume = (358 - theta) / 10f;
            _audios[1].volume = 1f - (358 - theta) / 10f;
        }
        else if (262 < theta && theta < 273)
        {
            _audios[3].volume = (272 - theta) / 10f;
            _audios[0].volume = 1f - (272 - theta) / 10f;
        }
        else if (172 < theta && theta < 183)
        {
            _audios[2].volume = (182 - theta) / 10f;
            _audios[3].volume = 1f - (182 - theta) / 10f;
        }
        else if (82 < theta && theta < 93)
        {
            Debug.Log(_audios[2].volume);
            _audios[1].volume = (92 - theta) / 10f;
            _audios[2].volume = 1f - (92 - theta) / 10f;
        }
    }
}
