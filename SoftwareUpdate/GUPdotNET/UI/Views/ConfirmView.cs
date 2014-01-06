// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmView.cs" company="Andy York">
//
// Copyright (c) 2013 Andy York
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Email: goontools@brdstudio.net
// Author: Andy York 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// Text displayed on the release notes label button.
        /// </summary>
        private const string ReleaseNotesLabel = "View Release Notes";

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.Views.ConfirmView"/> class.
        /// </summary>
        internal ConfirmView()
        {
            try
            {
                this.Build();
                this.Initalize();
            }
            catch (Exception error)
            {
                GlobalTools.HandleError(this, error);
            }
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
                var packageInfo = GlobalTools.PackageInfo;
                var programInfo = GlobalTools.ProgramInfo;
                this.ActionArea.HideAll();
                this.Title = string.Format(ConfirmTitle, programInfo.ProgramTitle, packageInfo.UpdateVersion.ToString());

                // set the update message base on the package file contents.
                string updateMessage = ConfigURLMissing;
                if (!string.IsNullOrEmpty(packageInfo.UpdateMessage))
                {
                    updateMessage = packageInfo.UpdateMessage;
                }
                else if (!string.IsNullOrEmpty(packageInfo.InstallerURL))
                    {
                        updateMessage = string.Format(ConfimUpdateMessage, programInfo.ProgramTitle, packageInfo.UpdateVersion.ToString());
                    }
                    else if (!string.IsNullOrEmpty(packageInfo.DownloadsURL))
                        {
                            updateMessage = string.Format(ConfimDownloadMessage, programInfo.ProgramTitle, packageInfo.UpdateVersion.ToString());
                        }

                this.updateMessageLabel.Text = updateMessage;
                this.installUpdatesButton.Sensitive = string.IsNullOrEmpty(packageInfo.InstallerURL) ? false : true;
                this.downloadsButton.Sensitive = string.IsNullOrEmpty(packageInfo.DownloadsURL) ? false : true;

                if (!string.IsNullOrEmpty(packageInfo.ReleaseNotesURL))
                {
                    LabelButton releaseNotesButton = new LabelButton(ReleaseNotesLabel);
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

        /// <summary>
        /// Method to handle when the cancel buttons has been clicked.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void CloseButton_Clicked(object sender, EventArgs args)
        {
            this.Respond(Gtk.ResponseType.No);
            this.Hide();
        }

        /// <summary>
        /// Method to handle when teh downloads button has been clicked.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void DownloadsButton_Clicked(object sender, EventArgs args)
        {
            ProcessTools.LaunchURL(GlobalTools.PackageInfo.DownloadsURL);
        }

        /// <summary>
        /// Method to handle when the install updates button has been clicked.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void InstallUpdatesButton_Clicked(object sender, EventArgs args)
        {
            this.Respond(Gtk.ResponseType.Yes);
            this.Hide();
        }
    }
}