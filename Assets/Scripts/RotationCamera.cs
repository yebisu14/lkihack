using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour {

    float countTime;
    float theta;
    float p_theta   = 1f;
    float nextTime  = 1;
    float r         = 1000;
    bool  move = true;

    float[] val_sin = new float[361];
    float[] val_cos = new float[361];

    [SerializeField]
    GameObject camera;

    public float Theta
    {
        get { return this.theta; }
        set { this.theta = value; }
    }
    public bool Move
    {
        get { return this.move; }
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

    void Update()
    {
        if (move)
        {
            countTime = Time.deltaTime * 4.0f;
            theta = theta >= 360 ? 0 : theta + countTime;
        }
        // exec/0.1ms
        //if (nextTime < countTime * 2) {

        // 円運動
        Vector3 pos = camera.transform.localPosition;
        pos.x = -r * (p_theta * (Mathf.PI / 180)) * Mathf.Sin(theta * Mathf.PI / 180);
        pos.z = r * (p_theta * (Mathf.PI / 180)) * Mathf.Cos(theta * Mathf.PI / 180);
        camera.transform.localPosition = pos;

        // カメラ方向
        Quaternion newAngle = Quaternion.AngleAxis(-theta + 180, Vector3.up);
        camera.transform.localRotation = newAngle;

        nextTime++;
        //}
    }

    public void ToggleRotate()
    {
        move = !move;
    }

    public void StopRotate()
    {
        move = false;
    }
}
