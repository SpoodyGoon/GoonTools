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
    
    
    public partial class frmUpdateCheck {
        
        private Gtk.Alignment alignment1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Alignment alignment9;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment10;
        
        private Gtk.Button btnAbout;
        
        private Gtk.Label label4;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.CheckButton cbxAutoUpdate;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.SpinButton spnUpdateTimeAmount;
        
        private Gtk.Alignment alignment7;
        
        private Gtk.Label label3;
        
        private Gtk.Alignment alignment8;
        
        private Gtk.ComboBox cboUpdateTimeType;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmUpdateCheck
            this.Name = "GUPdotNET.frmUpdateCheck";
            this.Title = Mono.Unix.Catalog.GetString("GUPdotNET Update Options");
            this.Icon = Gdk.Pixbuf.LoadFromResource("update_medium.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.HasSeparator = false;
            // Internal child GUPdotNET.frmUpdateCheck.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.BottomPadding = ((uint)(6));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.01F, 1F, 0.01F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.alignment9 = new Gtk.Alignment(0.8F, 0.5F, 0.01F, 1F);
            this.alignment9.Name = "alignment9";
            this.alignment9.TopPadding = ((uint)(8));
            // Container child alignment9.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"x-large\"><b>Update Options</b></span>");
            this.label1.UseMarkup = true;
            this.alignment9.Add(this.label1);
            this.hbox2.Add(this.alignment9);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox2[this.alignment9]));
            w3.Position = 0;
            // Container child hbox2.Gtk.Box+BoxChild
            this.alignment10 = new Gtk.Alignment(0.99F, 0.01F, 0.01F, 0.01F);
            this.alignment10.Name = "alignment10";
            // Container child alignment10.Gtk.Container+ContainerChild
            this.btnAbout = new Gtk.Button();
            this.btnAbout.CanFocus = true;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Relief = ((Gtk.ReliefStyle)(2));
            this.btnAbout.Xalign = 1F;
            this.btnAbout.Yalign = 0.01F;
            // Container child btnAbout.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.Xalign = 1F;
            this.label4.Yalign = 0.01F;
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"x-small\" color=\"blue\"><u>About GUPdotNET</u></span>");
            this.label4.UseMarkup = true;
            this.btnAbout.Add(this.label4);
            this.btnAbout.Label = null;
            this.alignment10.Add(this.btnAbout);
            this.hbox2.Add(this.alignment10);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox2[this.alignment10]));
            w6.Position = 1;
            w6.Expand = false;
            w6.Fill = false;
            this.alignment2.Add(this.hbox2);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w8.Position = 0;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment3.Add(this.hseparator1);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 0.5F, 1F);
            this.alignment4.Name = "alignment4";
            this.alignment4.LeftPadding = ((uint)(25));
            this.alignment4.RightPadding = ((uint)(25));
            // Container child alignment4.Gtk.Container+ContainerChild
            this.cbxAutoUpdate = new Gtk.CheckButton();
            this.cbxAutoUpdate.CanFocus = true;
            this.cbxAutoUpdate.Name = "cbxAutoUpdate";
            this.cbxAutoUpdate.Label = Mono.Unix.Catalog.GetString("Check for updates automatically.");
            this.cbxAutoUpdate.DrawIndicator = true;
            this.cbxAutoUpdate.UseUnderline = true;
            this.alignment4.Add(this.cbxAutoUpdate);
            this.vbox2.Add(this.alignment4);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment4]));
            w12.Position = 2;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.BorderWidth = ((uint)(4));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment2 = new Gtk.Alignment(0.5F, 0.5F, 0.5F, 0.5F);
            this.GtkAlignment2.Name = "GtkAlignment2";
            this.GtkAlignment2.LeftPadding = ((uint)(7));
            this.GtkAlignment2.TopPadding = ((uint)(4));
            this.GtkAlignment2.BottomPadding = ((uint)(4));
            // Container child GtkAlignment2.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Check ");
            this.alignment5.Add(this.label2);
            this.hbox1.Add(this.alignment5);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment5]));
            w14.Position = 0;
            w14.Expand = false;
            w14.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.spnUpdateTimeAmount = new Gtk.SpinButton(0, 100, 1);
            this.spnUpdateTimeAmount.CanFocus = true;
            this.spnUpdateTimeAmount.Name = "spnUpdateTimeAmount";
            this.spnUpdateTimeAmount.Adjustment.PageIncrement = 10;
            this.spnUpdateTimeAmount.ClimbRate = 1;
            this.spnUpdateTimeAmount.Numeric = true;
            this.spnUpdateTimeAmount.Value = 1;
            this.alignment6.Add(this.spnUpdateTimeAmount);
            this.hbox1.Add(this.alignment6);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment6]));
            w16.Position = 1;
            w16.Expand = false;
            w16.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment7 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("time(s) every");
            this.alignment7.Add(this.label3);
            this.hbox1.Add(this.alignment7);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment7]));
            w18.Position = 2;
            w18.Expand = false;
            w18.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment8 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.cboUpdateTimeType = Gtk.ComboBox.NewText();
            this.cboUpdateTimeType.WidthRequest = 125;
            this.cboUpdateTimeType.Name = "cboUpdateTimeType";
            this.alignment8.Add(this.cboUpdateTimeType);
            this.hbox1.Add(this.alignment8);
            Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment8]));
            w20.Position = 3;
            w20.Expand = false;
            w20.Fill = false;
            this.GtkAlignment2.Add(this.hbox1);
            this.frame1.Add(this.GtkAlignment2);
            this.vbox2.Add(this.frame1);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
            w23.Position = 3;
            w23.Expand = false;
            w23.Fill = false;
            this.alignment1.Add(this.vbox2);
            w1.Add(this.alignment1);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(w1[this.alignment1]));
            w25.Position = 0;
            w25.Expand = false;
            w25.Fill = false;
            // Internal child GUPdotNET.frmUpdateCheck.ActionArea
            Gtk.HButtonBox w26 = this.ActionArea;
            w26.Name = "dialog1_ActionArea";
            w26.Spacing = 6;
            w26.BorderWidth = ((uint)(5));
            w26.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w27 = ((Gtk.ButtonBox.ButtonBoxChild)(w26[this.buttonCancel]));
            w27.Expand = false;
            w27.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w28 = ((Gtk.ButtonBox.ButtonBoxChild)(w26[this.buttonOk]));
            w28.Position = 1;
            w28.Expand = false;
            w28.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 183;
            this.Hide();
            this.btnAbout.Clicked += new System.EventHandler(this.OnBtnAboutClicked);
            this.btnAbout.Entered += new System.EventHandler(this.OnBtnAboutEntered);
            this.btnAbout.Pressed += new System.EventHandler(this.OnBtnAboutPressed);
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
