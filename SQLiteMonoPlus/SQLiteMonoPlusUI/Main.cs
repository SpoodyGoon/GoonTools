using System;
using Gtk;

namespace SQLiteMonoPlusUI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			frmMain win = new frmMain ();
			win.Show ();
			Application.Run ();
		}
	}
}
