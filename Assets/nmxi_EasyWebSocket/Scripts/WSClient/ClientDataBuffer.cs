namespace nmxi.websocket.server{
	public static class ClientDataBuffer{
		public static byte[] ReceivedBytes;
		public static bool IsConnect;

		public static void Initialize(){
			ReceivedBytes = null;
			IsConnect = false;
		}
	}
}