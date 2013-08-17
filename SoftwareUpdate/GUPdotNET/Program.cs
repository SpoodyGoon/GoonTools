using System;
using System.Linq;
using GUPdotNET.Data;
using GUPdotNET.IO;
using Gtk;

namespace GUPdotNET
{
	public class MainClass
	{
		public static int Main(string[] args)
		{
			Application.Init();
			bool runSuccessful = true;
			try
			{
                GlobalTools.Initalized += GlobalTools_Initalized;
				if(args.Length > 0 && args[0].ToLower().Equals("background"))
				{
					GlobalTools.UpdateRunType = RunType.BackgroundCheck;
				}
				else 
				{
					GlobalTools.UpdateRunType = RunType.ManualCheck;
				}
				GlobalTools.Initalize();


			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.YesNo, false, ex.Message, "Error starting GUPdotNET auto-update tool.");
				md.WindowPosition = WindowPosition.CenterAlways;
				Gtk.ResponseType res = (Gtk.ResponseType)md.Run();
				md.Destroy();
			}
			Application.Run();
			return runSuccessful ? 0:1;
		}

        private static void GlobalTools_Initalized()
        {
        }
	}
}
