/*************************************************************************
 *                      UpdateInfo.cs
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
using System.Net;
using System.Xml;
using System.Configuration;
using System.Reflection;
using Gtk;

namespace GUPdotNET
{
	/// <summary>
	/// Description of UpdateInfo.
	/// </summary>
	public class UpdateInfo
	{
		#region Local File Info
		
		/// <summary>
		///  the freindly name of the application
		/// </summary>
		private string _ProgramTitle =  string.Empty;
		internal  string ProgramTitle
		{
			set{_ProgramTitle = value;}
			get{return _ProgramTitle;}
		}
		
		/// <summary>
		/// this is the actual name of the program i.e. MyProgram.exe
		/// </summary>
		private string _ProgramName =  string.Empty;
		internal string ProgramName
		{
			set{_ProgramName = value;}
			get{return _ProgramName;}
		}
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		private string _OS = string.Empty;
		internal string OS
		{
			set{_OS=value;}
			get{return _OS;}
		}
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		private string _InstallType = string.Empty;
		internal string InstallType
		{
			set{_InstallType=value;}
			get{return _InstallType;}
		}
		
		/// <summary>
		///  full path to the application we are updating
		/// </summary>
		private string _ProgramFullPath = string.Empty;
		public  string ProgramFullPath
		{
			set{_ProgramFullPath = value;}
			get{return _ProgramFullPath;}
		}
		
		/// <summary>
		///  This is URL for the web site
		///  containing the update information
		/// </summary>
		private string _UpdateInfoURL =  string.Empty;
		internal string UpdateInfoURL
		{
			set{_UpdateInfoURL = value;}
			get{return _UpdateInfoURL;}
		}
		
		/// <summary>
		///  This is the major version of the application
		///  we are looking to update
		/// </summary>
		private int _CurrentMajorVersion = -1;
		internal int CurrentMajorVersion
		{
			set{_CurrentMajorVersion=value;}
			get{return _CurrentMajorVersion;}
		}
		
		/// <summary>
		///  This is the minor version or the application
		///  we are looking to update
		/// </summary>
		private int _CurrentMinorVersion = -1;
		internal int CurrentMinorVersion
		{
			set{_CurrentMinorVersion=value;}
			get{return _CurrentMinorVersion;}
		}
		
		/// <summary>
		///  if this is set to true this will
		///  not report if no connection is made to the
		///  web server or if other interuptions occur
		/// </summary>
		private bool _SilentCheck = false;
		internal bool SilentCheck
		{
			set{_SilentCheck=value;}
			get{return _SilentCheck;}
		}
		
		/// <summary>
		/// This is the directory on the local maching
		/// where the new package will be stored and ran from
		/// </summary>
		private string _TempInstallerPath = string.Empty;
		internal string TempInstallerPath
		{
			set{_TempInstallerPath=value;}
			get{return _TempInstallerPath;}
		}
		
		#endregion Local File Info
				
		#region Remote Update Info
		
		/// <summary>
		///  The file that is the updated installation
		/// </summary>
		private string _UpdateFileURL = string.Empty;
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
		private int _UpdateMajorVersion = -1;
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
		private int _UpdateMinorVersion = -1;
		internal int UpdateMinorVersion
		{
			set{_UpdateMinorVersion = value;}
			get{return _UpdateMinorVersion;}
		}
		
		/// <summary>
		///  this is a generic string of the updatable version
		/// </summary>
		private string _LatestVersion = string.Empty;
		internal string LatestVersion
		{
			set{_LatestVersion=value;}
			get{return _LatestVersion;}
		}
		
		/// <summary>
		///  http URL of the update details if any
		/// </summary>
		private string _UpdateDetailsURL = string.Empty;
		internal string UpdateDetailsURL
		{
			set{_UpdateDetailsURL=value;}
			get{return _UpdateDetailsURL;}
		}
		
		/// <summary>
		///  this contains any error that is returned from the
		///  web site portion of the app
		/// </summary>
		private string _Error = string.Empty;
		internal string Error
		{
			set{_Error=value;}
			get{return _Error;}
		}
		
		#endregion Remote Update Info
		
		private bool IsLocalInfoLoaded = false;
		private bool IsRemoteInfoLoaded = false;
		public UpdateInfo()
		{
		}
		
		public UpdateInfo(UpdateInfoType ut)
		{
			LoadInfo(ut);
		}
		
		public UpdateInfo(bool blnSilentUpdate)
		{
			_SilentCheck = blnSilentUpdate;
		}
		
		public UpdateInfo(UpdateInfoType ut, bool blnSilentUpdate)
		{
			_SilentCheck = blnSilentUpdate;
			LoadInfo(ut);
		}
		
		public void LoadInfo(UpdateInfoType ut)
		{
			switch(ut)
			{
				case UpdateInfoType.Both:
					LoadLocalInfo();
					LoadRemoteInfo();
					break;
				case UpdateInfoType.Local:
					LoadLocalInfo();
					break;
				case UpdateInfoType.Remote:
					LoadRemoteInfo();
					break;
			}
		}
		
		public bool UpdateAvailable()
		{
			if(!IsLocalInfoLoaded)
				LoadLocalInfo();
			if(!IsRemoteInfoLoaded)
				LoadRemoteInfo();
			
			if(_UpdateMajorVersion > _CurrentMajorVersion || (_UpdateMajorVersion == _CurrentMajorVersion && _UpdateMinorVersion > _CurrentMinorVersion))
				return true;
			else
				return false;
			
		}
		
		private void LoadLocalInfo()
		{
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.GetCallingAssembly();
				_OS = ConfigurationManager.AppSettings["OS"].ToString();
				_InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
				_UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
				_ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
				_ProgramTitle = ConfigurationManager.AppSettings["ProgramTitle"].ToString();
				_CurrentMajorVersion = asm.GetName().Version.Major;
				_CurrentMinorVersion = asm.GetName().Version.Minor;
				_ProgramFullPath = asm.GetName().CodeBase;
				IsLocalInfoLoaded = true;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private void LoadRemoteInfo()
		{
			try
			{
				Common.Option.LastUpdateCheck = DateTime.Now;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(_UpdateInfoURL + "?InstallType=" + _InstallType.ToString() + "&OS=" + _OS.ToString());
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
				// get the xml that defines the update
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(s);				
				XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				// parse out the GUPdotNET element children
				for (int i = 0; i < nl.Count; i++)
				{
					_UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText.Trim());
					_UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText.Trim());
					_LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText.Trim();
					_UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText.Trim();
					_UpdateDetailsURL = nl[i].SelectSingleNode("UpdateDetailsURL").InnerText.Trim();
					_Error = nl[i].SelectSingleNode("UpdateError").InnerText.Trim();
				}
				// check for an error from the server
				if(_Error.Length > 2)
					throw new Exception("Error parsing the update xml file - " + System.Environment.NewLine + _Error);
				
				IsRemoteInfoLoaded = true;
			}
			catch(WebException e)
			{
				// if we get a web exception exit the update
				Common.HandleError(new Exception("Unable to connect to the update web site - " + System.Environment.NewLine + e.Message));
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
	}
	
	public enum UpdateInfoType
	{
		Both,
		Local,
		Remote,
		None
	}
}
