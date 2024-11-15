using EterPharmaPro.API.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.API.Models
{
	public class ResponseDeliveryModel
	{
		public string type { get; set; }
		public string table { get; set; }
		public string IDF { get; set; }
		public object data { get; set; }


	}
}
