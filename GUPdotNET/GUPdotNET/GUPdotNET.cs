// GUPdotNET.cs
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Security;
using System.Security.Permissions;
using Gtk;

namespace GUPdotNET
{
	public class UpdateCheck
	{
		// value from the calling application or from the app con
		private string _InstallType = null; 
		private string _ProgramName = null;
		private string _UpdateInfoURL = null;
		private int _CurrentMajorVersion = -1;
		private int _CurrentMinorVersion = -1;
		private bool _SilentCheck = true;
		private string _CallingApplication = null;
		
		// values that are imported from the aspx file on the listed web site
		private string _UpdateFileURL = null;
		private int _UpdateMajorVersion = -1;
		private int _UpdateMinorVersion = -1;
		private string _LatestVersion = null;
		private string _Error = null;
		
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
		
		/// <summary>
		///  the freindly name of the application
		/// </summary>
		public  string ProgramName
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
		
		/// <summary>
		///  The name of the application that we are looking to update
		/// </summary>
		 public string CallingApplication
		{
			set{_CallingApplication = value;}
			get{return _CallingApplication;}
		}
		
		#endregion Public Properties Local
		
		#region Public Properties Web Server
		
		/// <summary>
		///  The file that is the updated installation
		/// </summary>
		public string UpdateFileURL
		{
			get{return _UpdateFileURL;}
		}
		
		/// <summary>
		///  This is the major version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		 public int UpdateMajorVersion
		{
			get{return _UpdateMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		 public int UpdateMinorVersion
		{
			get{return _UpdateMinorVersion;}
		}
		
		/// <summary>
		///  this is a generic string of the updatable version
		/// </summary>
		 public string LatestVersion
		{
			get{return _LatestVersion;}
		}
		
		/// <summary>
		///  this contains any error that is returned from the
		///  web site portion of the app
		/// </summary>
		public string Error
		{
			get{return _Error;}
		}
		
		#endregion Public Properties Web Server
		
		 public void RunCheck()
		{
			bool blnSuccess = true;
			try
			{
				LoadUpdateInfo();
				if(_UpdateMajorVersion > _CurrentMajorVersion || (_UpdateMajorVersion == _CurrentMajorVersion && _UpdateMinorVersion > _CurrentMinorVersion))
				{
					frmUpdateConfirm fm = new frmUpdateConfirm(this);
					fm.Show ();
					Application.Run ();
				}
				else
				{
					if(_SilentCheck == false)
					{
						Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Not updates avalable at this time." ,"No updates");
						md.Run();
						md.Destroy();
					}
				}
				
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			//return blnSuccess;
		}
		
		
		
		 public void LoadUpdateInfo()
		{
			try
			{
				//System.Security.Permissions.EnvironmentPermission ep = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, System.Environment.CurrentDirectory);
				string strURI = _UpdateInfoURL +
					"?InstallType=" + _InstallType;
				
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strURI);
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				// Parse out the xml that has been returned
				ParseResponse(s);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		 public void ParseResponse(Stream s)
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(s);
				
				XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				for (int i = 0; i < nl.Count; i++)
				{
					_UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText;
					_UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText);
					_UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText);
					_LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText;
					_Error = nl[i].SelectSingleNode("Error").InnerText;
				}
			}
			
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
	}
}
