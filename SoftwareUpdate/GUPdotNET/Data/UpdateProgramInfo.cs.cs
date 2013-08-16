
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Reflection;
using Gtk;
using GoonTools;

namespace GUPdotNET.Data
{
	/// <summary>
	/// Data class containing the information concerning the program
	/// that GUPdotNET is supporting.
	/// </summary>
	public class UpdateProgramInfo
	{	
		/// <summary>
		///  The freindly name of the application
		/// </summary>
		internal  string ProgramTitle{ get; set; }

		/// <summary>
		/// This is the actual name of the program <example>MyProgram.exe</example>.
		/// </summary>
		internal string ProgramName{ get; set; }

		/// <summary>
		///  This is the GUPdotNET Config File Version.
		///  Different versions of GUPdotNET may have different file formats.
		/// </summary>
		internal System.Version ConfigFileVersion{ get; set; }

		/// <summary>
		/// This is the Operating System info gotten from
		/// the settings file if it is available, otherwise gotten from
		/// System.Enviroment methods.
		/// </summary>
		internal string OS{get;set;}

		/// <summary>
		/// The type of installer that is being supported by GUPdotNET.
		/// </summary>
		internal string InstallType{get;set;}	

		/// <summary>
		/// Full path to the application we are updating,
		/// should be the same directory that GUPdotNET is in.
		/// </summary>
		internal  string ProgramFullPath{ get; set; }
		
		/// <summary>
		///  The URL for the config file containing the update information.
		/// </summary>
		internal string UpdateInfoURL{get;set;}
		
		/// <summary>
		/// The current version of the program GUPdotNET is supporting,
		/// gotten from the settings file if present, otherwise gotten from the 
		/// calling assebly.
		/// </summary>
		internal System.Version ProgramVersion{get;set;}
		
		/// <summary>
		/// If this is set to true this will not report if no connection 
		/// is made to the web server or if other interuptions occur.
		/// </summary>
		internal bool SilentCheck{get;set;}
		
		/// <summary>
		/// This is the directory on the local maching
		/// where the new package(s) and other files 
		/// will be stored and ran from.
		/// </summary>
		internal string TempWorkingPath{get;set;}

		/*
		
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
		
		private CheckSumType GetCheckSumType(string strCheckSum)
		{
			switch(strCheckSum)
			{
				case "MD5":
					return CheckSumType.MD5;
				case "SHA1":
					return CheckSumType.SHA1;
				case "SHA256":
					return CheckSumType.SHA256;
				case "SHA384":
					return CheckSumType.SHA384;
				case "SHA512":
					return CheckSumType.SHA512;
			}
			return CheckSumType.MD5;
		}
		*/
	}
	/*
	public enum UpdateInfoType
	{
		Local,
		Remote,
		All,
		None
	}
	*/
}
