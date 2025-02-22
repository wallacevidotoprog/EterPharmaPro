using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using EterPharmaPro.Controllers;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Enums;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class UserModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public PermissoesController controlePermissions { get; set; }

		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; } = "USERS";

		public long? ID_LOJA { get; set; }

		public string NOME { get; set; } = string.Empty;

		public string PASS { get; set; } = string.Empty;

		public int FUNCAO { get; set; }

		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string FUNCAO_NAME { get; set; } = string.Empty;

		private int _permission;
		public int PERMISSION
		{
			get => _permission;
			set
			{
				_permission = value;

				PermissionsEnum permissions = Enum.IsDefined(typeof(PermissionsEnum), value) ? (PermissionsEnum)value: PermissionsEnum.Padrao;

				controlePermissions = new PermissoesController(value);
			}
		}

		public bool STATUS { get; set; } = true;
				
	}
}
