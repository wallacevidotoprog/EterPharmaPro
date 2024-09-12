using EterPharmaPro.Enuns;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class UserModel {

		public long? ID { get; set; }
		public long? ID_LOJA { get; set; }

		public string NOME { get; set; } = string.Empty;

		public FuncaoEnum? FUNCAO { get; set; } = FuncaoEnum.NONE;

        public bool STATUS { get; set; } = true;

        public DateTime? CREATE { get; set; }

		public DateTime? UPDATE { get; set; }

	}
}
