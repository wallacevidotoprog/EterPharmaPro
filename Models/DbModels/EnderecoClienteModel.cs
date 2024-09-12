﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class EnderecoClienteModel
	{
		public long ID { get; set; } = -1L;


		public object CLIENTE_ID { get; set; } = string.Empty;


		public string ENDERECO { get; set; } = string.Empty;


		public string OBSERVACAO { get; set; } = string.Empty;

		public DateTime? CREATE { get; set; }

		public DateTime? UPDATE { get; set; }
	}
}
