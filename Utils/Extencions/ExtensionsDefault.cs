using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using Newtonsoft.Json;
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
		//public static string GetNameCategory(this int id, List<ValidadeCategoria> validadeCategorias)
		//{
		//	return validadeCategorias.Find((ValidadeCategoria x) => x.ID == id).NOME;
		//}

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

		public static int ReturnIndexUserCB(string id, ComboBox cb)//modificar
		{
			try
			{
				BindingSource sb = (BindingSource)cb.DataSource;
				Dictionary<string, string> tempD = (Dictionary<string, string>)sb.DataSource;
				int index = 0;
				foreach (KeyValuePair<string, string> item in tempD)
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
			MessageBox.Show("Funcionário não encontrado.");
			return -1;
		}

		public static ComboBox CBListUser(this ComboBox cb, IEterDb eterDb)
		{
			Dictionary<string, string> users = new Dictionary<string, string>();
			List<UserModel> list = eterDb.DbUser.GetUser().Result;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].STATUS)
				{
					users.Add(list[i].ID.ToString(), list[i].ID_LOJA.ToString() + " - " + list[i].NOME);
				}
			}
			BindingSource bindingSource = new BindingSource
			{
				DataSource = users
			};
			cb.DataSource = bindingSource;
			cb.DisplayMember = "Value";
			cb.ValueMember = "Key";
			return cb;
		}

		public static async Task<AddressHttpModel> BuscaCepAsync(string cep)
		{
			HttpClient client = new HttpClient();
			try
			{
				HttpResponseMessage response = await client.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
				response.EnsureSuccessStatusCode();
				return JsonConvert.DeserializeObject<AddressHttpModel>(await response.Content.ReadAsStringAsync());
			}
			catch (HttpRequestException val)
			{
				MessageBox.Show("Message :" + ((Exception)(object)val).Message, "Exception Caught!");
			}
			return null;
		}

		public static DateTime DateTimeDay()
		{
			return DateTime.Parse($"01/{DateTime.Now.Month}/{DateTime.Now.Year}");
		}

		//public static TypeDoc TypeDocs(this string type)
		//{
		//	int t = type.Length;
		//	return (type.Length == 11) ? TypeDoc.CPF : ((type.Length < 5) ? TypeDoc.ID : ((type.Length == 14) ? TypeDoc.CNPJ : ((type.Length > 8 || type.Length < 9) ? TypeDoc.RG : TypeDoc.NONE)));
		//}
	}
}
