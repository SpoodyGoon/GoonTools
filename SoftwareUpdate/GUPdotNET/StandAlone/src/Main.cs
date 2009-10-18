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
		private static RunType _RunType = RunType.None;
		private static int _Return = 0;
		public static int Main (string[] args)
		{
			Application.Init();
			
			// see if we are running options or if it is a
			// standard time based update check
			if(args.Length < 1)
				_RunType = RunType.Options;
			else if(args[0].ToLower() == "updatecheck")
				_RunType = RunType.UpdateCheck;
			else
				_RunType = RunType.Options;	
				
			// this loads the enviroment, options and 
			// commonly used static functions
			Common.LoadAll();			
			
			// run an update check to see if we need and update
			// if so ask the user
			if(_RunType == RunType.UpdateCheck)
			{				
				UpdateCheck uc = new UpdateCheck();
				_Return = uc.RunUpdate(false) ? 0:1;
			}
			else
			{
				// display the option dialog for the user
				frmOptions fm = new frmOptions();
				fm.Run();
				_Return = fm.Result;
				fm.Destroy();
			}
			
			return _Return;
		}
	}
}