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
		private string _OS = null;
		private string _DirChar = null;
		private string _AppPath = null;
		private string _ProgramName = null;
		private string _SavePath = null;
		private string _UserOptionFile = null;
		private UserFileType _CurrentUserFileType = UserFileType.xml;
		private string _ErrorLogFile = null;
		private string _ImagePath = null;
		private string _CustomThemesPath = null;
		private string _DefaultsPath = null;
		public EnviromentData()
		{
			try
			{
				so.FileInfo tmpFileInfo = null;
				so.DirectoryInfo tmpDirInfo = null;
				sr.Assembly asm = sr.Assembly.GetExecutingAssembly ();
				
				// set the operating system
				_OS=se.OSVersion.Platform.ToString();
				_DirChar = so.Path.DirectorySeparatorChar.ToString();
				
				// set the app path
				tmpFileInfo = new so.FileInfo(asm.Location);
				_AppPath = tmpFileInfo.Directory.FullName;
				_ProgramName = asm.GetName().Name;
				
				// use a subfolder of the app path when debuggin for the personal files
				if(sc.ConfigurationManager.AppSettings["Debug"].ToLower() == "false")
				{
					// if not debugging then use a subfolder of the application data folder
					tmpDirInfo = new so.DirectoryInfo(so.Path.Combine(se.GetFolderPath(se.SpecialFolder.ApplicationData), _ProgramName));
					if(!tmpDirInfo.Exists)
						tmpDirInfo.Create();
					_SavePath = tmpDirInfo.FullName;
				}
				else
				{
					tmpDirInfo = new so.DirectoryInfo(so.Path.Combine(_AppPath, "DebugFiles"));
					if(!tmpDirInfo.Exists)
						tmpDirInfo.Create();
					_SavePath = tmpDirInfo.FullName;
				}
				
				_CurrentUserFileType = GetUserFileType();
				
				// get the defaults path - this is where we keep the things we copy over
				// when setting up a new user or for other items that are central to the application and not
				// center to the user
				tmpDirInfo = new so.DirectoryInfo(so.Path.Combine(_AppPath , "Data"));
				_DefaultsPath = tmpDirInfo.FullName;
				
				// where to look for custome themes when working in windows and 
				// the custome themes flag is set in the app config
				if(sc.ConfigurationManager.AppSettings["AllowCustomThemes"].ToLower() == "true")
				{
					tmpDirInfo = new so.DirectoryInfo(so.Path.Combine(_DefaultsPath , "CustomThemes"));
					_CustomThemesPath = tmpDirInfo.FullName;
				}
				
				// where to put images that are loaded on the fly
				tmpDirInfo = new so.DirectoryInfo(so.Path.Combine(_DefaultsPath , "Images"));
				_ImagePath = tmpDirInfo.FullName;
				
				// where the error log goes
				tmpFileInfo = new so.FileInfo(so.Path.Combine(_SavePath , "error.txt"));
				_ErrorLogFile = tmpFileInfo.FullName;
				
				// where the user options file is
				tmpFileInfo = new so.FileInfo(so.Path.Combine(_SavePath,  _ProgramName + "." + _CurrentUserFileType.ToString().ToLower()));
				_UserOptionFile = tmpFileInfo.FullName;
			}
			catch(Exception ex)
			{
				// we don't have a complete set up yet so use a simple message box
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
				md.Run();
				md.Destroy();
			}
		}
		
		private UserFileType GetUserFileType()
		{
			switch(System.Configuration.ConfigurationManager.AppSettings["UserFileFormat"].ToLower())
			{
				case "xml":
					return UserFileType.xml;
				case "dat":
					return UserFileType.dat;
				default:
					throw new Exception("Invalid user file type select.");
			}
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
		
		public string ImagePath
		{
			get{return _ImagePath;}
		}
		
		public string CustomThemesPath
		{
			get{return _CustomThemesPath;}
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
