// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCheck.cs" company="Andy York">
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

namespace GUPdotNET
{
    using System;
    using System.Diagnostics;
    using Gtk;
    using GUPdotNET.Data;
    using GUPdotNET.IO;
    using GUPdotNET.UI.Views;

    /// <summary>
    /// This class is the main logic tree for the application, 
    /// determines the programs current state, loads config files
    /// and provides feedback to the end user.
    /// </summary>
    internal class UpdateCheck
    {
        /// <summary>
        /// The installer started message for display in the exit dialog window.
        /// </summary>
        private const string InstallerStartedMessage = "\n<b>Update installer successfully started.</b>\n\nExiting <i>GUPdotNET</i> so the installer can complete the update process.";

        /// <summary>
        /// The message displayed when there is not update available.
        /// </summary>
        private const string NoUpdateMessage = "No Update Available";

        /// <summary>
        /// The message displayed in the dialog window when a checksum has failed validation.
        /// </summary>
        private const string ChecksumInvalidMessage = "The installer file failed validation, it is recomended that you do not continue to this install.\nDo you want to ignore this warning and install <b>{0}</b> anyways?";

        /// <summary>
        /// The title for the dialog window when a checksum has failed validation.
        /// </summary>
        private const string ChecksumInvalidTitle = "File Validation Failed";

        /// <summary>
        /// Gets or sets the root window when there is one, in some circumstances
        /// there will be no root window to provide a parent for dialog windows.
        /// </summary>
        internal Gdk.Window RootWindow { get; set; }

        /// <summary>
        /// Runs the main logic methods for determining what actions
        /// the application needs to execute.
        /// </summary>
        /// <returns><c>true</c>, if the application should exit at the end of the process, <c>false</c> otherwise.</returns>
        internal bool RunUpdateCheck()
        {
            return this.RunUpdateCheck(false);
        }

        /// <summary>
        /// Runs the main logic methods for determining what actions
        /// the application needs to execute.
        /// </summary>
        /// <param name="forceCheck">If set to <c>true</c> force check, which is used in for manual update checks.</param>
        /// <returns><c>true</c>, if the application should exit at the end of the process, <c>false</c> otherwise.</returns>
        internal bool RunUpdateCheck(bool forceCheck)
        {
            bool exitAfterProcess = false;
            var options = GlobalTools.Options;

            if (forceCheck || (options.UpdateSchedule > -1 && DateTime.Now.Subtract(options.LastUpdateCheck).TotalDays.CompareTo(Convert.ToDouble(options.UpdateSchedule)) == 1))
            {
                GlobalTools.ProgramInfo = new ProgramInfo();
                GlobalTools.ProgramInfo.Load();
                GlobalTools.PackageInfo = new PackageInfo();
                if (GlobalTools.PackageInfo.Load())
                {

                    // After loading the program and package information
                    // update the options file to reflect that an update check
                    // has been performed.
                    GlobalTools.Options.LastUpdateCheck = DateTime.Now;
                    GlobalTools.Options.Save();

                    // check to see if a newer version is available
                    if (GlobalTools.PackageInfo.UpdateVersion.CompareTo(GlobalTools.ProgramInfo.ProgramVersion) < 1)
                    {
                        if (GlobalTools.UpdateRunType == RunType.ManualCheck)
                        {
                            MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, NoUpdateMessage, NoUpdateMessage);
                            md.Run();
                            md.Destroy();
                        }

                        GlobalTools.LocalSystem.CleanTempPaths();
                        return true;
                    }

                    // this is the dialog response that will be reused
                    // during the update process the reponse type for
                    // continueing will be Gtk.ResponseType.Yes anything else will
                    // break the process flow.
                    Gtk.ResponseType response = Gtk.ResponseType.None;

                    // let the user know there is an update available and
                    // as if the user wants to install it.
                    ConfirmView confirmView = new ConfirmView();
                    if (this.RootWindow != null)
                    {
                        confirmView.ParentWindow = this.RootWindow;
                        confirmView.Modal = true;
                    }

                    response = (Gtk.ResponseType)confirmView.Run();
                    confirmView.Destroy();

                    if (response == ResponseType.Yes)
                    {
                        DownloadView downloadView = new DownloadView();
                        if (this.RootWindow != null)
                        {
                            downloadView.ParentWindow = this.RootWindow;
                            downloadView.Modal = true;
                        }

                        response = (Gtk.ResponseType)downloadView.Run();
                        downloadView.Destroy();
                    }

                    if (response == ResponseType.Yes)
                    {
                        if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.InstallerURL))
                        {
                            string installerPath = GlobalTools.ToLocalFile(GlobalTools.PackageInfo.InstallerURL);
                            if (!string.IsNullOrEmpty(installerPath))
                            {
                                if (this.ValidateChecksum(installerPath))
                                {
                                    InstallRunner installRunner = new InstallRunner(GlobalTools.ProgramInfo.ProgramFullPath, installerPath, GlobalTools.PackageInfo.InstallerType);
                                    installRunner.Start();
                                    exitAfterProcess = true;
                                    System.Threading.Thread.Sleep(1000);
                                    MessageDialog exitWarningDialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, true, InstallerStartedMessage, "Exiting Updater");
                                    exitWarningDialog.WindowPosition = WindowPosition.CenterAlways;
                                    exitWarningDialog.Run();
                                    exitWarningDialog.Destroy();
                                }
                            }
                        }
                        else if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.DownloadsURL))
                            {
                                Process.Start(GlobalTools.PackageInfo.DownloadsURL);
                            }

                        /*
                    InstallView installView = new InstallView();
                    response = (Gtk.ResponseType)installView.Run();
                    installView.Destroy();
                    */

                        // Clean up the temporary files
                        GlobalTools.LocalSystem.CleanTempPaths();
                    }
                }
            }

            return exitAfterProcess;
        }

        /// <summary>
        /// Validates the the file checksum against the checksum provided in the package configuration.
        /// </summary>
        /// <param name="filePath">The full path to the installer file.</param>
        /// <returns><c>true</c>, if checksum was validated, <c>false</c> otherwise.</returns>
        private bool ValidateChecksum(string filePath)
        {
            bool checksumValid = true;
            if (!string.IsNullOrEmpty(GlobalTools.PackageInfo.InstallerChecksum))
            {
                string fileChecksum = GlobalTools.FileChecksumGet(filePath);
                if (!fileChecksum.Equals(GlobalTools.PackageInfo.InstallerChecksum))
                {
                    checksumValid = false;
                    MessageDialog checksumDialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Warning, ButtonsType.YesNo, true, string.Format(ChecksumInvalidMessage, GlobalTools.ProgramInfo.ProgramTitle), ChecksumInvalidTitle);
                    checksumDialog.DefaultResponse = ResponseType.No;
                    if (checksumDialog.Run() == (int)Gtk.ResponseType.Yes)
                    {
                        checksumValid = true;
                    }

                    checksumDialog.Destroy();
                }
            }

            return checksumValid;
        }
    }
}
