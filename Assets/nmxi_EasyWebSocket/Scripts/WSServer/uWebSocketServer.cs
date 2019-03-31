using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace nmxi.websocket.server{
	public class uWebSocketServer : WebSocketBehavior {
    
		//StartConnection
		protected override void OnOpen(){
			Debug.Log("Client Connected (WS Server)");
			ServerDataBuffer.IsConnect = true;
		}

		//OnReciveMessage
		protected override void OnMessage(MessageEventArgs e){
			ServerDataBuffer.ReceivedBytes = e.RawData;
        }

		protected override void OnClose(CloseEventArgs e){
			Debug.Log("Client Disconnected (WS Server)");
			ServerDataBuffer.IsConnect = false;
		}
	}
}