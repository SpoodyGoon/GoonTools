using System;
using Gtk;

namespace libMonoTools.UI.Custom
{
    [System.ComponentModel.ToolboxItem(true)]
    public class LabelButton : Gtk.EventBox
    {
        private string _Text = "LinkButton";
        private Gtk.Label _DisplayLabel = new Gtk.Label("URLButton");
        public LabelButton() : base()
        {
            Build();
        }

        public LabelButton(string text) 
        {
            _Text = text;
            Build();
        }

        public string Text {
            get {
                return _Text;
            }
            set { 
                _Text = value;
                SetLabel();
            }
        }
        
        private void Build ()
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
        
        private void SetLabel ()
        {
            _DisplayLabel.Text = _Text;
            _DisplayLabel.QueueResize();
            this.QueueResize();
            this.QueueDraw();
            this.ShowAll();
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

