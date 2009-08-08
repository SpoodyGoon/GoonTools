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

class MainClass
{
	public static void Main (string[] args)
	{
		Application.Init ();
		bool _SilentCheck = false;
		int _MajorVersion;
		int _MinorVersion;
		try
		{
			// the first 2 args are required
			if(args.Length >= 2)
			{
				_MajorVersion = int.Parse(args[0].ToString().Trim());
				_MinorVersion = int.Parse(args[1].ToString().Trim());
				
				if(args[2] != null)
				{					
					// the 3 argument if it exists tell the updater if
					// we want to do the update in the backgound (true) or not
					if(args[2].ToLower() == "true")
						_SilentCheck = true;
				}
			}
			else
			{
				throw new Exception("Missing version arguments.");
			}
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "GUPdotNET update error");
			md.Run();
			md.Destroy();
		}
		GUPdotNET.UpdateCheck uc = new GUPdotNET.UpdateCheck();
		uc.RunCheck(blnSilentCheck);
		Application.Run ();
	}
}