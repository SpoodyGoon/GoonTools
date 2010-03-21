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
		private static int _Return = 0;
		private static System.Collections.Hashtable _Arguments = new System.Collections.Hashtable();
		public static int Main (string[] args)
		{
			Application.Init();
			string[] strTMP;
			for(int i = 0; i < args.Length; i++)
			{
				strTMP = args[i].Split('=');
				_Arguments.Add(strTMP[0], strTMP[1]);
			}
			
//			if(_Arguments.Contains("ShowOptions"))
//			{
//				if(_Arguments["ShowOptions"].ToString() == "true")
//					_RunType = RunType.Options;
//				else
//					_RunType = RunType.UpdateCheck;
//			}
			
			// the theme is not important and is used on windows only programs
			// if it fails let it fail and continue to move forward.
			try
			{
				if(_Arguments.Contains("ThemeFile"))
				{
					System.IO.FileInfo fi = new System.IO.FileInfo(_Arguments["ThemeFile"].ToString());
					if(fi.Exists)
						Gtk.Rc.Parse(fi.FullName);
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.ToString());
				Console.Read();
				// one of the only places you'll ever catch me doing an empty catch block
				// this is not a mission critical items if it fails let it and move on
			}
			
			// run an update check to see if we need and update
			// if so ask the user
//			if(_RunType == RunType.UpdateCheck)
//			{
//				_Return = UpdateCheck.RunUpdate(false) ? 0:1;
//			}
//			else
//			{
//				// display the option dialog for the user
//				frmOptions fm = new frmOptions();
//				fm.Run();
//				_Return = fm.Result;
//				fm.Destroy();
//			}
			
			return _Return;
		}
	}
}