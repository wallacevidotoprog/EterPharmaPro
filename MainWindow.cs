﻿using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Services.XLSX;
using EterPharmaPro.Utils;
using EterPharmaPro.Utils.Extencions;
using EterPharmaPro.Views;
using EterPharmaPro.Views.Manipulados;
using EterPharmaPro.Views.Validade;
using System;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToastNotification;
using ToastNotification.Enum;
using ToastNotifications;

namespace EterPharmaPro
{
	public partial class MainWindow : Form
	{
		private readonly IEterDb eterDb;
		private DatabaseProdutosDb DatabaseProdutosDb;

		private CancellationTokenSource cancellationTokenSource;
		public MainWindow()
		{
			InitializeComponent();
			eterDb = new EterDb();
			cancellationTokenSource = new CancellationTokenSource();
		}
		private async void MainWindow_Load(object sender, EventArgs e)
		{
			//testeAsync();
			DatabaseProdutosDb = new DatabaseProdutosDb(toolStripProgressBar_status, cancellationTokenSource.Token);
			SetLogin();
			/// await NotifyValite.CheckeVality(eterDb);
			await Task.Run(() => NotifyValite.CheckeVality(eterDb));
		}

		private async Task testeAsync()
		{
			try
			{
				UserModel user = new UserModel
				{
					ID_LOJA = 5050,
					FUNCAO = 1,
					NOME = "TESTE"
				};
				long? id = null;
				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{

							user.ID = await eterDb.ActionDb.INSERT<UserModel>(user, connection, transaction);




							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							user.NOME = " TESTE 2";
							user.PASS = "1315456";
							bool test = await eterDb.ActionDb.UPDATE<UserModel>(user, connection, transaction);




							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							bool test = await eterDb.ActionDb.DELETE<UserModel>(user.ID, connection, transaction);




							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}


				//List<ClienteModel> temp = await eterDb.ActionDb.GETFIELDS<ClienteModel>(new QueryWhereModel());
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private void SetLogin()
		{
			AcesUser acesUser = new AcesUser(eterDb);
			acesUser.ShowDialog();
			if (!acesUser.loginSucced)
			{
				SetLogin();
			}
			else
			{
				this.Text = $"ETER PHARMA PRO [ {eterDb.UserModelAcess.ID_LOJA.ToString().PadLeft(4, '0')} - {eterDb.UserModelAcess.NOME} - {eterDb.UserModelAcess.FUNCAO_NAME} ]";


				//Notifications notifications = new Notifications();
				//notifications.Show("SUCESS", $"Bem Vindo {eterDb.UserModelAcess.FUNCAO_NAME} {eterDb.UserModelAcess.NOME}", this.Icon.ToBitmap());

				SendAlertBox.Send($"Bem Vindo {eterDb.UserModelAcess.FUNCAO_NAME} {eterDb.UserModelAcess.NOME}", TypeAlertEnum.Info);
				toolStripButton_conf.Visible = (eterDb.UserModelAcess.FUNCAO_NAME == "DEV") ? true : false;
			}
		}
		private void OpenForm(Form form)
		{
			try
			{
				if (panel_center.Controls.Count > 0)
				{
					panel_center.Controls.RemoveAt(0);
				}
				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				form.Dock = DockStyle.Fill;

				form.FormClosed += ChildForm_FormClosed;
				panel_center.Controls.Clear();
				panel_center.Controls.Add(form);
				form?.Show();
				toolStrip_menu.Visible = false;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

			}
		}

		private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			toolStrip_menu.Visible = true;
		}

		private void fORMUToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new CreateManipulados(eterDb));

		private void gERARVALIDADEDOMÊSToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new CreateValidade(eterDb, DatabaseProdutosDb));

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
			}
		}

		private void toolStripDropDownButton_impressos_Click(object sender, EventArgs e) => OpenForm(new IMPRESSOS(eterDb, DatabaseProdutosDb));

		private async void toolStripButton_conf_Click(object sender, EventArgs e)
		{
			var read = new ReadProdutoXLSX();

			//read.ProgressUpdated += (progress) =>
			//{
			//	if (bar_teste.ProgressBar.InvokeRequired)
			//	{
			//		bar_teste.ProgressBar.Invoke(new Action(() => {
			//			bar_teste.Value = progress.Progress;
			//			bar_teste.Maximum = progress.Max;
			//		}));
			//	}
			//	else
			//	{
			//		bar_teste.Value = progress.Progress;
			//		bar_teste.Maximum = progress.Max;
			//	}

			//};

			var ts = await read.ReadAllProdutos(@"C:\Users\walla\OneDrive\Área de Trabalho\Documento de WALLACE.xlsx");
		}

		private void rELATÓRIOToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new ReportValidades(eterDb, DatabaseProdutosDb));

		private void rELATÓRIOToolStripMenuItem1_Click(object sender, EventArgs e) => OpenForm(new ReportManipulacao(eterDb));

	}
}
