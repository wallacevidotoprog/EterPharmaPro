using EterPharmaPro.Enums;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class UserModel : BaseDbModal
	{
		public long? ID_LOJA { get; set; }

		public string NOME { get; set; } = string.Empty;

		public string FUNCAO { get; set; } = string.Empty;

		public bool STATUS { get; set; } = true;

	}
}
