using EterPharmaPro.Enuns;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbUser
	{
		Task<long?> CreateUser(UserModel model);

		Task<bool> UpdateUser(UserModel model);

		Task<bool> DeleteUser(string id);

		Task<List<UserModel>> GetUser(string queryID = null, QueryUserEnum queryUser = QueryUserEnum.NONE);
	}
}
