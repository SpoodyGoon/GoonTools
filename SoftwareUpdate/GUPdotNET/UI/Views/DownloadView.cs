// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DownloadView.cs" company="Andy York">
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
    using System.ComponentModel;
    using System.Net;
    using Gtk;
    using io = System.IO;

    /// <summary>
    /// A dialog for handling downloading installer files for running them locally.
    /// </summary>
    internal partial class DownloadView : Gtk.Dialog
    {
        /// <summary>
        /// The standard object for downloading files from a remote web site.
        /// </summary>
        private WebClient webClient = new WebClient();

        /// <summary>
        /// Flag to identify when the expose event has been fired.
        /// </summary>
        private bool isExposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.Views.DownloadView"/> class.
        /// </summary>
        internal DownloadView()
        {
            try
            {
                // TODO: add logic to keep downloaded open when "start installer after..." is NOT checked.
                this.Build();
                this.Initalize();
            }
            catch (Exception error)
            {
                GlobalTools.HandleError(this, error);
            }
        }

        /// <summary>
        /// Raises the cancel button clicked event that stops the download.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        protected void OnCancelButtonClicked(object sender, EventArgs e)
        {
            this.webClient.CancelAsync();
        }

        /// <summary>
        /// Raises the hide window button clicked event that minimalizes
        /// the window to the icon tray effectively hiding the window from view.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        protected void OnHideWindowButtonClicked(object sender, EventArgs e)
        {
            this.Iconify();
        }

        /// <summary>
        /// The primary method for loading defaults, adding custom objects to the window,
        /// and basic setup of the widgets.
        /// </summary>
        private void Initalize()
        {
            try
            {
                // set the default response to no, only
                // when the download is completed successfully
                // with the response be "Yes" which will keep the
                // update logic flow going.
                this.DefaultResponse = ResponseType.No;
                this.ActionArea.Hide();
                this.Close += delegate(object sender, EventArgs e)
                {
                    this.Respond(ResponseType.No);
                };

                this.DeleteEvent += delegate(object o, DeleteEventArgs args)
                {
                    this.Respond(ResponseType.No);
                };

                this.ExposeEvent += delegate(object sender, Gtk.ExposeEventArgs args)
                {
                    if (!this.isExposed)
                    {
                        System.Threading.Thread.Sleep(1000);
                        this.DownloadFile();
                        this.isExposed = true;
                    }
                };

                this.QueueResize();
                this.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        /// <summary>
        /// Event fired by the web client when the progress of a download has changed.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="downloadProgressArgs">Arguments containing details on the progress of the download.</param>
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressArgs)
        {
            try
            {
                this.downloadingProgressbar.Fraction = (double)(downloadProgressArgs.ProgressPercentage * 0.01);
                this.downloadingProgressbar.Text = (downloadProgressArgs.ProgressPercentage * 0.01).ToString("P");
                this.downloadingProgressbar.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        /// <summary>
        /// Method that sets up and start the downloading of the installer file.
        /// </summary>
        private void DownloadFile()
        {
            try
            {
                if (string.IsNullOrEmpty(GlobalTools.PackageInfo.InstallerURL))
                {
                    throw new Exception("URL for the update package is missing.");
                }

                Uri installerUri = new Uri(GlobalTools.PackageInfo.InstallerURL);
                this.webClient.DownloadProgressChanged += this.WebClient_DownloadProgressChanged;
                this.webClient.DownloadFileCompleted += this.WebClient_DownloadFileCompleted;
                this.webClient.DownloadFileAsync(installerUri, GlobalTools.ToLocalFile(installerUri));
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        /// <summary>
        /// The event that is fired when the download has completed the requested action.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="asyncCompletedArgs">Details relating to how and why the download has completed.</param>
        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedArgs)
        {
            if (asyncCompletedArgs.Cancelled)
            {
                this.downloadingProgressbar.Text = "Download Canceled";
                this.downloadingProgressbar.QueueDraw();
                MessageDialog errorMessage = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "Download Canceled", "Download Canceled");
                errorMessage.Run();
                errorMessage.Destroy();
                this.Respond(ResponseType.No);
            }
            else if (asyncCompletedArgs.Error != null)
            {
                this.downloadingProgressbar.Text = "Download Error";
                this.downloadingProgressbar.QueueDraw();
                GlobalTools.HandleError(this, asyncCompletedArgs.Error);
                this.Respond(ResponseType.No);
            }
            else
            {
                this.downloadingProgressbar.Fraction = 1.0d;
                this.downloadingProgressbar.Text = "Download Finished";
                this.downloadingProgressbar.QueueDraw();
                System.Threading.Thread.Sleep(1000);
                this.webClient.Dispose();
                this.Respond(ResponseType.Yes);
            }
        }
    }
}