using System;
using Mono.Data.SqliteClient;

namespace SQLiteMonoPlus
{
	public static class Utilities
	{			
		public static bool DatabaseTryConnect (string DBFile)
		{        	
			bool blnSuccess = true;
			//DBFile = Uri.EscapeUriString(DBFile);
			if(!System.IO.File.Exists(DBFile))
			   return false;

			try {
				SqliteConnection sqlCN = new SqliteConnection("URI=file:" + DBFile + ",version=3, busy_timeout=300");
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

