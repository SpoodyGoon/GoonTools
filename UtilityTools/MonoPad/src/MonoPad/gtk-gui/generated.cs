//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
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
                Gtk.IconSet w2 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("filenew.png"));
                w1.Add("filenew.png", w2);
                Gtk.IconSet w3 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("filesave.png"));
                w1.Add("filesave.png", w3);
                Gtk.IconSet w4 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("fileopen.png"));
                w1.Add("fileopen.png", w4);
                Gtk.IconSet w5 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("filesaveas.png"));
                w1.Add("filesaveas.png", w5);
                Gtk.IconSet w6 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("exit.png"));
                w1.Add("exit.png", w6);
                Gtk.IconSet w7 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("format-text-bold.png"));
                w1.Add("format-text-bold.png", w7);
                Gtk.IconSet w8 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("format-text-italic.png"));
                w1.Add("format-text-italic.png", w8);
                Gtk.IconSet w9 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("format-text-underline.png"));
                w1.Add("format-text-underline.png", w9);
                Gtk.IconSet w10 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("format-text-strikethrough.png"));
                w1.Add("format-text-strikethrough.png", w10);
                Gtk.IconSet w11 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("text_block.png"));
                w1.Add("text_block.png", w11);
                Gtk.IconSet w12 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("text_left.png"));
                w1.Add("text_left.png", w12);
                Gtk.IconSet w13 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("text_center.png"));
                w1.Add("text_center.png", w13);
                Gtk.IconSet w14 = new Gtk.IconSet(Gdk.Pixbuf.LoadFromResource("text_right.png"));
                w1.Add("text_right.png", w14);
                w1.AddDefault();
            }
        }
    }
    
    internal class BinContainer {
        
        private Gtk.Widget child;
        
        private Gtk.UIManager uimanager;
        
        public static BinContainer Attach(Gtk.Bin bin) {
            BinContainer bc = new BinContainer();
            bin.SizeRequested += new Gtk.SizeRequestedHandler(bc.OnSizeRequested);
            bin.SizeAllocated += new Gtk.SizeAllocatedHandler(bc.OnSizeAllocated);
            bin.Added += new Gtk.AddedHandler(bc.OnAdded);
            return bc;
        }
        
        private void OnSizeRequested(object sender, Gtk.SizeRequestedArgs args) {
            if ((this.child != null)) {
                args.Requisition = this.child.SizeRequest();
            }
        }
        
        private void OnSizeAllocated(object sender, Gtk.SizeAllocatedArgs args) {
            if ((this.child != null)) {
                this.child.Allocation = args.Allocation;
            }
        }
        
        private void OnAdded(object sender, Gtk.AddedArgs args) {
            this.child = args.Widget;
        }
        
        public void SetUiManager(Gtk.UIManager uim) {
            this.uimanager = uim;
            this.child.Realized += new System.EventHandler(this.OnRealized);
        }
        
        private void OnRealized(object sender, System.EventArgs args) {
            if ((this.uimanager != null)) {
                Gtk.Widget w;
                w = this.child.Toplevel;
                if (((w != null) 
                            && typeof(Gtk.Window).IsInstanceOfType(w))) {
                    ((Gtk.Window)(w)).AddAccelGroup(this.uimanager.AccelGroup);
                    this.uimanager = null;
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
