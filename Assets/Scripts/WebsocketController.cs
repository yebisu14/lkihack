using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nmxi.websocket.server;
using UnityEngine.Events;


namespace nmxi.websocket
{
    public class WebsocketController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            if (GetComponent<EasyWSServer>())
            {
                GetComponent<EasyWSServer>().StartWebSocketServer();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnReceiveBytes(byte[] b)
        {
            Debug.Log(System.Text.Encoding.GetEncoding("UTF-8").GetString(b));
        }
    }
}
