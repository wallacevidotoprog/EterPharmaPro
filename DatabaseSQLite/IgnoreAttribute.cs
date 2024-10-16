using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	[AttributeUsage(AttributeTargets.Property)]
	public class IgnoreAttribute : Attribute
	{
		public bool IgnoreOnInsert { get; }
		public bool IgnoreOnUpdate { get; }

		public IgnoreAttribute(bool ignoreOnInsert = false, bool ignoreOnUpdate = false)
		{
			IgnoreOnInsert = ignoreOnInsert;
			IgnoreOnUpdate = ignoreOnUpdate;
		}
	}
}
