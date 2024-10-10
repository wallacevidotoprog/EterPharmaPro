using EterPharmaPro.Enums;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class UserModel : BaseDbModal
	{
		public long? ID_LOJA { get; set; }

		public string NOME { get; set; } = string.Empty;

		public string PASS { get; set; } = string.Empty;

		public int FUNCAO { get; set; } 
		public string FUNCAO_NAME { get; set; } = string.Empty;

		public bool STATUS { get; set; } = true;

	}
}
