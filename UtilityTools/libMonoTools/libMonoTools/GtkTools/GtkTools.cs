
using System;
using Gtk;

namespace libMonoTools.Tools
{
    public class GtkHelper
    {
        public GtkHelper()
        {
        }

        public void SimpleMessage(string message, string title)
        {
            SimpleMessage(null, message, title);
        }

        public void SimpleMessage(Gtk.Window parent, string message, string title)
        {
            Gtk.MessageDialog md = new Gtk.MessageDialog(parent, DialogFlags.Modal, MessageType.Other, Gtk.ButtonsType.Ok, false, message, title);
            md.Title = title;
            md.MessageType = MessageType.Info;
            md.Run();
            md.Destroy();
        }

        public Gtk.Widget FindWidget(Gtk.Container ParentContainer, string WidgetName)
        {
            return FindWidget(ParentContainer, WidgetName, GLib.GType.None);
        }

        public Gtk.Widget FindWidget(Gtk.Container ParentContainer, string WidgetName, GLib.GType WidgetType)
        {
            Gtk.Widget wgtFound = null;
            foreach (Gtk.Widget wgt in ParentContainer.AllChildren)
            {
                if (wgt.Name.Equals(WidgetName, StringComparison.InvariantCultureIgnoreCase))
                {
                    wgtFound = wgt;
                }
            }
            return wgtFound;
        }
    }
}

