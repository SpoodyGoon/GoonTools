using System;
using Gtk;

namespace MonoTools.UI
{
    public abstract class LabelButton : Gtk.Label
    {
        private FontMarkup normalMarkup = new FontMarkup();
        private FontMarkup hoverMarkup = new FontMarkup();
        private bool isHover = false;
        protected string FontMarkupText = "Test Markup";

        protected abstract string TextValue{ set; get; }
        #region Private Properties Normal Font Format
        private string fontName = "";
        private string normalColorHex = "#003399";
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
        public virtual string FontName
        {
            set
            {
                this.fontName = value;
                this.UpdateMarkup(true, false);
            }
            get{ return this.fontName;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue("#003399")]
        [System.ComponentModel.Description("A hex value for the fonts color during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string FontColor
        {
            set
            {
                this.normalColorHex = value;
                this.UpdateMarkup(true, false);
            }
            get{ return this.normalColorHex;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("The size of font in points during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string Size
        {
            set
            {
                _Size = value;
                this.UpdateMarkup(true, false);
            }
            get{ return _Size;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Bold
        {
            set
            { 
                _Bold = value;
                this.UpdateMarkup(true, false);
            }
            get{ return _Bold;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Underlined
        {
            set
            {
                _Underlined = value;
                this.UpdateMarkup(true, false);
            }
            get{ return _Underlined;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool Italic
        {
            set
            {
                _Italic = value;
                this.UpdateMarkup(true, false);
            }
            get{ return _Italic;}
        }
        #endregion Private Properties Normal Font Format
        #region Private Properties Hover Font Format
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Description("The font name during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string HoverFontName
        {
            set
            {
                _HoverFontName = value;
                this.UpdateMarkup(false, true);
            }
            get{ return _HoverFontName;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue("#CC0000")]
        [System.ComponentModel.Description("A hex value for the fonts color during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public string HoverFontColor
        {
            set
            {
                _HoverColorHex = value;
                this.UpdateMarkup(false, true);
            }
            get{ return _HoverColorHex;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("The size of font in points during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual string HoverSize
        {
            set
            {
                _HoverSize = value;
                UpdateMarkup(false, true);
            }
            get{ return _HoverSize;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverBold
        {
            set
            {
                _HoverBold = value;
                UpdateMarkup(false, true);
            }
            get{ return _HoverBold;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during hover.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverUnderlined
        {
            set
            {
                _HoverUnderlined = value;
                UpdateMarkup(false, true);
            }
            get{ return _HoverUnderlined;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public virtual bool HoverItalic
        {
            set
            {
                _HoverItalic = value;
                UpdateMarkup(false, true);
            }
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
        }

        protected void UpdateMarkup(bool blnNormal, bool blnHover)
        {
            if (blnNormal)
            {
                this.normalMarkup.FontName = this.fontName;
                this.normalMarkup.FontState = MarkupFontState.Normal;
                this.normalMarkup.ForeColor = this.normalColorHex;
                if (!string.IsNullOrEmpty(_Size))
                {
                    this.normalMarkup.FontSize = Convert.ToInt32(_Size);
                }
                else
                {
                    this.normalMarkup.FontSize = null;
                }
                this.normalMarkup.Bold = _Bold;
                this.normalMarkup.Underline = _Underlined;
                this.normalMarkup.Italic = _Italic;
                this.normalMarkup.Initalize();
            }
            if (blnHover)
            {
                this.hoverMarkup.FontName = _HoverFontName;
                this.hoverMarkup.FontState = MarkupFontState.Hover;
                this.hoverMarkup.ForeColor = _HoverColorHex;
                if (!string.IsNullOrEmpty(_HoverSize))
                {
                    this.hoverMarkup.FontSize = Convert.ToInt32(_HoverSize);
                }
                else
                {
                    this.hoverMarkup.FontSize = null;
                }
                this.hoverMarkup.Bold = _HoverBold;
                this.hoverMarkup.Underline = _HoverUnderlined;
                this.hoverMarkup.Italic = _HoverItalic;
                this.hoverMarkup.Initalize();
            }
            this.UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (this.isHover)
            {
                this.LabelProp = hoverMarkup.MarkupTextGet(this.Text);
            }
            else
            {
                this.LabelProp = normalMarkup.MarkupTextGet(this.Text);
            }
            this.UseMarkup = true;
            this.QueueResize();
            this.QueueDraw();
        }

        protected override bool OnLeaveNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = false;
            this.UpdateDisplay();
            return base.OnLeaveNotifyEvent(evnt);
        }

        protected override bool OnEnterNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = true;
            this.UpdateDisplay();
            return base.OnEnterNotifyEvent(evnt);
        }
    }
}

