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
		private int _UpdateTimeAmount = 1;
		private string _UpdateTimeType;
		private bool _AutoUpdate = true;
		private DateTime _LastUpdate = DateTime.Now;
		private DateTime _LastUpdateCheck = DateTime.Now;
		private int _FileVersion = 1; // the file version does not nessicarily match the application version
		
		public Options()
		{
			
		}
		
		public Options(System.Collections.Hashtable hsh)
		{
			if(hsh.Contains("FileVersion"))
				_FileVersion = Convert.ToInt16(hsh["FileVersion"]);
			if(hsh.Contains("UpdateTimeAmount"))
				_UpdateTimeAmount = Convert.ToInt32(hsh["UpdateTimeAmount"]);
			if(hsh.Contains("UpdateTimeType"))
				_UpdateTimeType = hsh["UpdateTimeType"].ToString();
			if(hsh.Contains("AutoUpdate"))
				_AutoUpdate = Convert.ToBoolean(hsh["AutoUpdate"]);
			if(hsh.Contains("LastUpdate"))
				_LastUpdate = Convert.ToDateTime(hsh["LastUpdate"]);
			if(hsh.Contains("LastUpdateCheck"))
				_LastUpdateCheck = Convert.ToDateTime(hsh["LastUpdateCheck"]);
		}
		
		public System.Collections.Hashtable GetHashtable()
		{
			System.Collections.Hashtable hsh = new System.Collections.Hashtable();
			hsh.Add("FileVersion", _FileVersion);
			hsh.Add("UpdateTimeAmount", _UpdateTimeAmount);
			hsh.Add("UpdateTimeType", _UpdateTimeType);
			hsh.Add("AutoUpdate", _AutoUpdate);
			hsh.Add("LastUpdate", _LastUpdate);
			hsh.Add("LastUpdateCheck", _LastUpdateCheck);
			return hsh;
		}
		
		public int UpdateTimeAmount
		{
			set{ _UpdateTimeAmount = value;}
			get{ return _UpdateTimeAmount;}
		}
		
		public string UpdateTimeType
		{
			set{ _UpdateTimeType = value;}
			get{ return _UpdateTimeType;}
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
