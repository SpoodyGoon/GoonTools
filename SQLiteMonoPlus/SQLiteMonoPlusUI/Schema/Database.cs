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
		public IndexCollection Indexes = new IndexCollection();
		public Database (string DBFile)
		{
			_DatabaseFile = DBFile;
			try
			{
				if(!File.Exists(_DatabaseFile))
					throw new FileNotFoundException("Unable to find database file.", _DatabaseFile);
				
				if(!Common.DatabaseTryConnect(_DatabaseFile))
					throw new SqliteExecutionException("Unable to connect to database: " + _DatabaseFile);
				
				DBObjectsClear();
				LoadDBObjects(DBObjectsGet());
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private void LoadPragmas()
		{
            SqliteConnection sqlCN = new SqliteConnection(_DatabaseFile);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.TablesGet, sqlCN);
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            SqliteDataReader sqlReader = null;
            try
            {
            	sqlCN.Open();
            	while(sqlReader.Read())
            	{
            		
            	}
            	sqlReader.Close();
            	sqlCN.Close();
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
			finally
			{
				if(sqlReader != null)
				{
					if(!sqlReader.IsClosed)
						sqlReader.Close();
					
					sqlReader.Dispose();
				}
				
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				sqlCN.Dispose();
				sqlCMD.Dispose();
				
			}
			return dt;
		}
		
		private void LoadDBObjects(DataTable dt)
		{
			try
			{
				DataView dv = dt.DefaultView;
				dv.RowFilter = "Type = 'table'";
				dv.Sort = "TableName ASC";
				Table tbl;
				foreach(DataRowView drv = dv)
				{
					tbl = new Table(drv["ObjectName"].ToString().Trim(), drv["SQL"].ToString().Trim());
					this.Tables.Add(tbl);
				}
				
				dv.RowFilter = "Type = 'index'";
				dv.Sort = "TableName ASC, ObjectName ASC";
				Index idx;
				foreach(DataRowView drv = dv)
				{
					idx = new Index(drv["ObjectName"].ToString().Trim(), drv["SQL"].ToString().Trim(), drv["TableName"].ToString().Trim());
					this.Indexes.Add(idx);
				}
				
				dv.RowFilter = "Type = 'view'";
				dv.Sort = "TableName ASC, ObjectName ASC";
				View vw
				foreach(DataRowView drv = dv)
				{
					vw = new View(drv["ObjectName"].ToString().Trim(), drv["SQL"].ToString().Trim());
					this.Views.Add(vw);
				}
				
				// TODO: add in triggers
//				dv.RowFilter = "Type = 'trigger'";
//				dv.Sort = "TableName ASC, ObjectName ASC";
//				View vw
//				foreach(DataRowView drv = dv)
//				{
//					vw = new View(drv["ObjectName"].ToString().Trim(), drv["SQL"].ToString().Trim());
//					this.Views.Add(vw);
//				}
				
				
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private DataTable DBObjectsGet()
		{
            SqliteConnection sqlCN = new SqliteConnection(_DatabaseFile);
            SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.TablesGet, sqlCN);
            sqlCMD.CommandType = CommandType.Text;
            sqlCMD.CommandTimeout = 300;
            SqliteDataAdapter sqlDA = new SqliteDataAdapter(sqlCMD);
            DataTable dt = new DataTable("DBObjects");
            try
            {
            	sqlDA.Fill(dt);
            }
            catch (Exception ex)
            {
                Common.HandleError(ex);
            }
			finally
			{
				if(sqlCN.State != ConnectionState.Closed)
					sqlCN.Close();
				sqlCN.Dispose();
				sqlCMD.Dispose();
				sqlDA.Dispose();
			}
			return dt;
		}
		
		private void DBObjectsClear()
		{
			Tables.Clear();
			ForeignKeys.Clear();
			Views.Clear();
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

