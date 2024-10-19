using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class RequisicaoNotasModel
	{
		public long? ID { get; set; }
		public int REG_USERID { get; set; }
		public int USERID { get; set; }
		public DateTime? DATA_VENDA { get; set; }
		public List<(long? id,string name)> REQS { get; set; }


		public (ControlReqNotaDbModal control, List<ReqNotaDbModal> reqs) DisolveBySQL()
		{

			try
			{
				ControlReqNotaDbModal c = new ControlReqNotaDbModal
				{
					ID = this.ID,
					VENDEDOR = this.USERID,
					AUTHOR = this.REG_USERID,
					DATA_VENDA = this.DATA_VENDA
					
				};

				List<ReqNotaDbModal> r = new List<ReqNotaDbModal>();

				for (int i = 0; i < REQS.Count; i++)
				{
					r.Add(new ReqNotaDbModal
					{
						ID = REQS[i].id,
						REQ = REQS[i].name,
						CQN_ID =c.ID,
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

		public RequisicaoNotasModel DisolveFromSQL(ControlReqNotaDbModal control, List<ReqNotaDbModal> reqs)
		{
			try
			{
				ID = control.ID;
				USERID = Convert.ToInt32(control.VENDEDOR);
				REG_USERID = Convert.ToInt32(control.AUTHOR);
				DATA_VENDA = control.DATA_VENDA;

				REQS = new List<(long? id, string name)>();

				for (int i = 0; i < reqs.Count; i++)
				{
					REQS.Add((reqs[i].ID, reqs[i].REQ));
				}
				return this;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return this;
		}
	}
}
