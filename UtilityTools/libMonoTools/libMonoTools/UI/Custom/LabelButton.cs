using System;
using Gtk;

namespace libMonoTools.UI.Custom
{
    public abstract class LabelButton : Gtk.Label
    {
        protected string _DisplayText = "URLButton";
        private string _NormalColorHex = "#003399";
        private string _HoverColorHex = "#CC0000";
        private bool _Underlined = true;
        private bool _Bold = false;
        private bool _Italic = false;
        private bool _HoverItalic = false;
        private bool _HoverUnderlined = true;
        private bool _HoverBold = false;
        protected string FontMarkupText = "Test Markup";

        public LabelButton()
        {
            Build();
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Display Properties")]
        [System.ComponentModel.DefaultValue("URLButton")]
        [System.ComponentModel.Description("The text that is displayed.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string DisplayText {
            set 
            {
                _DisplayText = value;
                base.LabelProp = _DisplayText;
                base.QueueDraw();
                this.QueueDraw();
            }
            get{ return _DisplayText;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue("#003399")]
        [System.ComponentModel.Description("A hex value for the fonts color during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string FontColor {
            set {
                _NormalColorHex = value;
            }
            get{return _NormalColorHex;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Underlined {
            set{ _Underlined = value;}
            get{return _Underlined;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Bold {
            set{ _Bold = value;}
            get{return _Bold;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Italic {
            set{ _Italic = value;}
            get{return _Italic;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue("#CC0000")]
        [System.ComponentModel.Description("A hex value for the fonts color during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public string HoverFontColor {
            set {
                _HoverColorHex = value;
            }
            get{return _HoverColorHex;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during hover.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverUnderlined {
            set{ _HoverUnderlined = value;}
            get{return _HoverUnderlined;}
        }
        
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverBold {
            set{ _HoverBold = value;}
            get{return _HoverBold;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverItalic {
            set{ _HoverItalic = value;}
            get{return _HoverItalic;}
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
            //_DisplayLabel.Text = _Text;
            //_DisplayLabel.QueueResize();
            this.QueueResize();
            this.QueueDraw();
            this.ShowAll();
        }
    }
}

