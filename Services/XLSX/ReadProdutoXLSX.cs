using ClosedXML.Excel;
using EterPharmaPro.Models;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Services.XLSX
{
	public class ReadProdutoXLSX
	{
		public event Action<ProgressStatsModel> ProgressUpdated;

		public async Task<List<ProdutosModel>> ReadAllProdutos(string filename)
		{
			List<ProdutosModel> list = new List<ProdutosModel>(100); // Definindo capacidade inicial
			ProgressStatsModel progressStatsModel = new ProgressStatsModel();

			try
			{
				await Task.Run(() =>
				{
					using (XLWorkbook workbook = new XLWorkbook(filename))
					{
						IXLWorksheet worksheet = workbook.Worksheet(1);
						int rowCount = worksheet.LastRowUsed().RowNumber();
						progressStatsModel.Max = rowCount - 1; 
						list.Capacity = rowCount - 1;

						for (int r = 1; r < rowCount; r++)
						{
							
							string ean = worksheet.Cell(r + 1, 1).GetValue<string>();
							string codProduto = worksheet.Cell(r + 1, 2).GetValue<string>();
							string descricaoProduto = worksheet.Cell(r + 1, 3).GetValue<string>();
							bool status = worksheet.Cell(r + 1, 4).GetValue<string>().ToUpper() == "ATIVO";
							string laboratorio = worksheet.Cell(r + 1, 5).GetValue<string>();
							string grupo = worksheet.Cell(r + 1, 6).GetValue<string>();

							list.Add(new ProdutosModel
							{
								EAN = ean,
								COD_PRODUTO = codProduto,
								DESCRICAO_PRODUTO = descricaoProduto,
								STATUS = status,
								LABORATORIO = laboratorio,
								GRUPO = grupo
							});

							if (r % 10 == 0)
							{
								progressStatsModel.Progress = r; 
								ProgressUpdated?.Invoke(progressStatsModel);
							}
						}

						
						progressStatsModel.Progress = rowCount - 1;
						ProgressUpdated?.Invoke(progressStatsModel);
					}
				});

				return list;
			}
			catch (Exception ex)
			{
				ex.ErrorGet(); 
			}
			finally
			{
				progressStatsModel = new ProgressStatsModel();
			}
			return null;
		}
	}

}
