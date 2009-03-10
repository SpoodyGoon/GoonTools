// frmInstallDialog.cs created with MonoDevelop
// User: spoodygoon at 4:55 PM 3/8/2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;

namespace GUPdotNET
{
	
	
	public partial class frmInstallDialog : Gtk.Dialog
	{
		
		private UpdateCheck _GUPdotNET;
		private string _AdminPass = null;
		public frmInstallDialog(GUPdotNET.UpdateCheck gup, string AdminPass, string InstallPath)
		{
			this.Build();
			_GUPdotNET = gup;
			_AdminPass = AdminPass;
			this.Title =_GUPdotNET.ProgramName;
			this.lblTitle.Text = "<span size=\"large\"><b>Installing " + _GUPdotNET.ProgramName + "</b></span>";
			this.lblTitle.UseMarkup = true;
			this.lblMessage.Text = "Starting Install";
			this.lblMessage.UseMarkup = true;
			this.ShowNow();
				
			switch(_GUPdotNET.InstallType)
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
	}
}
