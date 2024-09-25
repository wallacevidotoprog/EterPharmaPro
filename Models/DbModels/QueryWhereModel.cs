using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class QueryWhereModel
	{
		public string WHERE { get; set; } = string.Empty;
		public string OPERATOR_WHERE { get; set; } = "=";
		public List<(object objAND, string op)> AND { get; set; } = null;

		public QueryWhereModel SetWhere(string propName, object setWhere)
		{
			WHERE = $"{propName} {OPERATOR_WHERE} {setWhere.ToString()}";
			return this;	
		}
		public string ReturnSQLQuery()
		{
			string tempQuery = string.Empty;

			if (WHERE == string.Empty)
			{
				return string.Empty;
			}
			tempQuery = $" WHERE {WHERE} ";
			if (AND is null)
			{
				return tempQuery;
			}

			foreach (var item in AND)
			{
				tempQuery += $" AND {nameof(item.objAND)} {item.op} {item.objAND.ToString()}";
			}
			return tempQuery;
		}
	}
}
