//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonoBPMonitor {
    
    
    public partial class frmBPEntry {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment10;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment8;
        
        private Gtk.Image image1;
        
        private Gtk.Alignment alignment9;
        
        private Gtk.Label label5;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.Table table1;
        
        private Gtk.Alignment alignment11;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment12;
        
        private Gtk.Label label7;
        
        private Gtk.Alignment alignment16;
        
        private Gtk.Label label6;
        
        private Gtk.Alignment alignment17;
        
        private Gtk.SpinButton spnSystolic;
        
        private Gtk.Alignment alignment18;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Entry txtReadingDate;
        
        private Gtk.Button btnDate;
        
        private Gtk.Image image2;
        
        private Gtk.Alignment alignment3;
        
        private MonoBPMonitor.Users.UserComboBox cboUser;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Label label3;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.SpinButton spnDiastolic;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.Label label4;
        
        private Gtk.Alignment alignment7;
        
        private Gtk.SpinButton spnHeartRate;
        
        private Gtk.Alignment alignment13;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment14;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TextView txtNotes;
        
        private Gtk.Alignment alignment15;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Button btnCancel;
        
        private Gtk.Button btnOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmBPEntry
            this.WidthRequest = 500;
            this.Name = "MonoBPMonitor.frmBPEntry";
            this.Icon = Gdk.Pixbuf.LoadFromResource("icon_small.png");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.DefaultWidth = 500;
            // Internal child MonoBPMonitor.frmBPEntry.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment10 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment10.Name = "alignment10";
            // Container child alignment10.Gtk.Container+ContainerChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.LeftPadding = ((uint)(46));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 18;
            this.hbox1.BorderWidth = ((uint)(4));
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment8 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.image1 = new Gtk.Image();
            this.image1.Name = "image1";
            this.image1.Pixbuf = Gdk.Pixbuf.LoadFromResource("icon.png");
            this.alignment8.Add(this.image1);
            this.hbox1.Add(this.alignment8);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment8]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment9 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment9.Name = "alignment9";
            // Container child alignment9.Gtk.Container+ContainerChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("<big><b>Blood Pressure Entry</b></big>");
            this.label5.UseMarkup = true;
            this.alignment9.Add(this.label5);
            this.hbox1.Add(this.alignment9);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment9]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            this.alignment1.Add(this.hbox1);
            this.alignment10.Add(this.alignment1);
            this.vbox2.Add(this.alignment10);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment10]));
            w8.Position = 0;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            this.alignment2.BorderWidth = ((uint)(5));
            // Container child alignment2.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(5)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.alignment11 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment11.Name = "alignment11";
            // Container child alignment11.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("User:");
            this.alignment11.Add(this.label2);
            this.table1.Add(this.alignment11);
            Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.alignment11]));
            w10.XOptions = ((Gtk.AttachOptions)(4));
            w10.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment12 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment12.Name = "alignment12";
            // Container child alignment12.Gtk.Container+ContainerChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("Diastolic:");
            this.alignment12.Add(this.label7);
            this.table1.Add(this.alignment12);
            Gtk.Table.TableChild w12 = ((Gtk.Table.TableChild)(this.table1[this.alignment12]));
            w12.TopAttach = ((uint)(3));
            w12.BottomAttach = ((uint)(4));
            w12.XOptions = ((Gtk.AttachOptions)(4));
            w12.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment16 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment16.Name = "alignment16";
            // Container child alignment16.Gtk.Container+ContainerChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Systolic:");
            this.alignment16.Add(this.label6);
            this.table1.Add(this.alignment16);
            Gtk.Table.TableChild w14 = ((Gtk.Table.TableChild)(this.table1[this.alignment16]));
            w14.TopAttach = ((uint)(2));
            w14.BottomAttach = ((uint)(3));
            w14.XOptions = ((Gtk.AttachOptions)(4));
            w14.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment17 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment17.Name = "alignment17";
            // Container child alignment17.Gtk.Container+ContainerChild
            this.spnSystolic = new Gtk.SpinButton(60, 220, 1);
            this.spnSystolic.CanFocus = true;
            this.spnSystolic.Name = "spnSystolic";
            this.spnSystolic.Adjustment.PageIncrement = 10;
            this.spnSystolic.ClimbRate = 1;
            this.spnSystolic.Numeric = true;
            this.spnSystolic.Value = 100;
            this.alignment17.Add(this.spnSystolic);
            this.table1.Add(this.alignment17);
            Gtk.Table.TableChild w16 = ((Gtk.Table.TableChild)(this.table1[this.alignment17]));
            w16.TopAttach = ((uint)(2));
            w16.BottomAttach = ((uint)(3));
            w16.LeftAttach = ((uint)(1));
            w16.RightAttach = ((uint)(2));
            w16.XOptions = ((Gtk.AttachOptions)(4));
            w16.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment18 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment18.Name = "alignment18";
            // Container child alignment18.Gtk.Container+ContainerChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.txtReadingDate = new Gtk.Entry();
            this.txtReadingDate.CanFocus = true;
            this.txtReadingDate.Name = "txtReadingDate";
            this.txtReadingDate.IsEditable = false;
            this.txtReadingDate.InvisibleChar = '●';
            this.hbox2.Add(this.txtReadingDate);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.hbox2[this.txtReadingDate]));
            w17.Position = 0;
            // Container child hbox2.Gtk.Box+BoxChild
            this.btnDate = new Gtk.Button();
            this.btnDate.CanFocus = true;
            this.btnDate.Name = "btnDate";
            // Container child btnDate.Gtk.Container+ContainerChild
            this.image2 = new Gtk.Image();
            this.image2.Name = "image2";
            this.image2.Pixbuf = Gdk.Pixbuf.LoadFromResource("date.png");
            this.btnDate.Add(this.image2);
            this.btnDate.Label = null;
            this.hbox2.Add(this.btnDate);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.hbox2[this.btnDate]));
            w19.Position = 1;
            w19.Expand = false;
            w19.Fill = false;
            this.alignment18.Add(this.hbox2);
            this.table1.Add(this.alignment18);
            Gtk.Table.TableChild w21 = ((Gtk.Table.TableChild)(this.table1[this.alignment18]));
            w21.TopAttach = ((uint)(1));
            w21.BottomAttach = ((uint)(2));
            w21.LeftAttach = ((uint)(1));
            w21.RightAttach = ((uint)(2));
            w21.XOptions = ((Gtk.AttachOptions)(4));
            w21.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.cboUser = new MonoBPMonitor.Users.UserComboBox();
            this.cboUser.Name = "cboUser";
            this.alignment3.Add(this.cboUser);
            this.table1.Add(this.alignment3);
            Gtk.Table.TableChild w23 = ((Gtk.Table.TableChild)(this.table1[this.alignment3]));
            w23.LeftAttach = ((uint)(1));
            w23.RightAttach = ((uint)(2));
            w23.XOptions = ((Gtk.AttachOptions)(4));
            w23.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment4 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Reading Date:");
            this.alignment4.Add(this.label3);
            this.table1.Add(this.alignment4);
            Gtk.Table.TableChild w25 = ((Gtk.Table.TableChild)(this.table1[this.alignment4]));
            w25.TopAttach = ((uint)(1));
            w25.BottomAttach = ((uint)(2));
            w25.XOptions = ((Gtk.AttachOptions)(4));
            w25.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.spnDiastolic = new Gtk.SpinButton(40, 150, 1);
            this.spnDiastolic.CanFocus = true;
            this.spnDiastolic.Name = "spnDiastolic";
            this.spnDiastolic.Adjustment.PageIncrement = 10;
            this.spnDiastolic.ClimbRate = 1;
            this.spnDiastolic.Numeric = true;
            this.spnDiastolic.Value = 80;
            this.alignment5.Add(this.spnDiastolic);
            this.table1.Add(this.alignment5);
            Gtk.Table.TableChild w27 = ((Gtk.Table.TableChild)(this.table1[this.alignment5]));
            w27.TopAttach = ((uint)(3));
            w27.BottomAttach = ((uint)(4));
            w27.LeftAttach = ((uint)(1));
            w27.RightAttach = ((uint)(2));
            w27.XOptions = ((Gtk.AttachOptions)(4));
            w27.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment6 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Heart Rate:");
            this.alignment6.Add(this.label4);
            this.table1.Add(this.alignment6);
            Gtk.Table.TableChild w29 = ((Gtk.Table.TableChild)(this.table1[this.alignment6]));
            w29.TopAttach = ((uint)(4));
            w29.BottomAttach = ((uint)(5));
            w29.XOptions = ((Gtk.AttachOptions)(4));
            w29.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment7 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.spnHeartRate = new Gtk.SpinButton(40, 120, 1);
            this.spnHeartRate.CanFocus = true;
            this.spnHeartRate.Name = "spnHeartRate";
            this.spnHeartRate.Adjustment.PageIncrement = 10;
            this.spnHeartRate.ClimbRate = 1;
            this.spnHeartRate.Numeric = true;
            this.spnHeartRate.Value = 55;
            this.alignment7.Add(this.spnHeartRate);
            this.table1.Add(this.alignment7);
            Gtk.Table.TableChild w31 = ((Gtk.Table.TableChild)(this.table1[this.alignment7]));
            w31.TopAttach = ((uint)(4));
            w31.BottomAttach = ((uint)(5));
            w31.LeftAttach = ((uint)(1));
            w31.RightAttach = ((uint)(2));
            w31.XOptions = ((Gtk.AttachOptions)(4));
            w31.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment2.Add(this.table1);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w33 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w33.Position = 1;
            w33.Expand = false;
            w33.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment13 = new Gtk.Alignment(0.02F, 0.5F, 0.01F, 0.01F);
            this.alignment13.Name = "alignment13";
            // Container child alignment13.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Notes:");
            this.alignment13.Add(this.label1);
            this.vbox2.Add(this.alignment13);
            Gtk.Box.BoxChild w35 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment13]));
            w35.Position = 2;
            w35.Expand = false;
            w35.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment14 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment14.Name = "alignment14";
            this.alignment14.LeftPadding = ((uint)(5));
            this.alignment14.RightPadding = ((uint)(5));
            this.alignment14.BorderWidth = ((uint)(2));
            // Container child alignment14.Gtk.Container+ContainerChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.txtNotes = new Gtk.TextView();
            this.txtNotes.HeightRequest = 200;
            this.txtNotes.CanFocus = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.WrapMode = ((Gtk.WrapMode)(2));
            this.txtNotes.PixelsAboveLines = 3;
            this.txtNotes.PixelsBelowLines = 3;
            this.txtNotes.PixelsInsideWrap = 5;
            this.txtNotes.LeftMargin = 3;
            this.txtNotes.RightMargin = 3;
            this.txtNotes.Indent = 4;
            this.GtkScrolledWindow.Add(this.txtNotes);
            this.alignment14.Add(this.GtkScrolledWindow);
            this.vbox2.Add(this.alignment14);
            Gtk.Box.BoxChild w38 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment14]));
            w38.Position = 3;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment15 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment15.Name = "alignment15";
            // Container child alignment15.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment15.Add(this.hseparator2);
            this.vbox2.Add(this.alignment15);
            Gtk.Box.BoxChild w40 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment15]));
            w40.Position = 4;
            w40.Expand = false;
            w40.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w41 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w41.Position = 0;
            // Internal child MonoBPMonitor.frmBPEntry.ActionArea
            Gtk.HButtonBox w42 = this.ActionArea;
            w42.Name = "dialog1_ActionArea";
            w42.Spacing = 6;
            w42.BorderWidth = ((uint)(5));
            w42.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnCancel = new Gtk.Button();
            this.btnCancel.CanDefault = true;
            this.btnCancel.CanFocus = true;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseStock = true;
            this.btnCancel.UseUnderline = true;
            this.btnCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.btnCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w43 = ((Gtk.ButtonBox.ButtonBoxChild)(w42[this.btnCancel]));
            w43.Expand = false;
            w43.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnOk = new Gtk.Button();
            this.btnOk.CanFocus = true;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseStock = true;
            this.btnOk.UseUnderline = true;
            this.btnOk.Label = "gtk-ok";
            this.AddActionWidget(this.btnOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w44 = ((Gtk.ButtonBox.ButtonBoxChild)(w42[this.btnOk]));
            w44.Position = 1;
            w44.Expand = false;
            w44.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultHeight = 596;
            this.Show();
            this.btnDate.Clicked += new System.EventHandler(this.OnBtnDateClicked);
            this.btnCancel.Clicked += new System.EventHandler(this.OnBtnCancelClicked);
            this.btnOk.Clicked += new System.EventHandler(this.OnBtnOkClicked);
        }
    }
}
