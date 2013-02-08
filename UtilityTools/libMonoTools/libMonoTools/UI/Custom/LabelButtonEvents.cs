//
//  LabelButtonEvents.cs
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

namespace libMonoTools.UI.Custom
{
    public delegate void TextChanged(object sender,TextChangedEventArgs args);
    public class TextChangedEventArgs : EventArgs
    {
        public TextChangedEventArgs ()
        {
        }
    }

    public delegate void Click(object sender,ClickEventArgs args);
    public class ClickEventArgs : EventArgs
    {
        public ClickEventArgs ()
        {
        }
    }

    public delegate void MouseOver(object sender,MouseOverEventArgs args);
    public class MouseOverEventArgs : EventArgs
    {
        public MouseOverEventArgs ()
        {
        }
    }

    public delegate void MouseOut(object sender,MouseOutEventArgs args);
    public class MouseOutEventArgs : EventArgs
    {
        public MouseOutEventArgs ()
        {
        }
    }
}

