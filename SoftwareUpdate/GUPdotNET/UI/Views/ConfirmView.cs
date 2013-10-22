// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ConfirmView.cs" company="Andy York">
// //
// // Copyright (c) 2013 Andy York
// //
// // This program is free software: you can redistribute it and/or modify
// // it under the +terms of the GNU General Public License as published by
// // the Free Software Foundation, either version 3 of the License, or
// // (at your option) any later version.
// //
// // This program is distributed in the hope that it will be useful,
// // but WITHOUT ANY WARRANTY; without even the implied warranty of
// // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// // GNU General Public License for more details.
// //
// // You should have received a copy of the GNU General Public License
// // along with this program.  If not, see http://www.gnu.org/licenses/. 
// // </copyright>
// // <summary>
// // Email: goontools@brdstudio.net
// // Author: Andy York 
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace GUPdotNET.UI.Views
{
    using System;
    using GUPdotNET.UI;

    /// <summary>
    /// A dialog window for showing confirmation messages when a new update is available.
    /// </summary>
    internal partial class ConfirmView : Gtk.Dialog
    {
        /// <summary>
        /// The string format for the confirm message shown when an update is available.
        /// </summary>
        private const string ConfimUpdateMessage = "An update is available for {0} version {1}.\nWould you like to update now?";

        /// <summary>
        /// A message to confirm when a update is available through the projects download page.
        /// </summary>
        private const string ConfimDownloadMessage = "An update is available for {0} version {1}.\nWould you like to go to the downloads page now?";

        /// <summary>
        /// An error message for when the URL is missing or incorrect.
        /// </summary>
        private const string ConfigURLMissing = "Unable to identify a location of an update installer or an update download page. Please refer to the project homepage to search for the new update.";

        /// <summary>
        /// The confirm title format.
        /// </summary>
        private const string ConfirmTitle = "{0} {1} Available";

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.Views.ConfirmView"/> class.
        /// </summary>
        internal ConfirmView()
        {
            this.Build();
            this.Initalize();
        }

        /// <summary>
        /// Event fired when the user selects the button to show the updates release notes.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
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

        /// <summary>
        /// The primary method for loading defaults, adding custom objects to the window,
        /// and basic setup of the widgets.
        /// </summary>
        private void Initalize()
        {
            try
            {
                this.Title = string.Format(ConfirmTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                string updateMessage = ConfigURLMissing;
                if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.InstallerURL))
                {
                    updateMessage = string.Format(ConfimUpdateMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                }
                else if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.DownloadsURL))
                {
                    updateMessage = string.Format(ConfimDownloadMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
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
    }
}