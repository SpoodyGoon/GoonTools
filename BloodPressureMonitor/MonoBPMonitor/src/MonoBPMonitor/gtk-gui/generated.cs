//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stetic {
    
    
    internal class Gui {
        
        private static bool initialized;
        
        internal static void Initialize(Gtk.Widget iconRenderer) {
            if ((Stetic.Gui.initialized == false)) {
                Stetic.Gui.initialized = true;
                Gtk.IconFactory w1 = new Gtk.IconFactory();
                Gtk.IconSet w2 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("edit_user.png"));
                w1.Add("edit_user.png", w2);
                Gtk.IconSet w3 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("edit_add.png"));
                w1.Add("edit_add.png", w3);
                Gtk.IconSet w4 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("edit_remove.png"));
                w1.Add("edit_remove.png", w4);
                Gtk.IconSet w5 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("exit.png"));
                w1.Add("exit.png", w5);
                Gtk.IconSet w6 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("help.png"));
                w1.Add("help.png", w6);
                Gtk.IconSet w7 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("icon_small.png"));
                w1.Add("icon_small.png", w7);
                Gtk.IconSet w8 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("doctor.png"));
                w1.Add("doctor.png", w8);
                Gtk.IconSet w9 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("rx.png"));
                w1.Add("rx.png", w9);
                Gtk.IconSet w10 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("ManageConnections.png"));
                w1.Add("ManageConnectinos.png", w10);
                Gtk.IconSet w11 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("ProjectWebSite.png"));
                w1.Add("ProjectWebSite.png", w11);
                Gtk.IconSet w12 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("ErrorLog.png"));
                w1.Add("ErrorLog.png", w12);
                Gtk.IconSet w13 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("Options.png"));
                w1.Add("Options.png", w13);
                Gtk.IconSet w14 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("DocumentOnline.png"));
                w1.Add("DocumentOnline.png", w14);
                Gtk.IconSet w15 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("issue_feature.png"));
                w1.Add("issue_feature.png", w15);
                Gtk.IconSet w16 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("update_small.png"));
                w1.Add("update_small.png", w16);
                w1.AddDefault();
            }
        }
    }
    
    internal class IconLoader {
        
        public static Gdk.Pixbuf LoadIcon(Gtk.Widget widget, string name, Gtk.IconSize size, int sz) {
            Gdk.Pixbuf res = widget.RenderIcon(name, size, null);
            if ((res != null)) {
                return res;
            }
            else {
                try {
                    return Gtk.IconTheme.Default.LoadIcon(name, sz, 0);
                }
                catch (System.Exception ) {
                    if ((name != "gtk-missing-image")) {
                        return Stetic.IconLoader.LoadIcon(widget, "gtk-missing-image", size, sz);
                    }
                    else {
                        Gdk.Pixmap pmap = new Gdk.Pixmap(Gdk.Screen.Default.RootWindow, sz, sz);
                        Gdk.GC gc = new Gdk.GC(pmap);
                        gc.RgbFgColor = new Gdk.Color(255, 255, 255);
                        pmap.DrawRectangle(gc, true, 0, 0, sz, sz);
                        gc.RgbFgColor = new Gdk.Color(0, 0, 0);
                        pmap.DrawRectangle(gc, false, 0, 0, (sz - 1), (sz - 1));
                        gc.SetLineAttributes(3, Gdk.LineStyle.Solid, Gdk.CapStyle.Round, Gdk.JoinStyle.Round);
                        gc.RgbFgColor = new Gdk.Color(255, 0, 0);
                        pmap.DrawLine(gc, (sz / 4), (sz / 4), ((sz - 1) 
                                        - (sz / 4)), ((sz - 1) 
                                        - (sz / 4)));
                        pmap.DrawLine(gc, ((sz - 1) 
                                        - (sz / 4)), (sz / 4), (sz / 4), ((sz - 1) 
                                        - (sz / 4)));
                        return Gdk.Pixbuf.FromDrawable(pmap, pmap.Colormap, 0, 0, 0, 0, sz, sz);
                    }
                }
            }
        }
    }
    
    internal class ActionGroups {
        
        public static Gtk.ActionGroup GetActionGroup(System.Type type) {
            return Stetic.ActionGroups.GetActionGroup(type.FullName);
        }
        
        public static Gtk.ActionGroup GetActionGroup(string name) {
            return null;
        }
    }
}
