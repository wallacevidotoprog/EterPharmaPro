using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.Extencions
{
	public static class ExtensionsDefault
	{		
		public static string ReturnInt(this string value)
		{
			return Regex.Replace(value, "[^0-9]", string.Empty);
		}

		public static string ReturnFormation(this string value, FormatationEnum format)
		{
			try
			{
				if (value == "0" || value == "")
				{
					return string.Empty;
				}
				switch (format)
				{
					case FormatationEnum.CPF:
						return Convert.ToUInt64(value.ReturnInt()).ToString("000\\.000\\.000\\-00");
					case FormatationEnum.RG:
						return Convert.ToUInt64(value.ReturnInt()).ToString("00\\.000\\.000\\-0");
					case FormatationEnum.TELEFONE:
						{
							string tempR = value.ReturnInt();
							if (tempR.Length == 11)
							{
								return Convert.ToUInt64(tempR).ToString("\\(00\\) 00000\\-0000");
							}
							if (tempR.Length == 10)
							{
								return Convert.ToUInt64(tempR).ToString("\\(00\\) 0000\\-0000");
							}
							return tempR;
						}
				}
			}
			catch (Exception)
			{
				return value;
			}
			return null;
		}

		public static int ReturnIndexUserCB(this ComboBox cb, object id)
		{
			try
			{
				BindingSource sb = (BindingSource)cb.DataSource;
				Dictionary<string, string> tempD = (Dictionary<string, string>)sb.DataSource;
				int index = 0;
				foreach (KeyValuePair<string, string> item in tempD)
				{
					if (item.Key.Equals(id.ToString()))
					{
						return index;
					}
					index++;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return -1;
		}

		public static int ReturnIndexCategoryCB(this ComboBox cb, long? id)
		{
			try
			{
				BindingSource sb = (BindingSource)cb.DataSource;
				Dictionary<long?, string> tempD = (Dictionary<long?, string>)sb.DataSource;
				int index = 0;
				foreach (KeyValuePair<long?, string> item in tempD)
				{
					if (item.Key.Equals(id))
					{
						return index;
					}
					index++;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return -1;
		}

		public static async Task<ComboBox> CBListUserAsync(this ComboBox cb, IEterDb eterDb, bool isStatusAll = false)
		{
			List<UserModel> list = await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel());

			Dictionary<string, string> users = new Dictionary<string, string>();

			foreach (var user in list)
			{
				string key = user.ID.ToString();

				string value = $"{user.ID_LOJA.ToString().PadLeft(4, '0')} - {user.NOME}";
				if (user.STATUS && !isStatusAll)
				{
					if (!users.ContainsKey(key))
					{
						users.Add(key, value);
					}
				}
				else if (isStatusAll)
				{
					if (!users.ContainsKey(key))
					{
						users.Add(key, value);
					}
				}

			}

			BindingSource bindingSource = new BindingSource
			{
				DataSource = users
			};

			cb.DataSource = bindingSource;
			cb.DisplayMember = "Value";
			cb.ValueMember = "Key";
			cb.SelectedIndex = 0;
			return cb;
		}

		public static ComboBox CBListCategory(this ComboBox cb, List<CategoriaDbModal> categoriaDbModal)//melhorar
		{
			Dictionary<long?, string> cat = new Dictionary<long?, string>();

			cat.Add(1, "SEM CATEGORIA");


			for (int i = 0; i < categoriaDbModal.Count; i++)
			{
				long? key = categoriaDbModal[i].ID;
				if (!cat.ContainsKey(key))
				{
					cat.Add(key, categoriaDbModal[i].NAME);
				}
			}

			BindingSource bindingSource = new BindingSource
			{
				DataSource = cat
			};

			cb.DataSource = bindingSource;
			cb.DisplayMember = "Value";
			cb.ValueMember = "Key";
			cb.SelectedIndex = 0;
			return cb;
		}

		public static async Task<AddressHttpModel> BuscaCepAsync(string cep)
		{
			HttpClient client = new HttpClient();
			cep = cep.ReturnInt();
			try
			{
				HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
				response.EnsureSuccessStatusCode();
				var temp = await response.Content.ReadAsStringAsync();
				if (temp.Contains("erro"))
				{
					return null;
				}

				return JsonConvert.DeserializeObject<AddressHttpModel>(temp);
			}
			catch (HttpRequestException val)
			{
				MessageBox.Show("Message :" + ((Exception)(object)val).Message, "Exception Caught!");
			}
			return null;
		}

		public static DateTime DateTimeDay(this DateTime dateTime)
		{
			return DateTime.Parse($"01/{DateTime.Now.Month}/{DateTime.Now.Year}");
		}


		public static long ToDatetimeUnix(this DateTime? dateTime) => ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
		public static long ToDatetimeUnix(this DateTime dateTime) => ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
		public static long ToDatetimeUnix(this string dateTime) => ((DateTimeOffset)Convert.ToDateTime(dateTime)).ToUnixTimeSeconds();
		public static DateTime? ToUnixDatetime(this long? DATE) => DATE.HasValue ? DateTimeOffset.FromUnixTimeSeconds(DATE.Value).DateTime : (DateTime?)null;
		public static string GetEnderecoArray(this List<EnderecoClienteDbModel> enderecoClienteModels, out int indexSelect)
		{
			try
			{
				if (enderecoClienteModels.Count == 0)
				{
					indexSelect = -1;
					return string.Empty;
				}
				if (enderecoClienteModels.Count == 1)
				{
					indexSelect = 0;
					return enderecoClienteModels[0].ENDERECO;

				}
				var tempEnd = new object[enderecoClienteModels.Count];
				for (int i = 0; i < tempEnd.Length; i++)
				{
					tempEnd[i] = new object[2]
					{
					i,
					enderecoClienteModels[i].ENDERECO
					};
				}
				var retList = InputList.Show(tempEnd, "Enderecos Cliente");
				if (retList != -1)
				{
					indexSelect = retList;
					return enderecoClienteModels[retList].ENDERECO;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			indexSelect = -1;
			return string.Empty;

		}

		public static EnderecoClienteDbModel GetEnderecoModel(this List<EnderecoClienteDbModel> enderecoClienteModels)
		{
			try
			{
				if (enderecoClienteModels.Count == 0)
				{
					return null;
				}
				if (enderecoClienteModels.Count == 1)
				{
					return enderecoClienteModels[0];

				}
				var tempEnd = new object[enderecoClienteModels.Count];
				for (int i = 0; i < tempEnd.Length; i++)
				{
					tempEnd[i] = new object[2]
					{
					i,
					enderecoClienteModels[i].ENDERECO
					};
				}
				var retList = InputList.Show(tempEnd, "Enderecos Cliente");
				if (retList != -1)
				{
					return enderecoClienteModels[retList];
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;

		}
		public static ClienteModel GetClienteArray(this List<ClienteModel> clienteModels)
		{
			try
			{
				object[] tempEnd;
				int retList;
				if (clienteModels.Count > 1)
				{
					tempEnd = new object[clienteModels.Count];
					for (int i = 0; i < tempEnd.Length; i++)
					{
						tempEnd[i] = new object[2]
						{
							i,
							"CLIENTE: " + clienteModels[i].NOME + $" | TOTAL DE ENDEREÇOS: {(((List<EnderecoClienteDbModel>)clienteModels[i].ENDERECO != null) ? ((List<EnderecoClienteDbModel>)clienteModels[i].ENDERECO).Count : 0)}"
						};
					}
					retList = InputList.Show(tempEnd, "Clientes");
					if (retList == -1)
					{
						return null;
					}
					ClienteModel tempSelect = clienteModels[retList];
					tempSelect.ENDERECO = ((List<EnderecoClienteDbModel>)tempSelect.ENDERECO).GetEnderecoModel();
					return tempSelect;

				}
				else
				{
					ClienteModel tempSelect = clienteModels[0];
					tempSelect.ENDERECO = ((List<EnderecoClienteDbModel>)tempSelect.ENDERECO).GetEnderecoModel();
					return tempSelect;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public static void StartVFD(this Control control)
		{

			ToolTip validationToolTip = new ToolTip
			{
				IsBalloon = true,
				ToolTipIcon = ToolTipIcon.Warning,
				ToolTipTitle = "Campo Obrigatório"
			};
			validationToolTip.Show("Este campo é obrigatório", control, 0, -40, 3000);
		}

		public static string PadRight(string text, int totalWidth)
		{
			if (text.Length >= totalWidth)
			{
				return text.Substring(0, totalWidth);
			}
			return text.PadRight(totalWidth);
		}
		
	}
}
