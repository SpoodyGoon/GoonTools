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

namespace GoonTools.Helper
{
	[Serializable]
	public class Options
	{
		// for the dblocationand connection string the default locations
		// are very likely to be the perminant locations
		private string _ConnString = "URI=file:" +  GoonTools.Common.EnvData.SavePath + "BPMonitor.s3db,version=3, busy_timeout=3000";
		private string _DBLocation = GoonTools.Common.EnvData.SavePath + "BPMonitor.s3db";
		private bool _SaveErrorLog = true; // this is just a flag to save the error to the save directory
		private int _HistoryDefaultShow = 30; // this is the amount of history we want to show
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
			if(hsh.Contains("HistoryDefaultShow"))
				_HistoryDefaultShow = Convert.ToInt32(hsh["HistoryDefaultShow"]);
		}
		
		public System.Collections.Hashtable GetOptionsTable()
		{
			System.Collections.Hashtable hsh = new System.Collections.Hashtable();
			hsh.Add("FileVersion", _FileVersion);
			hsh.Add("ConnString", _ConnString);
			hsh.Add("DBLocation", _DBLocation);
			hsh.Add("SaveErrorLog", _SaveErrorLog);
			hsh.Add("HistoryDefaultShow", _HistoryDefaultShow);
			return hsh;
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
	}
	
}
