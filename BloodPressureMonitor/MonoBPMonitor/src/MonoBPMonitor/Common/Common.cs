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
using System.IO;
using System.Data;
using Gtk;
using GoonTools.Helper;

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
		private static GoonTools.Helper.MetaInformation _MetaInfo;
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
		
		public static GoonTools.Helper.MetaInformation MetaInfo
		{
			get{return _MetaInfo;}
		}
		
		#endregion Public Properties
		
		#region Loading and Saving
		
		public static void LoadAll()
		{
			try
			{
				// make sure the directory exists
				if(!Directory.Exists(EnvData.SavePath))
					Directory.CreateDirectory(EnvData.SavePath);
				
				// search for the options file if it exists load it
				// if it has not been saved load the defaults
				if(File.Exists(EnvData.UserOptionFile))
				{
					LoadUserData();
				}
				else
				{
					_Option = new Helper.Options();
					_MetaInfo = new Helper.MetaInformation();
					SaveUserData();
				}
				
				// copy over a new database if it's not already there
				if(!File.Exists(Option.DBLocation))
					File.Copy(Path.Combine(EnvData.DataPath , "BPMonitor.s3db"), Option.DBLocation);
				
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public static void LoadUserData()
		{
			try
			{
				DataSet ds = new DataSet(_EnvData.ProgramName);
				ds.ReadXml(EnvData.UserOptionFile, XmlReadMode.ReadSchema);
				DataTable dtTMP = (DataTable)ds.Tables["Options"];
				if(dtTMP != null)
					_Option = new GoonTools.Helper.Options(dtTMP);
				else
					_Option = new GoonTools.Helper.Options();
				
				dtTMP = (DataTable)ds.Tables["MetaInfo"];
				if(dtTMP != null)
					_MetaInfo = new GoonTools.Helper.MetaInformation(dtTMP);
				else
					_MetaInfo = new GoonTools.Helper.MetaInformation();
					
				ds.Clear();
				ds.Dispose();				
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public static void SaveUserData()
		{
			try
			{
				DataSet ds = new DataSet(_EnvData.ProgramName);
				ds.Tables.Add((System.Data.DataTable)_Option.ToDataTable());
				ds.Tables.Add((System.Data.DataTable)_MetaInfo.ToDataTable());
				ds.WriteXml(EnvData.UserOptionFile, System.Data.XmlWriteMode.WriteSchema);
				ds.Clear();
				ds.Dispose();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		#endregion Loading and Saving
		
		#region Logs
		
		public static void HandleError(Exception ex)
		{
			HandleError(null, ex);
		}
		
		public static void HandleError(Gtk.Window parent_window, Exception ex)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(System.Environment.NewLine + "------------------------------------------------------------------------------");
			sb.Append(System.Environment.NewLine + "--------------------------- " + DateTime.Now.ToString() + " --------------------------");
			sb.Append(System.Environment.NewLine + ex.ToString());
			sb.Append(System.Environment.NewLine + "------------------------------------------------------------------------------");
			if(_Option.SaveErrorLog == true)
			{
				StreamWriter sw = new StreamWriter(EnvData.ErrorLog, true);
				sw.Write(sb.ToString());
				sw.Close();
			}
			
			MonoBPMonitor.frmErrorMessage md = new MonoBPMonitor.frmErrorMessage(sb.ToString());
			md.WindowPosition = WindowPosition.Mouse;
			md.Run();
			md.Destroy();
			sb.Length = 0;
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
		
		#endregion Logs
		
	}
}
