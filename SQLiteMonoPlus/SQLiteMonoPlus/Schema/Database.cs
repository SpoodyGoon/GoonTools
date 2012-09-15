using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.SqliteClient;
using SQLiteMonoPlus.Data.Schema;

namespace SQLiteMonoPlus.Schema
{
	public class Database
	{
		public Connection DBConnection;
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

		public Database (Connection DBConn)
		{
			DBConnection = DBConn;
		}
		
		public void LoadSchema ()
		{
				DBObjectsClear ();
				LoadPragmas ();
				LoadDBObjects ();
				LoadTableColumns ();
				LoadIndexDetails ();
				LoadForeignKeys ();
		}
		
		private void LoadPragmas ()
		{
			SqliteConnection sqlCN = new SqliteConnection (DBConnection.ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = 300;
			SqliteDataReader sqlReader = null;
				Pragmas.Clear ();
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
            	
				for (int i = 0; i < DatabasePragmaList.Length; i++) {
					sqlCMD.CommandText = Pragma.PragmaBase.Replace ("[PragmaName]", DatabasePragmaList [i]);
					sqlCMD.CommandType = CommandType.Text;
					sqlCMD.CommandTimeout = 300;
					sqlReader = sqlCMD.ExecuteReader ();
					if (sqlReader.HasRows) {
						while (sqlReader.Read()) {
							Pragmas.Add (DatabasePragmaList [i], sqlReader [0].ToString ());
							System.Diagnostics.Debug.WriteLine (DatabasePragmaList [i] + " - " + sqlReader [0].ToString ());
						}
					}
				}
				
				if(sqlReader != null)
					sqlReader.Close ();
				sqlCN.Close ();
		}
		
		private void DBObjectsClear ()
		{
			Tables.Clear ();
			ForeignKeys.Clear ();
			Views.Clear ();
		}
		
		private void LoadDBObjects ()
		{
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
		
		private DataTable DBObjectsGet ()
		{
			SqliteConnection sqlCN = new SqliteConnection (DBConnection.ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand (AdminSQL.TablesGet, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = 300;
			SqliteDataAdapter sqlDA = new SqliteDataAdapter (sqlCMD);
			DataTable dt = new DataTable ("DBObjects");
				sqlDA.Fill (dt);
			return dt;
		}

		private void LoadTableColumns ()
		{
			SqliteConnection sqlCN = new SqliteConnection (DBConnection.ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			SqliteDataReader sqlReader = null;
			sqlCMD.Connection = sqlCN;
			sqlCN.Open ();
			foreach (Table t in this.Tables) {
				sqlCMD.CommandText = Pragma.TableInfo.Replace("[TableName]", t.TableName);
				sqlCMD.CommandType = CommandType.Text;
				sqlCMD.CommandTimeout = 300;
				sqlReader = sqlCMD.ExecuteReader ();
				while (sqlReader.Read()) {
					t.Columns.Add (new Column (Convert.ToInt32 (sqlReader ["cid"]), sqlReader ["name"].ToString (), sqlReader ["type"].ToString (), sqlReader ["notnull"].ToString () == "0" ? true : false, (object)sqlReader ["dflt_value"], Convert.ToBoolean (sqlReader ["pk"])));
				}
				sqlCMD.Parameters.Clear();
			}

			if(sqlReader!= null)
				sqlReader.Close ();
			sqlCN.Close ();
		}

		private void LoadForeignKeys ()
		{
			SqliteConnection sqlCN = new SqliteConnection (DBConnection.ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			SqliteDataReader sqlReader = null;
				ForeignKey fk;
				Column col;
				ForeignKeyAction tmpAction;
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
				foreach (Table t in this.Tables) {
					sqlCMD.CommandText = Pragma.ForeignKeyList.Replace ("[TableName]", t.TableName);
					sqlCMD.CommandType = CommandType.Text;
					sqlCMD.CommandTimeout = 300;
					sqlReader = sqlCMD.ExecuteReader ();
					while (sqlReader.Read()) {
						fk = new ForeignKey();
						col = (Column)t.Columns [sqlReader ["from"].ToString ()];
						fk.PKColumn = col;
						col.ForeingKey =true;
						fk.FKTable = (Table)this.Tables [sqlReader ["table"].ToString ()];
						col = (Column)fk.FKTable.Columns [sqlReader ["to"].ToString ()];
						fk.FKColumn = col;
						col.ForeingKey = true;
						if(ForeignKeyAction.TryParse(sqlReader["on_update"].ToString(), out tmpAction))
						   fk.OnUpdate = tmpAction;
						if(ForeignKeyAction.TryParse(sqlReader["on_delete"].ToString(), out tmpAction))
						   fk.OnDelete = tmpAction;

						t.ForeignKeys.Add(fk);

					}			
				}
				if(sqlReader!= null)
					sqlReader.Close ();
				sqlCN.Close ();
		}

		private void LoadIndexDetails ()
		{
			SqliteConnection sqlCN = new SqliteConnection (DBConnection.ConnectionString);
			SqliteCommand sqlCMD = new SqliteCommand ();
			SqliteDataReader sqlReader = null;
				sqlCMD.Connection = sqlCN;
				sqlCN.Open ();
				foreach (Table t in this.Tables) {
					foreach (Index ix in t.Indexes) {
						sqlCMD.CommandText = Pragma.IndexInfo.Replace ("[IndexName]", ix.IndexName);
						sqlCMD.CommandType = CommandType.Text;
						sqlCMD.CommandTimeout = 300;
						sqlReader = sqlCMD.ExecuteReader ();
						while (sqlReader.Read()) {
							ix.IndexColumns.Add ((Column)t.Columns [sqlReader ["name"].ToString ()]);
						}
					}

					sqlCMD.CommandText = Pragma.IndexList.Replace ("[TableName]", t.TableName);
					sqlCMD.CommandType = CommandType.Text;
					sqlCMD.CommandTimeout = 300;
					sqlReader = sqlCMD.ExecuteReader ();
					while (sqlReader.Read()) {
						if (!sqlReader ["name"].ToString ().Contains ("sqlite_autoindex"))
							((Index)t.Indexes [sqlReader ["name"].ToString ()]).Unique = sqlReader ["unique"].ToString () == "1" ? true : false;
					}				
				}
				if(sqlReader!= null)
					sqlReader.Close ();
				sqlCN.Close ();
		}
	}
}

