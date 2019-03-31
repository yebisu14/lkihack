using nmxi.websocket.server;
using UnityEngine;
using WebSocketSharp;
using UniRx;
using UnityEngine.Events;

namespace nmxi.websocket.client{
    
    [System.Serializable]
    public class BytesEvent : UnityEvent<byte[]>{
    }
    
    public class EasyWSClient : MonoBehaviour{
        
        [SerializeField, ReadOnly] private State _state;
        
        [Space(15), SerializeField] private string _serverAddress;    //server ip address
        [SerializeField] private int _serverPort;    //use port

        [Space(15), SerializeField] private BytesEvent _receiveCallBack;
        
        private WebSocket wsc;

        public string GetState(){
            return _state.ToString();
        }

        public string ServerAddress{
            get{ return _serverAddress; }
            set{ _serverAddress = value; }
        }

        public int ServerPort{
            get{ return _serverPort; }
            set{ _serverPort = value; }
        }
        
        private enum State{
            Disconnect, Connecting
        }

        private void Awake(){
            CloseWSClient();
            
            ClientDataBuffer.Initialize();
            
            gameObject.ObserveEveryValueChanged(_ => ClientDataBuffer.IsConnect)
                .Subscribe(x => OnChangedWebSocketConnectionState(x));
            gameObject.ObserveEveryValueChanged(_ => ClientDataBuffer.ReceivedBytes)
                .Subscribe(x => ReceiveBytes(x));
        }

        void OnApplicationQuit(){
            CloseWSClient();
        }
        
        /// <summary>
        /// Start the WebSocket client
        /// </summary>
        /// <param name="serverAddress">ipAddress</param>
        public void StartWebSocketClient(){           
            var ca = "ws://" + _serverAddress + ":" + _serverPort + "/";
            Debug.Log("Connect to " + ca + " (WS Client)");
        
            wsc = new WebSocket(ca);
        
            wsc.OnMessage += (object sender, MessageEventArgs e) => {
                ClientDataBuffer.ReceivedBytes = e.RawData;
            };

            wsc.OnError += (sender, e) => {
                Debug.LogError("WS Err msg : " + e.Message + " (WS Client)");
            };

            wsc.OnOpen += (sender, e) => {
                Debug.Log("Connected to webSocket server (WS Client)");
                ClientDataBuffer.IsConnect = true;
            };

            wsc.OnClose += (sender, e) => {
                Debug.Log("Disconnected to WebSocket server (WS Client)");
                ClientDataBuffer.IsConnect = false;
                CloseWSClient();
            };
            
            wsc.Connect();
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
        private void ReceiveBytes(byte[] b){
            if (ClientDataBuffer.ReceivedBytes != null){
                _receiveCallBack.Invoke(b);
            }
        }

        /// <summary>
        /// Send message for server
        /// </summary>
        /// <param name="b">Byte data of message</param>
        public void SendMessage(byte[] b){
            if (wsc != null && _state == State.Connecting){
                wsc.Send(b);
            }
            else{
                Debug.LogError("It is not connected (WS Client)");
            }
        }

        private void CloseWSClient(){
            if (wsc != null){
                wsc.Close();
                wsc = null;
                _state = State.Disconnect;
            }
        }
    }
}