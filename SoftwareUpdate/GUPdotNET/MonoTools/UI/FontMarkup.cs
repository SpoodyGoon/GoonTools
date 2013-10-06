//
//  MarkupFont.cs
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

namespace MonoTools.UI
{
    public class FontMarkup
    {
        /// <summary>
        /// The string for holding the markup layout after loading.
        /// </summary>
        private string markupText = string.Empty;
        /// <summary>
        /// The place holder for where the text to be displayed is to be placed.
        /// </summary>
        public const string PlaceHolder = "[TEXT]";

        /// <summary>
        /// Gets a value indicating whether the markup text has been built.
        /// </summary>
        /// <value><c>true</c> if this instance is initalized, meaning that the markup text has been built; otherwise, <c>false</c>.</value>
        public bool IsInitalized { get; private set; }

        /// <summary>
        /// Gets or sets the name of the the descriptive name for the markup.
        /// </summary>
        public string MarkupName { get; set; }

        public MarkupFontState FontState { get; set; }

        public string FontName { get; set; }

        public Nullable<int> FontSize { get; set; }

        public string ForeColor { get; set; }

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        public bool Underline { get; set; }

        public string MarkupText
        {
            get { return markupText; }
        }

        public string MarkupTextGet(string text)
        {
            if (!string.IsNullOrEmpty(markupText))
            {
                return markupText.Replace(PlaceHolder, text);
            }
            else
            {
                return text;
            }
        }

        public FontMarkup()
        {
            this.IsInitalized = false;
            this.MarkupName = "MarkupName";
            this.FontState = MarkupFontState.Normal;
            this.Bold = false;
            this.Italic = false;
            this.Underline = false;
        }

        public void Initalize()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<span");
            if (this.FontName != null)
                sb.Append(" face=\"" + this.FontName + "\"");
            // Assume sizes are all in points perform math
            // to convert to markup usable size in 1024ths of a point
            if (this.FontSize != null)
                sb.Append(" size=\"" + (this.FontSize * 1024).ToString() + "\"");
            if (this.ForeColor != null)
                sb.Append(" foreground=\"" + this.ForeColor + "\"");
            if (this.Bold)
                sb.Append(" weight=\"Bold\"");
            if (this.Italic)
                sb.Append(" style=\"Italic\"");
            if (this.Underline)
                sb.Append(" underline=\"single\"");
            sb.Append(">" + PlaceHolder + "</span>");
            this.markupText = sb.ToString();
            this.IsInitalized = true;
        }

        public void Scale(double scale)
        {
            if (this.FontSize != null && this.FontSize > 0)
            {
                this.FontSize = Convert.ToInt32(Math.Floor(Convert.ToDouble(this.FontSize) * scale));
                this.Initalize();
            }
        }
    }

    public enum MarkupFontState
    {
        Normal,
        Hover,
        Visited,
        Active,
        Inactive,
        Enabled,
        Disabled
    }
}

