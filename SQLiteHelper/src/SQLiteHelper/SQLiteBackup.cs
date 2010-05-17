/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 5/17/2010
 * Time: 4:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.SqliteClient;
using Gtk;

namespace GoonTools
{
	/// <summary>
	/// Description of SQLiteBackup.
	/// </summary>
	public class SQLiteBackup
	{
		#region Private Properties
		
		private string _DatabaseURL = null;
		private SQLiteBackupType _CurrentBackupType = SQLiteBackupType.Both;
		
		#endregion Private Properties
		
		#region Public Properties
		
		public string DatabaseURL
		{
			set{_DatabaseURL = value;}
			get{return _DatabaseURL;}
		}
		
		public SQLiteBackupType CurrentBackupType
		{
			set{_CurrentBackupType = value;}
			get{return _CurrentBackupType;}
		}
		
		#endregion Public Properties
		
		#region Class Constructors
		
		public SQLiteBackup(string dbURL)
		{
			_DatabaseURL = dbURL;
		}
		
		public SQLiteBackup(string dbURL, SQLiteBackupType BackupType)
		{
			_DatabaseURL = dbURL;
			_CurrentBackupType = BackupType;
		}
		
		#endregion Class Constructors
		
		#region Public Methods
		
		public bool WriteBackupFile(string FilePath, SQLiteBackupType BackupType)
		{
			_CurrentBackupType = BackupType;
			return WriteBackupFile(FilePath);
		}
		
		public bool WriteBackupFile(string FilePath)
		{
			bool blnSuccess = true;
			StreamWriter sw = null;
			try
			{
				if (File.Exists (FilePath))
					File.Delete (FilePath);
				
				sw = new StreamWriter (FilePath, false);
				sw.Write(GetBackupString());
			}
			
			catch (Exception ex)
			{
				blnSuccess = false;
				throw new Exception (ex.ToString ());
			}
			finally
			{				
				sw.Flush ();
				sw.Close ();
				sw.Dispose ();
			}
			return blnSuccess;
		}
		
		public string GetBackupString()
		{
			if (String.IsNullOrEmpty (_DatabaseURL))
				throw new Exception ("Database File Location not set.");
			
			if (!File.Exists (_DatabaseURL))
				throw new FileNotFoundException ("Database File Location does not exist. " + Environment.NewLine + " Supplied Location: " + _DatabaseURL);
			
			SQLiteHelper slh = new SQLiteHelper(_DatabaseURL);
			System.Text.StringBuilder sbBase = new System.Text.StringBuilder();
			try
			{
				ArrayList ar = new ArrayList ();
				sbBase.Append(" -- ######################## BEGIN TABLE SQL ######################## -- " + System.Environment.NewLine);
				DataTable dt = slh.ExecuteDataTable ("SELECT name, sql FROM sqlite_master WHERE type='table' and name <> 'sqlite_sequence' ORDER BY name;");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ar.Add (dt.Rows[i]["name"].ToString ());
					sbBase.Append (dt.Rows[i]["sql"].ToString () + Environment.NewLine + Environment.NewLine);
				}
				dt.Clear ();
				sbBase.Append (Environment.NewLine + " -- ######################## END TABLE SQL ######################### -- " + Environment.NewLine);
				
				sbBase.Append (Environment.NewLine + " -- ######################## BEGIN INDEX SQL ######################## -- " + Environment.NewLine);
				
				dt = slh.ExecuteDataTable ("SELECT name, sql FROM sqlite_master WHERE type='index' ORDER BY name;");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					sbBase.Append (dt.Rows[i]["sql"].ToString () + Environment.NewLine);
				}
				dt.Clear ();
				sbBase.Append (Environment.NewLine + " -- ######################## END INDEX SQL ######################### -- " + Environment.NewLine);
				
				sbBase.Append (Environment.NewLine + " -- ######################## BEGIN VIEW SQL ######################## -- " + Environment.NewLine);
				
