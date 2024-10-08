﻿using System;

namespace EterPharmaPro.Models.DbModels
{
	public class ClienteModel : BaseDbModal
	{		

		public string CPF { get; set; } = string.Empty;


		public string RG { get; set; } = string.Empty;


		public string NOME { get; set; } = string.Empty;


		public string TELEFONE { get; set; } = string.Empty;


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
