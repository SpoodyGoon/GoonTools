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
using System.IO;
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
		private static GUPdotNET.Helper.EnviromentInfo _EnvData = new GUPdotNET.Helper.EnviromentInfo();
		private static string _OptionsFileName = "GUPdotNET.dat"; 		
		
		#endregion Private Properties
		
		#region Public Properties
		
		public static GUPdotNET.Helper.Options Option
		{
			get{return _Option;}
		}
		
		public static GUPdotNET.Helper.EnviromentInfo EnvData
		{
			get{return _EnvData;}
		}
		
		#endregion Public Properties
		
		#region Loading and Saving
		
		public static void LoadAll()
		{
			try
			{
				if(!Directory.Exists(EnvData.BasePath))
				   Directory.CreateDirectory(EnvData.BasePath);
				if(!Directory.Exists(EnvData.SavePath))
				   Directory.CreateDirectory(EnvData.SavePath);
				// search for the options file if it exists load it
				// if it has not been saved load the defaults
				if(File.Exists(EnvData.SavePath + _OptionsFileName))
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
				Stream stream = new FileStream(EnvData.SavePath + _OptionsFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				_Option = (GUPdotNET.Helper.Options) formatter.Deserialize(stream);
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
				Stream stream = new FileStream(EnvData.SavePath + _OptionsFileName, FileMode.Create, FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, _Option);
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
					StreamWriter sw = new StreamWriter(_EnvData.SavePath + "update.log", true);
					sw.Write(sw.NewLine + "####################################");
					sw.Write(sw.NewLine + " " + DateTime.Now.ToString() + " ");
					sw.Write(sw.NewLine + ResultMess + sw.NewLine + sw.NewLine);
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
			if(ConfigurationManager.AppSettings["SaveErrorLog"].ToLower() == "true")
			{
				StreamWriter sw = new StreamWriter(_EnvData.SavePath + "error.log", true);
				sw.Write(sw.NewLine + "------------------------------------------------------------------------------");
				sw.Write(sw.NewLine + "--------------------------- " + DateTime.Now.ToString() + " --------------------------");
				sw.Write(sw.NewLine + ex.ToString());
				sw.Write(sw.NewLine + "------------------------------------------------------------------------------");
				sw.Close();
			}
				
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();			
		}
		
		#endregion Logs
		
	}
}
