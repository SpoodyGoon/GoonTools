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
    
    
    public partial class frmSuPass {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Label label1;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Label lblp;
        
        private Gtk.Entry txtAdminPass;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.Label label3;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmSuPass
            this.WidthRequest = 450;
            this.HeightRequest = 250;
            this.Name = "GUPdotNET.frmSuPass";
            this.Title = Mono.Unix.Catalog.GetString("Administrator Password Needed");
            this.Icon = Stetic.IconLoader.LoadIcon(this, "gtk-dialog-warning", Gtk.IconSize.Menu, 16);
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.AllowShrink = true;
            this.HasSeparator = false;
            // Internal child GUPdotNET.frmSuPass.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.TopPadding = ((uint)(5));
            this.alignment1.BottomPadding = ((uint)(4));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"large\"><b>Administrator Password Needed</b></span>");
            this.label1.UseMarkup = true;
            this.alignment1.Add(this.label1);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.vbox2.Add(this.hseparator1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox2[this.hseparator1]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            this.alignment3.BottomPadding = ((uint)(5));
            // Container child alignment3.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.WidthRequest = 410;
            this.label2.Name = "label2";
            this.label2.LabelProp = "<span size=\"small\" font_family=\"Arial\">In order to update this program you need to enter the administrator password.</span>";
            this.label2.UseMarkup = true;
            this.label2.Wrap = true;
            this.alignment3.Add(this.label2);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w6.Position = 2;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            this.alignment4.LeftPadding = ((uint)(22));
            this.alignment4.RightPadding = ((uint)(50));
            // Container child alignment4.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.lblp = new Gtk.Label();
            this.lblp.Name = "lblp";
            this.lblp.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"small\" font_family=\"Arial\"><b>Password: </b></span>");
            this.lblp.UseMarkup = true;
            this.hbox1.Add(this.lblp);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox1[this.lblp]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.txtAdminPass = new Gtk.Entry();
            this.txtAdminPass.CanFocus = true;
            this.txtAdminPass.Name = "txtAdminPass";
            this.txtAdminPass.IsEditable = true;
            this.txtAdminPass.ActivatesDefault = true;
            this.txtAdminPass.InvisibleChar = '●';
            this.hbox1.Add(this.txtAdminPass);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.hbox1[this.txtAdminPass]));
            w8.Position = 1;
            this.alignment4.Add(this.hbox1);
            this.vbox2.Add(this.alignment4);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment4]));
            w10.Position = 3;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.01F, 0.5F, 0.2F, 1F);
            this.alignment2.Name = "alignment2";
            this.alignment2.LeftPadding = ((uint)(20));
            this.alignment2.TopPadding = ((uint)(8));
            this.alignment2.BottomPadding = ((uint)(8));
            // Container child alignment2.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.WidthRequest = 375;
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"small\" font_family=\"Arial\"><b>Please Note:</b> the administrator password will not be saved by this program and is not used for any other purpose than to install this update.</span>");
            this.label3.UseMarkup = true;
            this.label3.Wrap = true;
            this.alignment2.Add(this.label3);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w12.Position = 4;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.vbox2.Add(this.hseparator2);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox2[this.hseparator2]));
            w13.Position = 5;
            w13.Expand = false;
            w13.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w14.Position = 0;
            // Internal child GUPdotNET.frmSuPass.ActionArea
            Gtk.HButtonBox w15 = this.ActionArea;
            w15.Name = "dialog1_ActionArea";
            w15.Spacing = 6;
            w15.BorderWidth = ((uint)(5));
            w15.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w16 = ((Gtk.ButtonBox.ButtonBoxChild)(w15[this.buttonCancel]));
            w16.Expand = false;
            w16.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w17 = ((Gtk.ButtonBox.ButtonBoxChild)(w15[this.buttonOk]));
            w17.Position = 1;
            w17.Expand = false;
            w17.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 456;
            this.DefaultHeight = 250;
            this.Show();
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
