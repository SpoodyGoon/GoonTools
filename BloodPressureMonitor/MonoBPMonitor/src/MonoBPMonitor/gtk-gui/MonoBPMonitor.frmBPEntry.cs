// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

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
        
        private Gtk.Alignment alignment19;
        
        private Gtk.Label label8;
        
        private Gtk.Alignment alignment20;
        
        private MonoBPMonitor.Users.UserComboBox cboUser;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Alignment alignment21;
        
        private Gtk.ComboBox cboHours;
        
        private Gtk.Alignment alignment22;
        
        private Gtk.Label label9;
        
        private Gtk.Alignment alignment25;
        
        private Gtk.ComboBox cboMinutes;
        
        private Gtk.Alignment alignment24;
        
        private Gtk.RadioButton rbnAM;
        
        private Gtk.Alignment alignment23;
        
        private Gtk.RadioButton rbnPM;
        
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
            this.HasSeparator = false;
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
            this.table1 = new Gtk.Table(((uint)(6)), ((uint)(2)), false);
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
            w12.TopAttach = ((uint)(4));
            w12.BottomAttach = ((uint)(5));
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
            w14.TopAttach = ((uint)(3));
            w14.BottomAttach = ((uint)(4));
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
            w16.TopAttach = ((uint)(3));
            w16.BottomAttach = ((uint)(4));
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
            this.txtReadingDate.WidthRequest = 125;
            this.txtReadingDate.CanFocus = true;
            this.txtReadingDate.Name = "txtReadingDate";
            this.txtReadingDate.IsEditable = true;
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
            this.alignment19 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment19.Name = "alignment19";
            // Container child alignment19.Gtk.Container+ContainerChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Reading Date:");
            this.alignment19.Add(this.label8);
            this.table1.Add(this.alignment19);
            Gtk.Table.TableChild w23 = ((Gtk.Table.TableChild)(this.table1[this.alignment19]));
            w23.TopAttach = ((uint)(1));
            w23.BottomAttach = ((uint)(2));
            w23.XOptions = ((Gtk.AttachOptions)(4));
            w23.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment20 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment20.Name = "alignment20";
            // Container child alignment20.Gtk.Container+ContainerChild
            this.cboUser = new MonoBPMonitor.Users.UserComboBox();
            this.cboUser.Name = "cboUser";
            this.alignment20.Add(this.cboUser);
            this.table1.Add(this.alignment20);
            Gtk.Table.TableChild w25 = ((Gtk.Table.TableChild)(this.table1[this.alignment20]));
            w25.LeftAttach = ((uint)(1));
            w25.RightAttach = ((uint)(2));
            w25.XOptions = ((Gtk.AttachOptions)(4));
            w25.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment21 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment21.Name = "alignment21";
            // Container child alignment21.Gtk.Container+ContainerChild
            this.cboHours = Gtk.ComboBox.NewText();
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("1"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("2"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("3"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("4"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("5"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("6"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("7"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("8"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("9"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("10"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("11"));
            this.cboHours.AppendText(Mono.Unix.Catalog.GetString("12"));
            this.cboHours.Name = "cboHours";
            this.cboHours.Active = 0;
            this.alignment21.Add(this.cboHours);
            this.hbox3.Add(this.alignment21);
            Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment21]));
            w27.Position = 0;
            w27.Expand = false;
            w27.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment22 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment22.Name = "alignment22";
            this.alignment22.LeftPadding = ((uint)(1));
            this.alignment22.RightPadding = ((uint)(1));
            // Container child alignment22.Gtk.Container+ContainerChild
            this.label9 = new Gtk.Label();
            this.label9.Name = "label9";
            this.label9.LabelProp = Mono.Unix.Catalog.GetString("<b>:</b>");
            this.label9.UseMarkup = true;
            this.alignment22.Add(this.label9);
            this.hbox3.Add(this.alignment22);
            Gtk.Box.BoxChild w29 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment22]));
            w29.Position = 1;
            w29.Expand = false;
            w29.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment25 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment25.Name = "alignment25";
            // Container child alignment25.Gtk.Container+ContainerChild
            this.cboMinutes = Gtk.ComboBox.NewText();
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("00"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("05"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("10"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("15"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("20"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("25"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("30"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("35"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("40"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("45"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("50"));
            this.cboMinutes.AppendText(Mono.Unix.Catalog.GetString("55"));
            this.cboMinutes.Name = "cboMinutes";
            this.cboMinutes.Active = 0;
            this.alignment25.Add(this.cboMinutes);
            this.hbox3.Add(this.alignment25);
            Gtk.Box.BoxChild w31 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment25]));
            w31.Position = 2;
            w31.Expand = false;
            w31.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment24 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment24.Name = "alignment24";
            // Container child alignment24.Gtk.Container+ContainerChild
            this.rbnAM = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("a.m."));
            this.rbnAM.CanFocus = true;
            this.rbnAM.Name = "rbnAM";
            this.rbnAM.Active = true;
            this.rbnAM.DrawIndicator = true;
            this.rbnAM.UseUnderline = true;
            this.rbnAM.Group = new GLib.SList(System.IntPtr.Zero);
            this.alignment24.Add(this.rbnAM);
            this.hbox3.Add(this.alignment24);
            Gtk.Box.BoxChild w33 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment24]));
            w33.Position = 3;
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment23 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment23.Name = "alignment23";
            // Container child alignment23.Gtk.Container+ContainerChild
            this.rbnPM = new Gtk.RadioButton(Mono.Unix.Catalog.GetString("p.m."));
            this.rbnPM.CanFocus = true;
            this.rbnPM.Name = "rbnPM";
            this.rbnPM.DrawIndicator = true;
            this.rbnPM.UseUnderline = true;
            this.rbnPM.Group = this.rbnAM.Group;
            this.alignment23.Add(this.rbnPM);
            this.hbox3.Add(this.alignment23);
            Gtk.Box.BoxChild w35 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment23]));
            w35.Position = 4;
            this.alignment3.Add(this.hbox3);
            this.table1.Add(this.alignment3);
            Gtk.Table.TableChild w37 = ((Gtk.Table.TableChild)(this.table1[this.alignment3]));
            w37.TopAttach = ((uint)(2));
            w37.BottomAttach = ((uint)(3));
            w37.LeftAttach = ((uint)(1));
            w37.RightAttach = ((uint)(2));
            w37.XOptions = ((Gtk.AttachOptions)(4));
            w37.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment4 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Reading Time:");
            this.alignment4.Add(this.label3);
            this.table1.Add(this.alignment4);
            Gtk.Table.TableChild w39 = ((Gtk.Table.TableChild)(this.table1[this.alignment4]));
            w39.TopAttach = ((uint)(2));
            w39.BottomAttach = ((uint)(3));
            w39.XOptions = ((Gtk.AttachOptions)(4));
            w39.YOptions = ((Gtk.AttachOptions)(4));
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
            Gtk.Table.TableChild w41 = ((Gtk.Table.TableChild)(this.table1[this.alignment5]));
            w41.TopAttach = ((uint)(4));
            w41.BottomAttach = ((uint)(5));
            w41.LeftAttach = ((uint)(1));
            w41.RightAttach = ((uint)(2));
            w41.XOptions = ((Gtk.AttachOptions)(4));
            w41.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment6 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 0.01F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Heart Rate:");
            this.alignment6.Add(this.label4);
            this.table1.Add(this.alignment6);
            Gtk.Table.TableChild w43 = ((Gtk.Table.TableChild)(this.table1[this.alignment6]));
            w43.TopAttach = ((uint)(5));
            w43.BottomAttach = ((uint)(6));
            w43.XOptions = ((Gtk.AttachOptions)(4));
            w43.YOptions = ((Gtk.AttachOptions)(4));
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
            Gtk.Table.TableChild w45 = ((Gtk.Table.TableChild)(this.table1[this.alignment7]));
            w45.TopAttach = ((uint)(5));
            w45.BottomAttach = ((uint)(6));
            w45.LeftAttach = ((uint)(1));
            w45.RightAttach = ((uint)(2));
            w45.XOptions = ((Gtk.AttachOptions)(4));
            w45.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment2.Add(this.table1);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w47 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w47.Position = 1;
            w47.Expand = false;
            w47.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment13 = new Gtk.Alignment(0.02F, 0.5F, 0.01F, 0.01F);
            this.alignment13.Name = "alignment13";
            // Container child alignment13.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Notes:");
            this.alignment13.Add(this.label1);
            this.vbox2.Add(this.alignment13);
            Gtk.Box.BoxChild w49 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment13]));
            w49.Position = 2;
            w49.Expand = false;
            w49.Fill = false;
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
            Gtk.Box.BoxChild w52 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment14]));
            w52.Position = 3;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment15 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment15.Name = "alignment15";
            // Container child alignment15.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment15.Add(this.hseparator2);
            this.vbox2.Add(this.alignment15);
            Gtk.Box.BoxChild w54 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment15]));
            w54.Position = 4;
            w54.Expand = false;
            w54.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w55 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w55.Position = 0;
            // Internal child MonoBPMonitor.frmBPEntry.ActionArea
            Gtk.HButtonBox w56 = this.ActionArea;
            w56.Name = "dialog1_ActionArea";
            w56.Spacing = 6;
            w56.BorderWidth = ((uint)(5));
            w56.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnCancel = new Gtk.Button();
            this.btnCancel.CanDefault = true;
            this.btnCancel.CanFocus = true;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseStock = true;
            this.btnCancel.UseUnderline = true;
            this.btnCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.btnCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w57 = ((Gtk.ButtonBox.ButtonBoxChild)(w56[this.btnCancel]));
            w57.Expand = false;
            w57.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnOk = new Gtk.Button();
            this.btnOk.CanFocus = true;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseStock = true;
            this.btnOk.UseUnderline = true;
            this.btnOk.Label = "gtk-ok";
            this.AddActionWidget(this.btnOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w58 = ((Gtk.ButtonBox.ButtonBoxChild)(w56[this.btnOk]));
            w58.Position = 1;
            w58.Expand = false;
            w58.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultHeight = 616;
            this.Show();
            this.btnDate.Clicked += new System.EventHandler(this.OnBtnDateClicked);
            this.btnCancel.Clicked += new System.EventHandler(this.OnBtnCancelClicked);
            this.btnOk.Clicked += new System.EventHandler(this.OnBtnOkClicked);
        }
    }
}
