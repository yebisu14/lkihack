using nmxi.websocket.client;
using nmxi.websocket.server;
using UnityEngine;

namespace nmxi.websocket{
    [ExecuteInEditMode]
    public class ClientControllerSample : MonoBehaviour{

        [SerializeField] private string _sendText;

        public void ConnectToServer(){
            if(GetComponent<EasyWSClient>()){
                GetComponent<EasyWSClient>().StartWebSocketClient();   
            }
        }

        public void SendTest(){
            if(GetComponent<EasyWSClient>()){
                GetComponent<EasyWSClient>()
                    .SendMessage(System.Text.Encoding.GetEncoding("Shift_JIS").GetBytes(_sendText));   
            }
        }

        public void OutPutLogFromShiftJISBytes(byte[] b){
            Debug.Log(System.Text.Encoding.GetEncoding("Shift_JIS").GetString(b));
        }
    }
}