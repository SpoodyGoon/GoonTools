/*************************************************************************
 *                      frmSuPass.cs                                     
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

namespace GUPdotNET
{
	
	
	public partial class frmSuPass : Gtk.Dialog
	{
		
		/// <summary>
		///  we'll do more with this after the windows release
		/// </summary>
		
		public frmSuPass()
		{
			this.Build();
		}
		
		internal string AdminPass
		{
			get{return txtAdminPass.Text;}
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			// TODO: if the admin password is needed and it is not provided exit the program
			this.Hide();
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
