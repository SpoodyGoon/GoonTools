// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace GUPdotNET {
    
    
    public partial class frmReTry {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.TextView txtMessage;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Button btnCancel;
        
        private Gtk.Button btnReTry;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmReTry
            this.Name = "GUPdotNET.frmReTry";
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.BorderWidth = ((uint)(4));
            this.HasSeparator = false;
            // Internal child GUPdotNET.frmReTry.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.txtMessage = new Gtk.TextView();
            this.txtMessage.CanFocus = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.WrapMode = ((Gtk.WrapMode)(2));
            this.txtMessage.PixelsAboveLines = 4;
            this.txtMessage.PixelsBelowLines = 4;
            this.txtMessage.PixelsInsideWrap = 4;
            this.txtMessage.LeftMargin = 4;
            this.txtMessage.RightMargin = 4;
            this.txtMessage.Indent = 5;
            this.alignment2.Add(this.txtMessage);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w3.Position = 0;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.TopPadding = ((uint)(4));
            this.alignment1.BottomPadding = ((uint)(4));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment1.Add(this.hseparator2);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w6.Position = 0;
            // Internal child GUPdotNET.frmReTry.ActionArea
            Gtk.HButtonBox w7 = this.ActionArea;
            w7.Name = "dialog1_ActionArea";
            w7.Spacing = 6;
            w7.BorderWidth = ((uint)(5));
            w7.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnCancel = new Gtk.Button();
            this.btnCancel.CanDefault = true;
            this.btnCancel.CanFocus = true;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseStock = true;
            this.btnCancel.UseUnderline = true;
            this.btnCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.btnCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w8 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.btnCancel]));
            w8.Expand = false;
            w8.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnReTry = new Gtk.Button();
            this.btnReTry.CanDefault = true;
            this.btnReTry.CanFocus = true;
            this.btnReTry.Name = "btnReTry";
            this.btnReTry.UseUnderline = true;
            // Container child btnReTry.Gtk.Container+ContainerChild
            Gtk.Alignment w9 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment1.Gtk.Container+ContainerChild
            Gtk.HBox w10 = new Gtk.HBox();
            w10.Spacing = 2;
            // Container child GtkHBox1.Gtk.Container+ContainerChild
            Gtk.Image w11 = new Gtk.Image();
            w11.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-redo", Gtk.IconSize.Menu, 16);
            w10.Add(w11);
            // Container child GtkHBox1.Gtk.Container+ContainerChild
            Gtk.Label w13 = new Gtk.Label();
            w13.LabelProp = Mono.Unix.Catalog.GetString("Retry");
            w13.UseUnderline = true;
            w10.Add(w13);
            w9.Add(w10);
            this.btnReTry.Add(w9);
            this.AddActionWidget(this.btnReTry, -5);
            Gtk.ButtonBox.ButtonBoxChild w17 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.btnReTry]));
            w17.Position = 1;
            w17.Expand = false;
            w17.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 300;
            this.Show();
            this.btnCancel.Clicked += new System.EventHandler(this.OnBtnCancelClicked);
            this.btnReTry.Clicked += new System.EventHandler(this.OnBtnReTryClicked);
        }
    }
}
