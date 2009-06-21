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
using System.IO;
using System.Reflection;
using Mono.Unix;

namespace GoonTools
{
	/// <summary>
	///  This class contains data that is related to the
	///  enviroment around the probram
	/// </summary>
	public class EnviromentData
	{
		private string _AppName;
		private string _AppPath;
		private string _DirChar;
		private string _OS;
		private string _ImageFolder;
		private string _SaveFolder;
		public EnviromentData()
		{
			_AppPath=GetAppPath();
			_AppName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			_OS=System.Environment.OSVersion.Platform.ToString();
			_DirChar=GetDirChar();
			_ImageFolder=GetImageFolder();
			_SaveFolder=GetSaveFolder();
		}
		
		#region Public Properties
		
		public string AppPath
		{
			get{ return _AppPath;}
		}
		
		public string DirChar
		{
			get{return _DirChar;}
		}
		
		public string OS
		{
			get{return _OS;}
		}
		
		public string SaveFolder
		{
			get{return _SaveFolder;}
		}
		
		public string ImageFolder
		{
			get{return _ImageFolder;}
		}
		
		#endregion Public Properties
		
		private string GetAppPath()
		{
			string strAppPath = Assembly.GetExecutingAssembly().CodeBase;
			strAppPath = strAppPath.Substring(0, strAppPath.LastIndexOf(System.IO.Path.AltDirectorySeparatorChar) + 1).Replace(@"file://","");
			return strAppPath;
		}
		
		private string GetDirChar()
		{
			string strDirChar = null;
			if(System.Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				strDirChar = @"\";
			}
			else
			{
				strDirChar = @"/";
			}
			
			return strDirChar;
		}		
		
		private string GetSaveFolder()
		{
			return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + GetDirChar() + _AppName + GetDirChar();
		}
		
		private string GetImageFolder()
		{
			return _AppPath +  "images" + GetDirChar();
		}
	}
}
