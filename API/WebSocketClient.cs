using EterPharmaPro.API.Models;
using SuperSocket.ClientEngine;
using System;
using ToastNotification;
using WebSocket4Net;
using Newtonsoft.Json;
using EterPharmaPro.API.Enum;
using EterPharmaPro.Models.DbModels;
using System.Windows.Forms;
using FirebaseAdmin.Messaging;
using System.Threading;
using System.Threading.Tasks;
using EterPharmaPro.Utils.Extencions;

namespace EterPharmaPro.API
{
	public class WebSocketClient
	{
		public event EventHandler<MessageWebSockerModel> MessageReceived;
		public WebSocketState webSocketState;
		private bool isTryReconnect;
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

		private async Task TryReconnectAsync()
		{
			isTryReconnect = true;
			while (webSocket.State == WebSocketState.Closed || webSocket.State == WebSocketState.Connecting)
			{
				try
				{
					webSocket.Open();
					await Task.Delay(100000);

					if (webSocket.State == WebSocketState.Open)
					{
						SendAlertBox.SendT("Reconexão com WebSocket bem-sucedida.", ToastNotification.Enum.TypeAlertEnum.Success);
						isTryReconnect = false;
						break;
					}
				}
				catch (Exception ex)
				{
					ex.ErrorGet();
					//SendAlertBox.SendT($"Erro ao tentar reconectar: {ex.Message}", ToastNotification.Enum.TypeAlertEnum.Error);
				}
			}

		}
		public void InitClient(MessageWebSockerModel model) => SendMessage(model);

		public void SendMessage(MessageWebSockerModel message)
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

		private async void WebSocket_Closed(object sender, System.EventArgs e)
		{
			if (!isTryReconnect)
			{
				SendAlertBox.SendT("WebSocket desconectado.", ToastNotification.Enum.TypeAlertEnum.Info);
			}
			await TryReconnectAsync();
		}

		private void WebSocket_Error(object sender, ErrorEventArgs e)
		{
			if (!isTryReconnect)
			{

				SendAlertBox.SendT(e.Exception.Message, ToastNotification.Enum.TypeAlertEnum.Error);
			}
		}

		private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			MessageWebSockerModel resp = JsonConvert.DeserializeObject<MessageWebSockerModel>(e.Message);
			if (resp.type == TypesReciverWebSocketConst.Delivery)
			{
				SendAlertBox.SendT($"{resp.name}: {resp.message}", ToastNotification.Enum.TypeAlertEnum.Success);
			}
			MessageReceived?.Invoke(this, resp);
		}

		private void WebSocket_Opened(object sender, System.EventArgs e)
		{
			webSocketState = webSocket.State;
			SendAlertBox.SendT("WebSocket conectado.", ToastNotification.Enum.TypeAlertEnum.Success);

			
		}
	}
}
