// frmInstallDialog.cs created with MonoDevelop
// User: spoodygoon at 4:55 PM 3/8/2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;
using System.Net;
using System.Security.Permissions;
using System.Diagnostics;
using Gtk;

namespace GUPdotNET
{
	
	
	public partial class frmInstallDialog : Gtk.Dialog
	{
		
		private string _AdminPass = null;
		// this is the global flag signaling if we want to cancel the update
		private bool _Cancel = false;
		public frmInstallDialog()
		{
			this.Build();
			
			this.Title = GUPdotNET.ProgramTitle;
			this.lblTitle.Text = "<span size=\"large\"><b>Installing " +  GUPdotNET.ProgramTitle + "</b></span>";
			this.lblTitle.UseMarkup = true;
			this.lblMessage.Text = "Starting Install";
			this.lblMessage.UseMarkup = true;
			this.ShowNow();
			
			switch(GUPdotNET.InstallType)
			{
				case "Win32":
					PrepInstallWin32();
					break;
				case "Linux_rpm":
					
					break;
				case "Linux_src":
					break;
				case "Linux_bin":
					break;
				default:
					throw new Exception("Invalid Install Type");
			}
		}
		
		
		
		private void PrepInstallWin32()
		{
			Gtk.ResponseType resp = ResponseType.None;
			
			bool blnProgramOpen = FindWindow(GUPdotNET.ProgramName);
			while(blnProgramOpen == true && _Cancel == false)
			{
				// ask the user to save changes and close calling application
				string strRequest = "To continue the install please save open files and close " + GUPdotNET.ProgramTitle + " before we continue";
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.OkCancel, false, strRequest);
				if(((Gtk.ResponseType)md.Run()) == ResponseType.Ok)
				{
					blnProgramOpen = FindWindow(GUPdotNET.ProgramName);
				}
				else
				{
					_Cancel = true;
					this.Respond(Gtk.ResponseType.Cancel);
					this.Hide();
				}
				md.Destroy();
			}
			
			if(_Cancel == false)
			{
				bool blnHasAccess = HasAccess();
				while(blnHasAccess == false && _Cancel == false)
				{
					frmSuPass fm = new frmSuPass();
					Gtk.ResponseType rsp = (Gtk.ResponseType)fm.Run();
					if(rsp == ResponseType.Ok)
					{
						blnHasAccess = HasAccess();
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
		
		private bool HasAccess()
		{
			// assume the user has access
			bool blnHasAccess = true;
			
			FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.AllAccess, GUPdotNET.TempInstallerPath);
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
		
		private bool FindWindow(string strProcessName)
		{
			bool blnReturn = false;
			Process[] processes = Process.GetProcessesByName(strProcessName);
			foreach (Process p in processes)
			{
				//IntPtr pFoundWindow = p.MainWindowHandle;
				// Do something with the handle...
				
				// if we get here the process is still running
				blnReturn = true;
			}
			return blnReturn;
		}
	}
}
