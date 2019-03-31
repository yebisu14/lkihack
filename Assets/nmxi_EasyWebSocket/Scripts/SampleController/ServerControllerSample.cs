using nmxi.websocket.client;
using nmxi.websocket.server;
using UnityEngine;

namespace nmxi.websocket{
    [ExecuteInEditMode]
    public class ServerControllerSample : MonoBehaviour{

        [SerializeField] private string _sendText;

        public void StartServer(){
            if (GetComponent<EasyWSServer>()){
                GetComponent<EasyWSServer>().StartWebSocketServer();
            }
        }

        public void SendTest(){
            if (GetComponent<EasyWSServer>()){
                GetComponent<EasyWSServer>()
                    .BroadCastMessage(System.Text.Encoding.GetEncoding("Shift_JIS").GetBytes(_sendText));
            }
        }

        public void OutPutLogFromShiftJISBytes(byte[] b){
            Debug.Log(System.Text.Encoding.GetEncoding("Shift_JIS").GetString(b));
        }
    }
}