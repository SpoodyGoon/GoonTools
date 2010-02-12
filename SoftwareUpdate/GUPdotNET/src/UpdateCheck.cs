﻿/*************************************************************************
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

namespace GUPdotNET
{
	/// <summary>
	/// Description of RunUpdate.
	/// </summary>
	public class UpdateCheck
	{
		public static bool RunUpdate()
		{
			return RunUpdate(false);
		}
		
		public static bool RunUpdate(bool blnSilentUpdate)
		{
			bool blnSuccess = true;
			UpdateInfo _UpdateInfo = new UpdateInfo(UpdateInfoType.All, blnSilentUpdate);
			try
			{
				_UpdateInfo.LoadInfo(UpdateInfoType.All);
				
				if(DateTime.Compare(DateTime.Now, Common.Option.LastUpdate.AddHours(Common.Option.UpdateHours)) > 0)
				{
					// tell the user there is an update availalbe
					// and ask if they would like to update
					frmConfirm dlgConfirm = new frmConfirm(_UpdateInfo);
					if((Gtk.ResponseType)dlgConfirm.Run() == Gtk.ResponseType.Yes)
					{
						// update confirmed get installer file
						frmDownload dlgDownload = new frmDownload(_UpdateInfo);
						dlgDownload.Show();
						DownloadStatus LoadStat = dlgDownload.CurrentStatus;
						while(LoadStat == DownloadStatus.Prep || LoadStat == DownloadStatus.InProcess)
						{
							GLib.Timeout.Add(1000, delegate{return false;});
						}
						dlgDownload.Destroy();
						
						if(LoadStat == DownloadStatus.Success)
						{
							// if the download was sucessful then procede with the install
							frmInstall Inst = new frmInstall(_UpdateInfo);
							Inst.Run();
							Inst.Destroy();
						}
					}
					dlgConfirm.Destroy();
				}
				else
				{
					if(!blnSilentUpdate)
					{
						MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "No Update Available", "No Update Available");
						md.Run();
						md.Destroy();
					}
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			return blnSuccess;
		}
	}
}
