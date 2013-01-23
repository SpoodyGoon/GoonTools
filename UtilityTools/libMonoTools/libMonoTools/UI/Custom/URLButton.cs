using System;

namespace libMonoTools.UI.Custom
{
	[System.ComponentModel.ToolboxItem(true)]
	public class URLButton : Gtk.EventBox
	{
		private string _Text = "URLButton";
		private string _URL = "";
		Gtk.Label _DisplayLabel = new Gtk.Label("URLButton");		
		private Gdk.Cursor  cursorhand= new Gdk.Cursor(Gdk.CursorType.Hand2); 
		private Gdk.Cursor  cursordefault = null;
		public URLButton (string text, string url) : base()
		{
			_DisplayLabel.SingleLineMode = true;
			_DisplayLabel.Xpad = 5;
			this.Add(_DisplayLabel);
			_Text = text;
			_URL = url;
			this.ShowAll();
		}

		public string Text {
			get{ return _Text;}
			set{ _Text = value;}
		}

		public string URL {
			get{ return _URL;}
			set{ _URL = value;}
		}

		protected override bool OnEnterNotifyEvent (Gdk.EventCrossing evnt)
		{
			this.GdkWindow.Cursor = Gdk.CursorType.Hand1;
			return base.OnEnterNotifyEvent (evnt);
		}

		protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
		{

			this.GdkWindow.Cursor = Gdk.CursorType.CenterPtr;
			return base.OnLeaveNotifyEvent (evnt);
		}
	}
}

