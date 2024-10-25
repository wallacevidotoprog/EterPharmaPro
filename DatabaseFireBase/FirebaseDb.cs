
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



		public async Task<string> AddDataAsync(string path, object data)
		{
			var result = await firebaseClient
				.Child(path)
				.PostAsync(data);

			return result.Key;
		}

		public async Task GetDataAsync(string path)
		{
			var result = await firebaseClient
				.Child(path)
				.OnceAsync<object>();

			foreach (var item in result)
			{
				Console.WriteLine($"{item.Key}: {item.Object}");
			}
		}
	}
}
