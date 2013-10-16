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
using GUPdotNET.UI;

namespace GUPdotNET.UI.Views
{
    internal partial class ConfirmView : Gtk.Dialog
    {
        /// <summary>
        /// The string format for the confirm message shown when an update is available.
        /// </summary>
        private const string confimUpdateMessage = "An update is available for {0} version {1}.\nWould you like to update now?";
        private const string confimDownloadMessage = "An update is available for {0} version {1}.\nWould you like to go to the downloads page now?";
        private const string configURLMissing = "Unable to identify a location of an update installer or an update download page. Please refer to the project homepage to search for the new update.";
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
                string updateMessage = configURLMissing;
                if(!string.IsNullOrEmpty(GlobalTools.PackageInfo.InstallerURL))
                {
                    updateMessage = string.Format(confimUpdateMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                }
                else if(!string.IsNullOrEmpty(GlobalTools.PackageInfo.DownloadsURL))
                {
                    updateMessage = string.Format(confimDownloadMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                }

                this.updateMessageLabel.Text = updateMessage;
                if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.ReleaseNotesURL))
                {
                    LabelButton releaseNotesButton = new LabelButton("View Release Notes");
                    releaseNotesButton.Clicked += this.OnReleaseNotesButtonClicked;
                    this.releaseNotesAlignment.Add(releaseNotesButton);
                    this.releaseNotesAlignment.ShowAll();
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

        protected void OnReleaseNotesButtonClicked(object sender)
        {
            try
            {
                GUPdotNET.ProcessTools.LaunchURL(GlobalTools.PackageInfo.ReleaseNotesURL);
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }
    }
}

