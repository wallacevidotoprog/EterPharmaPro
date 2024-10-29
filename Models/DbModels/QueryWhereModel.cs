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
		public List<QMulti> QMULTI { get; set; } = null;
		public string SetQmOpt { get; set; } = " AND ";


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
			if (atr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length >= 2)
			{
				return new string[] { "'", "'" };
			}
			return new string[] { string.Empty, string.Empty };
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

		public QueryWhereModel SetMult(string propName, object setAttr, string setOpt = " = ")
		{

			string[] withLike = CheckedAtr(setAttr.ToString());
			if (setOpt.ToUpper().Contains("LIKE"))
			{
				withLike = QueryLike(setOpt);
				setOpt = "LIKE";
			}

			QMULTI = QMULTI ?? new List<QMulti>();

			QMULTI.Add(new QMulti
			{
				prop = propName,
				opt = setOpt,
				attr = $"{withLike[0]}{setAttr}{withLike[1]}"
			}); 

			return this;
		}
		public QueryWhereModel SetMult(List<QMulti> qmult)
		{
			QMULTI = qmult;
			return this;
		}

		public string ReturnSQLQuery()
		{
			string tempQuery = string.Empty;

			if (string.IsNullOrEmpty(WHERE)) return string.Empty;		


			if (QMULTI is null) return $" WHERE {WHERE} ";

			tempQuery = $" WHERE {WHERE} {SetQmOpt}";


            for (int i = 0; i < QMULTI.Count; i++)
            {
				tempQuery += $" {QMULTI[i].prop} {QMULTI[i].opt} {QMULTI[i].attr} ";

				if (i < QMULTI.Count-1)
				{
					tempQuery += $" {SetQmOpt} ";
				}
			}

			return tempQuery;
		}
	}

	public class QMulti
	{
		public string prop { get; set; }
		public  string attr { get; set; }
		public  string opt {  get; set; }

	}
}
