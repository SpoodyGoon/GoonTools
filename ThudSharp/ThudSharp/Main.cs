using System;
using Gtk;

namespace ThudSharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			//GoonTools.Common.LoadAll();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}