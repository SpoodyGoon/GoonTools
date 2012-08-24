using System;
using Gtk;
using Gdk;

namespace SQLiteMonoPlusUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class TabLabel : Gtk.Bin
	{
		private Gdk.Pixbuf _Hover;
		private Gdk.Pixbuf _Normal;
		public TabLabel (string strLabelText)
		{
			this.Build ();
			_Hover = Gdk.Pixbuf.LoadFromResource("TabCloseHover.png").ScaleSimple(16, 16,InterpType.Nearest);
			_Normal = Gdk.Pixbuf.LoadFromResource("TabClose.png").ScaleSimple(16, 16,InterpType.Nearest);
			imgClose.Pixbuf = _Normal;
			imgClose.SetPadding(0,0);
			imgClose.QueueDraw();
			lblTabLabel.Text = strLabelText;
			this.ShowAll();
		}


		protected void OnEvtCloseEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{
			imgClose.Pixbuf = _Hover;
			imgClose.QueueDraw();
		}

		protected void OnEvtCloseLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			imgClose.Pixbuf = _Normal;
			imgClose.QueueDraw();
		}

		protected void OnEvtCloseButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
			MessageDialog md = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, "Not Implemented", "Not Implemented");
			md.Run();
			md.Destroy();
		}
	}
}

