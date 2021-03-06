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
using System.Diagnostics;
using Gtk;
using GoonTools.Helper;

namespace GoonTools
{
	/// <summary>
	/// This is a static class that holds values that
	/// are reqularly used by the program it also first off
	/// the serialzation of certian objects
	/// </summary>
	static internal class Common
	{
        private static GoonTools.Helper.Options _Option;
		private static GoonTools.Helper.MetaInformation _MetaInfo;
		private static GoonTools.Helper.EnviromentData _EnvData;
		
		#region Public Properties

		static internal GoonTools.Helper.Options Option
		{
			get { return _Option; }
		}

		static internal GoonTools.Helper.EnviromentData EnvData
		{
			get { return _EnvData; }
		}

		static internal GoonTools.Helper.MetaInformation MetaInfo
		{
			get { return _MetaInfo; }
		}
		
		internal static string CurrentLicense
		{
			get{return GoonTools.Helper.Licenses.GPL3;}
		}

		#endregion Public Properties

		#region Loading and Saving

		static internal void LoadAll ()
		{
			try
			{
                _EnvData = new EnviromentData();
                _MetaInfo = new MetaInformation();
                _Option = new Options();

				// make sure the directory exists
				if (!Directory.Exists (_EnvData.SavePath))
					Directory.CreateDirectory (_EnvData.SavePath);
				
				// search for the options file if it exists load it
				// if it has not been saved load the defaults
				if (File.Exists (_EnvData.UserOptionFile))
				{
					LoadUserData ();
				}

				
				else
				{
					_Option = new Helper.Options ();
					_MetaInfo = new Helper.MetaInformation ();
					SaveUserData ();
				}
				
				// copy over a new database if it's not already there
				if (!File.Exists (Option.DBLocation))
					File.Copy (Path.Combine (_EnvData.DataPath, "BPMonitor.s3db"), _Option.DBLocation);
				
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}

		static internal void LoadUserData ()
		{
			DataSet ds = new DataSet (_EnvData.ProgramName);
			try
			{
				FileInfo fi = new FileInfo (_EnvData.UserOptionFile);
				if (fi.Exists)
				{
					ds.ReadXml (_EnvData.UserOptionFile);
					DataTable dtTMP = (DataTable)ds.Tables["Options"];
					if (dtTMP != null)
						_Option = new GoonTools.Helper.Options (dtTMP);
					else
						_Option = new GoonTools.Helper.Options ();
					
					dtTMP = (DataTable)ds.Tables["MetaInfo"];
					if (dtTMP != null)
						_MetaInfo = new GoonTools.Helper.MetaInformation (dtTMP);
					else
						_MetaInfo = new GoonTools.Helper.MetaInformation ();
				}
				else
				{
					_Option = new Helper.Options ();
					_MetaInfo = new Helper.MetaInformation ();
				}
				
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
			finally
			{
				ds.Clear ();
				ds.Dispose ();
			}
		}

		static internal void SaveUserData ()
		{
			try
			{
				DataSet ds = new DataSet (_EnvData.ProgramName);
				ds.Tables.Add ((System.Data.DataTable)_Option.ToDataTable ());
				ds.Tables.Add ((System.Data.DataTable)_MetaInfo.ToDataTable ());
				ds.WriteXml (_EnvData.UserOptionFile);
				ds.Clear ();
				ds.Dispose ();
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}

		#endregion Loading and Saving

		#region Logs

		static internal void HandleError (Exception ex)
		{
			HandleError (null, ex);
		}

		static internal void HandleError (Gtk.Window parent_window, Exception ex)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder ();
			try
			{
				if (System.Configuration.ConfigurationManager.AppSettings["Debug"].ToLower () == "true")
					Console.WriteLine (ex.ToString ());
				
				sb.Append (System.Environment.NewLine + "------------------------------------------------------------------------------");
				sb.Append (System.Environment.NewLine + "--------------------------- " + DateTime.Now.ToString () + " --------------------------");
				sb.Append (System.Environment.NewLine + ex.ToString ());
				sb.Append (System.Environment.NewLine + "------------------------------------------------------------------------------");
				if(_Option != null && _EnvData != null)
				{
					if (_Option.SaveErrorLog == true)
					{
						StreamWriter sw = new StreamWriter (_EnvData.ErrorLog, true);
						sw.Write (sb.ToString ());
						sw.Close ();
					}
					
					
					MonoBPMonitor.frmErrorMessage md = new MonoBPMonitor.frmErrorMessage (sb.ToString ());
					md.WindowPosition = WindowPosition.Mouse;
					md.Run ();
					md.Destroy ();
				}
				else
				{
					MessageDialog md = new MessageDialog (parent_window, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, ex.ToString (), "An Error Has Occured");
					md.Run ();
					md.Destroy ();
				}
			}
			catch (Exception exCatchAll)
			{
				MessageDialog md = new MessageDialog (parent_window, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, exCatchAll.ToString () + System.Environment.NewLine + System.Environment.NewLine + ex.ToString (), "An Error Has Occured");
				md.Run ();
				md.Destroy ();
			}
			finally
			{
				sb.Length = 0;
			}
		}

		static internal void CleanErrorLog ()
		{
			try
			{
				StreamWriter sw = new StreamWriter (_EnvData.ErrorLog, false);
				sw.Write ("");
				sw.Close ();
			}
			catch (Exception ex)
			{
				HandleError (ex);
				
			}
		}

		#endregion Logs

		#region Launch URL

		private static string _LaunchURL = string.Empty;
		static internal void LaunchURL (string URL)
		{
			_LaunchURL = URL;
			System.Threading.Thread trd = new System.Threading.Thread (new System.Threading.ThreadStart (StartURL));
			trd.Start ();
		}

		private static void StartURL ()
		{
			Process.Start (_LaunchURL);
		}
		
		#endregion Launch URL
		
	}
}
