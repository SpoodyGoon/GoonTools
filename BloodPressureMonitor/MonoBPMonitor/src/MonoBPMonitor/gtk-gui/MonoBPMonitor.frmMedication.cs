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
    
    
    public partial class frmMedication {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Label label7;
        
        private Gtk.Alignment alignment9;
        
        private Gtk.Table table1;
        
        private Gtk.Alignment alignment1;
        
        private MonoBPMonitor.Users.UserComboBox usercombobox2;
        
        private Gtk.Alignment alignment10;
        
        private Gtk.Entry txtMedicine;
        
        private Gtk.Alignment alignment11;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment13;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment14;
        
        private Gtk.Entry txtDosage;
        
        private Gtk.Alignment alignment18;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Entry txtEndDate;
        
        private Gtk.Button btnEndDateClean;
        
        private Gtk.Image image5;
        
        private Gtk.Button btnEndDate;
        
        private Gtk.Image image2;
        
        private Gtk.Alignment alignment2;
        
        private MonoBPMonitor.Doctors.DoctorComboBox cboDoctor;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Alignment alignment19;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Entry txtStartDate;
        
        private Gtk.Button btnStartDateClean;
        
        private Gtk.Image image3;
        
        private Gtk.Button btnStartDate;
        
        private Gtk.Image image4;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.Label label3;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.Label label4;
        
        private Gtk.Alignment alignment7;
        
        private Gtk.Label label6;
        
        private Gtk.Alignment alignment8;
        
        private Gtk.Label label5;
        
        private Gtk.Alignment alignment12;
        
        private Gtk.HButtonBox hbuttonbox2;
        
        private Gtk.Button btnAdd;
        
        private Gtk.Alignment alignment15;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment16;
        
        private Gtk.HButtonBox hbuttonbox3;
        
        private Gtk.Button btnDelete;
        
        private Gtk.Alignment alignment17;
        
        private Gtk.ScrolledWindow swMedication;
        
        private Gtk.Button btnClose;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmMedication
            this.Name = "MonoBPMonitor.frmMedication";
            this.Icon = Gdk.Pixbuf.LoadFromResource("rx.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(2));
            // Internal child MonoBPMonitor.frmMedication.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("<big><b>Manage Medication</b></big>");
            this.label7.UseMarkup = true;
            this.alignment3.Add(this.label7);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment9 = new Gtk.Alignment(0.9F, 0.5F, 0.5F, 1F);
            this.alignment9.Name = "alignment9";
            // Container child alignment9.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(6)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            this.table1.BorderWidth = ((uint)(2));
            // Container child table1.Gtk.Table+TableChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            // Container child alignment1.Gtk.Container+ContainerChild
            this.usercombobox2 = null;
            this.alignment1.Add(this.usercombobox2);
            this.table1.Add(this.alignment1);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.alignment1]));
            w5.LeftAttach = ((uint)(1));
            w5.RightAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment10 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment10.Name = "alignment10";
            // Container child alignment10.Gtk.Container+ContainerChild
            this.txtMedicine = new Gtk.Entry();
            this.txtMedicine.CanFocus = true;
            this.txtMedicine.Name = "txtMedicine";
            this.txtMedicine.IsEditable = true;
            this.txtMedicine.InvisibleChar = '●';
            this.alignment10.Add(this.txtMedicine);
            this.table1.Add(this.alignment10);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.alignment10]));
            w7.TopAttach = ((uint)(2));
            w7.BottomAttach = ((uint)(3));
            w7.LeftAttach = ((uint)(1));
            w7.RightAttach = ((uint)(2));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment11 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment11.Name = "alignment11";
            // Container child alignment11.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Medicine:");
            this.alignment11.Add(this.label2);
            this.table1.Add(this.alignment11);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.alignment11]));
            w9.TopAttach = ((uint)(2));
            w9.BottomAttach = ((uint)(3));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment13 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment13.Name = "alignment13";
            // Container child alignment13.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Doctor:");
            this.alignment13.Add(this.label1);
            this.table1.Add(this.alignment13);
            Gtk.Table.TableChild w11 = ((Gtk.Table.TableChild)(this.table1[this.alignment13]));
            w11.TopAttach = ((uint)(1));
            w11.BottomAttach = ((uint)(2));
            w11.XOptions = ((Gtk.AttachOptions)(4));
            w11.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment14 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment14.Name = "alignment14";
            // Container child alignment14.Gtk.Container+ContainerChild
            this.txtDosage = new Gtk.Entry();
            this.txtDosage.WidthRequest = 258;
            this.txtDosage.CanFocus = true;
            this.txtDosage.Name = "txtDosage";
            this.txtDosage.IsEditable = true;
            this.txtDosage.InvisibleChar = '●';
            this.alignment14.Add(this.txtDosage);
            this.table1.Add(this.alignment14);
            Gtk.Table.TableChild w13 = ((Gtk.Table.TableChild)(this.table1[this.alignment14]));
            w13.TopAttach = ((uint)(3));
            w13.BottomAttach = ((uint)(4));
            w13.LeftAttach = ((uint)(1));
            w13.RightAttach = ((uint)(2));
            w13.XOptions = ((Gtk.AttachOptions)(4));
            w13.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment18 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment18.Name = "alignment18";
            // Container child alignment18.Gtk.Container+ContainerChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.txtEndDate = new Gtk.Entry();
            this.txtEndDate.CanFocus = true;
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.IsEditable = false;
            this.txtEndDate.InvisibleChar = '●';
            this.hbox2.Add(this.txtEndDate);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox2[this.txtEndDate]));
            w14.Position = 0;
            // Container child hbox2.Gtk.Box+BoxChild
            this.btnEndDateClean = new Gtk.Button();
            this.btnEndDateClean.CanFocus = true;
            this.btnEndDateClean.Name = "btnEndDateClean";
            // Container child btnEndDateClean.Gtk.Container+ContainerChild
            this.image5 = new Gtk.Image();
            this.image5.Name = "image5";
            this.image5.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-clear", Gtk.IconSize.Menu, 16);
            this.btnEndDateClean.Add(this.image5);
            this.btnEndDateClean.Label = null;
            this.hbox2.Add(this.btnEndDateClean);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.hbox2[this.btnEndDateClean]));
            w16.Position = 1;
            w16.Expand = false;
            w16.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.btnEndDate = new Gtk.Button();
            this.btnEndDate.CanFocus = true;
            this.btnEndDate.Name = "btnEndDate";
            // Container child btnEndDate.Gtk.Container+ContainerChild
            this.image2 = new Gtk.Image();
            this.image2.Name = "image2";
            this.image2.Pixbuf = Gdk.Pixbuf.LoadFromResource("date.png");
            this.btnEndDate.Add(this.image2);
            this.btnEndDate.Label = null;
            this.hbox2.Add(this.btnEndDate);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.hbox2[this.btnEndDate]));
            w18.Position = 2;
            w18.Expand = false;
            w18.Fill = false;
            this.alignment18.Add(this.hbox2);
            this.table1.Add(this.alignment18);
            Gtk.Table.TableChild w20 = ((Gtk.Table.TableChild)(this.table1[this.alignment18]));
            w20.TopAttach = ((uint)(5));
            w20.BottomAttach = ((uint)(6));
            w20.LeftAttach = ((uint)(1));
            w20.RightAttach = ((uint)(2));
            w20.XOptions = ((Gtk.AttachOptions)(4));
            w20.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.cboDoctor = null;
            this.alignment2.Add(this.cboDoctor);
            this.table1.Add(this.alignment2);
            Gtk.Table.TableChild w22 = ((Gtk.Table.TableChild)(this.table1[this.alignment2]));
            w22.TopAttach = ((uint)(1));
            w22.BottomAttach = ((uint)(2));
            w22.LeftAttach = ((uint)(1));
            w22.RightAttach = ((uint)(2));
            w22.XOptions = ((Gtk.AttachOptions)(4));
            w22.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.alignment19 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment19.Name = "alignment19";
            // Container child alignment19.Gtk.Container+ContainerChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.txtStartDate = new Gtk.Entry();
            this.txtStartDate.CanFocus = true;
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.IsEditable = false;
            this.txtStartDate.InvisibleChar = '●';
            this.hbox3.Add(this.txtStartDate);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.hbox3[this.txtStartDate]));
            w23.Position = 0;
            // Container child hbox3.Gtk.Box+BoxChild
            this.btnStartDateClean = new Gtk.Button();
            this.btnStartDateClean.CanFocus = true;
            this.btnStartDateClean.Name = "btnStartDateClean";
            // Container child btnStartDateClean.Gtk.Container+ContainerChild
            this.image3 = new Gtk.Image();
            this.image3.Name = "image3";
            this.image3.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-clear", Gtk.IconSize.Menu, 16);
            this.btnStartDateClean.Add(this.image3);
            this.btnStartDateClean.Label = null;
            this.hbox3.Add(this.btnStartDateClean);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.hbox3[this.btnStartDateClean]));
            w25.Position = 1;
            w25.Expand = false;
            w25.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.btnStartDate = new Gtk.Button();
            this.btnStartDate.CanFocus = true;
            this.btnStartDate.Name = "btnStartDate";
            // Container child btnStartDate.Gtk.Container+ContainerChild
            this.image4 = new Gtk.Image();
            this.image4.Name = "image4";
            this.image4.Pixbuf = Gdk.Pixbuf.LoadFromResource("date.png");
            this.btnStartDate.Add(this.image4);
            this.btnStartDate.Label = null;
            this.hbox3.Add(this.btnStartDate);
            Gtk.Box.BoxChild w27 = ((Gtk.Box.BoxChild)(this.hbox3[this.btnStartDate]));
            w27.Position = 2;
            w27.Expand = false;
            w27.Fill = false;
            this.alignment19.Add(this.hbox3);
            this.alignment4.Add(this.alignment19);
            this.table1.Add(this.alignment4);
            Gtk.Table.TableChild w30 = ((Gtk.Table.TableChild)(this.table1[this.alignment4]));
            w30.TopAttach = ((uint)(4));
            w30.BottomAttach = ((uint)(5));
            w30.LeftAttach = ((uint)(1));
            w30.RightAttach = ((uint)(2));
            w30.XOptions = ((Gtk.AttachOptions)(4));
            w30.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment5 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("End Date:");
            this.alignment5.Add(this.label3);
            this.table1.Add(this.alignment5);
            Gtk.Table.TableChild w32 = ((Gtk.Table.TableChild)(this.table1[this.alignment5]));
            w32.TopAttach = ((uint)(5));
            w32.BottomAttach = ((uint)(6));
            w32.XOptions = ((Gtk.AttachOptions)(4));
            w32.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment6 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Dosage:");
            this.alignment6.Add(this.label4);
            this.table1.Add(this.alignment6);
            Gtk.Table.TableChild w34 = ((Gtk.Table.TableChild)(this.table1[this.alignment6]));
            w34.TopAttach = ((uint)(3));
            w34.BottomAttach = ((uint)(4));
            w34.XOptions = ((Gtk.AttachOptions)(4));
            w34.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment7 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Start Date:");
            this.alignment7.Add(this.label6);
            this.table1.Add(this.alignment7);
            Gtk.Table.TableChild w36 = ((Gtk.Table.TableChild)(this.table1[this.alignment7]));
            w36.TopAttach = ((uint)(4));
            w36.BottomAttach = ((uint)(5));
            w36.XOptions = ((Gtk.AttachOptions)(4));
            w36.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment8 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("User:");
            this.alignment8.Add(this.label5);
            this.table1.Add(this.alignment8);
            Gtk.Table.TableChild w38 = ((Gtk.Table.TableChild)(this.table1[this.alignment8]));
            w38.XOptions = ((Gtk.AttachOptions)(4));
            w38.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment9.Add(this.table1);
            this.vbox2.Add(this.alignment9);
            Gtk.Box.BoxChild w40 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment9]));
            w40.Position = 1;
            w40.Expand = false;
            w40.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment12 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment12.Name = "alignment12";
            // Container child alignment12.Gtk.Container+ContainerChild
            this.hbuttonbox2 = new Gtk.HButtonBox();
            this.hbuttonbox2.Name = "hbuttonbox2";
            // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
            this.btnAdd = new Gtk.Button();
            this.btnAdd.CanFocus = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseStock = true;
            this.btnAdd.UseUnderline = true;
            this.btnAdd.Label = "gtk-add";
            this.hbuttonbox2.Add(this.btnAdd);
            Gtk.ButtonBox.ButtonBoxChild w41 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnAdd]));
            w41.Expand = false;
            w41.Fill = false;
            this.alignment12.Add(this.hbuttonbox2);
            this.vbox2.Add(this.alignment12);
            Gtk.Box.BoxChild w43 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment12]));
            w43.Position = 2;
            w43.Expand = false;
            w43.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment15 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment15.Name = "alignment15";
            // Container child alignment15.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment15.Add(this.hseparator1);
            this.vbox2.Add(this.alignment15);
            Gtk.Box.BoxChild w45 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment15]));
            w45.Position = 3;
            w45.Expand = false;
            w45.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment16 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment16.Name = "alignment16";
            this.alignment16.LeftPadding = ((uint)(25));
            // Container child alignment16.Gtk.Container+ContainerChild
            this.hbuttonbox3 = new Gtk.HButtonBox();
            this.hbuttonbox3.Name = "hbuttonbox3";
            this.hbuttonbox3.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
            // Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
            this.btnDelete = new Gtk.Button();
            this.btnDelete.CanFocus = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseStock = true;
            this.btnDelete.UseUnderline = true;
            this.btnDelete.Label = "gtk-delete";
            this.hbuttonbox3.Add(this.btnDelete);
            Gtk.ButtonBox.ButtonBoxChild w46 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3[this.btnDelete]));
            w46.Expand = false;
            w46.Fill = false;
            this.alignment16.Add(this.hbuttonbox3);
            this.vbox2.Add(this.alignment16);
            Gtk.Box.BoxChild w48 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment16]));
            w48.Position = 4;
            w48.Expand = false;
            w48.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment17 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment17.Name = "alignment17";
            this.alignment17.BottomPadding = ((uint)(6));
            // Container child alignment17.Gtk.Container+ContainerChild
            this.swMedication = new Gtk.ScrolledWindow();
            this.swMedication.CanFocus = true;
            this.swMedication.Name = "swMedication";
            this.swMedication.ShadowType = ((Gtk.ShadowType)(1));
            this.alignment17.Add(this.swMedication);
            this.vbox2.Add(this.alignment17);
            Gtk.Box.BoxChild w50 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment17]));
            w50.Position = 5;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w51 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w51.Position = 0;
            // Internal child MonoBPMonitor.frmMedication.ActionArea
            Gtk.HButtonBox w52 = this.ActionArea;
            w52.Name = "dialog1_ActionArea";
            w52.Spacing = 6;
            w52.BorderWidth = ((uint)(5));
            w52.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnClose = new Gtk.Button();
            this.btnClose.CanDefault = true;
            this.btnClose.CanFocus = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseStock = true;
            this.btnClose.UseUnderline = true;
            this.btnClose.Label = "gtk-close";
            this.AddActionWidget(this.btnClose, -7);
            Gtk.ButtonBox.ButtonBoxChild w53 = ((Gtk.ButtonBox.ButtonBoxChild)(w52[this.btnClose]));
            w53.Expand = false;
            w53.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 760;
            this.DefaultHeight = 699;
            this.Show();
            this.btnStartDateClean.Clicked += new System.EventHandler(this.OnBtnStartDateCleanClicked);
            this.btnStartDate.Clicked += new System.EventHandler(this.OnBtnDateClicked);
            this.btnEndDateClean.Clicked += new System.EventHandler(this.OnBtnEndDateCleanClicked);
            this.btnEndDate.Clicked += new System.EventHandler(this.OnBtnDateClicked);
            this.btnAdd.Clicked += new System.EventHandler(this.OnBtnAddClicked);
            this.btnDelete.Clicked += new System.EventHandler(this.OnBtnDeleteClicked);
            this.btnClose.Clicked += new System.EventHandler(this.OnBtnCloseClicked);
        }
    }
}
