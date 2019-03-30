﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour {

    float countTime;
    int   theta;
    int   p_theta   = 1;
    int   nextTime  = 1;
    int   r         = 1000;

    float[] val_sin = new float[361];
    float[] val_cos = new float[361];

    [SerializeField]
    GameObject camera;

    public int Theta
    {
        get { return this.theta; }
        private set { this.theta = value; }
    }

    void Start () {
        Vector3 pos = camera.transform.localPosition;
        pos.z = 1;
        camera.transform.localPosition = pos;

        int i;
        for (i = 0; i <= 360; i++)
        {
            val_sin[i] = Mathf.Sin(i * Mathf.PI / 180);
        }
        for (i = 0; i <= 360; i++)
        {
            val_cos[i] = Mathf.Cos(i * Mathf.PI / 180);
        }
    }

    void Update() {
        countTime += Time.deltaTime;
        // exec/0.1ms
        if (nextTime < countTime * 50) {

            // 円運動
            Vector3 pos = camera.transform.localPosition;
            theta = theta >= 360 ? 0 : theta + p_theta;
            pos.x = -r * (p_theta * (Mathf.PI / 180)) * val_sin[theta];
            pos.z = r  * (p_theta * (Mathf.PI / 180)) * val_cos[theta];
            camera.transform.localPosition = pos;

            // カメラ方向
            Quaternion newAngle = Quaternion.AngleAxis(-theta + 180, Vector3.up);
            camera.transform.localRotation = newAngle;

            nextTime++;
        }
    }
}
