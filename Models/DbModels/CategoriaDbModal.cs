﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class CategoriaDbModal :BaseDbModal
	{
        public string NAME { get; set; }
        public long? USER_ID { get; set; }
    }
}