				dt = slh.ExecuteDataTable ("SELECT name, sql FROM sqlite_master WHERE type='view' ORDER BY name;");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					sbBase.Append(dt.Rows[i]["sql"].ToString () + Environment.NewLine);
				}
				dt.Clear ();
				
				sbBase.Append (Environment.NewLine + " -- ######################## END VIEW SQL ######################### -- " + Environment.NewLine);
				
				sbBase.Append (Environment.NewLine + " -- ######################## BEGIN TRIGGER SQL ######################## -- " + Environment.NewLine);
				
				dt = slh.ExecuteDataTable ("SELECT name, sql FROM sqlite_master WHERE type='trigger' ORDER BY name;");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					sbBase.Append(dt.Rows[i]["sql"].ToString () + Environment.NewLine);
				}
				dt.Clear ();
				
				sbBase.Append (Environment.NewLine + " -- ######################## END TRIGGER SQL ######################### -- " + Environment.NewLine);
				
				sbBase.Append (Environment.NewLine + " -- ######################## BEGIN DATA SQL ######################## -- " + Environment.NewLine);
				
				string BaseInsert = "INSERT INTO -TABLENAME- (-COLUMNS-) VALUES (-VALUES-);";
				System.Text.StringBuilder sb = new System.Text.StringBuilder ();
				System.Text.StringBuilder sbValues = new System.Text.StringBuilder ();
				for (int i = 0; i < ar.Count; i++)
				{
					dt = slh.ExecuteDataTable ("SELECT * FROM " + ar[i].ToString () + " ;");
					// construct the insert portion
					for (int j = 0; j < dt.Columns.Count; j++)
					{
						sb.Append (dt.Columns[j].ColumnName + ", ");
					}
					// get rid of the last comma
					sb.Remove (sb.Length - 2, 2);
					for (int j = 0; j < dt.Rows.Count; j++)
					{
						for (int k = 0; k < dt.Columns.Count; k++)
						{
							switch (dt.Columns[k].DataType.ToString ())
							{
								case "System.String":
								case "System.Xml":
								case "System.Guid":
									sbValues.Append ("'" + dt.Rows[j][k].ToString () + "', ");
									break;
								case "System.Decimal":
								case "System.Double":
								case "System.Currency":
								case "System.Int16":
								case "System.Int32":
								case "System.Int64":
								case "System.UInt16":
								case "System.UInt32":
								case "System.UInt64":
									sbValues.Append (dt.Rows[j][k].ToString () + ", ");
									break;
									
								case "System.Date":
								case "System.DateTime":
								case "System.Time":
									sbValues.Append (slh.ToSQLiteDateTime (dt.Rows[j][k].ToString ()) + ", ");
									break;
									
								case "System.Boolean":
									sbValues.Append ("'" + dt.Rows[j][k].ToString () + "', ");
									break;
								default:
									sbValues.Append ("'" + dt.Rows[j][k].ToString () + "', ");
									break;
							}
						}
						// get rid of the last comma
						if (sbValues.Length > 1)
							sbValues.Remove (sbValues.Length - 2, 2);
						
						sbBase.Append (BaseInsert.Replace ("-TABLENAME-", ar[i].ToString ()).Replace ("-COLUMNS-", sb.ToString ()).Replace ("-VALUES-", sbValues.ToString ()));
						sbValues.Remove (0, sbValues.Length);
					}
					sbBase.Append (Environment.NewLine);
					if (sb.Length > 0)
						sb.Remove (0, sb.Length);
				}
				sbBase.Append (Environment.NewLine + " -- ######################## END DATA SQL ########################## -- " + Environment.NewLine);
				
				
			}
			catch (Exception ex)
			{
				throw new Exception (ex.ToString ());
			}
			
			return sbBase.ToString();
		}
		
		#endregion Public Methods
	}
	
	public enum SQLiteBackupType
	{
		None,
		Data,
		Schema,
		Both
	}
}
