using EterPharmaPro.API.Models;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Models.API;
using EterPharmaPro.Utils.Extencions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToastNotification.Enum;
using ToastNotification;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Interfaces;

namespace EterPharmaPro.API
{
	public class ActionAPI
	{
		private readonly ConnectionAPI connection;
		public readonly ApiServices apiService;
		public bool isConnected { get; private set; }
		private bool isConnectedAPI { get;  set; }
		private bool isConnectedDb { get;  set; }

		public ActionAPI(IEterDb eterDb)
		{
			connection = new ConnectionAPI();
			apiService = new ApiServices(connection.webSocketClient, eterDb);


		}
		
		public static async Task<ActionAPI> CreateAsync(IEterDb eterDb)
		{
			var instance = new ActionAPI(eterDb);
			await instance.ConnectionAsync();
			return instance;
		}
		private async Task ConnectionAsync()
		{
			try
			{
				HttpResponseMessage response = await connection.client.GetAsync(connection.host + "connected");
				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();

					var temp = JsonConvert.DeserializeObject<ResponseConnectedModel>(responseData);
					isConnectedAPI = temp.API;
					isConnectedDb = temp.DB;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				isConnectedAPI = false;
				isConnectedDb = false;
			}
			isConnected = isConnectedAPI && isConnectedDb;
		}
		private async void TesteConnect()
		{
			if (!isConnected)
			{
				await ConnectionAsync();
				throw new InvalidOperationException($"*Entente novamente* Não esta conectado corretamente. (isConnectedAPI:{isConnectedAPI} - isConnectedDb:{isConnectedDb})");
			}
			
		}
		public async Task<List<EntregaApiModel>> GETALL(object table)
		{
			try
			{
				TesteConnect();
				HttpResponseMessage response = await connection.client.GetAsync(connection.host + table.ToString().ToLower());
				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();

					var temp = JsonConvert.DeserializeObject<ResponseModel<Dictionary<string, EntregaApiModel>>>(responseData);
					foreach (var item in temp.data)
					{
						item.Value.FIREBASE_ID = item.Key;

					}
					return temp.data.Values.ToList();
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<T> GET<T>(object id, object table)
		{
			try
			{
				TesteConnect();
				HttpResponseMessage response = await connection.client.GetAsync(connection.host +table.ToString().ToLower()+ "/" + id);
				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();
					var temp = JsonConvert.DeserializeObject<ResponseModel<T>>(responseData);
					return temp.data;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return default;
		}

		public async Task<string> INSERT<T>(T model, object table)
		{
			try
			{
				TesteConnect();
				string teste = connection.host + table.ToString().ToLower();
				StringContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await connection.client.PostAsync(connection.host + table.ToString().ToLower(), content);

				if (response.IsSuccessStatusCode)
				{
					var resp = JsonConvert.DeserializeObject<ResponseModel<object>>(await response.Content.ReadAsStringAsync());
					return resp.actionResult ? (string)resp.data : null;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<bool> UPDATE(object id, object table)
		{
			try
			{
				TesteConnect();
				HttpResponseMessage response = await connection.client.DeleteAsync(connection.host + table.ToString().ToLower() + "/" + id);
				if (response.IsSuccessStatusCode)
				{
					await response.Content.ReadAsStringAsync();
					return true;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<bool> DELETE(object id, object table)
		{
			try
			{
				TesteConnect();

				HttpResponseMessage response = await connection.client.DeleteAsync(connection.host + table.ToString().ToLower() + "/" + id);
				if (response.IsSuccessStatusCode)
				{
					await response.Content.ReadAsStringAsync();
					return true;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return false;
		}
	}
}
