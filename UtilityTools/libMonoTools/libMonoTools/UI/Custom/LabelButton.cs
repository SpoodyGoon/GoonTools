using System;
using Gtk;

namespace libMonoTools.UI.Custom
{
    public abstract class LabelButton : Gtk.Label
    {
        private libMonoTools.Tools.FontMarkup _NormalMarkup = new libMonoTools.Tools.FontMarkup();
        private libMonoTools.Tools.FontMarkup _HoverMarkup = new libMonoTools.Tools.FontMarkup();
        private bool _IsHover = false;
        protected string FontMarkupText = "Test Markup";
        protected abstract string TextValue{ set; get; }

        #region Private Properties Normal Font Format
        private string _FontName = "";
        private string _NormalColorHex = "#003399";
        private string _Size = null;
        private bool _Underlined = true;
        private bool _Bold = false;
        private bool _Italic = false;
        #endregion  Private PropertiesNormal Font Format

        #region  Private PropertiesHover Font Format
        private string _HoverFontName = "";
        private string _HoverColorHex = "#CC0000";
        private string _HoverSize = null;
        private bool _HoverBold = false;
        private bool _HoverUnderlined = true;
        private bool _HoverItalic = false;
        #endregion  Private PropertiesHover Font Format

        
        #region Private Properties Normal Font Format        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Description("The font name during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string FontName {
            set{ _FontName = value;
                UpdateMarkup(true, false);}
            get{ return _FontName;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue("#003399")]
        [System.ComponentModel.Description("A hex value for the fonts color during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string FontColor {
            set {
                _NormalColorHex = value;
                UpdateMarkup(true, false);
            }
            get{ return _NormalColorHex;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("The size of font in points during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string Size {
            set{ _Size = value;
                UpdateMarkup(true, false);}
            get{ return _Size;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Bold {
            set { 
                _Bold = value;
                UpdateMarkup(true, false);
            }
            get{ return _Bold;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Underlined {
            set{ _Underlined = value;
                UpdateMarkup(true, false);}
            get{ return _Underlined;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Italic {
            set{ _Italic = value;
                UpdateMarkup(true, false);}
            get{ return _Italic;}
        }        
        #endregion Private Properties Normal Font Format

        #region Private Properties Hover Font Format
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Description("The font name during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string HoverFontName {
            set{ _HoverFontName = value;
                UpdateMarkup(false, true);}
            get{ return _HoverFontName;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue("#CC0000")]
        [System.ComponentModel.Description("A hex value for the fonts color during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public string HoverFontColor {
            set {
                _HoverColorHex = value;
                UpdateMarkup(false, true);
            }
            get{ return _HoverColorHex;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("The size of font in points during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string HoverSize {
            set{ _HoverSize = value;
                UpdateMarkup(false, true);}
            get{ return _HoverSize;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverBold {
            set{ _HoverBold = value;
                UpdateMarkup(false, true);}
            get{ return _HoverBold;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during hover.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverUnderlined {
            set{ _HoverUnderlined = value;
                UpdateMarkup(false, true);}
            get{ return _HoverUnderlined;}
        }
        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverItalic {
            set{ _HoverItalic = value;
                UpdateMarkup(false, true);}
            get{ return _HoverItalic;}
        }
        #endregion Private Properties Hover Font Format

        public LabelButton() : base()
        {
            this.Events = Gdk.EventMask.LeaveNotifyMask | Gdk.EventMask.EnterNotifyMask | Gdk.EventMask.ButtonReleaseMask | Gdk.EventMask.AllEventsMask;
            this.SetFlag(Gtk.WidgetFlags.AppPaintable);
            this.SetFlag(Gtk.WidgetFlags.Sensitive);
            this.CanFocus = true;
            this.Sensitive = true;
            this.AppPaintable = true;
            this.Selectable = true;
            this.SingleLineMode = true;
            this.Wrap = false;
            this.AppPaintable = true;
            this.Ypad = 3;

//            this.EnterNotifyEvent += delegate(object o, EnterNotifyEventArgs args)
//            {
//                _IsHover = true;
//                UpdateDisplay();
//            };
//            this.LeaveNotifyEvent += delegate(object o, LeaveNotifyEventArgs args)
//            {
//                _IsHover = false;
//                UpdateDisplay();
//            };
        }

        protected void UpdateMarkup (bool blnNormal, bool blnHover)
        {
            if(blnNormal)
            {
                _NormalMarkup.FontName = _FontName;
                _NormalMarkup.FontState = libMonoTools.Tools.MarkupFontState.Normal;
                _NormalMarkup.Color = _NormalColorHex;
                if(!string.IsNullOrEmpty(_Size))
                    _NormalMarkup.Size = Convert.ToInt32(_Size);
                else
                    _NormalMarkup.Size = null;
                _NormalMarkup.Bold = _Bold;
                _NormalMarkup.Underline = _Underlined;
                _NormalMarkup.Italic = _Italic;
                _NormalMarkup.BuildMarkup();
            }
            if(blnHover)
            {
                _HoverMarkup.FontName = _HoverFontName;
                _HoverMarkup.FontState = libMonoTools.Tools.MarkupFontState.Hover;
                _HoverMarkup.Color = _HoverColorHex;
                if(!string.IsNullOrEmpty(_HoverSize))
                    _HoverMarkup.Size = Convert.ToInt32(_HoverSize);
                else
                    _HoverMarkup.Size = null;
                _HoverMarkup.Bold = _HoverBold;
                _HoverMarkup.Underline = _HoverUnderlined;
                _HoverMarkup.Italic = _HoverItalic;
                _HoverMarkup.BuildMarkup();
            }
            UpdateDisplay();
        }

        private void UpdateDisplay ()
        {
            if(_IsHover)
            {
                this.LabelProp = _HoverMarkup.MarkupTextGet(this.Text);
            }
            else
            {
                this.LabelProp = _NormalMarkup.MarkupTextGet(this.Text);
            }
            this.UseMarkup = true;
            this.QueueResize();
            this.QueueDraw();
        }

        protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
        {
            _IsHover = false;
            UpdateDisplay();
            return base.OnLeaveNotifyEvent(evnt);
        }

        protected override bool OnEnterNotifyEvent (Gdk.EventCrossing evnt)
        {
            _IsHover = true;
            UpdateDisplay();
            return base.OnEnterNotifyEvent(evnt);
        }
    }
}

