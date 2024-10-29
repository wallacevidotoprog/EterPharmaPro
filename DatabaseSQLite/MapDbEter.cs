using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class MapDbEter
	{
		private readonly string _connectionString;

		public MapDbEter(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<List<T>> QueryAsync<T>(string query) where T : new()
		{
			List<T> result = new List<T>();

			using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
			{
				await connection.OpenAsync();

				using (SQLiteCommand command = new SQLiteCommand(query, connection))
				{
					using (SQLiteDataReader reader = (SQLiteDataReader)await command.ExecuteReaderAsync())
					{
						while (await reader.ReadAsync())
						{
							T item = Mapper.Map<T>(reader);
							result.Add(item);
						}
					}
				}
			}

			return result;
		}
	}
	public static class Mapper
	{
		public static T Map<T>(SQLiteDataReader reader) where T : new()
		{
			T obj = new T();
			Type objType = typeof(T);

			for (int i = 0; i < reader.FieldCount; i++)
			{
				string columnName = reader.GetName(i);
				PropertyInfo property = objType.GetProperty(columnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

				if (property != null && !reader.IsDBNull(i))
				{
					object value = reader.GetValue(i);

					if (property.PropertyType.IsEnum)
					{
						value = ConvertToEnum(value, property.PropertyType);
					}
					else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						Type underlyingType = Nullable.GetUnderlyingType(property.PropertyType);

						if (underlyingType == typeof(DateTime))
						{
							if (int.TryParse(value.ToString(), out int result))
							{
								value = ConvertUnixTimestampToDateTime(value);
							}
							else
							{
								value = Convert.ToDateTime(value);
							}
						}
						else if (underlyingType.IsEnum)
						{
							value = ConvertToEnum(value, underlyingType);
						}
						else
						{
							value = Convert.ChangeType(value, underlyingType);
						}
					}
					else if (property.PropertyType == typeof(DateTime))
					{
						
						if (int.TryParse(value.ToString(),out int result))
						{
							value = ConvertUnixTimestampToDateTime(value);
						}
						
						else
						{
							value = Convert.ToDateTime(value);
						}
						
					}
					else
					{
						value = Convert.ChangeType(value, property.PropertyType);
					}

					property.SetValue(obj, value);
				}
			}

			return obj;
		}

		private static object ConvertToEnum(object value, Type enumType)
		{
			if (value is long longValue)
			{
				return Enum.ToObject(enumType, longValue);
			}

			throw new InvalidCastException($"Cannot convert {value.GetType()} to {enumType}");
		}
		private static DateTime ConvertUnixTimestampToDateTime(object value)
		{
			if (value is long longValue)
			{
				DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
				return epoch.AddSeconds(longValue).ToLocalTime();
			}

			throw new InvalidCastException($"Cannot convert {value.GetType()} to DateTime");
		}
	}
}
