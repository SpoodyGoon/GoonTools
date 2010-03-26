/*************************************************************************
 *                      frmInstall.cs
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
using GoonTools;

namespace libGUPdotNET
{	
	
	public partial class frmInstall : Gtk.Dialog
	{
//		private SecureString _AdminPass = null;
//		// this is the global flag signaling if we want to cancel the update
//		private bool _Cancel = false;
//		private bool _IsSystemInstall = true;
		private UpdateInfo _UpdateInfo;
		public frmInstall(UpdateInfo updateinfo)
		{
			this.Build();
			_UpdateInfo = updateinfo;
			
			this.Title = _UpdateInfo.ProgramTitle;
			this.lblTitle.Text = "<span size=\"large\"><b>Installing " +  _UpdateInfo.ProgramName + "</b></span>";
			this.lblTitle.UseMarkup = true;
			this.lblMessage.Text = "Starting Install";
			this.lblMessage.UseMarkup = true;
			this.ShowNow();
			
			switch(_UpdateInfo.OS)
			{
				case "Windows":
					PrepInstallWin32();
					break;
				case "Linux":
//					PrepInstallLinux();
//					InstallLinuxRPM();
					break;
				case "Mac":
//					PrepInstallLinux();
//				InstallLinuxSource();
					break;
				default:
					throw new Exception("Invalid Install Type");
			}
		}
		
		#region Windows Install
		
		private void PrepInstallWin32()
		{		
			// TODO: test this functinality
			Process p = Process.GetCurrentProcess();
			p.Exited += delegate { System.Diagnostics.Process.Start(_UpdateInfo.TempInstallerPath); };
			// ask the user to save changes and close calling application
			Gtk.MessageDialog md = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.OkCancel, false, "The update is ready to install " + _UpdateInfo.ProgramName + " please save any changes you have and click ok to continue the update.", "Save & Close");
			if(((Gtk.ResponseType)md.Run()) == ResponseType.Ok)
			{
				Common.LogUpdate("Update install");
				Common.Option.LastUpdate = DateTime.Now;
				Common.SaveOptions();
				Gtk.Application.Quit();
				this.Respond(Gtk.ResponseType.Cancel);
				this.Hide();
			}
			else
			{
				this.Respond(Gtk.ResponseType.Cancel);
				this.Hide();
			}
			md.Destroy();
		}
		
		
		
//		private bool HasAccess(string _TempInstallerPath)
//		{
//			// assume the user has access
//			bool blnHasAccess = true;
//			
//			FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.AllAccess, _TempInstallerPath);
//			try
//			{
//				f2.Demand();
//			}
//			catch (System.Security.SecurityException s)
//			{
//				blnHasAccess = false;
//				Console.WriteLine(s.Message);
//			}
//			return blnHasAccess;
//		}
		
//		private void InstallWindows()
//		{
//			
//		}
		
		#endregion Windows Install
		
		#region RPM Install
		
//		private void InstallRPM()
//		{
//			if(Environment.UserName != "root")
//			{
//				Gtk.InputDialog imp = new InputDialog();
//				imp.Title = "Admin Password";
//				
//			}
//		}
		
		#endregion RPM Install
	}
}
