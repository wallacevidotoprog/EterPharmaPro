using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IFirebaseDb
	{
		string UID { get; set; }

		string FIREBASE_ID { get; set; }
	}
}
