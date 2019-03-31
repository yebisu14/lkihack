using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nmxi.websocket.server;
using UnityEngine.Events;


namespace nmxi.websocket
{
    public class WebsocketController : MonoBehaviour
    {
        [SerializeField]
        GameObject camera;
        static RotationCamera rotationCamera;

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
                rotationCamera.Theta = 135;
                rotationCamera.StopRotate();
            }else if(command == "summer")
            {
                rotationCamera.Theta = 225;
                rotationCamera.StopRotate();
            }else if(command == "autumn")
            {
                rotationCamera.Theta = 315;
                rotationCamera.StopRotate();
            }else if(command == "winter")
            {
                rotationCamera.Theta = 45;
                rotationCamera.StopRotate();
            }else if(command == "togglemove")
            {
                rotationCamera.ToggleRotate();
            }else if(command == "nextscene")
            {
                // TODO:next scene
            }else{

            }
            //Debug.Log(command);
        }
    }
}
