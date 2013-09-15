//
//  UpdateCheck.cs
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

namespace GUPdotNET
{
    using System;
    using Gtk;
    using GUPdotNET.Data;
    using GUPdotNET.UI.Views;
    using MonoTools;

    /// <summary>
    /// This class is the main logic tree for the application, 
    /// determines the programs current state, loads config files
    /// and provides feedback to the end user.
    /// </summary>
    internal class UpdateCheck
    {
        /// <summary>
        /// Gets or sets the root window when there is one, in some circumstances
        /// there will be no root window to provide a parent for dialog windows.
        /// </summary>
        internal Gtk.Window RootWindow { get; set; }

        /// <summary>
        /// Runs the main logic methods for determining what actions
        /// the application needs to execute.
        /// </summary>
        internal void RunUpdateCheck()
        {
            this.RunUpdateCheck(false);
        }

        /// <summary>
        /// Runs the main logic methods for determining what actions
        /// the application needs to execute.
        /// </summary>
        /// <param name="forceCheck">If set to <c>true</c> force check, which is used in for manual update checks.</param>
        internal void RunUpdateCheck(bool forceCheck)
        {
            if (forceCheck || DateTime.Now.Subtract(GlobalTools.Options.LastUpdateCheck) > GlobalTools.Options.UpdateSchedule)
            {
                GlobalTools.ProgramInfo = new ProgramInfo();
                GlobalTools.ProgramInfo.Load();
                GlobalTools.PackageInfo = new PackageInfo();
                GlobalTools.PackageInfo.Load();

                // this is the dialog response that will be reused
                // during the update process the reponse type for
                // continueing will be Gtk.ResponseType.Yes anything else will
                // break the process flow.
                Gtk.ResponseType response = Gtk.ResponseType.None;

                // let the user know there is an update available and
                // as if the user wants to install it.
                ConfirmView confirmView = new ConfirmView();
                response = (Gtk.ResponseType)confirmView.Run();
                confirmView.Destroy();

                if (response == ResponseType.Yes)
                {
                    DownloadView downloadView = new DownloadView();
                    response = (Gtk.ResponseType)downloadView.Run();
                    downloadView.Destroy();
                }

                if (response == ResponseType.Yes)
                {
                    InstallView installView = new InstallView();
                    response = (Gtk.ResponseType)installView.Run();
                    installView.Destroy();
                }
            }
            else
            {
                if (GlobalTools.UpdateRunType == RunType.ManualCheck)
                {
                    MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "No Update Available", "No Update Available");
                    md.Run();
                    md.Destroy();
                }
            }
        }
    }
}
