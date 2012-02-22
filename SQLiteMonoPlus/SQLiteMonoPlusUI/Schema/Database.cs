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
		public Dictionary<string, string> Pragmas = new Dictionary<string, string> ();
		public TableCollection Tables = new TableCollection ();
		public ForeignKeyCollection ForeignKeys = new ForeignKeyCollection();
		public ViewCollection Views = new ViewCollection();
		public Database (string DBFile)
		{
			_DatabaseFile = DBFile;
			if(File.Exists(_DatabaseFile))
			{
				LoadTables();
                //for(int i = 0; i < dt.Rows.Count; i ++)
                //{
                //    // TODO load the rest of the data via Pragma
                //}
			}
		}
		
		private void LoadTables()
        {
            SqliteConnection sqlCN = new SqliteConnection(_DatabaseFile);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.TablesGet, sqlCN);
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            SqliteDataReader sqlReader = null;
            try
            {
                Table t;
                sqlCN.Open();
                sqlReader = sqlCMD.ExecuteReader();
                while (sqlReader.Read())
                {
                    t = new Table(sqlReader["TableName"].ToString());
                    this.Tables.Add(t);
                }
                sqlReader.Close();
                sqlCN.Close();
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
		}

        private void LoadTableDetails()
        {
            SqliteConnection sqlCN = new SqliteConnection(_DatabaseFile);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.TableDetailsGet, sqlCN);
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            SqliteDataReader sqlReader = null;
            try
            {
                sqlCN.Open();
                sqlReader = sqlCMD.ExecuteReader();
                while (sqlReader.Read())
                {
                }
                sqlReader.Close();
                sqlCN.Close();
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
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

