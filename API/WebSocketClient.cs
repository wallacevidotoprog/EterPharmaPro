using EterPharmaPro.API.Models;
using SuperSocket.ClientEngine;
using System;
using ToastNotification;
using WebSocket4Net;
using Newtonsoft.Json;
using EterPharmaPro.API.Enum;
using EterPharmaPro.Models.DbModels;

namespace EterPharmaPro.API
{
	public class WebSocketClient
	{
		public event EventHandler<MessageWebSockerModel> MessageReceived;

		private readonly WebSocket webSocket;

		public WebSocketClient(string url)
		{
			webSocket = new WebSocket(url);

			webSocket.Opened += WebSocket_Opened;

			webSocket.MessageReceived += WebSocket_MessageReceived;

			webSocket.DataReceived += WebSocket_DataReceived;

			webSocket.Error += WebSocket_Error;

			webSocket.Closed += WebSocket_Closed;


			webSocket.Open();

		}

		public void InitClient(MessageWebSockerModel model) => EnviarMensagem(model);

		public void EnviarMensagem(MessageWebSockerModel message)
		{
			if (webSocket.State == WebSocketState.Open)
			{
				webSocket.Send(JsonConvert.SerializeObject(message));
			}
			else
			{
				SendAlertBox.SendT("WebSocket não está aberto.", ToastNotification.Enum.TypeAlertEnum.Warning);
			}
		}
		private void WebSocket_DataReceived(object sender, DataReceivedEventArgs e)
		{
			SendAlertBox.SendT(e.Data.ToString(), ToastNotification.Enum.TypeAlertEnum.Success);
		}

		private void WebSocket_Closed(object sender, System.EventArgs e)
		{
			SendAlertBox.SendT("WebSocket desconectado.", ToastNotification.Enum.TypeAlertEnum.Info);
		}

		private void WebSocket_Error(object sender, ErrorEventArgs e)
		{
			SendAlertBox.SendT(e.Exception.Message, ToastNotification.Enum.TypeAlertEnum.Error);
		}

		private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			MessageWebSockerModel resp = JsonConvert.DeserializeObject<MessageWebSockerModel>(e.Message);
			if (resp.type == TypesReciverWebSocketEnum.Message)
			{
				SendAlertBox.SendT($"{resp.name}: {resp.message}", ToastNotification.Enum.TypeAlertEnum.Success);
			}
			MessageReceived?.Invoke(this, resp);
		}

		private void WebSocket_Opened(object sender, System.EventArgs e)
		{
			SendAlertBox.SendT("WebSocket conectado.", ToastNotification.Enum.TypeAlertEnum.Success);

			InitClient(new MessageWebSockerModel
			{
				type = TypesReciverWebSocketEnum.Register,
				user = new UserModel
				{
					ID = 1515,
					ID_LOJA = 1515,
					NOME = "LOJA 15",
					STATUS = true
				}
			});
		}
	}
}
