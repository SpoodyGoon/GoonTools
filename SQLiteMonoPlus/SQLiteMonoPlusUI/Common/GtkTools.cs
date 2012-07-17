//  
//  GtkTools.cs
//  
//  Author:
//       Andrew York <yahtzeesharp@brdstudio.net>
// 
//  Copyright (c) 2012 Andrew York
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
namespace SQLiteMonoPlusUI.GlobalTools
{
    public static class GtkTools
    {
                
        internal static void SimpleMessage(string message, string title)
        {
            SimpleMessage(null, message, title);
        }
        
        internal static void SimpleMessage(Gtk.Window parent, string message, string title)
        {           
            Gtk.MessageDialog md = new Gtk.MessageDialog(parent, DialogFlags.Modal, MessageType.Other, Gtk.ButtonsType.Ok, false, message, title);
            md.Run();
            md.Destroy();
        }	
        
        internal static Gtk.Widget FindWidget(Gtk.Container ParentContainer, string WidgetName)
        {
            return FindWidget(ParentContainer, WidgetName, GLib.GType.None);
        }
        
        internal static Gtk.Widget FindWidget(Gtk.Container ParentContainer, string WidgetName, GLib.GType WidgetType)
        {
            Gtk.Widget wgtFound = null;
            foreach(Gtk.Widget wgt in ParentContainer.AllChildren)
            {
                if(wgt.Name.Equals(WidgetName, StringComparison.InvariantCultureIgnoreCase))
                {
                    wgtFound = wgt;
                }
            }
            return wgtFound;
        }
    }
}

