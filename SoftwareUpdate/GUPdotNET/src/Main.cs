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
		public static void Main (string[] args)
		{
			Application.Init ();
			bool _SilentCheck = false;
			try
			{
//				if(args.Length > 0)
//					if(args[0].ToLower() == "true")
//						_SilentCheck = true;
				
				UpdateCheck uc = new UpdateCheck();
				uc.CurrentMajorVersion = System.Reflection.Assembly.GetCallingAssembly().GetName().Version.Major;
				uc.CurrentMajorVersion = System.Reflection.Assembly.GetCallingAssembly().GetName().Version.Minor;
				uc.ProgramFullPath = System.Reflection.Assembly.GetCallingAssembly().GetName().EscapedCodeBase;
				// TODO: get the job or the full name to check for a lock
				uc.SilentCheck = _SilentCheck;
				uc.RunUpdateCheck();
				Application.Run ();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "GUPdotNET update error");
				md.Run();
				md.Destroy();
			}
		}
	}
}