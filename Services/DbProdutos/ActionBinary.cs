using EterPharmaPro.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Services.DbProdutos
{
	public static class ActionBinary
	{
		#region PRODUTOS
		public static List<ProdutosModel> ReadProdutos(ref ToolStripProgressBar progressBar)
		{
			List<ProdutosModel> list = new List<ProdutosModel>();
			try
			{
				if (File.Exists(Directory.GetCurrentDirectory() + "\\DADOS\\produtos.eter"))
				{
					using (FileStream stream = File.Open(Directory.GetCurrentDirectory() + "\\DADOS\\produtos.eter", FileMode.Open))
					{
						using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: false))
						{
							int lines = reader.ReadInt32();
							progressBar.Maximum = lines;
							for (int i = 0; i < lines; i++)
							{
								list.Add(new ProdutosModel
								{
									EAN = reader.ReadString(),
									COD_PRODUTO = reader.ReadString(),
									DESCRICAO_PRODUTO = reader.ReadString(),
									STATUS = reader.ReadBoolean(),
									LABORATORIO = reader.ReadString(),
									GRUPO = reader.ReadString()
								});
								progressBar.Increment(1);
							}
						}
					}
				}
				else
				{
					MessageBox.Show("ERRO\nArquivo não encontrado.", "ReadProdutos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERRO\n" + ex.Message, "ReadProdutos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				progressBar.Value = 0;
			}
			return list;
		}
		#endregion
	}
}
