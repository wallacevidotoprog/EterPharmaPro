
using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.Utils.Extencions;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseFireBase
{
	public class FirebaseDb
	{
		private readonly FirebaseClient firebaseClient;
		public FirebaseDb()
        {
			firebaseClient = new FirebaseClient("https://eterpharma-default-rtdb.firebaseio.com/");

		}

		protected string GetTableName<T>(T model)
		{
			var tableNameProperty = typeof(T).GetProperty("TABLE_NAME");
			if (tableNameProperty == null)
			{
				//throw new Exception("O modelo não possui uma propriedade TABLE_NAME.");
				return null;
			}

			return tableNameProperty.GetValue(model)?.ToString();
		}

		public async Task<string> AddDataAsync<T>(T data)
		{
			try
			{
				string path = GetTableName(data);

				if (string.IsNullOrEmpty(path))
				{
					return null;
				}

				var result = await firebaseClient
					.Child(path)
					.PostAsync(data);

				return result.Key;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<List<T>> GetDataAsync<T>()
		{
			try
			{
				string path = GetTableName(Activator.CreateInstance<T>());

				if (string.IsNullOrEmpty(path))
				{
					return default;
				}

				var result = await firebaseClient
					.Child(path)
					.OnceAsync<T>();

				List<T> ts = result.Select(item => item.Object).ToList();
				return ts;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return default;
		}


	}
}
