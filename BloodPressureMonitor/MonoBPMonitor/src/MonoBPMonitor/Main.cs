/*************************************************************************
 *                      Main.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
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
using so = System.IO;
using Gtk;

namespace MonoBPMonitor
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			GoonTools.Common.LoadAll();
			if(System.Configuration.ConfigurationManager.AppSettings["AllowCustomTheme"].ToLower() == "true" && GoonTools.Common.Option.UseCustomTheme == true)
			{
				if(GoonTools.Common.Option.CustomThemeFile == "")
				{
					so.DirectoryInfo di = new so.DirectoryInfo(so.Path.Combine(GoonTools.Common.EnvData.ThemeFolder, GoonTools.Common.Option.CustomThemeName));
					if(di.Exists)
					{
						so.FileInfo fi = new so.FileInfo(so.Path.Combine(so.Path.Combine(di.FullName, "gtk-2.0"), "gtkrc"));
						if(fi.Exists)
						{
							GoonTools.Common.Option.CustomThemeFile = fi.FullName;
							Gtk.Rc.Parse(GoonTools.Common.Option.CustomThemeFile);							
						}
					}
				}
				else
				{
					Gtk.Rc.Parse(GoonTools.Common.Option.CustomThemeFile);
				}
			}
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}