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
using Gtk;

namespace GUPdotNET
{
	
	public partial class frmUpdateConfirm : Gtk.Dialog
	{
		public frmUpdateConfirm(string programtitle, string programname, string newversion)
		{
			this.Build();
			try
			{
				
				this.Title = programtitle;
				this.lblProgramTitle.Text = "<span size=\"large\"><b>" + programname + " Update</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "<span size=\"medium\">There is an update available for " + programtitle + ".\r\nWould you like to upgrade to " + programtitle + " " + newversion + " now?</span>";
				this.lblUpdateMessage.UseMarkup = true;
				this.lblUpdateMessage.Wrap = true;
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		protected virtual void OnBtnNoClicked (object sender, System.EventArgs e)
		{
			this.Visible = false;
			this.ShowAll();
			this.Hide();
			this.Respond(Gtk.ResponseType.No);
		}
			
		protected virtual void OnBtnYesClicked (object sender, System.EventArgs e)
		{
			
			this.Respond(Gtk.ResponseType.Yes);
			this.Visible = false;
			this.ShowAll();
			this.Hide();
		}
	}
}
