//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUPdotNET {
    
    
    public partial class frmDownload {
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.ProgressBar progressbar1;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Button btnCancel1;
        
        private Gtk.Button button9;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmDownload
            this.Name = "GUPdotNET.frmDownload";
            this.Title = Mono.Unix.Catalog.GetString("Downloading Update");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.BorderWidth = ((uint)(3));
            this.AllowShrink = true;
            this.Decorated = false;
            this.DestroyWithParent = true;
            this.SkipPagerHint = true;
            this.SkipTaskbarHint = true;
            // Internal child GUPdotNET.frmDownload.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 9;
            this.hbox1.BorderWidth = ((uint)(3));
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.LeftPadding = ((uint)(10));
            this.alignment1.TopPadding = ((uint)(6));
            this.alignment1.RightPadding = ((uint)(10));
            this.alignment1.BottomPadding = ((uint)(6));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.progressbar1 = new Gtk.ProgressBar();
            this.progressbar1.WidthRequest = 120;
            this.progressbar1.Name = "progressbar1";
            this.progressbar1.Text = Mono.Unix.Catalog.GetString("Starting Download");
            this.progressbar1.Ellipsize = ((Pango.EllipsizeMode)(1));
            this.alignment1.Add(this.progressbar1);
            this.hbox1.Add(this.alignment1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment1]));
            w3.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            this.alignment3.LeftPadding = ((uint)(4));
            this.alignment3.TopPadding = ((uint)(4));
            this.alignment3.RightPadding = ((uint)(4));
            this.alignment3.BottomPadding = ((uint)(4));
            // Container child alignment3.Gtk.Container+ContainerChild
            this.btnCancel1 = new Gtk.Button();
            this.btnCancel1.CanFocus = true;
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.UseStock = true;
            this.btnCancel1.UseUnderline = true;
            this.btnCancel1.Label = "gtk-cancel";
            this.alignment3.Add(this.btnCancel1);
            this.hbox1.Add(this.alignment3);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment3]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            this.GtkAlignment.Add(this.hbox1);
            this.frame1.Add(this.GtkAlignment);
            w1.Add(this.frame1);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(w1[this.frame1]));
            w8.Position = 0;
            w8.Expand = false;
            w8.Fill = false;
            // Internal child GUPdotNET.frmDownload.ActionArea
            Gtk.HButtonBox w9 = this.ActionArea;
            w9.Sensitive = false;
            w9.Name = "dialog1_ActionArea";
            w9.Spacing = 10;
            w9.BorderWidth = ((uint)(5));
            w9.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.button9 = new Gtk.Button();
            this.button9.CanFocus = true;
            this.button9.Name = "button9";
            this.button9.UseUnderline = true;
            this.button9.Label = Mono.Unix.Catalog.GetString("button9");
            this.AddActionWidget(this.button9, 0);
            Gtk.ButtonBox.ButtonBoxChild w10 = ((Gtk.ButtonBox.ButtonBoxChild)(w9[this.button9]));
            w10.Expand = false;
            w10.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 371;
            this.DefaultHeight = 111;
            w9.Hide();
            this.Show();
        }
    }
}
