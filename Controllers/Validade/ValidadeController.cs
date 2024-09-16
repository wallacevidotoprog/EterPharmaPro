using EterPharmaPro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Validade
{
	public class ValidadeController
	{
        private readonly IEterDb eterDb;
        public ValidadeController(IEterDb _eterDb)
        {
                eterDb = _eterDb;
        }
    }
}
