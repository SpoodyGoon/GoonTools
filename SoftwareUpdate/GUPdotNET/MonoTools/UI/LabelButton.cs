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

namespace MonoTools.UI
{
    [System.ComponentModel.ToolboxItem(true)]
    public class LabelButton : Gtk.Label
    {
        public MarkupFont NormalFont = new MarkupFont();
        public MarkupFont HoverFont = new MarkupFont();

        public string DisplayText{ get; set; }

        public event System.Action Clicked;
        public LabelButton()
        {
            this.NormalFont.Color = "#ab0a0a";
            this.NormalFont.Underline = true;
            this.HoverFont.Color = "#ab0a0a";
            this.HoverFont.Underline = true;
            this.DisplayText = "About GUPdotNET";
            this.Initalize();
        }

        public void Initalize()
        {
            this.Events = Gdk.EventMask.LeaveNotifyMask | Gdk.EventMask.EnterNotifyMask | Gdk.EventMask.ButtonReleaseMask | Gdk.EventMask.ExposureMask | Gdk.EventMask.AllEventsMask;
            this.CanFocus = true;
            this.Sensitive = true;
            this.DoubleBuffered = true;
            this.AppPaintable = true;

            if (!this.NormalFont.IsLoaded)
            {
                this.NormalFont.Load();
            }
            if (!this.HoverFont.IsLoaded)
            {
                this.HoverFont.Load();
            }

            this.ButtonReleaseEvent += delegate
            {
                if (this.Clicked != null)
                {
                    this.Clicked();
                }
            };
            
            this.Text = this.NormalFont.MarkupTextGet(this.DisplayText);
            this.UseMarkup = true;
            this.QueueDraw();

            this.EnterNotifyEvent += LabelButton_MouseOver;
            this.LeaveNotifyEvent += LabelButton_MouseOut;
        }

        private void LabelButton_MouseOut(object o, Gtk.LeaveNotifyEventArgs args)
        {
            
            this.Text = this.NormalFont.MarkupTextGet(this.DisplayText);
            this.UseMarkup = true;
            this.QueueDraw();
        }

        private void LabelButton_MouseOver (object o, Gtk.EnterNotifyEventArgs args)
        {
            
            this.Text = this.HoverFont.MarkupTextGet(this.DisplayText);
            this.UseMarkup = true;
            this.QueueDraw();
        }

        public enum ButtonState
        {
            Normal,
            Hover,
            Active,
            Disabled
        }
    }
}

