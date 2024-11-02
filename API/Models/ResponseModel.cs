using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.API.Models
{
	public class ResponseModel<T>
	{
        public T data { get; set; }
        public bool actionResult { get; set; }
    }
}
