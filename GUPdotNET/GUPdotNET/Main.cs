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
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			Application.Run ();
			try
			{
				if(args[0] != null)
				{
					GUPdotNET.ProgramName = System.IO.Path.GetFileName(args[0]);
					GUPdotNET.ProgramFullPath = System.IO.Path.GetDirectoryName(args[0]);
					if(args[1] == "true")
						GUPdotNET.SilentCheck = true;
					else
						GUPdotNET.SilentCheck = false;
				}
				GUPdotNET.InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
				GUPdotNET.ProgramTitle = ConfigurationManager.AppSettings["ProgramTitle"].ToString();
				GUPdotNET.UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
				GUPdotNET.CurrentMajorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMajorVersion"].ToString());
				GUPdotNET.CurrentMinorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMinorVersion"].ToString());
				UpdateCheck uc = new UpdateCheck();
				uc.RunCheck();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
	}
}