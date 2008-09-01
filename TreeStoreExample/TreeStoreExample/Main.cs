// Main.cs created with MonoDevelop
// User: spoodygoon at 5:45 PM 8/13/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;

namespace TreeStoreExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}