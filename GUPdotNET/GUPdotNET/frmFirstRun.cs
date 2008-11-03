// frmFirstRun.cs
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
using System.IO;

namespace GUPdotNET
{
	
	
	public partial class frmFirstRun : Gtk.Dialog
	{
		
		public frmFirstRun()
		{
			this.Build();
		}

		protected virtual void OnBtnNoClicked (object sender, System.EventArgs e)
		{
			if(System.IO.File.Exists("gdnFirstRunYes.txt"))
				System.IO.File.Delete("gdnFirstRunYes.txt");
			System.IO.StreamWriter sw = new StreamWriter("gdnFirstRunNo.txt");
			sw.WriteLine("No");
			sw.Close();
			sw.Flush();
			this.Hide();
		}

		protected virtual void OnBtnYesClicked (object sender, System.EventArgs e)
		{
			if(System.IO.File.Exists("gdnFirstRunNo.txt"))
				System.IO.File.Delete("gdnFirstRunNo.txt");
			System.IO.StreamWriter sw = new StreamWriter("gdnFirstRunYes.txt");
			sw.WriteLine("Yes");
			sw.Close();
			sw.Flush();
			this.Hide();
		}
	}
}
