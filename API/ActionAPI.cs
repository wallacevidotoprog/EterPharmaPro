using EterPharmaPro.Models.FirebaseModel;
using EterPharmaPro.Utils.Extencions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EterPharmaPro.API
{
	public class ActionAPI
	{
		private readonly ConnectionAPI connection;

		public ActionAPI()
		{
			connection = new ConnectionAPI();
		}


		public async Task<object> GETALL()
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
                    return temp.Values;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<string> SEND<T>(T model)
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
	}
}
