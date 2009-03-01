/*************************************************************************
 *                      frmUpdateConfirm.cs                                     
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
				// TODO: remove this in the stetic file
				this.cbxAutoCheck.Visible = false;
				this.cbxAutoCheck.ShowAll();
				
				this.Title = _GUPdotNET.ProgramName;
				this.lblProgramTitle.Text = "<span size=\"xx-large\"><b>" + _GUPdotNET.ProgramName + " Update</b></span>";
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
			this.Hide();
		}
	}
}
