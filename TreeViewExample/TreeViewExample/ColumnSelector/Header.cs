
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	public class Header : Gtk.DrawingArea
	{
		
		public Header()
		{
			
		}
		
		[GLib.DefaultSignalHandlerAttribute()]
		[GLib.ConnectBeforeAttribute()]		
		protected override bool OnButtonPressEvent(Gdk.EventButton evnt)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got Here");
			md.Run();
			md.Destroy();
			return base.OnButtonPressEvent(evnt);
		}
		
		[GLib.ConnectBefore]
		protected override bool OnExposeEvent(Gdk.EventExpose evnt)
		{
			Gdk.Window win = evnt.Window;
			Gdk.Rectangle area = evnt.Area;
			
			win.DrawRectangle(Style.DarkGC(StateType.Normal), true, this.Allocation.X, this.Allocation.Y, 10,10);
			win.DrawRectangle(Style.BlackGC,false,area);
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got Here");
			md.Run();
			md.Destroy();
			base.OnExposeEvent(evnt);
			return true;
		}
		
		[GLib.ConnectBefore]
		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got Here");
			md.Run();
			md.Destroy();
			// Insert layout code here.
		}
		
		[GLib.ConnectBefore]
		protected override void OnSizeRequested(ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got Here");
			md.Run();
			md.Destroy();
			requisition.Height = 30;
			requisition.Width = 30;
		}
	}
}
