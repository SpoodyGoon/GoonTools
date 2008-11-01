// frmUpdateConfirm.cs created with MonoDevelop
// User: spoodygoon at 7:30 PM 6/1/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	
	
	public partial class frmUpdateConfirm : Gtk.Dialog
	{
		
		public frmUpdateConfirm()
		{
			this.Build();
			try
			{
				this.Title = ConfigurationManager.AppSettings["MessageBoxTitle"].ToString();
				this.lblProgramTitle.Text = "<span size=\"xx-large\"><b>" + ConfigurationManager.AppSettings["MessageBoxTitle"].ToString() + "</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "There is an update available for " + ConfigurationManager.AppSettings["ProgramName"].ToString() + ".\r\nWould you like to upgrate to version: " + MainClass.GetOption("Version") + " now?";
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}			
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			try
			{
				if(this.cbxAutoCheck.Active == true)
				{
					if(File.Exists("gdnFirstRunNo.txt"))
						File.Delete("gdnFirstRunNo.txt");
					System.IO.StreamWriter sw = new StreamWriter("gdnFirstRunYes.txt");
					sw.WriteLine("Yes");
					sw.Flush();
					sw.Close();
					
				}
				else
				{
					if(File.Exists("gdnFirstRunYes.txt"))
						System.IO.File.Delete("gdnFirstRunYes.txt");
					System.IO.StreamWriter sw = new StreamWriter("gdnFirstRunNo.txt");
					sw.WriteLine("No");
					sw.Close();
					sw.Flush();
				}
				this.Hide();
				frmUpdateDownload fm = new frmUpdateDownload();
				fm.Run();
				fm.Dispose();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			Gtk.Application.Quit();
		}
	}
}
