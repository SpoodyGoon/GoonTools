/*************************************************************************
 *                      frmAbout.cs
 *
 * 		Copyright (C) Date: 10/18/2009 - Time: 5:54 PM
 *		User: Andy - <monotodo@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

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
		/// Gets or sets the root window when there is one, in some surcomstances
		/// there will be no root window to provide a parent for dialog windows.
		/// </summary>
		internal Gtk.Window RootWindow{ get; set; }

		/// <summary>
		/// The string format for the confirm message shown when an update is available.
		/// </summary>
        private const string confimMessage = "An update is available for {0} version {1}.\nWould you like to update now?";
        
		/// <summary>
		/// Runs the main logic methods for determining what actions
		/// the application needs to execute.
		/// </summary>
        internal void RunUpdateCheck()
        {
            if (DateTime.Now.Subtract(GlobalTools.Options.LastUpdateCheck) > GlobalTools.Options.UpdateSchedule)
            {
                GlobalTools.ProgramInfo = new UpdateProgramInfo();
                GlobalTools.ProgramInfo.Load();
                GlobalTools.PackageInfo = new UpdatePackageInfo();
                GlobalTools.PackageInfo.Load();

				MessageDialog confirmMessageDialog = new MessageDialog(this.RootWindow, DialogFlags.Modal, MessageType.Question, ButtonsType.YesNo, string.Format(confimMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString()), "Update Available");
				confirmMessageDialog.SetResponseSensitive(ResponseType.None, false);
                Gtk.Button releaseNotesButton = (confirmMessageDialog.AddButton("View Release Notes", ResponseType.None) as Gtk.Button);
                releaseNotesButton.Clicked += delegate(object sender, EventArgs e)
                {
                    ProcessTools.LaunchURL(GlobalTools.PackageInfo.PackageFiles["ReleaseNotes"].URL);
                };

                if ((Gtk.ResponseType)confirmMessageDialog.Run() == Gtk.ResponseType.Yes)
                {
                    DownloadView downloadView = new DownloadView();
                    downloadView.Run();
                    downloadView.Destroy();
                }

                // tell the user there is an update availalbe
                // and ask if they would like to update
                //					ConfirmationView confirmationView = new ConfirmationView();
                //					if((Gtk.ResponseType)confirmationView.Run() == Gtk.ResponseType.Yes)
                //					{
                //						// update confirmed get installer file
                //						DownloadView downloadView = new DownloadView();
                //						downloadView.Show();
                //						DownloadStatus LoadStat = downloadView.CurrentStatus;
                //						while(LoadStat == DownloadStatus.Prep || LoadStat == DownloadStatus.InProcess)
                //						{
                //							GLib.Timeout.Add(1000, delegate{return false;});
                //						}
                //						downloadView.Destroy();
                //						
                //						if(LoadStat == DownloadStatus.Success)
                //						{
                //							// if the download was sucessful then procede with the install
                //							InstallView installView = new InstallView();
                //							installView.Run();
                //							installView.Destroy();
                //						}
                //					}
                //					confirmationView.Destroy();
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
