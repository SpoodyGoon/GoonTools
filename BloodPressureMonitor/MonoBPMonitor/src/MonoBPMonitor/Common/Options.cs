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
using cm = System.Configuration.ConfigurationManager;

namespace GoonTools.Helper
{
	[Serializable]
	internal class Options
	{
		#region Private Properties
		/// <summary>
		/// for the dblocationand connection string the default locations
		/// are very likely to be the perminant locations		
		/// </summary>
		private string _DBLocation = System.IO.Path.Combine (GoonTools.Common.EnvData.SavePath, "BPMonitor.s3db");
		/// <summary>
		/// just a simple flag to save the error to the save directory or not
		/// </summary>
		private bool _SaveErrorLog = true;
		/// <summary>
		/// Weather or not to limit the number or rows on displayed on the 
		/// main (top level) form or not and if so what the limit is
		/// </summary>
		private bool _LimitHistory = true;
		private int _HistoryDefaultShow = 30;
		// this is the amount of history we want to show
		private bool _BackupSchema = true;
		private bool _BackupData = true;
		private bool _BackupOptions = true;
		private bool _BackupLogs = true;
		private string _CustomThemeName = "Elegance";
		private string _CustomThemeFile = "";
		/// <summary>
		/// the flag weather or not to use custom themes
		/// there are a couple of different ways this is set
		/// 1. by the checkbox on the options form
		/// 2. by the app.config
		/// 3. ONLY if the OS is Windows		
		/// </summary>
		private bool _UseCustomTheme = true;
		/// <summary>
		/// the flag to determine weather or not we will use a 
		/// application based updater or the repository
		/// there are a couple of different ways this is set
		/// 1. by the app.config
		/// 2. by the project debug variables
		/// 3. ONLY if the OS is Windows
		/// </summary>
		private bool _UseCustomUpdate = true;
		/// <summary>
		/// A way to keep track of different versions 
		/// of user save files in case there is a change and needs an update
		/// not currently used but may be needed for later updates
		/// </summary>
		private Version _FileVersion = new Version(1,0);

		#endregion Private Properties

		#region Constructors

		internal Options ()
		{
			// Inital Setup of the global options 
			// Custom Themes and Custom Update
			if(cm.AppSettings["AllowCustomTheme"].ToLower() == "true" && GoonTools.Common.Option.UseCustomTheme == true && GoonTools.Common.EnvData.IsWindows == true)
			{
			}
		}

