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
using System.Data;
using System.Collections;

namespace GUPdotNET.Helper
{
	public class Options
	{
		private string _UpdateTime = "Day";
		private int _UpdateHours = 24;
		private bool _AutoUpdate = true;
		private DateTime _LastUpdate = DateTime.Now;
		private DateTime _LastUpdateCheck = DateTime.Now;
		private int _FileVersion = 1; // the file version does not nessicarily match the application version
		public readonly string[] _UpdateTimes = new string[]{"Day", "Week", "Month", "Quarter", "Year", "Never"};
		// empty contruct
		public Options()
		{
			
		}
		
		// loading options from a Hashtable
		public Options(System.Collections.Hashtable hsh)
		{
			if(hsh.Contains("FileVersion"))
				_FileVersion = Convert.ToInt16(hsh["FileVersion"]);
			if(hsh.Contains("UpdateTime"))
				_UpdateTime = hsh["UpdateTime"].ToString();
			if(hsh.Contains("UpdateHours"))
				_UpdateHours = Convert.ToInt32(hsh["UpdateHours"]);
			if(hsh.Contains("AutoUpdate"))
				_AutoUpdate = Convert.ToBoolean(hsh["AutoUpdate"]);
			if(hsh.Contains("LastUpdate"))
				_LastUpdate = Convert.ToDateTime(hsh["LastUpdate"]);
			if(hsh.Contains("LastUpdateCheck"))
				_LastUpdateCheck = Convert.ToDateTime(hsh["LastUpdateCheck"]);
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
			dr = (DataRow)dt.Rows.Find("UpdateTime");
			if(dr != null)
				_UpdateTime = dr["Value"].ToString();			
			dr = (DataRow)dt.Rows.Find("UpdateHours");
			if(dr != null)
				_UpdateHours = Convert.ToInt32(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("AutoUpdate");
			if(dr != null)
				_AutoUpdate = Convert.ToBoolean(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("LastUpdate");
			if(dr != null)
				_LastUpdate = Convert.ToDateTime(dr["Value"]);			
			dr = (DataRow)dt.Rows.Find("LastUpdateCheck");
			if(dr != null)
				_LastUpdateCheck = Convert.ToDateTime(dr["Value"]);
		}
		
		
		// Getting options into a hashtable
		public Hashtable GetOptionsTable()
		{
			System.Collections.Hashtable hsh = new System.Collections.Hashtable();
			hsh.Add("FileVersion", _FileVersion);
			hsh.Add("UpdateTime", _UpdateTime);
			hsh.Add("UpdateHours", _UpdateHours);
			hsh.Add("AutoUpdate", _AutoUpdate);
			hsh.Add("LastUpdate", _LastUpdate);
			hsh.Add("LastUpdateCheck", _LastUpdateCheck);
			return hsh;
		}
		
		// Getting the optinos in a datatable
		public Hashtable ToHashtable()
		{
			System.Collections.Hashtable hsh = new System.Collections.Hashtable();
			hsh.Add("FileVersion", _FileVersion);
			hsh.Add("UpdateTime", _UpdateTime);
			hsh.Add("UpdateHours", _UpdateHours);
			hsh.Add("AutoUpdate", _AutoUpdate);
			hsh.Add("LastUpdate", _LastUpdate);
			hsh.Add("LastUpdateCheck", _LastUpdateCheck);
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
			dr["Key"] = "UpdateTime";
			dr["Value"] = _UpdateTime;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "UpdateHours";
			dr["Value"] = _UpdateHours;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "AutoUpdate";
			dr["Value"] = _AutoUpdate;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "LastUpdate";
			dr["Value"] = _LastUpdate;
			dt.Rows.Add(dr);
			dr = dt.NewRow();
			dr["Key"] = "LastUpdateCheck";
			dr["Value"] = _LastUpdateCheck;
			dt.Rows.Add(dr);
			return dt;
		}
		
		public int UpdateHours
		{
			set{ _UpdateHours = value;}
			get{ return _UpdateHours;}
		}
		
		public string UpdateTime
		{
			set{ _UpdateTime = value;}
			get{ return _UpdateTime;}
		}
		
		public bool AutoUpdate
		{
			set{ _AutoUpdate = value;}
			get{ return _AutoUpdate;}
		}
		
		public DateTime LastUpdate
		{
			set{_LastUpdate=value;}
			get{return _LastUpdate;}
		}
		
		public DateTime LastUpdateCheck
		{
			set{_LastUpdateCheck=value;}
			get{return _LastUpdateCheck;}
		}
		
		public int FileVersion
		{
			set{ _FileVersion = value;}
			get{ return _FileVersion;}
		}
	}
}
