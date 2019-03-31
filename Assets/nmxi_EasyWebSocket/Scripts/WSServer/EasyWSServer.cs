using UnityEngine;
using UniRx;
using WebSocketSharp.Server;
using UnityEngine.Events;

namespace nmxi.websocket.server{
    [System.Serializable]
    public class BytesEvent : UnityEvent<byte[]>{
    }
    
    public class EasyWSServer : MonoBehaviour{
        
        [SerializeField, ReadOnly] private State _state;
        
        [Space(15), SerializeField] private int _usePort;    //use port
        
        [Space(15), SerializeField] private BytesEvent _receiveCallBack;
            
        private WebSocketServer wss;
        
        public string GetState(){
            return _state.ToString();
        }

        private enum State{
            Disconnect, Connecting
        }

        public int ServerPort{
            get{ return _usePort; }
            set{ _usePort = value; }
        }
            
        private void Awake(){
            CloseWSServer();
            
            ServerDataBuffer.Initialize();
    
            gameObject.ObserveEveryValueChanged(_ => ServerDataBuffer.IsConnect)
                .Subscribe(x => OnChangedWebSocketConnectionState(x));
            gameObject.ObserveEveryValueChanged(_ => ServerDataBuffer.ReceivedBytes)
                .Subscribe(x => OnReceiveBytes(x));
        }
            
        private void OnApplicationQuit(){
            CloseWSServer();
        }
    
        /// <summary>
        /// Start the WebSocket server
        /// </summary>
        public void StartWebSocketServer(){
            CloseWSServer();
            
            wss = new WebSocketServer(_usePort);
            wss.AddWebSocketService<uWebSocketServer>("/");
            wss.Start();
            
            Debug.Log("Start WebSocket server (WS Server)");
        }
    
        /// <summary>
        /// Close the WebSocket server
        /// </summary>
        public void CloseWebSocketServer(){
            if (wss != null){
                wss.Stop();
                
                Debug.Log("Stoped WebSocket sever (WS Server)");
            }
        }
    
        /// <summary>
        /// Broad cast message
        /// </summary>
        /// <param name="b">Byte data of message</param>
        public void BroadCastMessage(byte[] b){
            if (wss != null && _state == State.Connecting){
                wss.WebSocketServices["/"].Sessions.Broadcast(b);   
            }
            else{
                Debug.LogError("It is not connected (WS Server)");
            }
        }
    
        /// <summary>
        /// When connecting or not connecting websocket is switched
        /// WebSocketの状態が"接続","未接続"で切り替えられたら
        /// </summary>
        /// <param name="f">Is connecting</param>
        private void OnChangedWebSocketConnectionState(bool f){
            if (f){
                ///OnOpen
                _state = State.Connecting;
            }
            else{
                ///OnClose
                _state = State.Disconnect;
            }
        }
    
        /// <summary>
        /// Behavior at receiving data on websocket
        /// </summary>
        /// <param name="b">Received bytes</param>
        private void OnReceiveBytes(byte[] b){
            if (ServerDataBuffer.ReceivedBytes != null){
                _receiveCallBack.Invoke(b);
            }
        }

        private void CloseWSServer(){
            if (wss != null){
                wss.Stop();
                wss = null;
                _state = State.Disconnect;
            }
        }
    }
}