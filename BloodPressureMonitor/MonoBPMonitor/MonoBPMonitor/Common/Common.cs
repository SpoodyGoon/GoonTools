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
		private static GoonTools.Global.Options _Option;
		private static GoonTools.Global.EnviromentData _EnvData = new GoonTools.Global.EnviromentData();
		
		#region Public Properties
		
		public static GoonTools.Global.Options Option
		{
			get{return _Option;}
		}
		
		public static GoonTools.Global.EnviromentData EnvData
		{
			get{return _EnvData;}
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
				if(File.Exists(EnvData.SavePath + "Options.dat"))
				{
					LoadOptions();
				}
				else
				{
					_Option = new GoonTools.Global.Options();
					SaveOptions();
				}
				
				// copy over a new database if it's not already there
				if(!File.Exists(Option.DBLocation))
					File.Copy(EnvData.DefaultsPath + "BPMonitor.s3db", Option.DBLocation);
				
				
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public static void LoadOptions()
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				Stream stream = new FileStream(EnvData.SavePath + "Options.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
				_Option = (GoonTools.Global.Options) formatter.Deserialize(stream);
				stream.Close();
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public static void SaveOptions()
		{
			try
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				Stream stream = new FileStream(EnvData.SavePath + "Options.dat", FileMode.Create, FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, _Option);
				stream.Close();
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}		
		
		#endregion Loading and Saving
		
	}
}