using EterPharmaPro.Enums;
using System;
using System.Collections.Generic;

namespace EterPharmaPro.Controllers
{
	public class PermissoesController
	{
		private int _permissoes;

		public PermissoesController(int permissoes)
		{
			_permissoes = permissoes;
		}
		public PermissoesController(PermissionsEnum[] permissoesIniciais)
		{
            if (permissoesIniciais.Length != 0)
            {
				AddArray(permissoesIniciais);

			}
		}

		public void AddArray(PermissionsEnum[] permissoesIniciais)
		{
            for (int i = 0; i < permissoesIniciais.Length; i++)
            {
				Add(permissoesIniciais[i]);
            }
        }

		public void Add(PermissionsEnum permissao)
		{
			_permissoes |= (int)permissao;
		}

		public void Remove(PermissionsEnum permissao)
		{
			_permissoes &= ~(int)permissao;
		}

		public bool HasPermission(PermissionsEnum permissao)
		{
			return (_permissoes & (int)permissao) != 0;
		}
		public bool HasPermission(int permissao)
		{
			return (_permissoes & permissao) != 0;
		}

		public int GetPermissionsAsInt()
		{
			return _permissoes;
		}

		public List<PermissionsEnum> GetActivePermissions()
		{
			List<PermissionsEnum> activePermissions = new List<PermissionsEnum>();

			foreach (PermissionsEnum perm in Enum.GetValues(typeof(PermissionsEnum)))
			{
				if (perm != PermissionsEnum.Padrao && HasPermission(perm))
				{
					activePermissions.Add(perm);
				}
			}

			return activePermissions;
		}

	}
}
