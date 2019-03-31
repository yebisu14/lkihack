using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nmxi.websocket.server{
	public static class ServerDataBuffer{
		public static byte[] ReceivedBytes;
		public static bool IsConnect;

		public static void Initialize(){
			ReceivedBytes = null;
			IsConnect = false;
		}
	}
}