//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUPdotNET {
    
    
    public partial class frmDownload {
        
        private Gtk.Alignment alignment1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.ProgressBar pgbDownload;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Button btnCancel;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Button btnHide;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmDownload
            this.Name = "GUPdotNET.frmDownload";
            this.Title = Mono.Unix.Catalog.GetString("frmDownload");
            this.Icon = Gdk.Pixbuf.LoadFromResource("downloading.png");
            this.WindowPosition = ((Gtk.WindowPosition)(1));
            this.Modal = true;
            this.BorderWidth = ((uint)(8));
            this.Resizable = false;
            this.AllowGrow = false;
            this.DestroyWithParent = true;
            this.Gravity = ((Gdk.Gravity)(2));
            // Container child GUPdotNET.frmDownload.Gtk.Container+ContainerChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            // Container child alignment1.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 10;
            this.hbox1.BorderWidth = ((uint)(4));
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.pgbDownload = new Gtk.ProgressBar();
            this.pgbDownload.WidthRequest = 200;
            this.pgbDownload.Name = "pgbDownload";
            this.pgbDownload.Text = Mono.Unix.Catalog.GetString("Starting Download");
            this.alignment2.Add(this.pgbDownload);
            this.hbox1.Add(this.alignment2);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment2]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.btnCancel = new Gtk.Button();
            this.btnCancel.CanFocus = true;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseUnderline = true;
            // Container child btnCancel.Gtk.Container+ContainerChild
            Gtk.Alignment w3 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w4 = new Gtk.HBox();
            w4.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w5 = new Gtk.Image();
            w5.Pixbuf = Gdk.Pixbuf.LoadFromResource("cancel.png");
            w4.Add(w5);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w7 = new Gtk.Label();
            w7.LabelProp = Mono.Unix.Catalog.GetString("_Cancel");
            w7.UseUnderline = true;
            w4.Add(w7);
            w3.Add(w4);
            this.btnCancel.Add(w3);
            this.alignment3.Add(this.btnCancel);
            this.hbox1.Add(this.alignment3);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment3]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.btnHide = new Gtk.Button();
            this.btnHide.CanFocus = true;
            this.btnHide.Name = "btnHide";
            this.btnHide.UseUnderline = true;
            // Container child btnHide.Gtk.Container+ContainerChild
            Gtk.Alignment w13 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w14 = new Gtk.HBox();
            w14.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w15 = new Gtk.Image();
            w15.Pixbuf = Gdk.Pixbuf.LoadFromResource("hide.png");
            w14.Add(w15);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w17 = new Gtk.Label();
            w17.LabelProp = Mono.Unix.Catalog.GetString("_Hide");
            w17.UseUnderline = true;
            w14.Add(w17);
            w13.Add(w14);
            this.btnHide.Add(w13);
            this.alignment4.Add(this.btnHide);
            this.hbox1.Add(this.alignment4);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment4]));
            w22.Position = 2;
            w22.Expand = false;
            w22.Fill = false;
            this.alignment1.Add(this.hbox1);
            this.Add(this.alignment1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 382;
            this.DefaultHeight = 58;
            this.Show();
            this.btnCancel.Clicked += new System.EventHandler(this.OnBtnCancelClicked);
            this.btnHide.Clicked += new System.EventHandler(this.OnBtnHideClicked);
        }
    }
}
