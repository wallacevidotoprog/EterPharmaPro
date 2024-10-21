using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class ActionDbBase : IActionDbBase
	{

		protected readonly string _databaseConnection;

		public ActionDbBase(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		protected string GetTableName<T>(T model)
		{
			var tableNameProperty = typeof(T).GetProperty("TABLE_NAME");
			if (tableNameProperty == null)
			{
				throw new Exception("O modelo não possui uma propriedade TABLE_NAME.");
			}

			return tableNameProperty.GetValue(model)?.ToString();
		}

		public async Task<long?> INSERT<T>(T model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				try
				{
					string tableName = GetTableName(model);

					IEnumerable<PropertyInfo> properties = typeof(T).GetProperties().Where(p => p.GetCustomAttribute<IgnoreAttribute>()?.IgnoreOnInsert != true).Where(p =>
					{
						var value = p.GetValue(model);
						return value != null &&
							   !(value is string str && string.IsNullOrEmpty(str)) &&
							   !(value is int num && num == -1);
					});

					string columnNames = string.Join(", ", properties.Select(p => p.Name));
					string parameterNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));



					string Query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						foreach (var property in properties)
						{
							var value = property.GetValue(model) ?? DBNull.Value;
							command.Parameters.AddWithValue($"@{property.Name}", value);
						}

						await command.ExecuteNonQueryAsync();
						return connection.LastInsertRowId;
					}

				}
				catch (Exception ex)
				{
					ex.ErrorGet();

					return -1;
				}

			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return -1;
		}

		public async Task<bool> UPDATE<T>(T model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				try
				{
					string tableName = GetTableName(model);

					IEnumerable<PropertyInfo> properties = typeof(T).GetProperties().Where(p => p.GetCustomAttribute<IgnoreAttribute>()?.IgnoreOnUpdate != true).Where(p =>
					{
						var value = p.GetValue(model);
						return value != null &&
							   !(value is string str && string.IsNullOrEmpty(str)) &&
							   !(value is int num && num == -1);
					});

					string setClauses = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
					string Query = $"UPDATE {tableName} SET {setClauses} WHERE ID = @ID";


					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						foreach (var property in properties)
						{
							var value = property.GetValue(model) ?? DBNull.Value;
							command.Parameters.AddWithValue($"@{property.Name}", value);
						}
						await command.ExecuteNonQueryAsync();
						return true;
					}
				}
				catch (Exception ex)
				{
					ex.ErrorGet();

					return false;
				}

			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<bool> DELETE<T1>(QueryDeleteModel query, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				T1 model = Activator.CreateInstance<T1>();
				string tableName = GetTableName(model);

				string Query = $"DELETE FROM {tableName} {query.ReturnSQLQuery()}";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					await command.ExecuteNonQueryAsync();
				}

				return true;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

				return false;
			}
		}

		public async Task<List<T>> GETFIELDS<T>(QueryWhereModel query) where T : new()
		{
			try
			{
				T model = Activator.CreateInstance<T>();
				string tableName = GetTableName(model);
				return await new MapDbEter(_databaseConnection).QueryAsync<T>($"SELECT * FROM {tableName} {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

	}
}
