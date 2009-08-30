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
		public Options()
		{
			
		}
		
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
		
		public System.Collections.Hashtable GetOptionsTable()
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
