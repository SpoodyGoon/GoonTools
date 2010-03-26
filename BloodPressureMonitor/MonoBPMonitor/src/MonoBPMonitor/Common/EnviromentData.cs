/*************************************************************************
 *                      EnviromentData.cs
 *
 *	 	Copyright (C) 2010
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
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using sc = System.Configuration;
using Gtk;

namespace GoonTools.Helper
{
	/// <summary>
	///  This class contains data that is related to the
	///  enviroment around the probram
	/// </summary>
	internal class EnviromentData
	{
		private string _OS = null;
		private string _DirChar = null;
		private string _AppPath = null;
		private string _ProgramName = null;
		private string _SavePath = null;
		private string _UserOptionFile = null;
		private string _ErrorLogFile = null;
		private string _ThemePath = null;
		private string _UserThemePath = null;
		private string _DataPath = null;
		internal EnviromentData()
		{
			so.FileInfo fi;
			so.DirectoryInfo di;
			sr.Assembly asm = sr.Assembly.GetExecutingAssembly ();
			
			// set the operating system
			_OS=se.OSVersion.Platform.ToString();
			
			// the character that seperates paths in the local directorys
			_DirChar = so.Path.DirectorySeparatorChar.ToString();
			
			// set the app path
			 fi = new so.FileInfo(asm.Location);
			_AppPath = fi.Directory.FullName;
			_ProgramName = asm.GetName().Name;
			if(sc.ConfigurationManager.AppSettings["Debug"].ToLower() == "false")
			{
				// set the location of the save data for the user
				di = new so.DirectoryInfo(so.Path.Combine(se.GetFolderPath(se.SpecialFolder.ApplicationData), _ProgramName));
				
			}
			else
			{
				di = new so.DirectoryInfo(so.Path.Combine(_AppPath, "DebugFiles"));
			}
			
			if(!di.Exists)
				di.Create();
			
			_SavePath = di.FullName;			
			
			// get the defaults path - this is where we keep the things we copy over
			// when setting up a new user
			di = new so.DirectoryInfo(so.Path.Combine(_AppPath , "Data"));
			if(!di.Exists)
				di.Create();
			
			_DataPath = di.FullName;
			
			// create the default theme directory
			di = new so.DirectoryInfo(so.Path.Combine(_AppPath , "Themes"));
			if(!di.Exists)
				di.Create();
			_ThemePath = di.FullName;
			
			// create the use theme directory
			di = new so.DirectoryInfo(so.Path.Combine(_SavePath , "Themes"));
			if(!di.Exists)
				di.Create();			
			_UserThemePath = di.FullName;
			
			// the error file
			fi = new so.FileInfo(so.Path.Combine(_SavePath , "error.txt"));
			_ErrorLogFile = fi.FullName;
			// the options save file
			fi = new so.FileInfo(so.Path.Combine(_SavePath, _ProgramName + ".xml"));
			_UserOptionFile = fi.FullName;
		}
		
		#region Public Properties
		
		internal string OS
		{
			get{return _OS;}
		}
		
		internal string DirChar
		{
			get{return _DirChar;}
		}
		
		internal string AppPath
		{
			get{ return _AppPath;}
		}
		
		internal string ProgramName
		{
			get{return _ProgramName;}
		}
		
		internal string SavePath
		{
			get{return _SavePath;}
		}
		internal string UserOptionFile
		{
			get{return _UserOptionFile;}
		}
		
		internal string DataPath
		{
			get{return _DataPath;}
		}
		
		internal string ThemeFolder
		{
			get{return _ThemePath;}
		}
		
		internal string UserThemeFolder
		{
			get{return _UserThemePath;}
		}
		
		internal string ErrorLog
		{
			get{return _ErrorLogFile;}
		}		
		
		#endregion Public Properties
		
		#region Public Methods
		
		internal string GetNewTempFolder(string Name)
		{
			return GetNewTempFolder(Name, true);
		}
		
		internal string GetNewTempFolder(string Name, bool Overwrite)
		{
			string tmpName = so.Path.Combine(so.Path.GetTempPath(), Name);
			try
			{
				if(Overwrite)
				{
					if(so.Directory.Exists(tmpName))
						so.Directory.Delete(tmpName);
					
					so.Directory.CreateDirectory(tmpName);
				}
				else
				{
					string tmp = tmpName;
					int i = 0;
					while(so.Directory.Exists(tmp))
					{
						tmp = tmpName + i.ToString();
						i++;
					}
					so.Directory.CreateDirectory(tmp);
					tmpName = tmp;
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			return tmpName;
		}
		
		internal string GetNewTempFile(string Name)
		{
			return GetNewTempFile(so.Path.GetFileNameWithoutExtension(Name), so.Path.GetExtension(Name), true);
		}
		
		internal string GetNewTempFile(string Name, string Extension)
		{
			return GetNewTempFile(Name, Extension, true);
		}
		
		internal string GetNewTempFile(string Name, string Extension, bool Overwrite)
		{
			string tmpName = so.Path.Combine(System.IO.Path.GetTempPath(), Name + "." + Extension);
			if(Overwrite)
			{
				if(so.File.Exists(tmpName))
					so.File.Delete(tmpName);
				
				so.File.Create(tmpName);
			}
			else
			{
				string tmp = tmpName;
				int i = 0;
				while(so.File.Exists(tmp))
				{
					tmp = tmpName + i.ToString();
					i++;
				}
				so.File.Create(tmp);
				tmpName = tmp;
			}
			return tmpName;
		}
		
		#endregion Public Methods
	}

}
