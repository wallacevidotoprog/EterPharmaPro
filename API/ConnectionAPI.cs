using EterPharmaPro.Services;
using System;
using System.Net.Http;

namespace EterPharmaPro.API
{
	public class ConnectionAPI
	{
		public event EventHandler<string> serveMsg;

		public readonly WebSocketClient webSocketClient;
		public readonly HttpClient client;
		private readonly IniFile ini;
		public readonly string host;
		
		public ConnectionAPI()
		{
			client = new HttpClient();
			ini = new IniFile("config.ini");
			host = ini.Read("API", "HOST");

			_=webSocketClient = new WebSocketClient(ini.Read("API", "WEBSOCKET"));
		}



	}


}
