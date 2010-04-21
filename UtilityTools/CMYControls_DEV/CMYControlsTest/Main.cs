using System;
using Gtk;

namespace CMYControlsTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
//			System.IO.FileInfo fi = new System.IO.FileInfo(System.Configuration.ConfigurationManager.AppSettings["ThemeFile"]);
//			if(fi.Exists)
//			{
//				Gtk.Rc.Parse(fi.FullName);
//			}
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}