using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;

namespace SQLiteMonoPlusUI.Schema
{
	public class Database
	{
		private string _DatabaseFile = string.Empty;
		public Dictionary<string, string> Pragmas = new Dictionary<string, string> ();
		public TableCollection Tables = new TableCollection ();
		public ForeignKeyCollection ForeignKeys = new ForeignKeyCollection();
		public ViewCollection Views = new ViewCollection();
		public Database (string DBFile)
		{
			_DatabaseFile = DBFile;
			if(File.Exists(_DatabaseFile))
			{
				DataTable dt = LoadTables();
				for(int i = 0; i < dt.Rows.Count; i ++)
				{
					// TODO load the rest of the data via Pragma
				}
			}
		}
		
		private DataTable LoadTables()
		{
			SqliteConnection sqlCN = new SqliteConnection(_DatabaseFile);
			SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.TablesGet, sqlCN);
			sqlCMD.CommandType = CommandType.Text;
			sqlCMD.CommandTimeout = 300;
			SqliteDataAdapter sqlDA = new SqliteDataAdapter(sqlCMD);
			DataTable dt = new DataTable();
			sqlDA.Fill(dt);
			return dt;
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

