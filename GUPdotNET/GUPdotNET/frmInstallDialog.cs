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
		public frmInstallDialog(string AdminPass, string InstallPath)
		{
			this.Build();
			_AdminPass = AdminPass;
			this.Title = GUPdotNET.ProgramTitle;
			this.lblTitle.Text = "<span size=\"large\"><b>Installing " +  GUPdotNET.ProgramTitle + "</b></span>";
			this.lblTitle.UseMarkup = true;
			this.lblMessage.Text = "Starting Install";
			this.lblMessage.UseMarkup = true;
			this.ShowNow();
				
			switch(GUPdotNET.InstallType)
			{
			case "Win32":
				System.Diagnostics.Process.Start(InstallPath);
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
		
		
		
		private void StartInstallWin32(string strFile)
		{
			bool blnProgramOpen = FindWindow(GUPdotNET.ProgramName);
			while(blnProgramOpen == true)
			{
				// ask the user to save changes and close calling application
				string strRequest = "To continue the install please save open files and close " + GUPdotNET.ProgramTitle + " before we continue";
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.OkCancel, false, strRequest);
				md.Run();
				md.Destroy();
				
				blnProgramOpen = FindWindow(GUPdotNET.ProgramName);				
			}
			
			
			if(HasAccess(GUPdotNET.ProgramFullPath) == false)
			{
				frmSuPass fm = new frmSuPass();
				Gtk.ResponseType rsp = (Gtk.ResponseType)fm.Run();
				if(rsp == ResponseType.Ok)
				{
					_AdminPass = fm.AdminPass;
					frmInstallDialog fm2 = new frmInstallDialog(_AdminPass, strFile);
					fm2.Run();
					fm2.Destroy();
				}
				else
				{
					// TODO: find a path out of the program
				}
				fm.Destroy();
			}
			System.Diagnostics.Process.Start(strFile);
		}
		
		private bool HasAccess(string strPath)
		{
			// assume the user has access
			bool blnHasAccess = true;
			
			FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.AllAccess, strPath);
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
