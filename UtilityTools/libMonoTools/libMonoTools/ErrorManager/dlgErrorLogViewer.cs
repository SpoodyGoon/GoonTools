//
//  dlgErrorLogViewer.cs
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
using Gtk;

namespace libMonoTools.ErrorManager
{
    internal partial class dlgErrorLogViewer : Gtk.Dialog
    {
        internal dlgErrorLogViewer ()
        {
            this.Build ();
            System.IO.FileInfo fi = new System.IO.FileInfo (ErrorTools.ErrorToolSettings.ErrorLogFile);
            if (fi.Exists)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader (fi.FullName);
                txtErrorLogDisplay.Buffer.Text = sr.ReadToEnd ();
                sr.Close ();
                sr.Dispose ();
            }
            else
            {
                txtErrorLogDisplay.Buffer.Clear();
            }
        }

        protected void OnBtnSaveErrorLogClicked (object sender, EventArgs e)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo (ErrorTools.ErrorToolSettings.ErrorLogFile);
            if (fi.Exists)
            {
                FileChooserDialog dcf = new FileChooserDialog ("Save Error Log", this, FileChooserAction.Save, "Cance", ResponseType.Cancel, "Save", ResponseType.Ok);
                if (dcf.Run () == (int)Gtk.ResponseType.Ok)
                {
                    fi.CopyTo(dcf.Filename);
                }
                dcf.Destroy ();
            }
            else
            {
                MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, "No Error Log is available to export");
                md.Run();
                md.Destroy();
            }
        }

        protected void OnBtnClearErrorLogClicked (object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(ErrorTools.ErrorToolSettings.ErrorLogFile, false);
            sw.Write("");
            sw.Close();
            txtErrorLogDisplay.Buffer.Text = "";
            txtErrorLogDisplay.ShowNow();
        }

        protected void OnBtnCloseClicked (object sender, EventArgs e)
        {
            this.Respond(ResponseType.Close);
            this.Hide();
        }
    }
}