		internal Options (DataTable dt)
		{
			try
			{
				Version ver;
				if (dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
					throw new Exception ("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[] { (DataColumn)dt.Columns["Key"] };
				DataRow dr;
				// FileVersion
				dr = (DataRow)dt.Rows.Find ("FileVersion");
				if (dr != null)
				{
					
					_FileVersion = Convert.ToInt16 (dr["Value"]);
				}
				// DBLocation
				dr = (DataRow)dt.Rows.Find ("DBLocation");
				if (dr != null)
					_DBLocation = dr["Value"].ToString ();
				// SaveErrorLog
				dr = (DataRow)dt.Rows.Find ("SaveErrorLog");
				if (dr != null)
					_SaveErrorLog = Convert.ToBoolean (dr["Value"]);
				// CustomThemeName
				dr = (DataRow)dt.Rows.Find ("CustomThemeName");
				if (dr != null)
					_CustomThemeName = dr["Value"].ToString ();
				// CustomThemeFile
				dr = (DataRow)dt.Rows.Find ("CustomThemeFile");
				if (dr != null)
					_CustomThemeFile = dr["Value"].ToString ();
				// LimitHistory
				dr = (DataRow)dt.Rows.Find ("LimitHistory");
				if (dr != null)
					_LimitHistory = Convert.ToBoolean (dr["Value"]);
				// HistoryDefaultShow
				dr = (DataRow)dt.Rows.Find ("HistoryDefaultShow");
				if (dr != null)
					_HistoryDefaultShow = Convert.ToInt32 (dr["Value"]);
				// BackupSchema
				dr = (DataRow)dt.Rows.Find ("BackupSchema");
				if (dr != null)
					_BackupSchema = Convert.ToBoolean (dr["Value"]);
				// BackupData
				dr = (DataRow)dt.Rows.Find ("BackupData");
				if (dr != null)
					_BackupData = Convert.ToBoolean (dr["Value"]);
				// BackupOptions
				dr = (DataRow)dt.Rows.Find ("BackupOptions");
				if (dr != null)
					_BackupOptions = Convert.ToBoolean (dr["Value"]);
				// BackupLogs
				dr = (DataRow)dt.Rows.Find ("BackupLogs");
				if (dr != null)
					_BackupLogs = Convert.ToBoolean (dr["Value"]);
				// UseCustomTheme
				dr = (DataRow)dt.Rows.Find ("UseCustomTheme");
				if (dr != null)
					_UseCustomUpdate = Convert.ToBoolean (dr["Value"]);
				// UseCustomUpdate
				dr = (DataRow)dt.Rows.Find ("UseCustomUpdate");
				if (dr != null)
					_UseCustomUpdate = Convert.ToBoolean (dr["Value"]);
			}
			catch (Exception ex)
			{
				// 
				Common.HandleError (ex);
			}
		}

		#endregion Constructors

		#region Internal Methods

		internal DataTable ToDataTable ()
		{
			DataTable dt = new DataTable ("Options");
			try
			{
				dt.Columns.AddRange (new DataColumn[] { new DataColumn ("Key", typeof(string)), new DataColumn ("Value", typeof(object)) });
				dt.PrimaryKey = new DataColumn[] { dt.Columns["Key"] };
				System.Data.DataRow dr = dt.NewRow ();
				// FileVersion
				dr["Key"] = "FileVersion";
				dr["Value"] = _FileVersion;
				dt.Rows.Add (dr);
				// DBLocation
				dr = dt.NewRow ();
				dr["Key"] = "DBLocation";
				dr["Value"] = _DBLocation;
				dt.Rows.Add (dr);
				// SaveErrorLog
				dr = dt.NewRow ();
				dr["Key"] = "SaveErrorLog";
				dr["Value"] = _SaveErrorLog;
				dt.Rows.Add (dr);
				// CustomThemeName
				dr = dt.NewRow ();
				dr["Key"] = "CustomThemeName";
				dr["Value"] = _CustomThemeName;
				dt.Rows.Add (dr);
				// CustomThemeFile
				dr = dt.NewRow ();
				dr["Key"] = "CustomThemeFile";
				dr["Value"] = _CustomThemeFile;
				dt.Rows.Add (dr);
				// LimitHistory
				dr = dt.NewRow ();
				dr["Key"] = "LimitHistory";
				dr["Value"] = _LimitHistory;
				dt.Rows.Add (dr);
				// HistoryDefaultShow
				dr = dt.NewRow ();
				dr["Key"] = "HistoryDefaultShow";
				dr["Value"] = _HistoryDefaultShow;
				dt.Rows.Add (dr);
				// BackupSchema
				dr = dt.NewRow ();
				dr["Key"] = "BackupSchema";
				dr["Value"] = _BackupSchema;
				dt.Rows.Add (dr);
				// BackupData
				dr = dt.NewRow ();
				dr["Key"] = "BackupData";
				dr["Value"] = _BackupData;
				dt.Rows.Add (dr);
				// BackupOptions
				dr = dt.NewRow ();
				dr["Key"] = "BackupOptions";
				dr["Value"] = _BackupOptions;
				dt.Rows.Add (dr);
				// BackupLogs
				dr = dt.NewRow ();
				dr["Key"] = "BackupLogs";
				dr["Value"] = _BackupLogs;
				dt.Rows.Add (dr);
				// UseCustomTheme
				dr = dt.NewRow ();
				dr["Key"] = "UseCustomTheme";
				dr["Value"] = _UseCustomTheme;
				dt.Rows.Add (dr);
				// UseCustomUpdate
				dr = dt.NewRow ();
				dr["Key"] = "UseCustomUpdate";
				dr["Value"] = _UseCustomUpdate;
				dt.Rows.Add (dr);
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
			return dt;
		}

		internal void RefreshAll (System.Data.DataTable dt)
		{
			try
			{
				if (dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
					throw new Exception ("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[] { (DataColumn)dt.Columns["Key"] };
				DataRow dr;
				// FileVersion
				dr = (DataRow)dt.Rows.Find ("FileVersion");
				if (dr != null)
					_FileVersion = Convert.ToInt16 (dr["Value"]);
				// DBLocation
				dr = (DataRow)dt.Rows.Find ("DBLocation");
				if (dr != null)
					_DBLocation = dr["Value"].ToString ();
				// SaveErrorLog
				dr = (DataRow)dt.Rows.Find ("SaveErrorLog");
				if (dr != null)
					_SaveErrorLog = Convert.ToBoolean (dr["Value"]);
				// CustomThemeName
				dr = (DataRow)dt.Rows.Find ("CustomThemeName");
				if (dr != null)
					_CustomThemeName = dr["Value"].ToString ();
				// CustomThemeFile
				dr = (DataRow)dt.Rows.Find ("CustomThemeFile");
				if (dr != null)
					_CustomThemeFile = dr["Value"].ToString ();
				// LimitHistory
				dr = (DataRow)dt.Rows.Find ("LimitHistory");
				if (dr != null)
					_LimitHistory = Convert.ToBoolean (dr["Value"]);
				// HistoryDefaultShow
				dr = (DataRow)dt.Rows.Find ("HistoryDefaultShow");
				if (dr != null)
					_HistoryDefaultShow = Convert.ToInt32 (dr["Value"]);
				// BackupSchema
				dr = (DataRow)dt.Rows.Find ("BackupSchema");
				if (dr != null)
					_BackupSchema = Convert.ToBoolean (dr["Value"]);
				// BackupData
				dr = (DataRow)dt.Rows.Find ("BackupData");
				if (dr != null)
					_BackupData = Convert.ToBoolean (dr["Value"]);
				// BackupOptions
				dr = (DataRow)dt.Rows.Find ("BackupOptions");
				if (dr != null)
					_BackupOptions = Convert.ToBoolean (dr["Value"]);
				// BackupLogs
				dr = (DataRow)dt.Rows.Find ("BackupLogs");
				if (dr != null)
					_BackupLogs = Convert.ToBoolean (dr["Value"]);
				// UseCustomTheme
				dr = (DataRow)dt.Rows.Find ("UseCustomTheme");
				if (dr != null)
					_UseCustomUpdate = Convert.ToBoolean (dr["Value"]);
				// UseCustomUpdate
				dr = (DataRow)dt.Rows.Find ("UseCustomUpdate");
				if (dr != null)
					_UseCustomUpdate = Convert.ToBoolean (dr["Value"]);
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}

		#endregion Internal Methods

		#region Public Properties

		internal string DBLocation
		{
			get { return _DBLocation; }
			set { _DBLocation = value; }
		}

		internal bool SaveErrorLog
		{
			get { return _SaveErrorLog; }
			set { _SaveErrorLog = value; }
		}

		internal bool LimitHistory
		{
			get { return _LimitHistory; }
			set { _LimitHistory = value; }
		}

		internal int HistoryDefaultShow
		{
			get { return _HistoryDefaultShow; }
			set { _HistoryDefaultShow = value; }
		}

		internal int FileVersion
		{
			get { return _FileVersion; }
			set { _FileVersion = value; }
		}

		internal bool BackupSchema
		{
			get { return _BackupSchema; }
			set { _BackupSchema = value; }
		}

		internal bool BackupData
		{
			get { return _BackupData; }
			set { _BackupData = value; }
		}

		internal bool BackupOptions
		{
			get { return _BackupOptions; }
			set { _BackupOptions = value; }
		}

		internal bool BackupLogs
		{
			get { return _BackupLogs; }
			set { _BackupLogs = value; }
		}

		internal string CustomThemeName
		{
			get { return _CustomThemeName; }
			set { _CustomThemeName = value; }
		}

		internal string CustomThemeFile
		{
			get { return _CustomThemeFile; }
			set { _CustomThemeFile = value; }
		}

		internal bool UseCustomTheme
		{
			get { return _UseCustomTheme; }
			set { _UseCustomTheme = value; }
		}
		
		#endregion Public Properties
	}
	
}
