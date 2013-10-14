//
//  ConfirmView.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
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

namespace GUPdotNET.UI.Views
{
    internal partial class ConfirmView : Gtk.Dialog
    {
        /// <summary>
        /// The string format for the confirm message shown when an update is available.
        /// </summary>
        private const string confimMessage = "An update is available for {0} version {1}.\nWould you like to update now?";
        private const string confirmTitle = "{0} {1} Available";

        internal ConfirmView()
        {
            this.Build();
            this.Initalize();
        }

        private void Initalize()
        {
            try
            {
                this.Title = string.Format(confirmTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.updateMessageLabel.Text = string.Format(confimMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.ReleaseNotesURL))
                {
                    this.releaseNotesButton.Show();
                }
                else
                {
                    this.releaseNotesButton.Hide();
                }
                this.Close += delegate(object sender, EventArgs e)
                {
                    this.Respond(Gtk.ResponseType.No);
                    this.Hide();
                };
                this.DeleteEvent += delegate(object o, Gtk.DeleteEventArgs args)
                {
                    this.Respond(Gtk.ResponseType.No);
                    this.Hide();
                };
                this.DefaultResponse = Gtk.ResponseType.No;
                this.QueueResize();
                this.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        protected void OnReleaseNotesButtonClicked(object sender, EventArgs e)
        {
            try
            {
                MonoTools.ProcessTools.LaunchURL(GlobalTools.PackageInfo.ReleaseNotesURL);
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        protected void OnFileListDetailsButtonClicked(object sender, EventArgs e)
        {
            // TODO: add a dialog with a treeview to show the package details.
            throw new System.NotImplementedException();
        }
    }
}

