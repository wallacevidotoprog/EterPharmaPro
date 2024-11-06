using EterPharmaPro.Models.DbModels;
using Newtonsoft.Json;
using System;

namespace EterPharmaPro.Models.API
{
	public class EntregaFbModel
	{
		[JsonProperty("ID")]
		public long? ID { get; set; }

		[JsonProperty("FIREBASE_ID")]
		public string FIREBASE_ID { get; set; }

		[JsonProperty("UID")]
		public string UID { get; set; }

		[JsonProperty("DATE")]
		public DateTime? DATE { get; set; }

		[JsonProperty("VALUE")]
		public decimal VALUE { get; set; }

		[JsonProperty("KM")]
		public int? KM { get; set; }

		[JsonProperty("TYPE_DELIVERY")]
		public int? TYPE_DELIVERY { get; set; }

		[JsonProperty("USER_ID")]
		public INDENT USER_ID { get; set; }

		[JsonProperty("CLIENTE_ID")]
		public INDENT CLIENTE_ID { get; set; }

		[JsonProperty("ENDERECO_ID")]
		public INDENT ENDERECO_ID { get; set; }

		public EntregaFbModel()
		{

		}
		//public EntregaFbModel(EntregaDbModel model)
		//{
		//	ID = model.ID;
		//	UID = model.UID;
		//	DATE = model.DATE;
		//	VALUE = model.VALUE;
		//	KM = model.KM;
		//	TYPE_DELIVERY = model..TYPE_DELIVERY;

		//}
	}

	public class INDENT
	{
		[JsonProperty("ID")]
		public long? ID { get; set; }

		[JsonProperty("NAME")]
		public string NAME { get; set; }

		[JsonProperty("OBS")]
		public string OBS { get; set; }

		public INDENT() { }
		public INDENT(long? iD, string nAME)
		{
			ID = iD;
			NAME = nAME;
		}

		public INDENT(long? iD, string nAME, string oBS) : this(iD, nAME)
		{

			OBS = oBS;
		}
	}
}
