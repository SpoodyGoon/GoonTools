//
//  LinkButton.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
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

namespace libMonoTools
{
    [System.ComponentModel.DefaultEvent("Clicked")]
    [System.ComponentModel.DefaultProperty("DisplayText")]
    [System.ComponentModel.ToolboxItem(true)]
    public class LinkButton : libMonoTools.UI.Custom.LabelButton
    {
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.Category("Custom Events")]
        public event libMonoTools.UI.Custom.Click Clicked;
        private bool _MouseOverHand = true;
        public LinkButton() : base()
        {
            this.Events = Gdk.EventMask.LeaveNotifyMask | Gdk.EventMask.EnterNotifyMask | Gdk.EventMask.ButtonReleaseMask | Gdk.EventMask.AllEventsMask;
            this.CanFocus = true;
            this.Sensitive = true;
            this.AppPaintable = true;
            this.Selectable = true;
            this.SingleLineMode = true;
            this.Wrap = false;
            this.AppPaintable = true;
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
        [System.ComponentModel.DefaultValue(true)]
        [System.ComponentModel.Description("Use the hand cursor for mouse over.")]
        [System.ComponentModel.Browsable(true)]
        public bool MouseOverHand {
            get {
                return _MouseOverHand;
            }
            set {
                _MouseOverHand = value;
            }
        }

        protected override bool OnButtonReleaseEvent (Gdk.EventButton evnt)
        {
            Clicked(this);
            return base.OnButtonReleaseEvent(evnt);
        }
        
        protected override bool OnEnterNotifyEvent (Gdk.EventCrossing evnt)
        {
            if(_MouseOverHand)
            {
                evnt.Window.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand2);
                evnt.Window.Display.Sync(); 
            }
            return base.OnEnterNotifyEvent(evnt);
        }
        
        protected override bool OnLeaveNotifyEvent (Gdk.EventCrossing evnt)
        {
            if(_MouseOverHand)
            {
                evnt.Window.Cursor = new Gdk.Cursor(Gdk.CursorType.LastCursor);
                evnt.Window.Display.Sync(); 
            }
            return base.OnLeaveNotifyEvent(evnt);
        }
    }
}

