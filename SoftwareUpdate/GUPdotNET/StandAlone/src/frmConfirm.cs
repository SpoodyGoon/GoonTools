/*************************************************************************
 *                      frmConfirm.cs
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
	public partial class frmConfirm : Gtk.Dialog
	{	
		public frmConfirm(UpdateInfo updateinfo)
		{
			this.Build();
			try
			{				
				this.Title = updateinfo.ProgramTitle;
				this.lblProgramTitle.Text = "<span size=\"large\"><b>" + updateinfo.ProgramName + " Update</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "<span size=\"medium\">There is an update available for " + updateinfo.ProgramTitle + ".\r\nWould you like to upgrade to " + updateinfo.ProgramTitle + " " + updateinfo.LatestVersion + " now?</span>";
				this.lblUpdateMessage.UseMarkup = true;
				this.lblUpdateMessage.Wrap = true;
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
		}
							
		protected virtual void OnBtnNoClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
			
		protected virtual void OnBtnYesClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
