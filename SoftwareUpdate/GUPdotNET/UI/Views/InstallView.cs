// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstallView.cs" company="Andy York">
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// A dialog window to handle user feedback for more complex install methods
    /// like when building from source or when extracting a compressed file.
    /// </summary>
    internal partial class InstallView : Gtk.Dialog
    {
        /// <summary>
        /// A format for basic install messages.
        /// </summary>
        private const string InstallMessage = "Starting Install {0} version {1}.";

        /// <summary>
        /// The title format for the dialog window title.
        /// </summary>
        private const string InstallWindowTitle = "Installing {0} {1}";

        /// <summary>
        /// Template for the header label on in the window.
        /// </summary>
        private const string InstallTitle = "<b><big>Installing {0} {1}</big></b>";

        /// <summary>
        /// The title format for identifying programs that need to be closed to continue.
        /// </summary>
        private const string ProcessRunningTitle = "{0} Needs to Close";

        /// <summary>
        /// The message format for identifying programs that need to be closed to continue.
        /// </summary>
        private const string ProcessRunning = "{0} needs to close to install the new update.";

        /// <summary>
        /// Simple flag to identify when the install process is complete.
        /// </summary>
        private bool installComplete = false;

        /// <summary>
        /// Flag to identify when the expose event has been fired.
        /// </summary>
        private bool isExposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.Views.InstallView"/> class.
        /// </summary>
        internal InstallView()
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
        /// Raises the close window button clicked event.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnCloseWindowButtonClicked(object sender, EventArgs args)
        {
            if (this.installComplete)
            {
                this.Respond(Gtk.ResponseType.Yes);
                this.Hide();
            }
            else
            {
                this.Respond(Gtk.ResponseType.No);
                this.Hide();
            }
        }

        /// <summary>
        /// Raises the cancel install button clicked event.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnCancelInstallButtonClicked(object sender, EventArgs args)
        {
            this.Respond(Gtk.ResponseType.No);
            this.Hide();
        }

        /// <summary>
        /// Event fired when the expander widget state changes from open to close or close to open.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnDetailsExpanderActivated(object sender, EventArgs args)
        {
            this.QueueResize();
            this.QueueDraw();
        }

        /// <summary>
        /// The primary method for loading defaults, adding custom objects to the window,
        /// and basic setup of the widgets.
        /// </summary>
        private void Initalize()
        {
            try
            {
                this.Title = string.Format(InstallWindowTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.titleLabel.LabelProp = string.Format(InstallTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.processOverviewLabel.LabelProp = string.Format(InstallMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.installDetailsTextview.Buffer.Text += "Starting Update Process..." + Environment.NewLine;
                this.closeWindowButton.Hide();
                this.cancelInstallButton.Show();
                this.DefaultResponse = Gtk.ResponseType.No;
                this.DeleteEvent += delegate(object o, Gtk.DeleteEventArgs args)
                {
                    this.Respond(Gtk.ResponseType.No);
                    this.Hide();
                };

                this.ExposeEvent += delegate(object sender, Gtk.ExposeEventArgs args)
                {
                    if (!this.isExposed)
                    {
                        System.Threading.Thread.Sleep(1000);
                        this.InstallProcessRun();
                        this.isExposed = true;
                    }
                };

                this.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        /// <summary>
        /// Main method called for running the install processes.
        /// </summary>
        private void InstallProcessRun()
        {
            // TODO: find the application being supported in the process list
            // AND GUPdotNET to see if they are being ran
            try
            {
                /*
                var processes = Process.GetProcesses().Select(p => p.ProcessName.Contains(GlobalTools.ProgramInfo.ProgramFileName)).ToList();
                if (processes != null)
                {
                    Gtk.MessageDialog processDialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, Gtk.ButtonsType.OkCancel, false, string.Format(processRunning, GlobalTools.ProgramInfo.ProgramName), string.Format(processRunningTitle, GlobalTools.ProgramInfo.ProgramName));
                    processDialog.Run();
                    processDialog.Destroy();
                }
                */

                string installerPath = GlobalTools.ToLocalFile(GlobalTools.PackageInfo.InstallerURL);

                // start the installer running
                this.installDetailsTextview.Buffer.Text += "Starting Update Installer..." + Environment.NewLine;
                Process.Start(installerPath);
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }
    }
}