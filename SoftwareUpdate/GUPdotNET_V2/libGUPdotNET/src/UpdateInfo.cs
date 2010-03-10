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
using GoonTools;
using Gtk;

namespace GUPdotNET
{
	/// <summary>
	/// Description of UpdateInfo.
	/// </summary>
	/// // TODO: something is failing in the initializatin of update info
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
		///  This is the GUPdotNET Version
		///  Different versions of GUPdotNET may have different file formats
		/// </summary>
		private Version _XMLFileVersion = new Version(1,0);
		internal Version XMLFileVersion
		{
			set{_XMLFileVersion=value;}
			get{return _XMLFileVersion;}
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
		private Version _CurrentVersion = new Version();
		internal Version CurrentVersion
		{
			set{_CurrentVersion=value;}
			get{return _CurrentVersion;}
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
		private Version _UpdateVersion = new Version();
		internal Version UpdateVersion
		{
			set{_UpdateVersion= value;}
			get{return _UpdateVersion;}
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
		///  The CheckSum Type
		/// </summary>
		private CheckSum.CheckSumType _UseCheckSumType = CheckSum.CheckSumType.MD5;
		internal CheckSum.CheckSumType UseCheckSumType
		{
			set{_UseCheckSumType=value;}
			get{return _UseCheckSumType;}
		}
		
		/// <summary>
		///  The CheckSum of the installer or compressed file
		/// </summary>
		private string _UseCheckSum = string.Empty;
		internal string UseCheckSum
		{
			set{_UseCheckSum=value;}
			get{return _UseCheckSum;}
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
			try
			{
				switch(ut)
				{
					case UpdateInfoType.All:
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
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public bool UpdateAvailable
		{
			get{return CheckUpdate();}
		}
		
		private bool CheckUpdate()
		{
			if(!IsLocalInfoLoaded)
				LoadLocalInfo();
			if(!IsRemoteInfoLoaded)
				LoadRemoteInfo();
			
			if(_UpdateVersion.CompareTo(_CurrentVersion) > 1)
				return true;
			else
				return false;
		}
		
		private void LoadLocalInfo()
		{
			try
			{
				System.IO.FileInfo fi;
				System.Reflection.Assembly asm = System.Reflection.Assembly.GetCallingAssembly();
				// check to see if the versioning information is over ridden by the configuration file
				if(!string.IsNullOrEmpty(ConfigurationManager.AppSettings["MajorVersion"].ToString()) && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["MinorVersion"].ToString()))
					_CurrentVersion = new Version( Convert.ToInt32(ConfigurationManager.AppSettings["MajorVersion"].ToString()), Convert.ToInt32(ConfigurationManager.AppSettings["MinorVersion"].ToString()));
				else
					_CurrentVersion = asm.GetName().Version;
				
				// used for debugging in cases where we don't have the calling assembliy
				if(!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ProgramFullPath"].ToString()))
				{
					fi = new System.IO.FileInfo(ConfigurationManager.AppSettings["ProgramFullPath"].ToString());
					if(fi.Exists)
						_ProgramFullPath = fi.FullName;
				}
				else
				{
					fi = new System.IO.FileInfo(asm.GetName().CodeBase);
					if(fi.Exists)
						_ProgramFullPath = fi.FullName;
				}
				
				_OS = ConfigurationManager.AppSettings["OS"].ToString();
				_InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
				_UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
				_ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
				_ProgramTitle = ConfigurationManager.AppSettings["ProgramTitle"].ToString();
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
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(_UpdateInfoURL + "?XMLFileVersion=" + _XMLFileVersion.Major.ToString() + "." + _XMLFileVersion.Minor.ToString() + "&InstallType=" + _InstallType.ToString() + "&OS=" + _OS.ToString());
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
				// get the xml that defines the update
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(s);
				XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				// parse out the GUPdotNET element children
				for (int i = 0; i < nl.Count; i++)
				{
					_UpdateVersion = new Version(Convert.ToInt32(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText.Trim()),Convert.ToInt32(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText.Trim()));
					_LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText.Trim();
					_UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText.Trim();
					_UpdateDetailsURL = nl[i].SelectSingleNode("UpdateDetailsURL").InnerText.Trim();
					_UseCheckSumType = GetCheckSumType( nl[i].SelectSingleNode("CheckSumType").InnerText.Trim());
					_UseCheckSum = nl[i].SelectSingleNode("CheckSum").InnerText.Trim();
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
		
		private GoonTools.CheckSum.CheckSumType GetCheckSumType(string strCheckSum)
		{
			switch(strCheckSum)
			{
				case "MD5":
					return CheckSum.CheckSumType.MD5;
				case "SHA1":
					return CheckSum.CheckSumType.SHA1;
				case "SHA256":
					return CheckSum.CheckSumType.SHA256;
				case "SHA384":
					return CheckSum.CheckSumType.SHA384;
				case "SHA512":
					return CheckSum.CheckSumType.SHA512;
			}
			return CheckSum.CheckSumType.MD5;
		}
	}
	
	public enum UpdateInfoType
	{
		Local,
		Remote,
		All,
		None
	}
}
