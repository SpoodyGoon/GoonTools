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
using Gtk;
using Mono.Unix;

namespace GoonTools.Global
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
		private string _SavePath = string.Empty;
		private string _DefaultsPath = string.Empty;
		public EnviromentData()
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly ();
			
			// set the operating system
			_OS=System.Environment.OSVersion.Platform.ToString();
			
			// set the directory character string
			if(System.Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				_DirChar = @"\";
			}
			else
			{
				_DirChar = @"/";
			}
			
			// set the app path
			_AppPath = asm.CodeBase.Substring(0, asm.CodeBase.LastIndexOf(_DirChar) + 1).Replace("file://","");
			
			// set the location of the save data for the user
			_SavePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + _DirChar + asm.GetName().Name + _DirChar;
			
			// get the defaults path - this is where we keep the things we copy over
			// when setting up a new user
			_DefaultsPath = _AppPath + "data" + _DirChar;
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
		
		public string SavePath
		{
			get{return _SavePath;}
		}
		
		public string DefaultsPath
		{
			get{return _DefaultsPath;}
		}
		
		#endregion Public Properties
		
		#region Error Handling
		
		public void HandleError(Exception ex)
		{
			if(Common.Option.SaveErrorLog == true)
			{
				StreamWriter sw = new StreamWriter(_SavePath + "error.log", true);
				sw.Write("\n--------------------------------------------------------------------");
				sw.Write("\n---- " + DateTime.Now.ToString());
				sw.Write("\n" + ex.ToString());
				sw.Close();
			}
				
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
			
		}
		
		#endregion Error Handling
	}
}
