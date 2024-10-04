using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Models.Print;
using EterPharmaPro.Services.Prints;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.CarimboLoteValidade
{
	public class CreateLoteControladosController
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;
		private static RawPrinterHelper printerHelper;

		public bool inLoadProd = true;

		public CreateLoteControladosController(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
		{
			this.eterDb = eterDb;
			this.databaseProdutosDb = databaseProdutosDb;

			databaseProdutosDb.DatabaseProdutosLoaded += DatabaseProdutosLoaded;

		}

		public List<ProdutosModel> GetAllProdutos()
		{
			if (!databaseProdutosDb.CheckingLoad())
			{
				return null;
			}

			return databaseProdutosDb.produtos;
		}
		public bool CheckingLoadDbProd() => !databaseProdutosDb.CheckingLoad();
		public ProdutosModel GetProduto(string cod_produt)
		{
			if (!databaseProdutosDb.CheckingLoad())
			{
				return null;
			}
			return (cod_produt.Trim().Length >= 7) ?
				databaseProdutosDb.produtos.FirstOrDefault((ProdutosModel x) => x.EAN.Contains(cod_produt.Trim())) :
				databaseProdutosDb.produtos.FirstOrDefault((ProdutosModel x) => x.COD_PRODUTO.Contains(cod_produt.Trim().Replace(" ", null).PadLeft(6, '0')));
		}

		public async Task<ClienteModel> GetCliente(string value)
		{
			ClienteModel tempCliente = (await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("RG", value))).FirstOrDefault();
			if (tempCliente is null)
			{
				return null;
			}
			tempCliente.ENDERECO = await eterDb.DbEndereco.GetEndereco(new QueryWhereModel().SetWhere("CLIENTE_ID", tempCliente.ID));

			return tempCliente;
		}

		private void DatabaseProdutosLoaded(bool complet) => inLoadProd = !complet;

		public async Task<bool> FinishAsync(ClienteModel clienteModel, List<MedicamentosControladoLoteModel> medicamentosControladoLoteModel)
		{
			try
			{
				PrintDoc(clienteModel, medicamentosControladoLoteModel);
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			try
			{
				(long? IDC, long? IDE) = await eterDb.EterDbController.RegisterCliente(clienteModel);

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							for (int i = 0; i < medicamentosControladoLoteModel.Count; i++)
							{
								await eterDb.DbControlados.CreateControlado(medicamentosControladoLoteModel[i].CODIGO_MED, medicamentosControladoLoteModel[i].QUANTIDADE, medicamentosControladoLoteModel[i].DATA_VALIDADE, medicamentosControladoLoteModel[i].LOTE,clienteModel.ID.ToString(), connection, transaction);

							}

							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}


			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return false;
			}

			return false;
		}

		private void PrintDoc(ClienteModel clienteModel, List<MedicamentosControladoLoteModel> medicamentosControladoLoteModel)
		{
			printerHelper = new RawPrinterHelper();
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Nome: ",
				texto = clienteModel.NOME,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "RG: ",
				texto = clienteModel.RG.ReturnFormation(FormatationEnum.RG),
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Endereço :",
				texto = ((EnderecoClienteModel)clienteModel.ENDERECO).ENDERECO,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Telefone :",
				texto = clienteModel.TELEFONE.ReturnFormation(FormatationEnum.TELEFONE),
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			for (int i = 0; i < medicamentosControladoLoteModel.Count; i++)
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "Código: ",
					texto = medicamentosControladoLoteModel[i].CODIGO_MED,
					fontStyle = FormatTextPrintEnum.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "Medicamento: ",
					texto = medicamentosControladoLoteModel[i].NOME_MED,
					fontStyle = FormatTextPrintEnum.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "Quantidade: ",
					texto = medicamentosControladoLoteModel[i].QUANTIDADE.ToString(),
					fontStyle = FormatTextPrintEnum.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "Validade: ",
					texto = medicamentosControladoLoteModel[i].DATA_VALIDADE.ToShortDateString(),
					fontStyle = FormatTextPrintEnum.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "Lote: ",
					texto = medicamentosControladoLoteModel[i].LOTE,
					fontStyle = FormatTextPrintEnum.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					symbol = SymbolPrintEnum.Space
				});
			}
			printerHelper.PrintDocument();
		}
	}
}
