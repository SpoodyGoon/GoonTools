using System;
using Gtk;

namespace GUPdotNET
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			bool blnSilentCheck = true;
			Application.Init ();
			if(args.Length > 0 && args[0].ToLower() == "silent")
				blnSilentCheck = true;
			
			MainWindow mw = new MainWindow(blnSilentCheck);
			mw.Show();
			Application.Run ();
			
		}
	}
}