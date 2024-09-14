using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbUser
	{
		Task<long?> CreateUser(UserModel mode, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateUser(UserModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteUser(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<UserModel>> GetUser(string queryID = null, QueryUserEnum queryUser = QueryUserEnum.NONE);
	}
}
