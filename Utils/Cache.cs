using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Utils
{
	public  class Cache
	{
		private static Cache _instance;
		private static readonly object _lock = new object();

		public static Cache Instance
		{
			get
			{
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = new Cache();
					}
					return _instance;
				}
			}
		}

		private Cache() { }

		public UserModel UserModelAcess { get; set; }

		public List<PaymentDbModal> Paymente { get; set; }

		public List<SituationDbModal> Situation { get; set; }

		public List<DeliveryMethodDbModal> DeliveryMethod { get; set; }
	}
}
