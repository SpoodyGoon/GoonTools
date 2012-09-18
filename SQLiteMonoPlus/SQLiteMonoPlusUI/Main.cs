using System;
using libGlobalTools;
using Gtk;

namespace SQLiteMonoPlusUI
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
            libGlobalTools.Common.Load();
			GlobalData.StaticDataAccess.Load();
			frmMain win = new frmMain ();
			win.Show ();
			Application.Run ();
		}
	}
}
