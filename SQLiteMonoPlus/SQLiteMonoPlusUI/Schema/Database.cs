using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.SqliteClient;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI.Schema
{
	public class Database
	{
		private string _DatabaseFile = string.Empty;
		public string DatabaseName = string.Empty;
		private string _ConnectionString = string.Empty;
		public Dictionary<string, string> Pragmas = new Dictionary<string, string> ();
		public TableCollection Tables = new TableCollection ();
		public ForeignKeyCollection ForeignKeys = new ForeignKeyCollection ();
		public ViewCollection Views = new ViewCollection ();
		// TODO: move the list of pragmas to a config file
		public string[] PragmaList = new string[] {
				"auto_vacuum",
				"automatic_index",
				"cache_size",
				"case_sensitive_like",
				"checkpoint_fullfsync",
				"collation_list",
				"compile_options",
				"database_list",
				"encoding",
				"foreign_key_list",
				"foreign_keys",
				"freelist_count",
				"fullfsync",
				"ignore_check_constraints",
				"incremental_vacuum",
				"index_info",
				"index_list",
				"integrity_check",
				"journal_mode",
				"journal_size_limit",
				"legacy_file_format",
				"locking_mode",
				"max_page_count",
				"page_count",
				"page_size",
				"quick_check",
				"read_uncommitted",
				"recursive_triggers",
				"reverse_unordered_selects",
				"schema_version",
				"secure_delete",
				"shrink_memory",
				"synchronous",
				"table_info",
				"temp_store",
				"user_version",
				"wal_autocheckpoint",
				"wal_checkpoint",
				"writable_schema"
			};
		public string[] DatabasePragmaList = new string[] {
				"auto_vacuum",
				"automatic_index",
				"cache_size",
				"case_sensitive_like",
				"checkpoint_fullfsync",
				"encoding",
				"foreign_keys",
				"ignore_check_constraints",
				"journal_mode",
				"journal_size_limit",
				"legacy_file_format",
				"locking_mode",
				"max_page_count",
				"page_size",
				"quick_check",
				"read_uncommitted",
				"recursive_triggers",
				"reverse_unordered_selects",
				"schema_version",
				"secure_delete",
				"synchronous",
				"temp_store",
				"user_version",
				"wal_autocheckpoint",
				"wal_checkpoint",
				"writable_schema"
			};
		// TODO: move keyword list to a config file
		public string[] KeywordList = new string[] {
				"ABORT",
				"ACTION",
				"ADD",
				"AFTER",
				"ALL",
				"ALTER",
				"ANALYZE",
				"AND",
				"AS",
				"ASC",
				"ATTACH",
				"AUTOINCREMENT",
				"BEFORE",
				"BEGIN",
				"BETWEEN",
				"BY",
				"CASCADE",
				"CASE",
				"CAST",
				"CHECK",
				"COLLATE",
				"COLUMN",
				"COMMIT",
				"CONFLICT",
				"CONSTRAINT",
				"CREATE",
				"CROSS",
				"CURRENT_DATE",
				"CURRENT_TIME",
				"CURRENT_TIMESTAMP",
				"DATABASE",
				"DEFAULT",
				"DEFERRABLE",
				"DEFERRED",
				"DELETE",
				"DESC",
				"DETACH",
				"DISTINCT",
				"DROP",
				"EACH",
				"ELSE",
				"END",
				"ESCAPE",
				"EXCEPT",
				"EXCLUSIVE",
				"EXISTS",
				"EXPLAIN",
				"FAIL",
				"FOR",
				"FOREIGN",
				"FROM",
				"FULL",
				"GLOB",
				"GROUP",
				"HAVING",
				"IF",
				"IGNORE",
				"IMMEDIATE",
				"IN",
				"INDEX",
				"INDEXED",
				"INITIALLY",
				"INNER",
				"INSERT",
				"INSTEAD",
				"INTERSECT",
				"INTO",
				"IS",
				"ISNULL",
				"JOIN",
				"KEY",
				"LEFT",
				"LIKE",
				"LIMIT",
				"MATCH",
				"NATURAL",
				"NO",
				"NOT",
				"NOTNULL",
				"NULL",
				"OF",
				"OFFSET",
				"ON",
				"OR",
				"ORDER",
				"OUTER",
				"PLAN",
				"PRAGMA",
				"PRIMARY",
				"QUERY",
				"RAISE",
				"REFERENCES",
				"REGEXP",
				"REINDEX",
				"RELEASE",
				"RENAME",
				"REPLACE",
				"RESTRICT",
				"RIGHT",
				"ROLLBACK",
				"ROW",
				"SAVEPOINT",
				"SELECT",
				"SET",
				"TABLE",
				"TEMP",
				"TEMPORARY",
				"THEN",
				"TO",
				"TRANSACTION",
				"TRIGGER",
				"UNION",
				"UNIQUE",
				"UPDATE",
				"USING",
				"VACUUM",
				"VALUES",
				"VIEW",
				"VIRTUAL",
				"WHEN",
				"WHERE"
			};

		public Database (string DBFile)
		{
			_DatabaseFile = DBFile;
		}
		
		public void LoadSchema ()
		{
			try {
				FileInfo fi = new FileInfo (_DatabaseFile);
				
				if (!fi.Exists)
					throw new FileNotFoundException ("Unable to find database file.", fi.FullName);
				
				if (!Common.DatabaseTryConnect (fi.FullName))
					throw new SqliteExecutionException ("Unable to connect to database: " + fi.FullName);
				
				// create the connection string used
				// with this instance of the schema object
				_ConnectionString = Constants.ConnectionString.Simple.Replace ("[DBPATH]", fi.FullName);
				
				DatabaseName = fi.Name.Replace (fi.Extension, "");
					
				DBObjectsClear ();
				LoadDBObjects ();
				LoadTableColumns ();
				LoadIndexColumns ();
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
			
		}
		
		private void LoadPragmas ()
		{
			SqliteConnection sqlCN = new SqliteConnection (_ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = 300;
			SqliteDataReader sqlReader = null;
			try 
			{
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
            	
				for (int i = 0; i < DatabasePragmaList.Length; i++) {
					sqlCMD.CommandText = GlobalData.SQL.PragmaGeneric.Replace ("[PragmaName]", DatabasePragmaList [i]);
					while (sqlReader.Read()) {
	            		
					}
				}
				sqlReader.Close ();
				sqlCN.Close ();
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
			finally {
				if (sqlReader != null) {
					if (!sqlReader.IsClosed)
						sqlReader.Close ();
					
					sqlReader.Dispose ();
				}
				
				if (sqlCN.State != ConnectionState.Closed)
					sqlCN.Close ();
				sqlCN.Dispose ();
				sqlCMD.Dispose ();
				
			}
		}
		
		private void DBObjectsClear ()
		{
			Tables.Clear ();
			ForeignKeys.Clear ();
			Views.Clear ();
		}
		
		private void LoadDBObjects ()
		{
			try {
				DataTable dt = DBObjectsGet ();
				DataView dv = dt.DefaultView;
				dv.RowFilter = "ObjectType = 'table'";
				dv.Sort = "TableName ASC";
				Table tbl;
				foreach (DataRowView drv in dv) {
					tbl = new Table (drv ["ObjectName"].ToString ().Trim (), drv ["SQL"].ToString ().Trim ());
					this.Tables.Add (tbl);
				}
				
				dv.RowFilter = "ObjectType = 'index'";
				dv.Sort = "TableName ASC, ObjectName ASC";
				Index idx;
				foreach (DataRowView drv in dv) {
					tbl = Tables [drv ["TableName"].ToString ().Trim ()];
					idx = new Index (drv ["ObjectName"].ToString ().Trim (), drv ["SQL"].ToString ().Trim (), tbl.TableName);
					tbl.Indexes.Add (idx);
				}
				
				dv.RowFilter = "ObjectType = 'view'";
				dv.Sort = "TableName ASC, ObjectName ASC";
				View vw;
				foreach (DataRowView drv in dv) {
					vw = new View (drv ["ObjectName"].ToString ().Trim (), drv ["SQL"].ToString ().Trim ());
					this.Views.Add (vw);
				}
				
				dv.RowFilter = "ObjectType = 'trigger'";
				dv.Sort = "TableName ASC, ObjectName ASC";
				Trigger tgr;
				foreach (DataRowView drv in dv) {
					tbl = Tables [drv ["TableName"].ToString ().Trim ()];
					tgr = new Trigger (drv ["ObjectName"].ToString ().Trim (), drv ["SQL"].ToString ().Trim (), tbl.TableName);
					tbl.Triggers.Add (tgr);
				}
				
				
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
		}
		
		private DataTable DBObjectsGet ()
		{
			SqliteConnection sqlCN = new SqliteConnection (_ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand (GlobalData.SQL.TablesGet, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = 300;
			SqliteDataAdapter sqlDA = new SqliteDataAdapter (sqlCMD);
			DataTable dt = new DataTable ("DBObjects");
			try {
				sqlDA.Fill (dt);
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
			finally {
				if (sqlCN.State != ConnectionState.Closed)
					sqlCN.Close ();
				sqlCN.Dispose ();
				sqlCMD.Dispose ();
				sqlDA.Dispose ();
			}
			return dt;
		}

		private void LoadTableColumns ()
		{
			SqliteConnection sqlCN = new SqliteConnection (_ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			SqliteDataReader sqlReader = null;
			try {
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
				foreach(Table t in this.Tables) 
				{
					sqlCMD.CommandText = GlobalData.SQL.PragmaTableInfo.Replace ("[TableName]", t.TableName);
					sqlCMD.CommandType = CommandType.Text;
					sqlCMD.CommandTimeout = 300;
					sqlReader = sqlCMD.ExecuteReader ();
					while (sqlReader.Read()) 
					{
						t.Columns.Add (new Column (Convert.ToInt32 (sqlReader ["cid"]), sqlReader ["name"].ToString (), sqlReader ["type"].ToString (), sqlReader ["notnull"].ToString () == "0" ? true : false, (object)sqlReader ["dflt_value"], Convert.ToBoolean (sqlReader ["pk"])));
					}
				}
				sqlReader.Close ();
				sqlCN.Close ();
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
		}

		private void LoadIndexColumns ()
		{
			SqliteConnection sqlCN = new SqliteConnection (_ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			SqliteDataReader sqlReader = null;
			try 
			{
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
				foreach (Table t in this.Tables) 
				{
					foreach (Index ix in t.Indexes) 
					{
						sqlCMD.CommandText = GlobalData.SQL.PragmaTableInfo.Replace ("[IndexName]", ix.IndexName);
						sqlCMD.CommandType = CommandType.Text;
						sqlCMD.CommandTimeout = 300;
						sqlReader = sqlCMD.ExecuteReader ();
						while (sqlReader.Read()) 
						{
							ix.IndexColumns.Add((Column)t.Columns[sqlReader["name"].ToString()]);
						}
					}
				
				}
				sqlReader.Close ();
				sqlCN.Close ();
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
		}

		private void LoadViewColumns ()
		{
			SqliteConnection sqlCN = new SqliteConnection (_ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			SqliteDataReader sqlReader = null;
			try 
			{
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
				foreach (Table t in this.Tables) 
				{
					foreach (Index ix in t.Indexes) 
					{
						sqlCMD.CommandText = GlobalData.SQL.PragmaTableInfo.Replace ("[IndexName]", ix.IndexName);
						sqlCMD.CommandType = CommandType.Text;
						sqlCMD.CommandTimeout = 300;
						sqlReader = sqlCMD.ExecuteReader ();
						while (sqlReader.Read()) 
						{
							ix.IndexColumns.Add((Column)t.Columns[sqlReader["name"].ToString()]);
						}
					}
				
				}
				sqlReader.Close ();
				sqlCN.Close ();
			}
			catch (Exception ex) {
				Common.HandleError (ex);
			}
		}
	}

	public enum SQLiteDataType
	{
		Integer,
		Bool,
		Varchar,
		Double,
		Text,
		Blob,
		Real,
		DateTime,
		None
	}
}

