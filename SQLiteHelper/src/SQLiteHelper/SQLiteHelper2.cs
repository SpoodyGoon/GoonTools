/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 3/4/2011
 * Time: 2:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using sd = System.Data;
using md = Mono.Data.SqliteClient;

namespace SQLiteDataHelper
{
	/// <summary>
	/// Description of SQLiteHelper.
	/// </summary>
	public class SQLiteHelper
	{
		private string _DatabaseURL = null;
		public SQLiteHelper(string dbURL)
		{
			_DatabaseURL = dbURL;
		}
		
		public sd.DataTable ExecuteDataTable(string strSQL)
		{
			System.IO.FileInfo fi = new System.IO.FileInfo(_DatabaseURL);
			sd.DataTable dt = new sd.DataTable();
			md.SqliteConnection sqlCN = (md.SqliteConnection)GetConnection();
			md.SqliteCommand sqlCMD = new md.SqliteCommand(strSQL, sqlCN);
			md.SqliteDataAdapter sqlDA = new md.SqliteDataAdapter(sqlCMD);
			sqlDA.Fill(dt);
			return dt;
		}
		
		public System.Data.IDbConnection GetConnection()
		{
			return new md.SqliteConnection("URI=file:" + _DatabaseURL + ",version=3, busy_timeout=300");
		}
		
		public void ExecuteNonQuery(string strSQL)
		{
			
		}
		
		public string ExecuteScalar(string strSQL)
		{
			return "1";
		}
		
		public void Dispose()
		{
			
		}
	}
}
