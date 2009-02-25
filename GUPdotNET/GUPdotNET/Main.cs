// Main.cs
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using Gtk;

namespace GUPdotNET
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			UpdateCheck gdn = new UpdateCheck();
			//gdn.MyInstallType = args[0].ToString();
			gdn.CurrentMajorVersion = int.Parse(args[0].ToString());
			gdn.CurrentMinorVersion =  int.Parse(args[0].ToString());
			gdn.ProgramName =  args[0].ToString();
			gdn.UpdateInfoURL = args[0].ToString();
			gdn.CallingProcess = System.Diagnostics.Process.GetCurrentProcess();
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			Application.Run ();
			
		}
	}
}