﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class ValidadeDbModal : BaseDbModal
	{
        public long? USER_ID { get; set; }
        public DateTime? DATE { get; set; }

    }
}
