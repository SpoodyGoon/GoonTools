/*************************************************************************
 *                      frmReTry.cs                                    
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
	
	
	public partial class frmReTry : Gtk.Dialog
	{
		
		public frmReTry()
		{
			this.Build();
		}
		
		public string dlgTitle
		{
			set{this.Title=value;}
		}
		
		public string dlgMessage
		{
			set{this.txtMessage.Buffer.Text=value;}
		}

		protected virtual void OnBtnReTryClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
