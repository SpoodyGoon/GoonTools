using System;

namespace libMonoTools.UI.Custom
{
    [System.ComponentModel.DefaultProperty("DisplayText")]
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
        
        protected override string TextValue {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
            }
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Display Properties")]
        [System.ComponentModel.DefaultValue("LinkButton")]
        [System.ComponentModel.Description("The text displayed for the Link Button.")]
        [System.ComponentModel.Browsable(true)]
        public string DisplayText {
            get {
                return this.TextValue;
            }
            set {
                this.TextValue = value;
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
            evnt.Window.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand2);
            evnt.Window.Display.Sync(); 
            return base.OnEnterNotifyEvent(evnt);
        }

        protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
        {
            evnt.Window.Cursor = new Gdk.Cursor(Gdk.CursorType.LastCursor);
            evnt.Window.Display.Sync(); 
            return base.OnLeaveNotifyEvent(evnt);
        }
    }
}
