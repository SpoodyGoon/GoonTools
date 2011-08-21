using System;
using Gtk;

namespace SQLiteMonoPlusUI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
            GlobalTools.Common.Load();
			frmMain win = new frmMain ();
			win.Show ();
			Application.Run ();
		}
	}
}
