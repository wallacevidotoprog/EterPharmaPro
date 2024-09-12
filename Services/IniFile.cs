using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EterPharmaPro.Services
{
	public class IniFile
	{
		private readonly string path;

		private readonly Dictionary<string, Dictionary<string, string>> data;

		public IniFile(string path)
		{
			this.path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
			data = new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);
			if (File.Exists(path))
			{
				string[] lines = File.ReadAllLines(path);
				Dictionary<string, string> section = null;
				string[] array = lines;
				foreach (string line in array)
				{
					string trimmedLine = line.Trim();
					if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith(";"))
					{
						continue;
					}
					if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
					{
						string sectionName = trimmedLine.Substring(1, trimmedLine.Length - 2).Trim();
						section = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
						data[sectionName] = section;
					}
					else if (section != null)
					{
						string[] keyValuePair = trimmedLine.Split(new char[1] { '=' }, 2);
						if (keyValuePair.Length == 2)
						{
							string key = keyValuePair[0].Trim();
							string value = keyValuePair[1].Trim();
							section[key] = value;
						}
					}
				}
			}
			else
			{
				File.Create(path).Dispose();
			}
		}

		public string Read(string section, string key, string defaultValue = "")
		{
			if (data.TryGetValue(section, out var sectionData) && sectionData.TryGetValue(key, out var value))
			{
				return value;
			}
			return defaultValue;
		}

		public void Write(string section, string key, string value)
		{
			if (!data.TryGetValue(section, out var sectionData))
			{
				sectionData = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				data[section] = sectionData;
			}
			sectionData[key] = value;
			List<string> lines = new List<string>();
			foreach (KeyValuePair<string, Dictionary<string, string>> sectionPair in data)
			{
				lines.Add("[" + sectionPair.Key + "]");
				lines.AddRange(sectionPair.Value.Select((KeyValuePair<string, string> pair) => pair.Key + "=" + pair.Value));
			}
			File.WriteAllLines(path, lines);
		}
	}
}
