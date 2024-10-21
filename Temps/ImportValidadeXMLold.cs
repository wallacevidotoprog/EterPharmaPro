using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EterPharmaPro.Temps
{
	public class ImportValidadeXMLold
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;
		public List<ValidadeModel> validadeModels;

        public ImportValidadeXMLold(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
        {
			this.eterDb = eterDb;
			this.databaseProdutosDb = databaseProdutosDb;
			GetFilesXML();

		}

		public async void ProcessXml()
		{
			for (int i = 0; i < validadeModels.Count; i++)
			{
				ValidadeModel validadeModel = validadeModels[i];
				validadeModel.DADOS.IDdb = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID_LOJA", validadeModel.DADOS.ID))).FirstOrDefault().ID;
				// S/ CATEGORIA

				// add categoria 
				for (int c = 0; c < validadeModel.CATEGORIA.Count; c++)
                {
					if (validadeModel.CATEGORIA[c].ID == 0 || validadeModel.CATEGORIA[c].NOME =="" || validadeModel.CATEGORIA[c].NOME == null)
					{
						validadeModel.CATEGORIA[c].IDdb = 1;
						
					}
					else
					{
						var tc = (await eterDb.ActionDb.GETFIELDS<CategoriaDbModal>(new QueryWhereModel().SetWhere("NAME", validadeModel.CATEGORIA[c].NOME))).FirstOrDefault();

						if (tc is null)
						{
							using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
							{
								await connection.OpenAsync().ConfigureAwait(false);
								using (var transaction = connection.BeginTransaction())
								{
									try
									{
										validadeModel.CATEGORIA[c].IDdb = await eterDb.ActionDb.INSERT(new CategoriaDbModal { ID_LOJA = validadeModel.DADOS.IDdb, NAME = validadeModel.CATEGORIA[c].NOME }, connection, transaction);

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
						else
						{
							validadeModel.CATEGORIA[c].IDdb = tc.ID;
						}
					}
					
                }

				//add validade

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							validadeModel.IDdb = await eterDb.ActionDb.INSERT(new ValidadeDbModal { USER_ID = validadeModel.DADOS.IDdb, DATE = validadeModel.DADOS.DATA.ToDatetimeUnix() }, connection, transaction);

							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}

                //add produt

                for (int p = 0; p < validadeModel.PRODUTOS.Count; p++)
                {
					using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
					{
						await connection.OpenAsync().ConfigureAwait(false);
						using (var transaction = connection.BeginTransaction())
						{
							try
							{
								if (validadeModel.PRODUTOS[p].COD_PRODUTO.Length >10)
								{
									var tp = databaseProdutosDb.produtos.Where(x => x.EAN == validadeModel.PRODUTOS[p].COD_PRODUTO).FirstOrDefault();
									if (tp != null)
									{
										validadeModel.PRODUTOS[p].COD_PRODUTO = tp.COD_PRODUTO;
									}
									else
									{
										validadeModel.PRODUTOS[p].COD_PRODUTO = "0";
									}
								}
								long? tempIdV = await eterDb.ActionDb.INSERT(new ProdutoValidadeDbModal
								{
									PRODUTO_CODIGO = (int)Convert.ToUInt32(validadeModel.PRODUTOS[p].COD_PRODUTO),
									PRODUTO_DESCRICAO = validadeModel.PRODUTOS[p].DESCRICAO_PRODUTO,
									QUANTIDADE = validadeModel.PRODUTOS[p].QTD,
									DATA_VALIDADE = validadeModel.PRODUTOS[p].DATA.ToDatetimeUnix(),
									CATEGORIA_ID = (int)validadeModel.CATEGORIA.Where(x=>x.ID == validadeModel.PRODUTOS[p].CATEGORIA).First().IDdb   ,
									VALIDADE_ID = (int)validadeModel.IDdb

								}, connection, transaction);

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




            }
			MessageBox.Show("FINISH");
		}
        private  void GetFilesXML()
		{
			string[] fileEntries = Directory.GetFiles(@"C:\Users\walla\OneDrive\Área de Trabalho\VALIDADE", "*.xml");
			validadeModels = new List<ValidadeModel>();
			for (int i = 0; i < fileEntries.Length; i++)
			{
				try
				{
					ValidadeModel tempV =  DeserializePessoaFromXmlAsync(fileEntries[i]);
					validadeModels.Add(tempV);
				}
				catch (Exception ex)
				{
					ex.ErrorGet();
				}
			}
			
		}

		public static ValidadeModel DeserializePessoaFromXmlAsync(string xml, bool ev = false)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(ValidadeModel));
			ValidadeModel validade = new ValidadeModel();
			FileStream fs = new FileStream(xml, FileMode.Open, FileAccess.Read);
			try
			{
				validade = (ValidadeModel)serializer.Deserialize(fs);
				fs.Close();
			}
			finally
			{
				if (fs != null)
				{
					((IDisposable)fs).Dispose();
				}
			}
			
			return validade;
		}

	}



	[Serializable]
	public class ValidadeModel
	{
		public long? IDdb;
		public ValidadeDados DADOS { get; set; }

		public List<ValidadeProdutos> PRODUTOS { get; set; }

		public List<ValidadeCategoria> CATEGORIA { get; set; }
	}



	public class ValidadeDados
	{
		public long? IDdb;
		public string ID;

		public string NOME;

		public DateTime? DATA;
	}
	public class ValidadeProdutos
	{
		public int ID;

		public string EAN;

		public string COD_PRODUTO;

		public int CATEGORIA;

		public string DESCRICAO_PRODUTO;

		public int QTD;

		public DateTime DATA;
	}
	public class ValidadeCategoria
	{
		public int ID;

		public string NOME;

		public long? IDdb;
	}
}
