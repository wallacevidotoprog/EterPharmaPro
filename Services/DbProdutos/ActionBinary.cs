using EterPharmaPro.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Services.DbProdutos
{
	public static class ActionBinary
	{
		private static BACKUP _backup;
		#region PRODUTOS
		public static async Task<List<ProdutosModel>> ReadProdutosAsync(ToolStripProgressBar progressBar, CancellationToken cancellationToken)
		{
			List<ProdutosModel> list = new List<ProdutosModel>();
			string filePath = Directory.GetCurrentDirectory() + "\\DADOS\\produtos.eter";

			try
			{
				if (File.Exists(filePath))
				{
					using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
					{
						using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: false))
						{
							int lines = reader.ReadInt32();

							if (progressBar != null)
							{
								progressBar.Maximum = lines;
								progressBar.Value = 0;
							}

							for (int i = 0; i < lines; i++)
							{
								if (cancellationToken.IsCancellationRequested)
								{
									return list;
								}
								list.Add(new ProdutosModel
								{
									EAN = reader.ReadString(),
									COD_PRODUTO = reader.ReadString(),
									DESCRICAO_PRODUTO = reader.ReadString(),
									STATUS = reader.ReadBoolean(),
									LABORATORIO = reader.ReadString(),
									GRUPO = reader.ReadString()
								});

								if (progressBar != null)
								{
									await Task.Run(() => progressBar.ProgressBar.Invoke((Action)(() => progressBar.Increment(1))));
								}
							}
						}
					}
				}
				else
				{
					MessageBox.Show("ERRO\nArquivo não encontrado.", "ReadProdutos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("ERRO\nArquivo de produtos não encontrado.", "ReadProdutos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (IOException ex)
			{
				MessageBox.Show("ERRO de IO\n" + ex.Message, "ReadProdutos", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show("ERRO\n" + ex.Message, "ReadProdutos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				if (!cancellationToken.IsCancellationRequested)
				{
					if (progressBar != null)
					{
						progressBar.ProgressBar.Invoke((Action)(() => progressBar.Value = 0));
					}
				}

			}

			return list;
		}

		public static async Task<bool> WriteProdutosAsync(List<ProdutosModel> produtos, ToolStripProgressBar progressBar, CancellationToken cancellationToken)
		{
			try
			{
				string fileName = Directory.GetCurrentDirectory() + "\\DADOS\\produtos.eter";
				_backup = new BACKUP(fileName);
				if (File.Exists(fileName))
				{
					File.Delete(fileName);
				}
				using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
				{
					using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: false))
					{
						writer.Write(produtos.Count);

						progressBar.ProgressBar.Invoke((Action)(() =>
						{
							progressBar.Maximum = produtos.Count;
							progressBar.Value = 0;
						}));

						for (int i = 0; i < produtos.Count; i++)
						{
							cancellationToken.ThrowIfCancellationRequested();

							writer.Write(produtos[i].EAN);
							writer.Write(produtos[i].COD_PRODUTO);
							writer.Write(produtos[i].DESCRICAO_PRODUTO);
							writer.Write(produtos[i].STATUS);
							writer.Write(produtos[i].LABORATORIO);
							writer.Write(produtos[i].GRUPO);

							if (progressBar != null)
							{
								await Task.Run(() => progressBar.ProgressBar.Invoke((Action)(() => progressBar.Increment(1))));
							}
						}
					};

				}
				return true;
			}
			catch (Exception ex)
			{
				_backup.RestoreBackup();
				MessageBox.Show("ERRO\n" + ex.Message + "\nBACKUP Restaurado", "WriteProdutos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				progressBar.ProgressBar.Invoke((Action)(() =>
				{
					progressBar.Value = 0;
				}));
				return false;
			}
		}
		#endregion
	}

	public class BACKUP
	{
		private string fileName;

		private string data;

		public BACKUP(string _file)
		{
			fileName = _file;
			SetBackup();
		}

		private void SetBackup()
		{
			if (File.Exists(fileName))
			{
				data = File.ReadAllText(fileName);
			}
		}

		public void RestoreBackup()
		{
			if (data != null)
			{
				if (File.Exists(fileName))
				{
					File.Delete(fileName);
				}
				File.WriteAllText(fileName, data);
			}
		}
	}
}
