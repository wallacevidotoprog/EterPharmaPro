using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class QueryDeleteModel
	{
		private string Where { get; set; }

		private string[] CheckedAtr(string atr)
		{
			if (atr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length >= 2)
			{
				return new string[] { "'", "'" };
			}
			return new string[] { string.Empty, string.Empty };
		}
		private string[] QueryLike(string opt)
		{
			string[] withLike = new string[] { string.Empty, string.Empty };
			if (opt.ToUpper().Contains("LIKE"))
			{
				var ta = opt.ToUpper().Split(new string[] { "LIKE" }, StringSplitOptions.None);
				withLike[0] = "'" + ta[0] ?? string.Empty;
				withLike[1] = "'" + ta[1] ?? string.Empty;

				opt = "LIKE";
			}
			return withLike;
		}

		public QueryDeleteModel SetWhere(string propName, object setWhere, string opt = " = ")
		{
			string[] withLike = CheckedAtr(setWhere.ToString());
			if (opt.ToUpper().Contains("LIKE"))
			{
				withLike = QueryLike(opt);
				opt = "LIKE";
			}

			Where = $"{propName} {opt} {withLike[0]}{setWhere.ToString()}{withLike[1]}";
			return this;
		}

		public string ReturnSQLQuery() => $" WHERE {Where}";
		

	}
}
