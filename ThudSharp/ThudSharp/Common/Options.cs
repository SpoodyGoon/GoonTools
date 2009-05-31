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

namespace GoonTools
{
	[Serializable]
	public class Options
	{
		// for the dblocationand connection string the default locations
		// are very likely to be the perminant locations
		private bool _AutoSave = true;
		private int _AutoSaveTime = 5;
		private bool _CheckForUpdates = true;
		private bool _RememberOpenGame = true;
		private int _FileVersion = 1; // the file version does not nessicarily match the application version
		
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
		
		public bool CheckForUpdates
		{
			set{ _CheckForUpdates = value;}
			get{ return _CheckForUpdates;}
		}
		
		public bool RememberOpenGame
		{
			set{ _RememberOpenGame = value;}
			get{ return _RememberOpenGame;}
		}
		
		public int FileVersion
		{
			set{ _FileVersion = value;}
			get{ return _FileVersion;}
		}
	}
	
}
