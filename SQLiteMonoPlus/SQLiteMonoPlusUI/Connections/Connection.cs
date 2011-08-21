using System;

namespace SQLiteMonoPlusUI
{
	public class Connection
	{
		public string ConnectionName = string.Empty;
		public string FilePath = string.Empty;
		public string Password = null;
		public bool Pooling = false;
		public int MaxPoolSize = 0;
		public DateTime LastUsed = DateTime.Now;
		
		public Connection (string name, string path) 
		{
			ConnectionName = name;
			FilePath = path;
		}
		
		public Connection (string name, string path, string password) 
		{
			ConnectionName = name;
			FilePath = path;
			Password = password;
		}
		
		public Connection (string name, string path, bool pooling, int maxpoolsize) 
		{
			ConnectionName = name;
			FilePath = path;
			Pooling = pooling;
			MaxPoolSize = maxpoolsize;
		}
		
		public Connection (string name, string path, string password, bool pooling, int maxpoolsize) 
		{
			ConnectionName = name;
			FilePath = path;
			Password = password;
			Pooling = pooling;
			MaxPoolSize = maxpoolsize;
		}
		
		public Connection (System.Data.DataRow dr) 
		{
			if(!string.IsNullOrEmpty(dr["ConnectionName"].ToString()))
				ConnectionName = dr["ConnectionName"].ToString();
			
			if(!string.IsNullOrEmpty(dr["FilePath"].ToString()))
				FilePath = dr["FilePath"].ToString();
		
			if(!string.IsNullOrEmpty(dr["Password"].ToString()))
				Password = dr["Password"].ToString();
		
			if(!string.IsNullOrEmpty(dr["Pooling"].ToString()))
			   Pooling = Convert.ToBoolean(dr["Pooling"].ToString());
		
			if(!string.IsNullOrEmpty(dr["MaxPoolSize"].ToString()))
			   MaxPoolSize = Convert.ToInt32(dr["MaxPoolSize"].ToString());
				   
		}
		
		
	}
}

