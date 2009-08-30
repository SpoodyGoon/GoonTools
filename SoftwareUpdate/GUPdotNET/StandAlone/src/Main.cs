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
			bool blnSilentCheck = false;
			Application.Init ();
			
			Common.LoadAll();
			if(args.Length > 0 && args[0].ToLower() == "silent")
				blnSilentCheck = true;
			
			MainWindow mw = new MainWindow(blnSilentCheck);
			mw.Show();
			Application.Run ();
			
		}
	}
}