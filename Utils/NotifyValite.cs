using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Utils
{
	public static class NotifyValite
	{
		public static async Task CheckeVality(IEterDb eterDb)
		{
			DateTime primeiroDia = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1);
			DateTime ultimoDia = primeiroDia.AddMonths(1).AddDays(-1);

			QueryWhereModel queryWhereModel = new QueryWhereModel();

			queryWhereModel.WHERE = $"DATE  >=  {primeiroDia.ToDatetimeUnix()} AND DATE  <=  {ultimoDia.ToDatetimeUnix()}";
			List<ValidadeDbModal> tempValidadeDbModal = await eterDb.ActionDb.GETFIELDS<ValidadeDbModal>(queryWhereModel);

			string ids = string.Empty;// " AND ";

			for (int i = 0; i < tempValidadeDbModal.Count; i++)
			{
				ids += $" VALIDADE_ID = {tempValidadeDbModal[i].ID} {(i == tempValidadeDbModal.Count - 1 ? string.Empty : " OR ")} ";
			}
			queryWhereModel.WHERE = $"{ids}";
			//queryWhereModel.WHERE = $"DATA_VALIDADE  >=  {primeiroDia.ToDatetimeUnix()} AND DATA_VALIDADE  <=  {ultimoDia.ToDatetimeUnix()} {(ids.Length < 6 ? string.Empty : ids)}";
			List<ProdutoValidadeDbModal> temLp = await eterDb.ActionDb.GETFIELDS<ProdutoValidadeDbModal>(queryWhereModel);

			int qtdMesAtt = temLp.Where(x => x.DATA_VALIDADE.ToUnixDatetime()?.Month == DateTime.Today.Month).Count();
			int qtdMesAtt1 = temLp.Where(x => x.DATA_VALIDADE.ToUnixDatetime()?.Month == DateTime.Today.Month+1).Count();

			System.Windows.Forms.MessageBox.Show($"Alguns produtos estão próximos de vencer:\nTotal de produtos que vencerão esse mês: {qtdMesAtt}\nTotal de produtos que irão vencer no próximo mês: {qtdMesAtt1}" ,"ALERTA",System.Windows.Forms.MessageBoxButtons.OKCancel,System.Windows.Forms.MessageBoxIcon.Information);

		}
		
	}
}
