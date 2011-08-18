/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 8/18/2011
 * Time: 4:59 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SQLiteMonoPlusUI.Connections
{
	/// <summary>
	/// Description of ConnectionDataTable.
	/// </summary>
	public class ConnectionDataTable : System.Data.DataTable
	{
		public ConnectionDataTable()
		{
			this.Columns.Add(new System.Data.DataColumn("FriendlyName", typeof(string))); 
			this.Columns.Add(new System.Data.DataColumn("FilePath", typeof(string))); 
			this.Columns.Add(new System.Data.DataColumn("Password", typeof(string))); 
			this.Columns.Add(new System.Data.DataColumn("Pooling", typeof(bool))); 
			this.Columns.Add(new System.Data.DataColumn("MaxPoolSize", typeof(int))); 			
		}
	}
}
