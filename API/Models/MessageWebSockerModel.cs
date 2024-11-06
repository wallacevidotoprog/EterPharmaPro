using EterPharmaPro.Models.DbModels;

namespace EterPharmaPro.API.Models
{
	public class MessageWebSockerModel
	{
		public string type { get; set; }
		public string message { get; set; }
		public string idMsgPrivete { get; set; }
		public UserModel user { get; set; }
		public object data { get; set; }
		public string uid { get; set; }
		public string name { get; set; }
	}
}
