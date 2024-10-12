using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class QueryWhereModel
	{
		public string WHERE { get; set; } = string.Empty;
		public List<string> QMULTI { get; set; } = null;


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
		private string[] CheckedAtr(string atr)
		{
			if (atr.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Length >= 2)
			{
				return new string[] { "'", "'" };
			}
			return new string[] { string.Empty,string.Empty };
		}
		public QueryWhereModel SetWhere(string propName, object setWhere, string opt = " = ")
		{
			string[] withLike = CheckedAtr(setWhere.ToString());
			if (opt.ToUpper().Contains("LIKE"))
			{
				withLike = QueryLike(opt);
				opt = "LIKE";
			}

			WHERE = $"{propName} {opt} {withLike[0]}{setWhere.ToString()}{withLike[1]}";
			return this;
		}

		public QueryWhereModel SetMult(string propName, object setAtrb, string setOpt = " = ")
		{

			string[] withLike = CheckedAtr(setAtrb.ToString());
			if (setOpt.ToUpper().Contains("LIKE"))
			{
				withLike = QueryLike(setOpt);
				setOpt = "LIKE";
			}

			QMULTI = QMULTI ?? new List<string>();
			QMULTI.Add($"{propName} {setOpt} {withLike[0]}{setAtrb}{withLike[1]}");
			return this;
		}
		public QueryWhereModel SetMult(List<string> qmult)
		{
			QMULTI = qmult;
			return this;
		}
		public string ReturnSQLQuery()
		{
			string tempQuery = string.Empty;

			if (!string.IsNullOrEmpty(WHERE))
			{
				return $" WHERE {WHERE} ";
			}

			if (QMULTI is null)
			{
				return tempQuery;
			}

			return tempQuery += $" AND {string.Join(" AND ", QMULTI)}";
		}
	}
}
