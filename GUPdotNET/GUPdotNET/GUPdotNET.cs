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
	
	
	public class GUPdotNET
	{
		
		private string _OSVersion = "win32";
		private string _ProgramName = null;
		private string _FileSize = null;
		private string _UpdateFileURL = null;
		private int _UpdateMajorVersion = -1;
		private int _UpdateMinorVersion = -1;
		private string _UpdateInfoURL = null;
		private string _VersionInfo = null;
		private int _CurrentMajorVersion = -1;
		private int _CurrentMinorVersion = -1;
		
		#region "Public Properties"
		
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
		///  This is URL for the update/installer
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		public string UpdateFileURL
		{
			get{return _UpdateFileURL;}
		}
		
		public string VersionInfo
		{
			get{return _VersionInfo;}
		}
		
		public string ProgramName
		{
			set{_ProgramName = value;}
			get{return _ProgramName;}
		}
		
		/// <summary>
		///  This is the size of update/installer
		///  recieved from the web site
		///  containing the update information
		/// </summary>
		public string FileSize
		{
			get{return _FileSize;}
		}
		
		/// <summary>
		///  This is the major version
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		public int CurrentMajorVersion
		{
			set{_CurrentMajorVersion=value;}
		}
		
		/// <summary>
		///  This is the minor version
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		public int CurrentMinorVersion
		{
			set{_CurrentMinorVersion=value;}
		}
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		public string OSVersion
		{
			set{_OSVersion=value;}
		}
		
		/// <summary>
		///  This is the major version
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		public string UpdateInfoURL
		{
			set{_UpdateInfoURL=value;}
		}
		
		#endregion "Public Properties"
		
		public bool CheckUpdate()
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
					Gtk.Application.Quit();
				}
				
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			return blnSuccess;
		}
		
		
		
		public void LoadUpdateInfo()
		{
			try
			{
				//System.Security.Permissions.EnvironmentPermission ep = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, System.Environment.CurrentDirectory);
				string strOSVersion = "";
				if(ConfigurationManager.AppSettings["OSVersion"].ToString() != String.Empty)
					strOSVersion = "&OSVersion=" + _OSVersion;
				string strURI = _UpdateInfoURL +
					"?MajorVersion=" + _UpdateMajorVersion.ToString() +
					"?MinorVersion=" + _UpdateMinorVersion.ToString() +
					strOSVersion;
				
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
					_UpdateFileURL = nl[i].SelectSingleNode("NeedToBeUpdated").InnerText;
					_FileSize = nl[i].SelectSingleNode("Version").InnerText;
					_UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("Version").InnerText);
					_UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("Version").InnerText);
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
