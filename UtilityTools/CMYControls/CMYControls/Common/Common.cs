
using System;
using Gtk;

namespace CMYControls
{
	
	
	public static class Common
	{
		
		public static void HandleError(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, ex.Message, "CMYControls Error");
				md.Run();
				md.Destroy();
		}
		
		public static void HandleError(Exception ex, string Element)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, Element + System.Environment.NewLine + ex.Message, "CMYControls Error");
				md.Run();
				md.Destroy();
		}
		
	}
}
