using EterPharmaPro.API.Models;
using EterPharmaPro.Models.API;
using EterPharmaPro.Models.FirebaseModel;
using EterPharmaPro.Utils.Extencions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EterPharmaPro.API
{
	public class ActionAPI
	{
		private readonly ConnectionAPI connection;
		public bool isConnected { get; private set; }
		public bool isConnectedAPI { get; private set; }
		public bool isConnectedDb { get; private set; }

		public ActionAPI()
		{
			connection = new ConnectionAPI();

			_=TestConnectionAsync();
		}

		private async Task TestConnectionAsync()
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
			isConnected = isConnectedAPI = isConnectedDb;
		}

		public async Task<List<EntregaFbModel>> GETALL()
		{
			try
			{
				HttpResponseMessage response = await connection.client.GetAsync(connection.host + "delivery");
				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();

					var temp = JsonConvert.DeserializeObject<Dictionary<string, EntregaFbModel>>(responseData);
                    foreach (var item in temp)
                    {
						item.Value.FIREBASE_ID = item.Key;

					}
					return temp.Values.ToList();
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<string> INSERT<T>(T model)
		{
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await connection.client.PostAsync(connection.host + "delivery", content);
				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadAsStringAsync();
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<bool> UPDATE<T>(T model)
		{
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await connection.client.PostAsync(connection.host + "delivery", content);
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

		public async Task<bool> DELETE<T>(T model)
		{
			try
			{
				var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
				HttpResponseMessage response = await connection.client.PostAsync(connection.host + "delivery", content);
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
