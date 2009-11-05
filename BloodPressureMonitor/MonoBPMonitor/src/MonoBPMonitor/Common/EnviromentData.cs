/*************************************************************************
 *                      Global.cs
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
using so = System.IO;
using se = System.Environment;
using sr = System.Reflection;
using sc = System.Configuration;
using Gtk;
using Mono.Unix;

namespace GoonTools.Helper
{
	/// <summary>
	///  This class contains data that is related to the
	///  enviroment around the probram
	/// </summary>
	public class EnviromentData
	{
		private string _OS = string.Empty;
		private string _DirChar = string.Empty;
		private string _AppPath = string.Empty;
		private string _ProgramName = string.Empty;
		private string _SavePath = string.Empty;
		private string _UserOptionFile = string.Empty;
		private UserFileType _CurrentUserFileType = UserFileType.xml;
		private string _ErrorLogFile = string.Empty;
		private string _ThemePath = string.Empty;
		private string _DefaultsPath = string.Empty;
		public EnviromentData()
		{
			sr.Assembly asm = sr.Assembly.GetExecutingAssembly ();
			
			// set the operating system
			_OS=se.OSVersion.Platform.ToString();
			
			// set the directory character string
			if(se.OSVersion.Platform == PlatformID.Win32NT)
			{
				_DirChar = @"\";
			}
			else
			{
				_DirChar = @"/";
			}
			
			// set the app path
			so.FileInfo fi = new so.FileInfo(asm.Location);
			_AppPath = fi.Directory.FullName;
			_ProgramName = asm.GetName().Name;
			if(sc.ConfigurationManager.AppSettings["Debug"].ToLower() == "false")
			{
				// set the location of the save data for the user
				_SavePath = so.Path.Combine(se.GetFolderPath(se.SpecialFolder.ApplicationData), _ProgramName);
				
			}
			else
			{
				_SavePath = so.Path.Combine(_AppPath, "DebugFiles");
			}
			
			if(!so.Directory.Exists(_SavePath))
				so.Directory.CreateDirectory(_SavePath);
			
			_CurrentUserFileType = GetUserFileType();
			
			// get the defaults path - this is where we keep the things we copy over
			// when setting up a new user
			_DefaultsPath = so.Path.Combine(_AppPath , "Data");
			_ThemePath = so.Path.Combine(_AppPath , "Themes");
			_ErrorLogFile = so.Path.Combine(_SavePath , "error.txt");
			_UserOptionFile = so.Path.Combine(_SavePath, _ProgramName + "." + _CurrentUserFileType.ToString());
		}
		
		private UserFileType GetUserFileType()
		{
			switch(System.Configuration.ConfigurationManager.AppSettings["UserFileFormat"].ToLower())
			{
				case "xml":
					return UserFileType.xml;
				case "dat":
					return UserFileType.dat;
			}
			
			return UserFileType.xml;
		}
		
		#region Public Properties
		
		public string OS
		{
			get{return _OS;}
		}
		
		public string DirChar
		{
			get{return _DirChar;}
		}
		
		public string AppPath
		{
			get{ return _AppPath;}
		}
		
		public string ProgramName
		{
			get{return _ProgramName;}
		}
		
		public string SavePath
		{
			get{return _SavePath;}
		}
		public string UserOptionFile
		{
			get{return _UserOptionFile;}
		}
		
		public UserFileType CurrentUserFileType
		{
			get{return _CurrentUserFileType;}
		}
		
		public string DefaultsPath
		{
			get{return _DefaultsPath;}
		}
		
		public string ThemeFolder
		{
			get{return _ThemePath;}
		}
		
		public string ErrorLog
		{
			get{return _ErrorLogFile;}
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public string GetNewTempFolder(string Name)
		{
			return GetNewTempFolder(Name, true);
		}
		
		public string GetNewTempFolder(string Name, bool Overwrite)
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
		
		public string GetNewTempFile(string Name)
		{
			return GetNewTempFile(so.Path.GetFileNameWithoutExtension(Name), so.Path.GetExtension(Name), true);
		}
		
		public string GetNewTempFile(string Name, string Extension)
		{
			return GetNewTempFile(Name, Extension, true);
		}
		
		public string GetNewTempFile(string Name, string Extension, bool Overwrite)
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

	// this is the file formats for user preference
	// either xml or a binary dat file
	public enum UserFileType
	{
		dat,
		xml
	}
}
