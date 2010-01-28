/*************************************************************************
 *                      Options.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <MonoToDo@brdstudio.net>
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
using System.Data;
using so = System.IO;

namespace GoonTools.Helper
{
	public class Options
	{
		// for the dblocationand connection string the default locations
		// are very likely to be the perminant locations
		private int _FileVersion = 1; // the file version does not nessicarily match the application version
		private bool _AutoSave = true;
		private int _AutoSaveTime = 5;
		private bool _CheckForUpdates = true;
		private bool _UseTaskInheritance = true;
		private bool _RememberOpenTabs = true;
		private bool _SaveErrorLog = true;
		
		#region Constructors
		
		public Options()
		{
			// default constructor
		}
		
		public Options(DataTable dt)
		{
			try
			{
				if(dt.TableName != "Options" || dt.Columns[0].ColumnName != "Key" || dt.Columns[1].ColumnName != "Value")
					throw new Exception("Invalid Table Passed to load Options");
				dt.PrimaryKey = new DataColumn[]{(DataColumn)dt.Columns["Key"]};
				DataRow dr;
				// file version
				dr = (DataRow)dt.Rows.Find("FileVersion");
				if(dr != null)
					_FileVersion = Convert.ToInt16(dr["Value"]);
				// Auto save flag
				dr = (DataRow)dt.Rows.Find("AutoSave");
				if(dr != null)
					_AutoSave =  Convert.ToBoolean(dr["Value"]);
				// amount of time between auto saves
				dr = (DataRow)dt.Rows.Find("AutoSaveTime");
				if(dr != null)
					_AutoSaveTime = Convert.ToInt32(dr["Value"]);
				// weather or not to use task inheritence
				dr = (DataRow)dt.Rows.Find("UseTaskInheritance");
				if(dr != null)
					_UseTaskInheritance = Convert.ToBoolean(dr["Value"]);
				// weather or not to remember and reopen tab when next opening
				dr = (DataRow)dt.Rows.Find("RememberOpenTabs");
				if(dr != null)
					_RememberOpenTabs = Convert.ToBoolean(dr["Value"]);
				// Flag for saving the error log
				dr = (DataRow)dt.Rows.Find("SaveErrorLog");
				if(dr != null)
					_SaveErrorLog = Convert.ToBoolean(dr["Value"]);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		#endregion Constructors
		
		#region Public Properties
		
		public int FileVersion
		{
			set{ _FileVersion = value;}
			get{ return _FileVersion;}
		}
		
		public bool AutoSave
		{
			set{ _AutoSave = value;}
			get{ return _AutoSave;}
		}
		
		public int AutoSaveTime
		{
			set{ _AutoSaveTime = value;}
			get{ return _AutoSaveTime;}
		}
		
		public bool UseTaskInheritance
		{
			set{ _UseTaskInheritance = value;}
			get{ return _UseTaskInheritance;}
		}
		
		public bool RememberOpenTabs
		{
			set{ _RememberOpenTabs = value;}
			get{ return _RememberOpenTabs;}
		}
		
		public bool SaveErrorLog
		{
			set{ _SaveErrorLog = value;}
			get{ return _SaveErrorLog;}
		}
		
		#endregion Public Properties
		
		public DataTable ToDataTable()
		{
			DataTable dt = new DataTable("Options");
			try
			{
				dt.Columns.AddRange(new DataColumn[] { new DataColumn("Key", typeof(string)), new DataColumn("Value", typeof(object))});
				dt.PrimaryKey = new DataColumn[]{dt.Columns["Key"]};
				System.Data.DataRow dr = dt.NewRow();
				dr["Key"] = "FileVersion";
				dr["Value"] = _FileVersion;
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "AutoSave";
				dr["Value"] = _AutoSave;
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "AutoSaveTime";
				dr["Value"] = _AutoSaveTime;
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "UseTaskInheritance";
				dr["Value"] = _UseTaskInheritance;
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "RememberOpenTabs";
				dr["Value"] = _RememberOpenTabs;
				dt.Rows.Add(dr);
				dr = dt.NewRow();
				dr["Key"] = "SaveErrorLog";
				dr["Value"] = _SaveErrorLog;
				dt.Rows.Add(dr);
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			return dt;
		}
	}
	
}
