using System;

namespace libMonoTools.UI.Custom
{
	[System.ComponentModel.ToolboxItem(true)]
	public class URLButton : Gtk.EventBox
	{
		private string _Text = "URLButton";
		private string _URL = "";
		private Gtk.Label _DisplayLabel = new Gtk.Label("URLButton");		
		public URLButton () : base()
		{
            Build();
			this.ShowAll();
        } 

        public URLButton (string text, string url) 
        {
            _Text = text;
            _URL = url;
            Build();
            this.ShowAll();
        }

        [System.ComponentModel.DefaultValue("URLButton")]
        [System.ComponentModel.Description("Text Displayed for the URL")]
		public string Text {
			get
            { 
                return _Text;
            }
			set
            { 
                _Text = value;
                SetLabel();
            }
		}

		public string URL {
			get{ return _URL;}
			set{ _URL = value;}
		}

        private void Build()
        {
            this.AboveChild = true;
            this.VisibleWindow = true;
            this.AppPaintable = true;
            this.CanFocus = true;
            this.Sensitive = true;
            _DisplayLabel.SingleLineMode = true;
            _DisplayLabel.Xpad = 5;
            this.Add(_DisplayLabel);
            SetLabel();
        }

        private void SetLabel()
        {
            _DisplayLabel.Text = _Text;
            _DisplayLabel.QueueResize();
            this.ShowAll();
        }

		protected override bool OnEnterNotifyEvent (Gdk.EventCrossing evnt)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor(this.Display, Gdk.CursorType.Hand2);
			return base.OnEnterNotifyEvent (evnt);
		}

		protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
		{

            this.GdkWindow.Cursor = new Gdk.Cursor(this.Display, Gdk.CursorType.LastCursor);
			return base.OnLeaveNotifyEvent (evnt);
		}

       protected override bool OnExposeEvent (Gdk.EventExpose evnt)
        {
            SetLabel();
            return base.OnExposeEvent(evnt);
        }

	}
}

