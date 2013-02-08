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

namespace libMonoTools.Tools
{
    public class FontMarkup
    {
        private string _MarkupName = "MarkupName";
        private MarkupFontState _FontState = MarkupFontState.Normal;
        private string _FontName = "Serif";
        private Nullable<int> _Size = 10;
        // TODO: Implement Unit Of Measure
        //private string _UOM = "pt";
        private string _Color = "#ffffff";
        private bool _Bold = false;
        private bool _Italic = false;
        private bool _Underline = false;
        private string _Markup = string.Empty;
        public string PlaceHolder = "[TEXT]";
        
        public string Markup
        {
            get { return _Markup; }
        } 

        public string MarkupTextGet(string text)
        {
            if(!string.IsNullOrEmpty(_Markup))
                return _Markup.Replace(PlaceHolder, text);
            else
                return text;
        }
        
        public FontMarkup(string markupname, MarkupFontState fontstate, string fontname, string color, bool bold, bool underline, bool italic)
        {
            _MarkupName = markupname;
            _FontState = fontstate;
            _FontName = fontname;
            _Color = color;
            _Bold = bold;
            _Underline = underline;
            _Italic = italic;
        }   
        
        public FontMarkup(MarkupFontState fontstate, string fontname, string color, bool bold)
        {
            _FontState = fontstate;
            _FontName = fontname;
            _Color = color;
            _Bold = bold;
        }   
        
        public FontMarkup(string fontname, string color, bool bold)
        {
            _FontName = fontname;
            _Color = color;
            _Bold = bold;
        }    
        
        public FontMarkup(string fontname, string color)
        {
            _FontName = fontname;
            _Color = color;
        }    
        
        public FontMarkup()
        {
        } 
        
        private string BuildMarkup()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<span");
            if (_FontName != null)
                sb.Append(" face=\"" + _FontName + "\"");
            if (_Size != null)
                sb.Append(" size=\"" + _Size.ToString() + "\"");
            if (_Color != null)
                sb.Append(" foreground=\"" + _Color + "\"");
            if (_Bold)
                sb.Append(" weight=\"Bold\"");
            if (_Italic)
                sb.Append(" style=\"Italic\"");
            if (_Underline)
                sb.Append(" underline=\"single\"");
            sb.Append(">" + PlaceHolder + "</span>");
            return sb.ToString();
        }
        
        public void Scale(double scale)
        {
            if(_Size != null && _Size > 0)
            {
                _Size = Convert.ToInt32(Math.Floor(Convert.ToDouble(_Size) * scale));
                BuildMarkup();
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

