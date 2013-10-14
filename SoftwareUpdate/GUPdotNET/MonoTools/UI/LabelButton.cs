//
//  LabelButton.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using Gtk;
using MonoTools;

namespace MonoTools.UI
{
    public class LabelButton : Gtk.EventBox
    {
        private Gtk.Label displayLabel = new Gtk.Label();
        private const string NormalMarkupFormat = "";        
        public event System.Action<object> Clicked;
        private const string NormalOverride = "<span font_family=\"sans\" foreground=\"#003399\" size=\"8800\" weight=\"bold\" underline=\"single\">{0}</span>";
        private const string HoverOverride = "<span font_family=\"sans\"  foreground=\"#CC0000\" size=\"8800\" weight=\"bold\" underline=\"single\">{0}</span>";
        private bool isHover = false;
        public string TextValue{ get; set;}
        public LabelButton(string text) : base()
        {
            this.TextValue = text;
            this.Events = Gdk.EventMask.LeaveNotifyMask | Gdk.EventMask.EnterNotifyMask | Gdk.EventMask.ButtonReleaseMask | Gdk.EventMask.AllEventsMask;
            this.SetFlag(Gtk.WidgetFlags.AppPaintable);
            this.SetFlag(Gtk.WidgetFlags.Sensitive);
            this.CanFocus = true;
            this.CanDefault = true;
            this.Sensitive = true;
            this.AppPaintable = true;
            this.AboveChild = true;
            this.displayLabel.Selectable = false;
            this.displayLabel.SingleLineMode = true;
            this.displayLabel.Wrap = false;
            this.displayLabel.Ypad = 3;
            this.Add(this.displayLabel);
            this.UpdateDisplay();
        }

        protected override bool OnButtonReleaseEvent(Gdk.EventButton evnt)
        {
            if (this.Clicked != null)
            {
                this.Clicked(this);
            }
            return base.OnButtonReleaseEvent(evnt);
        }

        private void UpdateDisplay()
        {
            if (this.isHover)
            {
                this.displayLabel.LabelProp = string.Format(HoverOverride, this.TextValue);
            }
            else
            {
                this.displayLabel.LabelProp = string.Format(NormalOverride, this.TextValue);
            }
            this.displayLabel.UseMarkup = true;
            this.displayLabel.QueueResize();
            this.QueueResize();
            this.QueueDraw();
        }

        protected override bool OnEnterNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = true;
            this.UpdateDisplay();
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand1);
            return base.OnEnterNotifyEvent(evnt);
        }

        protected override bool OnLeaveNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = false;
            this.UpdateDisplay();
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
            return base.OnLeaveNotifyEvent(evnt);
        }
    }
}

