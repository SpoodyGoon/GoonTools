// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="LabelButton.cs" company="Andy York">
// //
// // Copyright (c) 2013 Andy York
// //
// // This program is free software: you can redistribute it and/or modify
// // it under the +terms of the GNU General Public License as published by
// // the Free Software Foundation, either version 3 of the License, or
// // (at your option) any later version.
// //
// // This program is distributed in the hope that it will be useful,
// // but WITHOUT ANY WARRANTY; without even the implied warranty of
// // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// // GNU General Public License for more details.
// //
// // You should have received a copy of the GNU General Public License
// // along with this program.  If not, see http://www.gnu.org/licenses/. 
// // </copyright>
// // <summary>
// // Email: goontools@brdstudio.net
// // Author: Andy York 
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace GUPdotNET.UI
{
    using System;
    using Gtk;

    /// <summary>
    /// A custom object made to function like the link button in WinForms.
    /// </summary>
    public class LabelButton : Gtk.EventBox
    {
        /// <summary>
        /// The markup template for displaying text when not having the mouse over the button.
        /// </summary>
        private const string NormalOverride = "<span font_family=\"sans\" foreground=\"#003399\" size=\"8800\" weight=\"bold\" underline=\"single\">{0}</span>";

        /// <summary>
        /// The markup template for displaying text when the mouse is over the button.
        /// </summary>
        private const string HoverOverride = "<span font_family=\"sans\"  foreground=\"#CC0000\" size=\"8800\" weight=\"bold\" underline=\"single\">{0}</span>";

        /// <summary>
        /// The label that displays the text to be displayed.
        /// </summary>
        private Gtk.Label displayLabel = new Gtk.Label();

        /// <summary>
        /// Simple flag identifying when the mouse is over the button.
        /// </summary>
        private bool isHover = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.LabelButton"/> class.
        /// </summary>
        /// <param name="text">The text value to be displayed for the button.</param>
        internal LabelButton(string text) : base()
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

        /// <summary>
        /// The button click event for when the button is clicked on by the mouse button.
        /// </summary>
        internal event System.Action<object> Clicked;

        /// <summary>
        /// Gets or sets the text value to be displayed for the button.
        /// </summary>
        internal string TextValue { get; set; }

        /// <summary>
        /// Raises the button release event event which fires the click event
        /// when the button being released is the left mouse button and the 
        /// click event is not null.
        /// </summary>
        /// <param name="buttonReleaseEvent">Event properties for getting the details of the event.</param>
        /// <returns>Boolean returns from the base object.</returns>
        protected override bool OnButtonReleaseEvent(Gdk.EventButton buttonReleaseEvent)
        {
            if (buttonReleaseEvent.Button == 1u && this.Clicked != null)
            {
                this.Clicked(this);
            }

            return base.OnButtonReleaseEvent(buttonReleaseEvent);
        }

        /// <summary>
        /// Raises the enter notify event event which is used to determine when the mouse is over the button.
        /// </summary>
        /// <param name="evnt">The parameter is not used.</param>
        /// <returns>Boolean returns from the base object.</returns>
        protected override bool OnEnterNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = true;
            this.UpdateDisplay();
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand1);
            return base.OnEnterNotifyEvent(evnt);
        }

        /// <summary>
        /// Raises the leave notify event event used to determine when the mouse is no longer over the button.
        /// </summary>
        /// <param name="evnt">The parameter is not used.</param>
        /// <returns>Boolean returns from the base object.</returns>
        protected override bool OnLeaveNotifyEvent(Gdk.EventCrossing evnt)
        {
            this.isHover = false;
            this.UpdateDisplay();
            this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
            return base.OnLeaveNotifyEvent(evnt);
        }

        /// <summary>
        /// Method for refreshing the text displayed on the button.
        /// </summary>
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
    }
}