using EterPharmaPro.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace EterPharmaPro.API
{
	public class ApiServices
	{
		private readonly WebSocketClient webSocketClient;

		public ApiServices(WebSocketClient webSocketClient)
		{
			this.webSocketClient = webSocketClient;

			webSocketClient.MessageReceived += WebSocketClient_MessageReceived;
		}

		private void WebSocketClient_MessageReceived(object sender, MessageWebSockerModel e)
		{
			//throw new NotImplementedException();
		}
		private void WebSocketClient_SendMessage(MessageWebSockerModel model)
		{
			if (webSocketClient.webSocketState == WebSocketState.Open)
			{
				webSocketClient.SendMessage(model);
			}
		}
	}
}
