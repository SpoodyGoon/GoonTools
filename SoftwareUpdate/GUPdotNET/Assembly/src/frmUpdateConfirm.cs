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
		public frmUpdateConfirm(string programtitle, string programname, string newversion)
		{
			this.Build();
			try
			{
				
				
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}	
		
		protected virtual void OnBtnAboutClicked (object sender, System.EventArgs e)
		{
			System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
			Gtk.AboutDialog ad = new Gtk.AboutDialog();
			ad.Title = "About GUPdotNET";
			ad.ProgramName = "GUPdotNET";
			ad.Comments = "General Purpose Update program for Mono/Gtk#.";
			ad.License = GoonTools.Const.License;
			ad.Authors = new String[]{"Andrew York <goontools@brdstudio.net>"};
			ad.Version = asm.GetName().Version.Major.ToString() + "." + asm.GetName().Version.Minor.ToString() + " alpha";
			ad.Logo = Gdk.Pixbuf.LoadFromResource("update_large.png");
			ad.Icon = Gdk.Pixbuf.LoadFromResource("update_medium.png");
			ad.AllowShrink = true;
			ad.AllowGrow = true;
			ad.Copyright = "GoonTools 2009";
			ad.HasSeparator = true;
			ad.Modal = true;
			ad.WidthRequest = 550;
			ad.HeightRequest = 300;
			ad.Website = "http://brdstudio.net/mbpmonitor/";
			ad.WebsiteLabel = "http://brdstudio.net/mbpmonitor/";
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
		
		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
			
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

	}

}
