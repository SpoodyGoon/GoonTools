/*************************************************************************
 *                      Common.cs
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
using System.Configuration;
using so = System.IO;
using Gtk;

namespace GUPdotNET
{
	/// <summary>
	/// This is a static class that holds values that
	/// are reqularly used by the program it also first off
	/// the serialzation of certian objects
	/// </summary>
	public static class Common
	{
		#region Private Properties
		
		private static GUPdotNET.Helper.Options _Option;
		private static string _AppPath = null;
		// this is where the calling application holds user info
		private static string _UserSaveLoc = null;
		private static string _SavePath = null;
		private static string _DirChar = so.Path.DirectorySeparatorChar.ToString();
		private static string _OptionsFile = null;
		private static string _UpdateFile = null;
		private static string _ErrorFile = null;
		#endregion Private Properties
		
		#region Public Properties
		
		public static GUPdotNET.Helper.Options Option
		{
			get{return _Option;}
		}
		
		public static string UserSaveLoc
		{
			get{return _SavePath;}
		}
		
		public static string AppPath
		{
			get{return _AppPath;}
		}
		
		#endregion Public Properties
		
		#region Loading and Saving
		
		public static void LoadAll(string usersaveloc)
		{
			_UserSaveLoc = so.Path.GetFullPath(usersaveloc);
			_SavePath = so.Path.GetFullPath(usersaveloc + "GUPdotNET" + _DirChar);
			_OptionsFile = so.Path.Combine(_SavePath, "Options.dat");
			_UpdateFile = so.Path.Combine(_SavePath, "Update.log");
			_ErrorFile = so.Path.Combine(_SavePath, "Error.log");
		}
		
		public static void LoadAll()
		{
			try
			{
				_AppPath = so.Path.GetFullPath(new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly ().CodeBase).Directory.FullName);
				
				if(!so.Directory.Exists(_UserSaveLoc))
					so.Directory.CreateDirectory(_UserSaveLoc);
				if(!so.Directory.Exists(_SavePath))
					so.Directory.CreateDirectory(_SavePath);
				// search for the options file if it exists load it
				// if it has not been saved load the defaults
				if(so.File.Exists(_OptionsFile))
				{
					LoadOptions();
				}
				else
				{
					_Option = new GUPdotNET.Helper.Options();
					SaveOptions();
				}
				
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public static void LoadOptions()
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				so.Stream stream = new so.FileStream(_OptionsFile, so.FileMode.Open, so.FileAccess.Read, so.FileShare.Read);
				_Option = new GUPdotNET.Helper.Options((System.Collections.Hashtable)formatter.Deserialize(stream));
				stream.Close();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public static void SaveOptions()
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				so.Stream stream = new so.FileStream(_OptionsFile, so.FileMode.Create, so.FileAccess.Write, so.FileShare.None);
				formatter.Serialize(stream, (System.Collections.Hashtable)_Option.GetOptionsTable());
				stream.Close();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		#endregion Loading and Saving
		
		
		#region Logs
		
		public static void LogUpdate(string ResultMess)
		{
			try
			{
				if(ConfigurationManager.AppSettings["SaveUpdateLog"].ToLower() == "true")
				{
					so.StreamWriter sw = new so.StreamWriter(_UpdateFile, true);
					sw.Write(sw.NewLine + ResultMess);
					sw.Close();
				}
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
				md.Run();
				md.Destroy();
			}
		}
		
		public static void HandleError(Exception ex)
		{
			HandleError(null, ex);
		}
		
		public static void HandleError(Gtk.Window parent_window, Exception ex)
		{
			if(ConfigurationManager.AppSettings["SaveErrorLog"].ToLower() == "true")
			{
				so.StreamWriter sw = new so.StreamWriter(_ErrorFile, true);
				sw.Write(sw.NewLine + "------------------------------------------------------------------------------");
				sw.Write(sw.NewLine + "--------------------------- " + DateTime.Now.ToString() + " --------------------------");
				sw.Write(sw.NewLine + ex.ToString());
				sw.Write(sw.NewLine + "------------------------------------------------------------------------------");
				sw.Close();
			}
			
			Gtk.MessageDialog md = new Gtk.MessageDialog(parent_window, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
		}
		
		#endregion Logs
		
	}
}
