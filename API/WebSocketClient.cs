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

namespace EterPharmaPro.API
{
	public class WebSocketClient
	{
		public event EventHandler<MessageWebSockerModel> MessageReceived;
		public WebSocketState webSocketState;

		private readonly WebSocket webSocket;
		private System.Windows.Forms.Timer time_reload;
		public WebSocketClient(string url)
		{
			webSocket = new WebSocket(url);

			webSocket.Opened += WebSocket_Opened;

			webSocket.MessageReceived += WebSocket_MessageReceived;

			webSocket.DataReceived += WebSocket_DataReceived;

			webSocket.Error += WebSocket_Error;

			webSocket.Closed += WebSocket_Closed;

			
			webSocket.Open();

			time_reload = new System.Windows.Forms.Timer();
			time_reload.Interval = 1;
			time_reload.Tick += Time_reload_Tick;
		}

		private void Time_reload_Tick(object sender, EventArgs e)
		{
			Thread.Sleep(1000);
			webSocket.Open();

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

		private void WebSocket_Closed(object sender, System.EventArgs e)
		{
			SendAlertBox.SendT("WebSocket desconectado.", ToastNotification.Enum.TypeAlertEnum.Info);
			time_reload.Start();
		}

		private void WebSocket_Error(object sender, ErrorEventArgs e)
		{
			SendAlertBox.SendT(e.Exception.Message, ToastNotification.Enum.TypeAlertEnum.Error);
		}

		private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			MessageWebSockerModel resp = JsonConvert.DeserializeObject<MessageWebSockerModel>(e.Message);
			if (resp.type == TypesReciverWebSocketEnum.NewDelivery || resp.type == TypesReciverWebSocketEnum.FinishDelivery)
			{
				SendAlertBox.SendT($"{resp.name}: {resp.message}", ToastNotification.Enum.TypeAlertEnum.Success);
			}
			MessageReceived?.Invoke(this, resp);
		}

		private void WebSocket_Opened(object sender, System.EventArgs e)
		{
			webSocketState = webSocket.State;
			time_reload.Stop();
			SendAlertBox.SendT("WebSocket conectado.", ToastNotification.Enum.TypeAlertEnum.Success);

			InitClient(new MessageWebSockerModel
			{
				type = TypesReciverWebSocketEnum.Register,
				user = new UserModel
				{
					ID = 1515,
					ID_LOJA = 1515,
					NOME = "LOJA 15 - PDV",
					STATUS = true
				}
			});
		}
	}
}
