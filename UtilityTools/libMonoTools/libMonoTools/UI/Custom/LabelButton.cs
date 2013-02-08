using System;
using Gtk;

namespace libMonoTools.UI.Custom
{
    [System.ComponentModel.ToolboxItem(true)]
    public abstract class LabelButton : Gtk.Label
    {
        protected string _Text = "LinkButton";
        private Gtk.Label _DisplayLabel = new Gtk.Label("URLButton");
        protected Gdk.Color _NormalColor = new Gdk.Color(222, 111,111);
        private string _NormalColorHex = "#AD0000";
        private Gdk.Color _HoverColor = new Gdk.Color(222, 111,111);
        private string _HoverColorHex = "#AD0000";
        private bool _Underlined = true;
        private bool _Bold = false;
        public string DisplayText
        {
            set
            {
                this.Text = value;

            }
        }

        [System.ComponentModel.DefaultValue("#AD0000")]
        public string FontColor
        {
            set
            {
                _NormalColorHex = value;
                _NormalColor = MonoTools.ColorConvert.ColorFromHex(_NormalColorHex);
            }
        }
        
        [System.ComponentModel.DefaultValue("#AD0000")]
        public string HoverFontColor
        {
            set
            {
                _NormalColorHex = value;
                _NormalColor = MonoTools.ColorConvert.ColorFromHex(_NormalColorHex);
            }
        }

        public bool Underlined
        {
            set{_Underlined = value;}
        }

        public bool Bold 
        {
            set{_Bold = value;}
        }

        
        private void Build ()
        {
            this.AppPaintable = true;
//            this.CanFocus = true;
//            this.Sensitive = true;
//            _DisplayLabel.SingleLineMode = true;
//            _DisplayLabel.Xpad = 5;
//
//            SetLabel();
        }
        
        private void SetLabel ()
        {
            _DisplayLabel.Text = _Text;
            _DisplayLabel.QueueResize();
            this.QueueResize();
            this.QueueDraw();
            this.ShowAll();
        }

        protected override void OnShown ()
        {
            base.OnShown();
        }

        protected override bool OnExposeEvent (Gdk.EventExpose evnt)
        {
            return base.OnExposeEvent(evnt);
        }

        protected override bool OnEnterNotifyEvent (Gdk.EventCrossing evnt)
        {
            return base.OnEnterNotifyEvent(evnt);
        }
        
        protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
        {
            return base.OnLeaveNotifyEvent(evnt);
        }
    }
}

