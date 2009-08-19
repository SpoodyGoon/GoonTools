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
	[Serializable]
	public class Options
	{
		private int _UpdateTimeAmount = 1;
		private UpdateDateType _UpdateTimeType;
		private bool _AutoUpdate = true;
		private bool _SaveErrorLog = false;
		private bool _SaveUpdateLog = true;
		private DateTime _LastUpdate = DateTime.Today;
		private DateTime _LastUpdateCheck = DateTime.Today;
		private int _FileVersion = 1; // the file version does not nessicarily match the application version
		
		public int UpdateTimeAmount
		{
			set{ _UpdateTimeAmount = value;}
			get{ return _UpdateTimeAmount;}
		}
		
		public UpdateDateType UpdateTimeType
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
		
		public bool SaveUpdateLog
		{
			set{_SaveUpdateLog=value;}
			get{return _SaveUpdateLog;}
		}
		
		public bool SaveErrorLog
		{
			set{_SaveErrorLog=value;}
			get{return _SaveErrorLog;}
		}
		
		public int FileVersion
		{
			set{ _FileVersion = value;}
			get{ return _FileVersion;}
		}
	}
}
