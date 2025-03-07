﻿using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class DeliveryDbModel : BaseDbModal, IFirebaseDb
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "DELIVERY";
		public string UID { get; set; }
		public string FIREBASE_ID { get; set; }

		public int USER_ID { get; set; }  

		public DateTime? DATE { get; set; }  

		public int KM { get; set; }

		public int STATS { get; set; }  

		public long DATE_COMPLETED { get; set; } 
	}
}
