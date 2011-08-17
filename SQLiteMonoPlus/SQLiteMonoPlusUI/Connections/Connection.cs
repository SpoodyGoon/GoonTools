using System;

namespace SQLiteMonoPlusUI
{
	public class Connection
	{
		public string FriendlyName = string.Empty;
		public string FilePath = string.Empty;
		public string Password = string.Empty;
		public bool Pooling = false;
		public int MaxPoolSize = 0;
		public Connection (string name, string path) 
		{
			FriendlyName = name;
			FilePath = path;
		}
		
		
	}
}

