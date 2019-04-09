using System;
using System.Collections.Generic;
using UnityEngine;
using nmxi.websocket.server;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace nmxi.websocket
{
    public class WebsocketController : MonoBehaviour
    {
        [SerializeField]
        GameObject camera;
        [SerializeField]
        string SceneName;

        static RotationCamera rotationCamera;

        Int32 gyroAlpha;

        void Start()
        {
            if (GetComponent<EasyWSServer>())
            {
                GetComponent<EasyWSServer>().StartWebSocketServer();
            }
            
            rotationCamera = camera.GetComponent<RotationCamera>();
        }

        void Update()
        {

        }

        public void OnReceiveBytes(byte[] b)
        {
            string command = System.Text.Encoding.GetEncoding("UTF-8").GetString(b);
            if(command == "spring")
            {
                Debug.Log(command);
                rotationCamera.Theta = (float)RotationCamera.Season.SPRING;
                rotationCamera.StopRotate();
                gyroAlpha = -1;
            }else if(command == "summer")
            {
                rotationCamera.Theta = (float)RotationCamera.Season.SUMMER;
                rotationCamera.StopRotate();
                gyroAlpha = -1;
            }else if(command == "autumn")
            {
                rotationCamera.Theta = (float)RotationCamera.Season.AUTUMN;
                rotationCamera.StopRotate();
                gyroAlpha = -1;
            }else if(command == "winter")
            {
                rotationCamera.Theta = (float)RotationCamera.Season.WINTER;
                rotationCamera.StopRotate();
                gyroAlpha = -1;
            }else if(command == "togglemove")
            {
                rotationCamera.ToggleRotate();
            }else if(command == "nextscene")
            {
                SceneManager.LoadScene(SceneName);
            }else{
                if (rotationCamera.Move)
                {
                    return;
                }
                if (gyroAlpha < 0)
                {
                    try
                    {
                        gyroAlpha = (int)float.Parse(command);
                    }
                    catch (FormatException) { }
                    return;
                }else{
                    try
                    {
                        Int32 currentAlpha;
                        currentAlpha = (int)float.Parse(command);

                        int newTheta = (int)rotationCamera.Theta + (gyroAlpha - currentAlpha);
                        gyroAlpha = currentAlpha;
                        rotationCamera.Theta = newTheta;

                    }
                    catch (FormatException) { }
                }
            }
        }
    }
}
