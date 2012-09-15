using System;
using Mono.Data.SqliteClient;

namespace SQLiteMonoPlus
{
	public static class Utilities
	{		
		public static bool DatabaseTryConnect(string DBFile)
		{        	
			bool blnSuccess = true;
			try {
				SqliteConnection sqlCN = new SqliteConnection(Constants.ConnectionString.Simple.Replace ("[DBPATH]", DBFile));
				SqliteCommand sqlCMD = new SqliteCommand (SQLiteMonoPlus.Constants.ConnectionString.ConnectionTest, sqlCN);
				sqlCN.Open ();
				sqlCMD.ExecuteNonQuery ();
				sqlCN.Close ();
				sqlCMD.Dispose ();
				sqlCN.Dispose ();
			}
			catch (Exception ex) {
				blnSuccess = false;
				Console.WriteLine (ex.ToString ());				
			}
			return blnSuccess;
		}
	}
}

