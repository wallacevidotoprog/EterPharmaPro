using EterPharmaPro.Models.DbModels;
using System;

namespace EterPharmaPro.Models.FirebaseModel
{
	public class EntregaFbModel : EntregaDbModel
	{

		public new (long? ID, string NAME) USER_ID { get; set; }

		public new (long? ID, string NAME) CLIENTE_ID { get; set; }

		public new (long? ID, string NAME, string OBS) ENDERECO_ID { get; set; }

        public EntregaFbModel()
        {
				
        }
        public EntregaFbModel(EntregaDbModel model)
		{
			ID = model.ID;
			UID = model.UID;
			DATE = model.DATE;
			VALUE = model.VALUE;
			KM = model.KM;
			TYPE_DELIVERY = model.TYPE_DELIVERY;
			TABLE_NAME = model.TABLE_NAME;

		}
	}
}
