using EterPharmaPro.Models.DbModels;
using Newtonsoft.Json;
using System;
using EterPharmaPro.Utils.Extencions;
using DocumentFormat.OpenXml.EMMA;

namespace EterPharmaPro.Models.API
{
	public class EntregaApiModel
	{
		[JsonProperty("ID")]
		public long? ID { get; set; }

		[JsonProperty("FIREBASE_ID")]
		public string FIREBASE_ID { get; set; }

		[JsonProperty("UID")]
		public string UID { get; set; }

		[JsonProperty("DATA")]
		public DateTime? DATA { get; set; }

		[JsonProperty("VALUE")]
		public decimal VALUE { get; set; }		

		[JsonProperty("TYPE_DELIVERY")]
		public INDENT TYPE_DELIVERY { get; set; }

		[JsonProperty("USER_ID")]
		public INDENT USER { get; set; }

		[JsonProperty("CLIENTE")]
		public INDENT CLIENTE { get; set; }

		[JsonProperty("ENDERECO")]
		public INDENT ENDERECO { get; set; }

		public EntregaApiModel() { }

		public EntregaApiModel(DeliveryInputDbModel model)
		{
			ID = model.ID;
			UID = model.UID;
			DATA = model.DATE;
			VALUE = model.VALUE;
		}


		/// <summary>
		/// Convert um DeliveryInputDbModel e seus derivador para um EntregaApiModel
		/// </summary>
		/// <param name="model"></param>
		/// <param name="modelUser"></param>
		/// <param name="modelClient"></param>
		/// <param name="modelEnd"></param>
		/// <param name="modelType"></param>
		public EntregaApiModel(DeliveryInputDbModel model, UserModel modelUser, ClienteDbModel modelClient, EnderecoClienteDbModel modelEnd, TypeDeliveryDbModel modelType)
		{
			ID = model.ID;
			UID = model.UID;
			DATA = model.DATE;
			VALUE = model.VALUE;
			SetUSERID(modelUser);
			SetCliente(modelClient);
			SetEndereco(modelEnd);
			SetType(modelType);

		}
		public void SetUSERID(UserModel model)
		{
			USER = new INDENT
			{
				ID = model.ID,
				NAME = model.NOME
			};
		}
		public void SetCliente(ClienteDbModel model)
		{
			CLIENTE = new INDENT
			{
				ID = model.ID,
				NAME = model.NOME
			};
		}
		public void SetEndereco(EnderecoClienteDbModel model)
		{
			ENDERECO = new INDENT
			{
				ID = model.ID,
				NAME = model.ENDERECO,
				OBS = model.OBSERVACAO
			};
		}

		internal void SetType(TypeDeliveryDbModel model)
		{
			TYPE_DELIVERY = new INDENT
			{
				ID = model.ID,
				NAME = model.NAME
			};
		}
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
