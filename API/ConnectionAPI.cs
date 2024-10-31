using EterPharmaPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.API
{
	public class ConnectionAPI
	{
        public readonly HttpClient client;
		private readonly IniFile ini;
		public readonly string host;
		public ConnectionAPI()
        {
			client = new HttpClient();
			ini = new IniFile("config.ini");
			host = ini.Read("API", "HOST");

		}
    }
}
