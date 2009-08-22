/*************************************************************************
 *                      frmUpdateCheck.cs
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
	
	public partial class frmUpdateCheck : Gtk.Dialog
	{
		#region Local Variable Declaration
		
		// value from the calling application or from the app con
		private string _ProgramTitle =  string.Empty;
		// this is the actual name of the program i.e. MyProgram.exe
		private string _ProgramName =  string.Empty;
		private string _OS = string.Empty;
		private string _InstallType = string.Empty;
		// this is the full path to the program i.e. C:/MyDocuments/MyProgramFolder/
		private string _ProgramFullPath = string.Empty;
		// this is the http URL where we get the update info from
		private string _UpdateInfoURL =  string.Empty;
		private int _CurrentMajorVersion = -1;
		private int _CurrentMinorVersion = -1;
		private bool _SilentCheck = false;
		private string _TempInstallerPath = string.Empty;
		
		#endregion Local Variable Declaration
		
		#region Web Variable Declaration
		
		// values that are imported from the aspx file on the listed web site
		// Major version of the update program
		private int _UpdateMajorVersion = -1;
		// Minor version of the update program
		private int _UpdateMinorVersion = -1;
		// friendly version string format
		private string _LatestVersion = string.Empty;
		// http URL of the new program
		private string _UpdateFileURL = string.Empty;
		// http URL of the update details if any
		private string _UpdateDetailsURL = string.Empty;
		// for any error that may happen
		private string _Error = string.Empty;
		
		#endregion Web Variable Declaration
		
		#region Public Properties Local
		
		/// <summary>
		///  the freindly name of the application
		/// </summary>
		public  string ProgramTitle
		{
			set{_ProgramTitle = value;}
			get{return _ProgramTitle;}
		}
		
		/// <summary>
		/// this is the actual name of the program i.e. MyProgram.exe
		/// </summary>
		public string ProgramName
		{
			set{_ProgramName = value;}
			get{return _ProgramName;}
		}
		
		/// <summary>
		///  This is the Operating System info
		///  Passed in by the program calling the GUPdotNET assembly/class
		/// </summary>
		public string OS
		{
			set{_OS=value;}
			get{return _OS;}
		}
		
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
		///  full path to the application we are updating
		/// </summary>
		public  string ProgramFullPath
		{
			set{_ProgramFullPath = value;}
			get{return _ProgramFullPath;}
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
		/// This is the directory on the local maching
		/// where the new package will be stored and ran from
		/// </summary>
		internal string TempInstallerPath
		{
			set{_TempInstallerPath=value;}
			get{return _TempInstallerPath;}
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
		///  http URL of the update details if any
		/// </summary>
		internal string UpdateDetailsURL
		{
			set{_UpdateDetailsURL=value;}
			get{return _UpdateDetailsURL;}
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
		
		private bool _ShowOptions = false;
		public frmUpdateCheck()
		{
			this.Build();
			LoadAppSetting();
			Common.LoadAll();
			this.Visible = false;
			this.ShowAll();
		}
		
		public frmUpdateCheck(bool showoptions)
		{
			this.Build();
			_ShowOptions = showoptions;
			LoadAppSetting();
			Common.LoadAll();
		}
		
		#endregion Constructors
		
		public void LoadAppSetting()
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
		}
		
		private void LoadControls()
		{
			try
			{
//				cboUpdateTimeType = ComboBox.NewText();
//				int Selected = 0;
//				for(int i=0; i < Common.DateLengths.Length; i++)
//				{				
//					cboUpdateTimeType.AppendText(Common.DateLengths[i]);
//					if(Common.DateLengths[i] == Common.Option.UpdateTimeType)
//						Selected = i;
//				}
				//ICollection ic = new CommaDelimitedStringCollection("Day", "Week", "Month", "Year", "Never");
				//ArrayList TimeType = new ArrayList(ic);
				//cboUpdateTimeType..Active = _DateLengths.;
				cbxAutoUpdate.Active = Common.Option.AutoUpdate;
				spnUpdateTimeAmount.Value = Common.Option.UpdateTimeAmount;
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
	
		
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			Common.SaveOptions();
			this.Hide();
		}
		
		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		
		protected virtual void OnBtnAboutClicked (object sender, System.EventArgs e)
		{
			btnAbout.Relief = ReliefStyle.None;
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			Gtk.AboutDialog ad = new Gtk.AboutDialog();
			ad.Title = "About GUPdotNET";
			ad.ProgramName = "GUPdotNET";
			ad.Comments ="General Purpose Update program for Mono/Gtk#.";
			ad.License = GUPdotNET.Const.License;
			ad.Authors = new String[]{"Andrew York <goontools@brdstudio.net>"};
			ad.Version = " " + asm.GetName().Version.Major.ToString() + "." + asm.GetName().Version.Minor.ToString() + " alpha";
			ad.Logo = Gdk.Pixbuf.LoadFromResource("update_large.png");
			ad.Icon = Gdk.Pixbuf.LoadFromResource("update_small.png");
			ad.AllowShrink = true;
			ad.AllowGrow = true;
			ad.Copyright = "GoonTools 2009";
			ad.HasSeparator = true;
			ad.Modal = true;
			ad.BorderWidth = 8;
			ad.WidthRequest = 350;
//			ad.HeightRequest = 300;
			ad.Website = "http://code.google.com/p/goontools/wiki/GUPdotNet";
			ad.WebsiteLabel = "GUPdotNET Web Site";
			ad.Run();
			ad.Destroy();
		}
		
		protected virtual void OnBtnAboutPressed (object sender, System.EventArgs e)
		{
			btnAbout.Relief = ReliefStyle.None;
		}
		
		protected virtual void OnBtnAboutEntered (object sender, System.EventArgs e)
		{
			btnAbout.Relief = ReliefStyle.None;
		}
		
		
		protected virtual void OnBtnCheckNowClicked (object sender, System.EventArgs e)
		{
			RunUpdateCheck();
		}
		
		#region Update Process
		
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
							frmInstallDialog Inst = new frmInstallDialog(_ProgramName, _ProgramTitle, _OS, _InstallType, _TempInstallerPath);
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
		
		#endregion Update Process
		
		#region Update Info Web
		
		private void UpdateInfoGet()
		{
			try
			{
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(_UpdateInfoURL + "?InstallType=" + _InstallType.ToString() + "&OS=" + _OS.ToString());
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
					_UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText.Trim());
					_UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText.Trim());
					_LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText.Trim();
					_UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText.Trim();
					_UpdateDetailsURL = nl[i].SelectSingleNode("UpdateDetailsURL").InnerText.Trim();
					_Error = nl[i].SelectSingleNode("Error").InnerText.Trim();
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
