using System;
using System.Collections.Generic;
using UnityEngine;
using nmxi.websocket.server;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace nmxi.websocket
{
    public class LeapWebsocketController : MonoBehaviour
    {
        void Start()
        {
            if (GetComponent<EasyWSServer>())
            {
                GetComponent<EasyWSServer>().StartWebSocketServer();
            }
        }

        void Update()
        {

        }

        public void OnReceiveBytes(byte[] b)
        {
            string command = System.Text.Encoding.GetEncoding("UTF-8").GetString(b);
            if (command == "spring")
            {
                SceneManager.LoadScene("Spring");
            }
            else if (command == "summer")
            {
                SceneManager.LoadScene("Summer");
            }
            else if (command == "autumn")
            {
                SceneManager.LoadScene("Fall");
            }
            else if (command == "winter")
            {
                SceneManager.LoadScene("Winter");
            }
            else if (command == "nextscene")
            {
                SceneManager.LoadScene("mainScene2");
            }
        }
    }
}
