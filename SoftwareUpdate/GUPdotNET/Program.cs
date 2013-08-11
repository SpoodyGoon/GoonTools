using System;
using System.Linq;
using GUPdotNET.Data;
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
				GlobalTools.Initalize();

				// no need to get fancy here keep it simple stupid
				GlobalTools.Startup.SuppressErrors = args.ToString().ToLower().Contains("suppresserrors");
				if(args.ToString().ToLower().Contains("options"))
				{
					GlobalTools.Startup.UpdateRunType = RunType.Options;
				}
				else if(args.ToString().ToLower().Contains("manual"))
				{
					GlobalTools.Startup.UpdateRunType = RunType.ManualCheck;
				}



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
	}
}
