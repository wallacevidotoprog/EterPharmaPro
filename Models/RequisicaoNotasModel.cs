using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class RequisicaoNotasModel
	{
		public int REG_USERID { get; set; }
		public int USERID { get; set; }
		public DateTime DATA_VENDA { get; set; }
		public List<string> REQS { get; set; }


		public (ControlReqNotaDbModal control, List<ReqNotaDbModal> reqs) Disolve()
		{

			try
			{
				ControlReqNotaDbModal c = new ControlReqNotaDbModal
				{
					VENDEDOR = this.USERID,
					AUTHOR = this.REG_USERID,
					DATA_VENDA = this.DATA_VENDA
				};
				List<ReqNotaDbModal> r = new List<ReqNotaDbModal>();

				for (int i = 0; i < REQS.Count; i++)
				{
					r.Add(new ReqNotaDbModal
					{
						REQ = REQS[i]
					});
				}
				return (c, r);
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return (null, null);
		}
	}
}
