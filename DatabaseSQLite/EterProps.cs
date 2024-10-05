using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterProps : IEterProps
	{
		private readonly string _databaseConnection;
		public EterProps(string databaseConnection)
        {
				_databaseConnection = databaseConnection;
        }
        #region insert

        #endregion

        #region update

        #endregion

        #region delete

        #endregion

        #region select
        public async Task<List<FuncaoDbModel>> GetFuncao(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<FuncaoDbModel>($"SELECT * FROM FUNCAO {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}
		#endregion

	}
}
