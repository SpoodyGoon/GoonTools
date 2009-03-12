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
				if(args.Length == 0)
				{
					GUPdotNET.InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
					GUPdotNET.ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
					GUPdotNET.UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
					GUPdotNET.CurrentMajorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMajorVersion"].ToString());
					GUPdotNET.CurrentMinorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMinorVersion"].ToString());
					GUPdotNET.SilentCheck = Convert.ToBoolean(ConfigurationManager.AppSettings["SilentCheck"].ToString());
					GUPdotNET.CallingApplication = ConfigurationManager.AppSettings["CallingApplication"].ToString();
					
				}
				else
				{
					GUPdotNET.InstallType = args[0].ToString();
					GUPdotNET.ProgramName = args[0].ToString();
					GUPdotNET.UpdateInfoURL = args[0].ToString();
					GUPdotNET.CurrentMajorVersion = Convert.ToInt32(args[0].ToString());
					GUPdotNET.CurrentMinorVersion = Convert.ToInt32(args[0].ToString());
					GUPdotNET.SilentCheck = Convert.ToBoolean(args[0].ToString());
					GUPdotNET.CallingApplication = args[0].ToString();
				}
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