/*************************************************************************
 *                      GUPdotNET.cs
 *
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>
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
using System.Net;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Security;
using System.Reflection;
using System.Security.Permissions;
using Gtk;

namespace GUPdotNET
{
	public class UpdateCheck
	{				
        #region Local Variable Declaration
		
		// value from the calling application or from the app con
		private static string _InstallType = null;
		private static string _ProgramTitle = null;
		// this is the full path to the program i.e. C:/MyDocuments/MyProgramFolder/
		private static string _ProgramFullPath = null;
		// this is the actual name of the program i.e. MyProgram.exe
		private static string _ProgramName = null;
		private static string _UpdateInfoURL = null;
		private static int _CurrentMajorVersion = -1;
		private static int _CurrentMinorVersion = -1;
		private static bool _SilentCheck = false;
		private static string _TempInstallerPath = null;
		
		#endregion Local Variable Declaration
		
		#region Web Variable Declaration
		
		// values that are imported from the aspx file on the listed web site
		private static string _UpdateFileURL = null;
		private static int _UpdateMajorVersion = -1;
		private static int _UpdateMinorVersion = -1;
		private static string _LatestVersion = null;
		private static string _Error = null;
		
		#endregion Web Variable Declaration
		
		#region Public Properties Local
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		internal static string InstallType
		{
			set{_InstallType=value;}
			get{return _InstallType;}
		}
		
		internal static string TempInstallerPath
		{
			set{_TempInstallerPath=value;}
			get{return _TempInstallerPath;}
		}
		
		/// <summary>
		///  the freindly name of the application
		/// </summary>
		internal static  string ProgramTitle
		{
			set{_ProgramTitle = value;}
			get{return _ProgramTitle;}
		}
		
		/// <summary>
		///  full path to the application we are updating
		/// </summary>
		internal static  string ProgramFullPath
		{
			set{_ProgramFullPath = value;}
			get{return _ProgramFullPath;}
		}
		
		internal static string ProgramName
		{
			set{_ProgramName = value;}
			get{return _ProgramName;}
		}
		
		/// <summary>
		///  This is URL for the web site
		///  containing the update information
		/// </summary>
		internal static string UpdateInfoURL
		{
			set{_UpdateInfoURL = value;}
			get{return _UpdateInfoURL;}
		}
		
		/// <summary>
		///  This is the major version of the application
		///  we are looking to update
		/// </summary>
		internal static int CurrentMajorVersion
		{
			set{_CurrentMajorVersion=value;}
			get{return _CurrentMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version or the application
		///  we are looking to update
		/// </summary>
		internal static int CurrentMinorVersion
		{
			set{_CurrentMinorVersion=value;}
			get{return _CurrentMinorVersion;}
		}
		
		/// <summary>
		///  if this is set to true this will
		///  not report if no connection is made to the
		///  web server or if other interuptions occur
		/// </summary>
		internal static bool SilentCheck
		{
			set{_SilentCheck=value;}
			get{return _SilentCheck;}
		}
		
		#endregion Public Properties Local
		
		#region Public Properties Web Server
		
		/// <summary>
		///  The file that is the updated installation
		/// </summary>
		internal static string UpdateFileURL
		{
			set{_UpdateFileURL=value;}
			get{return _UpdateFileURL;}
		}
		
		/// <summary>
		///  This is the major version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		internal static int UpdateMajorVersion
		{
			set{_UpdateMajorVersion= value;}
			get{return _UpdateMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		internal static int UpdateMinorVersion
		{
			set{_UpdateMinorVersion = value;}
			get{return _UpdateMinorVersion;}
		}
		
		/// <summary>
		///  this is a generic string of the updatable version
		/// </summary>
		internal static string LatestVersion
		{
			set{_LatestVersion=value;}
			get{return _LatestVersion;}
		}
		
		/// <summary>
		///  this contains any error that is returned from the
		///  web site portion of the app
		/// </summary>
		internal static string Error
		{
			set{_Error=value;}
			get{return _Error;}
		}
		
		#endregion Public Properties Web Server

		public void RunCheck(bool blnSilentCheck)
		{
			try
			{
				Gtk.ResponseType UpConResp = ResponseType.None;
				Gtk.ResponseType UpDownResp = ResponseType.None;
				
				// load the local data
				LoadLocalInfo(blnSilentCheck);
				
				// load the update info from the web
				LoadUpdateInfo();
				// check if we need an update via the major and minor version
				if(GUPdotNET.UpdateMajorVersion > GUPdotNET.CurrentMajorVersion || (GUPdotNET.UpdateMajorVersion == GUPdotNET.CurrentMajorVersion && GUPdotNET.UpdateMinorVersion > GUPdotNET.CurrentMinorVersion))
				{
					// tell the user there is an update availalbe
					// and ask if they would like to update
					frmUpdateConfirm UpCon = new frmUpdateConfirm();
					UpConResp = (Gtk.ResponseType)UpCon.Run();
					UpCon.Destroy();
					
					// if the user wants an update start the update dialog
					if(UpConResp == Gtk.ResponseType.Yes)
					{
						frmUpdateDownload UpDown = new frmUpdateDownload();
						UpDownResp = (Gtk.ResponseType)UpDown.Run();
						UpDown.Destroy();
					}
					
					// if the download was sucessful then procede with the install
					if(UpDownResp == ResponseType.Ok)
					{
						frmInstallDialog Inst = new frmInstallDialog();
						Inst.Run();
						Inst.Destroy();
					}
				}
				else
				{
					if(GUPdotNET.SilentCheck == false)
					{
						Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "No updates avalable at this time." ,"No updates");
						md.Run();
						md.Destroy();
					}
				}
				
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString() ,"Error");
				md.Run();
				md.Destroy();
			}
		}
		
		private void LoadLocalInfo(bool blnSilentCheck)
		{
			GUPdotNET.SilentCheck = blnSilentCheck;
			GUPdotNET.ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
			GUPdotNET.InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
			GUPdotNET.ProgramTitle = ConfigurationManager.AppSettings["ProgramTitle"].ToString();
			GUPdotNET.UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
			GUPdotNET.CurrentMajorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMajorVersion"].ToString());
			GUPdotNET.CurrentMinorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMinorVersion"].ToString());
		}
		
		#region Update Info Web
		
		private void LoadUpdateInfo()
		{
			try
			{
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(ConfigurationManager.AppSettings["UpdateInfoURL"].ToString() + "?InstallType=" + ConfigurationManager.AppSettings["InstallType"].ToString() );
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				ParseResponse(s);
			}
			catch(WebException e)
			{
				// if we get a web exception exit the update
				ExitUpdate("Unable to connect to the update web site - " + System.Environment.NewLine + e.Message);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void ParseResponse(Stream s)
		{
			try
			{
				// get the xml that defines the update
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(s);
				
				XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				// parse out the GUPdotNET element children
				for (int i = 0; i < nl.Count; i++)
				{
					GUPdotNET.UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText;
					GUPdotNET.UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText);
					GUPdotNET.UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText);
					GUPdotNET.LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText;
					GUPdotNET.Error = nl[i].SelectSingleNode("Error").InnerText;
				}
				// check for an error from the server
				if(GUPdotNET.Error.Length > 2)
					ExitUpdate("Error parsing the update xml file - " + System.Environment.NewLine + GUPdotNET.Error);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		#endregion Update Info Web
		
		private void ExitUpdate(string strExitMess)
		{
			// if we don't want a silent check tell the user
			// why we can't update
			if(GUPdotNET.SilentCheck == false && strExitMess != null)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, strExitMess, "Exiting Update");
				md.Run();
				md.Destroy();
			}
			
		}
	}
}
