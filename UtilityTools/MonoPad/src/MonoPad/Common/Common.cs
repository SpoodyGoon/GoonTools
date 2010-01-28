/*************************************************************************
 *                      Common.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <MonoToDo@brdstudio.net>
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
using System.Data;
using System.IO;
using Gtk;

namespace GoonTools
{
	/// <summary>
	/// This is a static class that holds values that
	/// are reqularly used by the program it also first off
	/// the serialzation of certian objects
	/// </summary>
	public static class Common
	{
		private static GoonTools.Helper.Options _Option;
		private static GoonTools.Helper.EnviromentData _EnvData = new GoonTools.Helper.EnviromentData();
		
		#region Public Properties
		
		public static GoonTools.Helper.Options Option
		{
			get{return _Option;}
		}
		
		public static GoonTools.Helper.EnviromentData EnvData
		{
			get{return _EnvData;}
		}
		
		
		#endregion Public Properties
		
		#region Loading and Saving
		
		public static void LoadAll()
		{
			// search for the options file if it exists load it
			// if it has not been saved load the defaults
			if(File.Exists(_EnvData.UserOptionFile))
			{
				LoadOptions();
			}
			else
			{
				_Option = new GoonTools.Helper.Options();
			}
			
		}
		
		public static void LoadOptions()
		{
			DataSet ds = new DataSet(_EnvData.ProgramName);
			ds.ReadXml(EnvData.UserOptionFile, XmlReadMode.ReadSchema);
			_Option = new GoonTools.Helper.Options((DataTable)ds.Tables["Options"]);
			ds.Clear();
			ds.Dispose();
		}
		
		public static void SaveOptions()
		{
			try
			{
				DataSet ds = new DataSet(_EnvData.ProgramName);
				ds.Tables.Add((System.Data.DataTable)_Option.ToDataTable());
				ds.WriteXml(EnvData.UserOptionFile, System.Data.XmlWriteMode.WriteSchema);
				ds.Clear();
				ds.Dispose();
			}
			catch(Exception Ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, Ex.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		
		#endregion Loading and Saving
		
		
		
		#region Error Handling
		
		public static void HandleError(Exception ex)
		{
			HandleError(null, ex);
		}
		
		public static void HandleError(Gtk.Window parent_window, Exception ex)
		{
			if(_Option.SaveErrorLog == true)
			{
				StreamWriter sw = new StreamWriter(EnvData.ErrorLog, true);
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
		
		public static void CleanErrorLog()
		{
			try
			{
				StreamWriter sw = new StreamWriter(EnvData.ErrorLog, false);
				sw.Write("");
				sw.Close();
			}
			catch(Exception ex)
			{
				HandleError(ex);
				
			}
		}
		
		#endregion Error Handling
		
	}
}
