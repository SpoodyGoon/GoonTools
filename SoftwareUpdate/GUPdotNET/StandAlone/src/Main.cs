/*************************************************************************
 *                      Main.cs
 *
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>
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
	class MainClass
	{
		public static int Main (string[] args)
		{
			if(args.Length < 2)
			{
				throw new Exception("Invalid number of arguments.");
			}
			else
			{
				Common.LoadAll(args[0].Trim());
				Gtk.Rc.ReparseAll();
				if(args[1].ToLower() == "updatecheck")
				{
					if(DateTime.Compare(DateTime.Now, Common.Option.LastUpdateCheck.AddHours(Common.Option.UpdateHours)) > 0)
					{
						UpdateInfo ui = new UpdateInfo();
						ui.LoadInfo(UpdateInfoType.All);
						// tell the user there is an update availalbe
						// and ask if they would like to update
						frmConfirm dlgConfirm = new frmConfirm(ui);
						if((Gtk.ResponseType)dlgConfirm.Run() == Gtk.ResponseType.Yes)
						{
							// update confirmed get installer file
							frmDownload dlgDownload = new frmDownload(ui);
							if((Gtk.ResponseType)dlgDownload.Run() == Gtk.ResponseType.Ok)
							{
								// if the download was sucessful then procede with the install
								frmInstall Inst = new frmInstall(ui);
								Inst.Run();
								Inst.Destroy();
								
							}
							dlgDownload.Destroy();
						}
						dlgConfirm.Destroy();
						return 0;
					}
				}
				else
				{
					frmOptions fm = new frmOptions();
					if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Yes)
					{
						Common.SaveOptions();
					}
					fm.Destroy();
				}
			}
			return 0;
		}
	}
}