using EterPharmaPro.DatabaseSQLite;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class ClienteModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "CLIENTES";

		public string CPF { get; set; } = string.Empty;

		public string RG { get; set; } = string.Empty;


		public string NOME { get; set; } = string.Empty;


		public string TELEFONE { get; set; } = string.Empty;

		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public object ENDERECO { get; set; } = null;

		

		public void MergeSE(ClienteModel other)
		{
			if (other != null)
			{
				ID = other.ID;
				CPF = other.CPF;
				RG = other.RG;
				NOME = other.NOME;
				TELEFONE = other.TELEFONE;
			}
		}
	}
}
