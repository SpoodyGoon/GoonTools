/*************************************************************************
 *                      EnviromentInfo.cs
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
using System.Configuration;
using Gtk;
using Mono.Unix;

namespace GUPdotNET.Helper
{
	/// <summary>
	///  This class contains information we need to know
	///  about the enviroment we are working in
	/// </summary>
	public class EnviromentInfo
	{		
		#region Private Properties
		
		private string _DirChar = string.Empty;
		private string _SavePath = string.Empty;
		private string _BasePath = string.Empty;
		
		#endregion Private Properties
		
		public EnviromentInfo()
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly ();
			
			// set the directory character string
			if(ConfigurationManager.AppSettings["OS"].ToString() == "Windows")
			{
				_DirChar = @"\";
			}
			else
			{
				_DirChar = @"/";
			}
			
			_BasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + _DirChar + asm.GetName().Name + _DirChar;
			_SavePath = _BasePath +  ConfigurationManager.AppSettings["ProgramName"].ToString() + _DirChar;
						
		}
		
		#region Public Properties
		
		public string DirChar
		{
			get{return _DirChar;}
		}
		
		public string BasePath
		{
			get{return _BasePath;}
		}
		
		public string SavePath
		{
			get{return _SavePath;}
		}
		
		#endregion Public Properties
	}
}
