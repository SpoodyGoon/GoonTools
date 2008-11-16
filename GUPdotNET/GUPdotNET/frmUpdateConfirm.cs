// frmUpdateConfirm.cs
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.


using System;
using System.IO;
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	
	
	public partial class frmUpdateConfirm : Gtk.Dialog
	{
		private UpdateCheck _GUPdotNET;
		public frmUpdateConfirm(UpdateCheck gdn)
		{
			this.Build();
			_GUPdotNET = gdn;
			try
			{
				this.Title = ConfigurationManager.AppSettings["MessageBoxTitle"].ToString();
				this.lblProgramTitle.Text = "<span size=\"xx-large\"><b>" + _GUPdotNET.ProgramName + "</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "There is an update available for " + _GUPdotNET.ProgramName + ".\r\nWould you like to upgrate to version: " + _GUPdotNET.LatestVersion + " now?";
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
				frmUpdateDownload fm = new frmUpdateDownload(_GUPdotNET);
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
