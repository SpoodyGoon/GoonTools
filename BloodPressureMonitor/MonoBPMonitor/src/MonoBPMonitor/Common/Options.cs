/*************************************************************************
 *                      Options.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.Collections;
using System.Data;

namespace GoonTools.Helper
{
	[Serializable]
	public class Options
	{
		// for the dblocationand connection string the default locations
		// are very likely to be the perminant locations
		private string _ConnString = "URI=file:" +  System.IO.Path.Combine(GoonTools.Common.EnvData.SavePath , "BPMonitor.s3db" ) + ",version=3, busy_timeout=3000";
		private string _DBLocation = System.IO.Path.Combine(GoonTools.Common.EnvData.SavePath, "BPMonitor.s3db");
		private bool _SaveErrorLog = true; // this is just a flag to save the error to the save directory
		private bool _LimitHistory = true; 
		private int _HistoryDefaultShow = 30; // this is the amount of history we want to show
		private bool _BackupSchema = true;
		private bool _BackupData = true;
		private bool _BackupOptions = true;
		private bool _BackupLogs = true;
		private string _CustomTheme = "System";
		private string _CustomThemeLocation = "System";
		private int _FileVersion = 1; // the file version does not nessicarily match the application version
		public Options()
		{
		}
		
		public Options(System.Collections.Hashtable hsh)
		{
			if(hsh.Contains("FileVersion"))
				_FileVersion = Convert.ToInt16(hsh["FileVersion"]);
			if(hsh.Contains("ConnString"))
				_ConnString = hsh["ConnString"].ToString();
			if(hsh.Contains("DBLocation"))
				_DBLocation = hsh["DBLocation"].ToString();
			if(hsh.Contains("SaveErrorLog"))
				_SaveErrorLog = Convert.ToBoolean(hsh["SaveErrorLog"]);
			if(hsh.Contains("LimitHistory"))
				_LimitHistory = Convert.ToBoolean(hsh["LimitHistory"]);
			if(hsh.Contains("HistoryDefaultShow"))
				_HistoryDefaultShow = Convert.ToInt32(hsh["HistoryDefaultShow"]);
			if(hsh.Contains("BackupSchema"))
				_BackupSchema = Convert.ToBoolean(hsh["BackupSchema"]);
			if(hsh.Contains("BackupData"))
				_BackupData = Convert.ToBoolean(hsh["BackupData"]);
			if(hsh.Contains("BackupOptions"))
				_BackupOptions = Convert.ToBoolean(hsh["BackupOptions"]);
			if(hsh.Contains("BackupLogs"))
				_BackupLogs = Convert.ToBoolean(hsh["BackupLogs"]);
		}
		
		public Options(DataTable dt)
		{
			if(dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
				throw new Exception("Invalid Table Passed to load Options");			
			dt.PrimaryKey = new DataColumn[]{(DataColumn)dt.Columns["Key"]};
			DataRow dr;
			
			dr = (DataRow)dt.Rows.Find("FileVersion");
			if(dr != null)
				_FileVersion = Convert.ToInt16(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("ConnString");
			if(dr != null)
				_ConnString = dr["Value"].ToString();			
			dr = (DataRow)dt.Rows.Find("DBLocation");
			if(dr != null)
				_DBLocation = dr["Value"].ToString();			
			dr = (DataRow)dt.Rows.Find("SaveErrorLog");
			if(dr != null)
				_SaveErrorLog = Convert.ToBoolean(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("LimitHistory");
			if(dr != null)
				_LimitHistory = Convert.ToBoolean(dr["Value"]);				
			dr = (DataRow)dt.Rows.Find("HistoryDefaultShow");
			if(dr != null)
				_HistoryDefaultShow = Convert.ToInt32(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("BackupSchema");
			if(dr != null)
				_BackupSchema = Convert.ToBoolean(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("BackupData");
			if(dr != null)
				_BackupData = Convert.ToBoolean(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("BackupOptions");
			if(dr != null)
				_BackupOptions = Convert.ToBoolean(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("BackupLogs");
			if(dr != null)
				_BackupLogs = Convert.ToBoolean(dr["Value"]);
		}
		
		public System.Collections.Hashtable ToHashtable()
		{
			System.Collections.Hashtable hsh = new System.Collections.Hashtable();
			hsh.Add("FileVersion", _FileVersion);
			hsh.Add("ConnString", _ConnString);
			hsh.Add("DBLocation", _DBLocation);
			hsh.Add("SaveErrorLog", _SaveErrorLog);
			hsh.Add("LimitHistory", _LimitHistory);
			hsh.Add("HistoryDefaultShow", _HistoryDefaultShow);
			hsh.Add("BackupSchema", _BackupSchema);
			hsh.Add("BackupData", _BackupData);
			hsh.Add("BackupOptions", _BackupOptions);
			hsh.Add("BackupLogs", _BackupLogs);
			hsh.Add("CustomTheme", _CustomTheme);
			hsh.Add("CustomThemeLocation", _CustomThemeLocation);
			return hsh;
		}
		
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("Options");
			dt.Columns.AddRange(new DataColumn[] { new DataColumn("Key", typeof(string)), new DataColumn("Value", typeof(object))});
			dt.PrimaryKey = new DataColumn[]{dt.Columns["Key"]};
			System.Data.DataRow dr = dt.NewRow();
			dr["Key"] = "FileVersion";
			dr["Value"] = _FileVersion;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "ConnString";
			dr["Value"] = _ConnString;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "DBLocation";
			dr["Value"] = _DBLocation;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "SaveErrorLog";
			dr["Value"] = _SaveErrorLog;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "LimitHistory";
			dr["Value"] = _LimitHistory;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "HistoryDefaultShow";
			dr["Value"] = _HistoryDefaultShow;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "BackupSchema";
			dr["Value"] = _BackupSchema;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "BackupData";
			dr["Value"] = _BackupData;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "BackupOptions";
			dr["Value"] = _BackupOptions;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "BackupLogs";
			dr["Value"] = _BackupLogs;
			dt.Rows.Add(dr);
			return dt;
		}
		
		public void RefreshAll(System.Collections.Hashtable hsh)
		{
			if(hsh.Contains("FileVersion"))
				_FileVersion = Convert.ToInt16(hsh["FileVersion"]);
			if(hsh.Contains("ConnString"))
				_ConnString = hsh["ConnString"].ToString();
			if(hsh.Contains("DBLocation"))
				_DBLocation = hsh["DBLocation"].ToString();
			if(hsh.Contains("SaveErrorLog"))
				_SaveErrorLog = Convert.ToBoolean(hsh["SaveErrorLog"]);
			if(hsh.Contains("LimitHistory"))
				_LimitHistory = Convert.ToBoolean(hsh["LimitHistory"]);
			if(hsh.Contains("HistoryDefaultShow"))
				_HistoryDefaultShow = Convert.ToInt32(hsh["HistoryDefaultShow"]);
			if(hsh.Contains("BackupSchema"))
				_BackupSchema = Convert.ToBoolean(hsh["BackupSchema"]);
			if(hsh.Contains("BackupData"))
				_BackupData = Convert.ToBoolean(hsh["BackupData"]);
			if(hsh.Contains("BackupOptions"))
				_BackupOptions = Convert.ToBoolean(hsh["BackupOptions"]);
			if(hsh.Contains("BackupLogs"))
				_BackupLogs = Convert.ToBoolean(hsh["BackupLogs"]);
			if(hsh.Contains("CustomTheme"))
				_CustomTheme = hsh["CustomTheme"].ToString();
			if(hsh.Contains("CustomThemeLocation"))
				_CustomThemeLocation = hsh["CustomThemeLocation"].ToString();
		}
		
		public string ConnString
		{
			set{ _ConnString = value;}
			get{ return _ConnString;}
		}
		
		public string DBLocation
		{
			set{ _DBLocation = value;}
			get{ return _DBLocation;}
		}
		
		public bool SaveErrorLog
		{
			set{ _SaveErrorLog = value;}
			get{ return _SaveErrorLog;}
		}
		
		public bool LimitHistory
		{
			set{ _LimitHistory = value;}
			get{ return _LimitHistory;}
		}
		
		public int HistoryDefaultShow
		{
			set{ _HistoryDefaultShow = value;}
			get{ return _HistoryDefaultShow;}
		}
		
		public int FileVersion
		{
			set{ _FileVersion = value;}
			get{ return _FileVersion;}
		}
		
		public bool BackupSchema
		{
			set{ _BackupSchema = value;}
			get{ return _BackupSchema;}
		}
		
		public bool BackupData
		{
			set{ _BackupData = value;}
			get{ return _BackupData;}
		}
		
		public bool BackupOptions
		{
			set{ _BackupOptions = value;}
			get{ return _BackupOptions;}
		}
		
		public bool BackupLogs
		{
			set{ _BackupLogs = value;}
			get{ return _BackupLogs;}
		}
		
		public string CustomTheme
		{
			set{ _CustomTheme = value;}
			get{ return _CustomTheme;}
		}
		
		public string CustomThemeLocation
		{
			set{ _CustomThemeLocation = value;}
			get{ return _CustomThemeLocation;}
		}
	}
	
}
