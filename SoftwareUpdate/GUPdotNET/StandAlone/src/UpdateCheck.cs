/*************************************************************************
 *                      UpdateCheck.cs
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
		private string _InstallType =  ConfigurationManager.AppSettings["InstallType"].ToString();
		private string _ProgramTitle =  ConfigurationManager.AppSettings["ProgramTitle"].ToString();
		// this is the full path to the program i.e. C:/MyDocuments/MyProgramFolder/
		private string _ProgramFullPath = string.Empty;
		// this is the actual name of the program i.e. MyProgram.exe
		private string _ProgramName =  ConfigurationManager.AppSettings["ProgramName"].ToString();
		private string _UpdateInfoURL =  ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
		private int _CurrentMajorVersion = -1;
		private int _CurrentMinorVersion = -1;
		private bool _SilentCheck = false;
		private string _TempInstallerPath = string.Empty;
		
		#endregion Local Variable Declaration
		
		#region Web Variable Declaration
		
		// values that are imported from the aspx file on the listed web site
		private string _UpdateFileURL = null;
		private int _UpdateMajorVersion = -1;
		private int _UpdateMinorVersion = -1;
		private string _LatestVersion = null;
		private string _Error = null;
		
		#endregion Web Variable Declaration
		
		#region Public Properties Local
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		public string InstallType
		{
			set{_InstallType=value;}
			get{return _InstallType;}
		}
		
		public string TempInstallerPath
		{
			set{_TempInstallerPath=value;}
			get{return _TempInstallerPath;}
		}
		
		/// <summary>
		///  the freindly name of the application
		/// </summary>
		public  string ProgramTitle
		{
			set{_ProgramTitle = value;}
			get{return _ProgramTitle;}
		}
		
		/// <summary>
		///  full path to the application we are updating
		/// </summary>
		public  string ProgramFullPath
		{
			set{_ProgramFullPath = value;}
			get{return _ProgramFullPath;}
		}
		
		public string ProgramName
		{
			set{_ProgramName = value;}
			get{return _ProgramName;}
		}
		
		/// <summary>
		///  This is URL for the web site
		///  containing the update information
		/// </summary>
		public string UpdateInfoURL
		{
			set{_UpdateInfoURL = value;}
			get{return _UpdateInfoURL;}
		}
		
		/// <summary>
		///  This is the major version of the application
		///  we are looking to update
		/// </summary>
		public int CurrentMajorVersion
		{
			set{_CurrentMajorVersion=value;}
			get{return _CurrentMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version or the application
		///  we are looking to update
		/// </summary>
		public int CurrentMinorVersion
		{
			set{_CurrentMinorVersion=value;}
			get{return _CurrentMinorVersion;}
		}
		
		/// <summary>
		///  if this is set to true this will
		///  not report if no connection is made to the
		///  web server or if other interuptions occur
		/// </summary>
		public bool SilentCheck
		{
			set{_SilentCheck=value;}
			get{return _SilentCheck;}
		}
		
		#endregion Public Properties Local
		
		#region Public Properties Web Server
		
		/// <summary>
		///  The file that is the updated installation
		/// </summary>
		internal string UpdateFileURL
		{
			set{_UpdateFileURL=value;}
			get{return _UpdateFileURL;}
		}
		
		/// <summary>
		///  This is the major version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		internal int UpdateMajorVersion
		{
			set{_UpdateMajorVersion= value;}
			get{return _UpdateMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		internal int UpdateMinorVersion
		{
			set{_UpdateMinorVersion = value;}
			get{return _UpdateMinorVersion;}
		}
		
		/// <summary>
		///  this is a generic string of the updatable version
		/// </summary>
		internal string LatestVersion
		{
			set{_LatestVersion=value;}
			get{return _LatestVersion;}
		}
		
		/// <summary>
		///  this contains any error that is returned from the
		///  web site portion of the app
		/// </summary>
		internal string Error
		{
			set{_Error=value;}
			get{return _Error;}
		}
		
		#endregion Public Properties Web Server

		#region Constructors
		
		public UpdateCheck()
		{
			
		}
		
		#endregion Constructors
		
		public void RunUpdateCheck()
		{
			try
			{
				// load the update info from the web
				UpdateInfoGet();
				// check if we need an update via the major and minor version
				if(_UpdateMajorVersion > _CurrentMajorVersion || (_UpdateMajorVersion == _CurrentMajorVersion && _UpdateMinorVersion > _CurrentMinorVersion))
				{
					// tell the user there is an update availalbe
					// and ask if they would like to update
					frmUpdateConfirm dlgConfirm = new frmUpdateConfirm(_ProgramTitle, _ProgramName, _LatestVersion);
					if((Gtk.ResponseType)dlgConfirm.Run() == Gtk.ResponseType.Ok)
					{
						// update confirmed get installer file
						frmUpdateDownload dlgDownload = new frmUpdateDownload(_ProgramTitle, _ProgramName, _UpdateFileURL);
						if((Gtk.ResponseType)dlgDownload.Run() == Gtk.ResponseType.Ok)
						{
							_TempInstallerPath = dlgDownload.TempFilePath;
							
							// if the download was sucessful then procede with the install
							frmInstallDialog Inst = new frmInstallDialog(_ProgramName, _ProgramTitle, _InstallType, _TempInstallerPath);
							Inst.Run();
							Inst.Destroy();
							
						}
						dlgDownload.Destroy();
					}
					else
					{
						Application.Quit();
					}
					dlgConfirm.Destroy();
				}
				else
				{
					// if the update check is not silent notify the user of the results
					if(_SilentCheck == false)
					{
						Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "No updates avalable at this time." ,"No updates");
						md.Run();
						md.Destroy();
					}
				}
				
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString() ,"GUPdotNET Update Error");
				md.Run();
				md.Destroy();
				// if we have an exception we want to exit the application 
				// so it doens't keep on running in the background
				Gtk.Application.Quit();
			}
		}
		
		#region Update Info Web
		
		private void UpdateInfoGet()
		{
			try
			{
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(_UpdateInfoURL + "?InstallType=" + _InstallType );
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				ParseResponse(s);
			}
			catch(WebException e)
			{
				// if we get a web exception exit the update
				throw new Exception("Unable to connect to the update web site - " + System.Environment.NewLine + e.Message);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.ToString());
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
					_UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText;
					_UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText);
					_UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText);
					_LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText;
					_Error = nl[i].SelectSingleNode("Error").InnerText;
				}
				// check for an error from the server
				if(_Error.Length > 2)
					throw new Exception("Error parsing the update xml file - " + System.Environment.NewLine + _Error);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.ToString());
			}
			
		}
		
		#endregion Update Info Web
	}
}
