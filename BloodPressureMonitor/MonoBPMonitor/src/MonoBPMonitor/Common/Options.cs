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
		private string _ConnString = "URI=file:" + System.IO.Path.Combine (GoonTools.Common.EnvData.SavePath, "BPMonitor.s3db") + ",version=3, busy_timeout=3000";
		private string _DBLocation = System.IO.Path.Combine (GoonTools.Common.EnvData.SavePath, "BPMonitor.s3db");
		private bool _SaveErrorLog = true;
		// this is just a flag to save the error to the save directory
		private bool _LimitHistory = true;
		private int _HistoryDefaultShow = 30;
		// this is the amount of history we want to show
		private bool _BackupSchema = true;
		private bool _BackupData = true;
		private bool _BackupOptions = true;
		private bool _BackupLogs = true;
		private string _CustomThemeName = "Elegance";
		private string _CustomThemeFile = "";
		private bool _UseCustomTheme = true;
		private int _FileVersion = 1;
		// the file version does not nessicarily match the application version
		public Options ()
		{
		}

		public Options (DataTable dt)
		{
			try {
				if (dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
					throw new Exception ("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[] { (DataColumn)dt.Columns["Key"] };
				DataRow dr;
				
				dr = (DataRow)dt.Rows.Find ("FileVersion");
				if (dr != null)
					_FileVersion = Convert.ToInt16 (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("ConnString");
				if (dr != null)
					_ConnString = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("DBLocation");
				if (dr != null)
					_DBLocation = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("SaveErrorLog");
				if (dr != null)
					_SaveErrorLog = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("CustomThemeName");
				if (dr != null)
					_CustomThemeName = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("CustomThemeFile");
				if (dr != null)
					_CustomThemeFile = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("UseCustomTheme");
				if (dr != null)
					_UseCustomTheme = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("LimitHistory");
				if (dr != null)
					_LimitHistory = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("HistoryDefaultShow");
				if (dr != null)
					_HistoryDefaultShow = Convert.ToInt32 (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupSchema");
				if (dr != null)
					_BackupSchema = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupData");
				if (dr != null)
					_BackupData = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupOptions");
				if (dr != null)
					_BackupOptions = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupLogs");
				if (dr != null)
					_BackupLogs = Convert.ToBoolean (dr["Value"]);
			} catch (Exception ex) {
				Common.HandleError (ex);
			}
		}

		public DataTable ToDataTable ()
		{
			DataTable dt = new DataTable ("Options");
			try {
				dt.Columns.AddRange (new DataColumn[] {
					new DataColumn ("Key", typeof(string)),
					new DataColumn ("Value", typeof(object))
				});
				dt.PrimaryKey = new DataColumn[] { dt.Columns["Key"] };
				System.Data.DataRow dr = dt.NewRow ();
				dr["Key"] = "FileVersion";
				dr["Value"] = _FileVersion;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "ConnString";
				dr["Value"] = _ConnString;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "DBLocation";
				dr["Value"] = _DBLocation;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "SaveErrorLog";
				dr["Value"] = _SaveErrorLog;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "CustomThemeName";
				dr["Value"] = _CustomThemeName;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "CustomThemeFile";
				dr["Value"] = _CustomThemeFile;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "UseCustomTheme";
				dr["Value"] = _UseCustomTheme;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "LimitHistory";
				dr["Value"] = _LimitHistory;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "HistoryDefaultShow";
				dr["Value"] = _HistoryDefaultShow;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "BackupSchema";
				dr["Value"] = _BackupSchema;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "BackupData";
				dr["Value"] = _BackupData;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "BackupOptions";
				dr["Value"] = _BackupOptions;
				dt.Rows.Add (dr);
				dr = dt.NewRow ();
				dr["Key"] = "BackupLogs";
				dr["Value"] = _BackupLogs;
				dt.Rows.Add (dr);
			} catch (Exception ex) {
				Common.HandleError (ex);
			}
			return dt;
		}

		public void RefreshAll (System.Data.DataTable dt)
		{
			try {
				if (dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
					throw new Exception ("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[] { (DataColumn)dt.Columns["Key"] };
				DataRow dr;
				
				dr = (DataRow)dt.Rows.Find ("FileVersion");
				if (dr != null)
					_FileVersion = Convert.ToInt16 (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("ConnString");
				if (dr != null)
					_ConnString = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("DBLocation");
				if (dr != null)
					_DBLocation = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("SaveErrorLog");
				if (dr != null)
					_SaveErrorLog = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("CustomThemeName");
				if (dr != null)
					_CustomThemeName = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("CustomThemeFile");
				if (dr != null)
					_CustomThemeFile = dr["Value"].ToString ();
				dr = (DataRow)dt.Rows.Find ("UseCustomTheme");
				if (dr != null)
					_UseCustomTheme = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("LimitHistory");
				if (dr != null)
					_LimitHistory = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("HistoryDefaultShow");
				if (dr != null)
					_HistoryDefaultShow = Convert.ToInt32 (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupSchema");
				if (dr != null)
					_BackupSchema = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupData");
				if (dr != null)
					_BackupData = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupOptions");
				if (dr != null)
					_BackupOptions = Convert.ToBoolean (dr["Value"]);
				dr = (DataRow)dt.Rows.Find ("BackupLogs");
				if (dr != null)
					_BackupLogs = Convert.ToBoolean (dr["Value"]);
			} catch (Exception ex) {
				Common.HandleError (ex);
			}
		}

		public string ConnString {
			get { return _ConnString; }
			set { _ConnString = value; }
		}

		public string DBLocation {
			get { return _DBLocation; }
			set { _DBLocation = value; }
		}

		public bool SaveErrorLog {
			get { return _SaveErrorLog; }
			set { _SaveErrorLog = value; }
		}

		public bool LimitHistory {
			get { return _LimitHistory; }
			set { _LimitHistory = value; }
		}

		public int HistoryDefaultShow {
			get { return _HistoryDefaultShow; }
			set { _HistoryDefaultShow = value; }
		}

		public int FileVersion {
			get { return _FileVersion; }
			set { _FileVersion = value; }
		}

		public bool BackupSchema {
			get { return _BackupSchema; }
			set { _BackupSchema = value; }
		}

		public bool BackupData {
			get { return _BackupData; }
			set { _BackupData = value; }
		}

		public bool BackupOptions {
			get { return _BackupOptions; }
			set { _BackupOptions = value; }
		}

		public bool BackupLogs {
			get { return _BackupLogs; }
			set { _BackupLogs = value; }
		}

		public string CustomThemeName {
			get { return _CustomThemeName; }
			set { _CustomThemeName = value; }
		}

		public string CustomThemeFile {
			get { return _CustomThemeFile; }
			set { _CustomThemeFile = value; }
		}

		public bool UseCustomTheme {
			get { return _UseCustomTheme; }
			set { _UseCustomTheme = value; }
		}
	}
	
}
