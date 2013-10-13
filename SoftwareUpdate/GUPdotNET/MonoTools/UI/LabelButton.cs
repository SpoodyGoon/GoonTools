using System;
using Gtk;

namespace MonoTools.UI
{
    public class LabelButton : Gtk.Label
    {
        private FontMarkup normalMarkup = new FontMarkup();
        private FontMarkup hoverMarkup = new FontMarkup();
        private bool isHover = false;
        public string FontMarkupText{ get; private set;}

        public string TextValue{ set; get; }
        #region Private Properties Normal Font Format
        private string fontName = "";
        private string normalColorHex = "#003399";
        private string _Size = null;
        private bool _Underlined = true;
        private bool _Bold = false;
        private bool _Italic = false;
        #endregion  Private PropertiesNormal Font Format
        #region  Private PropertiesHover Font Format
        private string hoverFontName = "";
        private string hoverColorHex = "#CC0000";
        private string hoverSize = null;
        private bool hoverBold = false;
        private bool hoverUnderlined = true;
        private bool hoverItalic = false;
        #endregion  Private PropertiesHover Font Format
        #region Private Properties Normal Font Format        
        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Normal Font Format")]
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Description("The font name during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public string FontName
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
        public string FontColor
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
        public string Size
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
        public bool Bold
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
        public bool Underlined
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
        public bool Italic
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
        public string HoverFontName
        {
            set
            {
                hoverFontName = value;
                this.UpdateMarkup(false, true);
            }
            get{ return hoverFontName;}
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
                hoverColorHex = value;
                this.UpdateMarkup(false, true);
            }
            get{ return hoverColorHex;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("The size of font in points during normal display.")]
        [System.ComponentModel.Browsable(true)]
        public string HoverSize
        {
            set
            {
                hoverSize = value;
                UpdateMarkup(false, true);
            }
            get{ return hoverSize;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font bold during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public bool HoverBold
        {
            set
            {
                hoverBold = value;
                UpdateMarkup(false, true);
            }
            get{ return hoverBold;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Is the font underlined during hover.")]
        [System.ComponentModel.Browsable(true)]
        public bool HoverUnderlined
        {
            set
            {
                hoverUnderlined = value;
                UpdateMarkup(false, true);
            }
            get{ return hoverUnderlined;}
        }

        [System.ComponentModel.RefreshProperties(System.ComponentModel.RefreshProperties.Repaint)]
        [System.ComponentModel.Category("Hover Font Format")]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Description("Is the font italic during hover display.")]
        [System.ComponentModel.Browsable(true)]
        public bool HoverItalic
        {
            set
            {
                hoverItalic = value;
                UpdateMarkup(false, true);
            }
            get{ return hoverItalic;}
        }
        #endregion Private Properties Hover Font Format
        public LabelButton(string text) : base("LabelButton")
        {
            this.TextValue = text;
            this.Events = Gdk.EventMask.LeaveNotifyMask | Gdk.EventMask.EnterNotifyMask | Gdk.EventMask.ButtonReleaseMask | Gdk.EventMask.AllEventsMask;
            this.SetFlag(Gtk.WidgetFlags.AppPaintable);
            this.SetFlag(Gtk.WidgetFlags.Sensitive);
            this.CanFocus = false;
            this.CanDefault = false;
            this.Sensitive = true;
            this.AppPaintable = true;
            this.Selectable = true;
            this.SingleLineMode = true;
            this.Wrap = false;
            this.Ypad = 3;
            this.UpdateMarkup(true, true);
            this.UpdateDisplay();
        }

        public void SetText(string text)
        {
            this.TextValue = text;
            this.UpdateMarkup(true, true);
            this.UpdateDisplay();
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
                this.hoverMarkup.FontName = hoverFontName;
                this.hoverMarkup.FontState = MarkupFontState.Hover;
                this.hoverMarkup.ForeColor = hoverColorHex;
                if (!string.IsNullOrEmpty(hoverSize))
                {
                    this.hoverMarkup.FontSize = Convert.ToInt32(hoverSize);
                }
                else
                {
                    this.hoverMarkup.FontSize = null;
                }
                this.hoverMarkup.Bold = hoverBold;
                this.hoverMarkup.Underline = hoverUnderlined;
                this.hoverMarkup.Italic = hoverItalic;
                this.hoverMarkup.Initalize();
            }
            this.UpdateDisplay();
        }

        private const string NormalOverride = "<span  foreground=\"#003399\" size=\"9200\" weight=\"bold\" underline=\"single\">{0}</span>";
        private const string HoverOverride = "<span  foreground=\"#CC0000\" size=\"9200\" weight=\"bold\" underline=\"single\">{0}</span>";
        private void UpdateDisplay()
        {
            if (this.isHover)
            {
                this.LabelProp = string.Format(NormalOverride, this.TextValue);
            }
            else
            {
                this.LabelProp = string.Format(HoverOverride, this.TextValue);
            }
            this.UseMarkup = true;
            this.QueueResize();
            this.QueueDraw();
        }

        public event System.Action<object> Clicked;
        protected override bool OnButtonReleaseEvent(Gdk.EventButton evnt)
        {
            if (this.Clicked != null)
            {
                this.Clicked(this);
            }
            return base.OnButtonReleaseEvent(evnt);
        }

        protected override bool OnLeaveNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = false;
            this.UpdateDisplay();
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
            return base.OnLeaveNotifyEvent(evnt);
        }

        protected override bool OnEnterNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = true;
            this.UpdateDisplay();
            // TODO fix the cursor for the mouse over event
            // most likely change the root element to be an event box
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand1);
            return base.OnEnterNotifyEvent(evnt);
        }
    }
}

