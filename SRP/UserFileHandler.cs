using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SRP
{
	public static class UserFileHandler
	{
		public static void SaveToFile(User user, string fileName)
		{
			File.WriteAllText(fileName, JsonConvert.SerializeObject(user));
		}
	}
}
