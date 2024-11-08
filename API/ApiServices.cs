using EterPharmaPro.API.Enum;
using EterPharmaPro.API.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils;
using System;
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

		public void AccessUser(UserModel userModelAcess)
		{
			webSocketClient.InitClient(new MessageWebSockerModel
			{
				type = TypesReciverWebSocketEnum.Register,
				user = userModelAcess
			});
		}

		private void WebSocketClient_MessageReceived(object sender, MessageWebSockerModel e)
		{
			EventGlobal.Publish(e);
		}
		
	}
}
