using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbRequisicoesNotas
	{
		Task<long?> CreateControl(ControlReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateControl(ControlReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteControl(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ControlReqNotaDbModal>> GetControl(QueryWhereModel query);


		Task<long?> CreateReqNota(ReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateReqNota(ReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteReqNota(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ReqNotaDbModal>> GetReqNota(QueryWhereModel query);
	}
}
