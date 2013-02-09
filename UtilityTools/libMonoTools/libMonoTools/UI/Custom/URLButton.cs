using System;

namespace libMonoTools.UI.Custom
{
    [System.ComponentModel.ToolboxItem(true)]
    public class URLButton : libMonoTools.UI.Custom.LabelButton
    {
        private string _URL = null;

        public URLButton()
        {
            this.ShowAll();
        }

        public URLButton(string text, string url)
        {
            this.DisplayText = text;
            _URL = url;
            this.ShowAll();
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Display Properties")]
        [System.ComponentModel.DefaultValue("URLButton")]
        [System.ComponentModel.Description("The text displayed for the URL Button.")]
        [System.ComponentModel.Browsable(true)]
        public override string DisplayText {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
            }
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Display Properties")]
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Description("The URL to be launched when the button is clicked.")]
        [System.ComponentModel.Browsable(true)]
        public string URL {
            get {
                return _URL;
            }
            set {
                _URL = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        protected override bool OnButtonReleaseEvent (Gdk.EventButton evnt)
        {
            if(!string.IsNullOrEmpty(_URL) && System.Uri.IsWellFormedUriString(_URL, UriKind.RelativeOrAbsolute))
            {
                libMonoTools.IO.ProcessTools.LaunchURL(_URL);
            }
            return base.OnButtonReleaseEvent(evnt);
        }

        protected override bool OnEnterNotifyEvent (Gdk.EventCrossing evnt)
        {
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand2);
            return base.OnEnterNotifyEvent(evnt);
        }

        protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
        {
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.LastCursor);
            return base.OnLeaveNotifyEvent(evnt);
        }
    }
}
