﻿/*************************************************************************
 *                      frmInstallDialog.cs
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
using System.Security;
using System.Security.Permissions;
using System.Diagnostics;
using Gtk;

namespace GUPdotNET
{	
	public partial class frmInstallDialog : Gtk.Dialog
	{		
		private SecureString _AdminPass = null;
		// this is the global flag signaling if we want to cancel the update
		private bool _Cancel = false;
		private bool _IsSystemInstall = true;
		private string _ProgramTitle = string.Empty;
		private string _ProgramName = string.Empty;
		private string _TempInstallerPath = string.Empty;
		private string _OS = string.Empty;
		private string _CurrentInstallType = string.Empty;
		public frmInstallDialog(string programname, string programtitle, string os, string currentinstalltype, string _tempinstallerpath)
		{
			this.Build();
			_ProgramTitle = programtitle;
			_ProgramName = programname;
			_CurrentInstallType = currentinstalltype;
			_OS = os;
			_TempInstallerPath = _tempinstallerpath;
			
			this.Title = programtitle;
			this.lblTitle.Text = "<span size=\"large\"><b>Installing " +  programtitle + "</b></span>";
			this.lblTitle.UseMarkup = true;
			this.lblMessage.Text = "Starting Install";
			this.lblMessage.UseMarkup = true;
			this.ShowNow();
			
			switch(os)
			{
				case "Windows":
					PrepInstallWin32();
					break;
				case "Linux":
					PrepInstallLinux();
					InstallLinuxRPM();
					break;
				case "Mac":
					PrepInstallLinux();
				InstallLinuxSource();
					break;
				default:
					throw new Exception("Invalid Install Type");
			}
		}
		
		#region Linux Install
		
		private void PrepInstallLinux()
		{
			// get the current users name and see if it is in our current path
			// if it is that means we are installing in the users home directory
//			if(GUPdotNET.ProgramFullPath.Contains(System.Environment.UserName) && System.Environment.UserName != "root" && GUPdotNET.InstallType != "Linux_rpm")
//			{
//				_IsSystemInstall = false;
//			}
//			else
//			{
//				// this is a system install and the user needs to be root
//				// or we need the password for sudo
//				_IsSystemInstall = true;
//				frmSuPass fm = new frmSuPass();
//				Gtk.ResponseType resp = (Gtk.ResponseType)fm.Run();
//				if(resp == ResponseType.Ok)
//				{
//					foreach(char c in fm.AdminPass)
//						_AdminPass.AppendChar(c);
//				}
//				fm.Destroy();
//			}
		}
		
		private void InstallLinuxBin()
		{
//			try
//			{
//				textview1.Buffer.Text += "\nChanging file permissions";
//				textview1.Buffer.Text += "\nchmod 775 " + GUPdotNET.TempInstallerPath;
//				System.Diagnostics.Process proc = new System.Diagnostics.Process();
//				proc.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(GUPdotNET.TempInstallerPath);
//				if(_IsSystemInstall == true)
//					proc.StartInfo.Password = _AdminPass;
//				proc.StartInfo.UseShellExecute = false;
//				proc.StartInfo.FileName = "chmod 775 " + GUPdotNET.TempInstallerPath;
//				proc.Start();
//				textview1.Buffer.Text += "\nStarting Installer";
//				textview1.Buffer.Text += "\n" + GUPdotNET.TempInstallerPath;
//				System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
//				proc2.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(GUPdotNET.TempInstallerPath);
//				if(_IsSystemInstall == true)
//					proc.StartInfo.Password = _AdminPass;
//				proc2.StartInfo.UseShellExecute = false;
//				proc2.StartInfo.FileName = GUPdotNET.TempInstallerPath;
//				proc2.Start();
//				
//			}
//			catch(Exception doh)
//			{
//				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString() ,"Error");
//				md.Run();
//				md.Destroy();
//			}			
		}
		
		private void InstallLinuxRPM()
		{
//			try
//			{
//				textview1.Buffer.Text += "\nChanging file permissions";
//				textview1.Buffer.Text += "\nchmod 775 " + GUPdotNET.TempInstallerPath;
//				System.Diagnostics.Process proc = new System.Diagnostics.Process();
//				proc.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(GUPdotNET.TempInstallerPath);
//				proc.StartInfo.Password = _AdminPass;
//				proc.StartInfo.UseShellExecute = false;
//				proc.StartInfo.FileName = "chmod 775 " + GUPdotNET.TempInstallerPath;
//				proc.Start();
//				textview1.Buffer.Text += "\nStarting Installer";
//				textview1.Buffer.Text += "\nrpm -Uvh " + GUPdotNET.TempInstallerPath;
//				System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
//				proc2.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(GUPdotNET.TempInstallerPath);
//				proc.StartInfo.Password = _AdminPass;
//				proc2.StartInfo.UseShellExecute = false;
//				proc2.StartInfo.FileName = "rpm -Uvh " + GUPdotNET.TempInstallerPath;
//				proc2.Start();
//				
//			}
//			catch(Exception doh)
//			{
//				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString() ,"Error");
//				md.Run();
//				md.Destroy();
//			}			
		}		
		
		private void InstallLinuxSource()
		{
//			try
//			{
//				textview1.Buffer.Text += "\nChanging file permissions";
//				textview1.Buffer.Text += "\nchmod 775 " + GUPdotNET.TempInstallerPath;
//				System.Diagnostics.Process proc = new System.Diagnostics.Process();
//				proc.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(GUPdotNET.TempInstallerPath);
//				proc.StartInfo.Password = _AdminPass;
//				proc.StartInfo.UseShellExecute = false;
//				proc.StartInfo.FileName = "chmod 775 " + GUPdotNET.TempInstallerPath;
//				proc.Start();
//				textview1.Buffer.Text += "\nStarting Installer";
//				textview1.Buffer.Text += "\nrpm -Uvh " + GUPdotNET.TempInstallerPath;
//				System.Diagnostics.Process proc2 = new System.Diagnostics.Process();
//				proc2.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(GUPdotNET.TempInstallerPath);
//				if(_IsSystemInstall == true)
//					proc.StartInfo.Password = _AdminPass;
//				proc2.StartInfo.UseShellExecute = false;
//				proc2.StartInfo.FileName = "rpm -Uvh " + GUPdotNET.TempInstallerPath;
//				proc2.Start();
				
//			}
//			catch(Exception doh)
//			{
//				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString() ,"Error");
//				md.Run();
//				md.Destroy();
//			}			
		}
		
		#endregion Linux Install
		
		#region Windows Install
		
		private void PrepInstallWin32()
		{			
			// ask the user to save changes and close calling application
			string strRequest = "The update is ready to install " + _ProgramTitle + " please save any changes you have and click ok to continue the update.";
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.OkCancel, false, strRequest);
			if(((Gtk.ResponseType)md.Run()) == ResponseType.Ok)
			{
				System.Diagnostics.Process.Start(_TempInstallerPath);
				Common.LogUpdate("Update install");
				Common.Option.LastUpdate = DateTime.Now;
				Common.SaveOptions();
				Application.Quit();
			}
			else
			{
				_Cancel = true;
				this.Respond(Gtk.ResponseType.Cancel);
				this.Hide();
			}
			md.Destroy();
			
			if(_Cancel == false)
			{
				bool blnHasAccess = HasAccess(_TempInstallerPath);
				while(blnHasAccess == false && _Cancel == false)
				{
					frmSuPass fm = new frmSuPass();
					Gtk.ResponseType rsp = (Gtk.ResponseType)fm.Run();
					if(rsp == ResponseType.Ok)
					{
						blnHasAccess = HasAccess(_TempInstallerPath);
					}
					else
					{
						_Cancel= true;
						this.Respond(Gtk.ResponseType.Cancel);
						this.Hide();
					}
					fm.Destroy();
				}
			}			
		}
		
		private bool HasAccess(string _TempInstallerPath)
		{
			// assume the user has access
			bool blnHasAccess = true;
			
			FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.AllAccess, _TempInstallerPath);
			try
			{
				f2.Demand();
			}
			catch (System.Security.SecurityException s)
			{
				blnHasAccess = false;
				Console.WriteLine(s.Message);
			}
			return blnHasAccess;
		}
		
		#endregion Windows Install
	}
}
