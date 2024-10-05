using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterProps
	{

		Task<List<FuncaoDbModel>> GetFuncao(QueryWhereModel query);
	}
}
