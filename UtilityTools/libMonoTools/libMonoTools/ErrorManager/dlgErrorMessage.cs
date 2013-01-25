//
//  dlgErrorMessage.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace libMonoTools.ErrorManager
{
    internal partial class dlgErrorMessage : Gtk.Dialog
    {
        internal dlgErrorMessage(Gtk.Window ParentWin, string ErrorMessage)
        {
            this.Build();
            
            if(ParentWin != null)
                this.ParentWindow = ParentWin.GdkWindow;
            
            txtErrorMessage.Buffer.Text = ErrorMessage;
            txtErrorDetails.Buffer.Text = ErrorMessage;
            this.ShowAll();
        }
        internal dlgErrorMessage(Gtk.Window ParentWin, System.Exception ex)
        {
            this.Build();
            
            if(ParentWin != null)
                this.ParentWindow = ParentWin.GdkWindow;

            txtErrorMessage.Buffer.Text = ex.Message;
            txtErrorDetails.Buffer.Text = ex.ToString();
            this.ShowAll();
        }

        protected void OnBtnCloseClicked (object sender, EventArgs e)
        {
            this.Destroy();
        }
    }
}

