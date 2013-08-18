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
using System;
using Gtk;
using GUPdotNET.Data;
using GUPdotNET.UI.Views;

namespace GUPdotNET
{
	/// <summary>
	/// Description of RunUpdateCheck.
	/// </summary>
    internal class UpdateCheck
	{
        internal UpdateCheck()
        {
        }

        internal void RunUpdateCheck()
		{				
				if(DateTime.Now.Subtract(GlobalTools.Options.LastUpdateCheck) > GlobalTools.Options.UpdateSchedule)
				{
                    
                GlobalTools.ProgramInfo = new UpdateProgramInfo();
                GlobalTools.ProgramInfo.Load();
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
					if(GlobalTools.UpdateRunType == RunType.ManualCheck)
					{
						MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "No Update Available", "No Update Available");
						md.Run();
						md.Destroy();
					}
				}
		}
	}
}
