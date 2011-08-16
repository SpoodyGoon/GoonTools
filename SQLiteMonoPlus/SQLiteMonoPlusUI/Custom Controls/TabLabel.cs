using System;

namespace SQLiteMonoPlusUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TabLabel : Gtk.Bin
	{
		public TabLabel ()
		{
			this.Build ();
		}

		protected void OnEvtCloseEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{
			imgClose.Pixbuf = Gdk.Pixbuf.LoadFromResource("TabCloseHover.png");
			imgClose.ShowNow();
		}

		protected void OnEvtCloseLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			imgClose.Pixbuf = Gdk.Pixbuf.LoadFromResource("TabClose.png");
			imgClose.ShowNow();
		}

		protected void OnEvtCloseButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
			throw new System.NotImplementedException ();
		}
	}
}

