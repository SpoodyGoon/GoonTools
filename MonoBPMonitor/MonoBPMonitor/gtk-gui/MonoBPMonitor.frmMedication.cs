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
        
        private Gtk.Table table1;
        
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
        
        private Gtk.ComboBox cboUser;
        
        private Gtk.ComboBox cboUser2;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmMedication
            this.Name = "MonoBPMonitor.frmMedication";
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.HasSeparator = false;
            // Internal child MonoBPMonitor.frmMedication.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.9F, 0.5F, 0.5F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(6)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            this.table1.BorderWidth = ((uint)(2));
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
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.alignment10]));
            w3.TopAttach = ((uint)(2));
            w3.BottomAttach = ((uint)(3));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment11 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment11.Name = "alignment11";
            // Container child alignment11.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Medicine:");
            this.alignment11.Add(this.label2);
            this.table1.Add(this.alignment11);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.alignment11]));
            w5.TopAttach = ((uint)(2));
            w5.BottomAttach = ((uint)(3));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment13 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment13.Name = "alignment13";
            // Container child alignment13.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Doctor:");
            this.alignment13.Add(this.label1);
            this.table1.Add(this.alignment13);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.alignment13]));
            w7.TopAttach = ((uint)(1));
            w7.BottomAttach = ((uint)(2));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
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
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.alignment14]));
            w9.TopAttach = ((uint)(3));
            w9.BottomAttach = ((uint)(4));
            w9.LeftAttach = ((uint)(1));
            w9.RightAttach = ((uint)(2));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
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
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.hbox2[this.txtEndDate]));
            w10.Position = 0;
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
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox2[this.btnEndDateClean]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
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
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.hbox2[this.btnEndDate]));
            w14.Position = 2;
            w14.Expand = false;
            w14.Fill = false;
            this.alignment18.Add(this.hbox2);
            this.table1.Add(this.alignment18);
            Gtk.Table.TableChild w16 = ((Gtk.Table.TableChild)(this.table1[this.alignment18]));
            w16.TopAttach = ((uint)(5));
            w16.BottomAttach = ((uint)(6));
            w16.LeftAttach = ((uint)(1));
            w16.RightAttach = ((uint)(2));
            w16.XOptions = ((Gtk.AttachOptions)(4));
            w16.YOptions = ((Gtk.AttachOptions)(4));
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
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.hbox3[this.txtStartDate]));
            w17.Position = 0;
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
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.hbox3[this.btnStartDateClean]));
            w19.Position = 1;
            w19.Expand = false;
            w19.Fill = false;
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
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.hbox3[this.btnStartDate]));
            w21.Position = 2;
            w21.Expand = false;
            w21.Fill = false;
            this.alignment19.Add(this.hbox3);
            this.alignment4.Add(this.alignment19);
            this.table1.Add(this.alignment4);
            Gtk.Table.TableChild w24 = ((Gtk.Table.TableChild)(this.table1[this.alignment4]));
            w24.TopAttach = ((uint)(4));
            w24.BottomAttach = ((uint)(5));
            w24.LeftAttach = ((uint)(1));
            w24.RightAttach = ((uint)(2));
            w24.XOptions = ((Gtk.AttachOptions)(4));
            w24.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment5 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("End Date:");
            this.alignment5.Add(this.label3);
            this.table1.Add(this.alignment5);
            Gtk.Table.TableChild w26 = ((Gtk.Table.TableChild)(this.table1[this.alignment5]));
            w26.TopAttach = ((uint)(5));
            w26.BottomAttach = ((uint)(6));
            w26.XOptions = ((Gtk.AttachOptions)(4));
            w26.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment6 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Dosage:");
            this.alignment6.Add(this.label4);
            this.table1.Add(this.alignment6);
            Gtk.Table.TableChild w28 = ((Gtk.Table.TableChild)(this.table1[this.alignment6]));
            w28.TopAttach = ((uint)(3));
            w28.BottomAttach = ((uint)(4));
            w28.XOptions = ((Gtk.AttachOptions)(4));
            w28.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment7 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Start Date:");
            this.alignment7.Add(this.label6);
            this.table1.Add(this.alignment7);
            Gtk.Table.TableChild w30 = ((Gtk.Table.TableChild)(this.table1[this.alignment7]));
            w30.TopAttach = ((uint)(4));
            w30.BottomAttach = ((uint)(5));
            w30.XOptions = ((Gtk.AttachOptions)(4));
            w30.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment8 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("User:");
            this.alignment8.Add(this.label5);
            this.table1.Add(this.alignment8);
            Gtk.Table.TableChild w32 = ((Gtk.Table.TableChild)(this.table1[this.alignment8]));
            w32.XOptions = ((Gtk.AttachOptions)(4));
            w32.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.cboUser = new Gtk.ComboBox();
            this.cboUser.WidthRequest = 175;
            this.cboUser.Name = "cboUser";
            this.table1.Add(this.cboUser);
            Gtk.Table.TableChild w33 = ((Gtk.Table.TableChild)(this.table1[this.cboUser]));
            w33.TopAttach = ((uint)(1));
            w33.BottomAttach = ((uint)(2));
            w33.LeftAttach = ((uint)(1));
            w33.RightAttach = ((uint)(2));
            w33.XOptions = ((Gtk.AttachOptions)(4));
            w33.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.cboUser2 = new Gtk.ComboBox();
            this.cboUser2.WidthRequest = 175;
            this.cboUser2.Name = "cboUser2";
            this.table1.Add(this.cboUser2);
            Gtk.Table.TableChild w34 = ((Gtk.Table.TableChild)(this.table1[this.cboUser2]));
            w34.LeftAttach = ((uint)(1));
            w34.RightAttach = ((uint)(2));
            w34.XOptions = ((Gtk.AttachOptions)(4));
            w34.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment3.Add(this.table1);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w36 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w36.Position = 1;
            w36.Expand = false;
            w36.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w37 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w37.Position = 0;
            // Internal child MonoBPMonitor.frmMedication.ActionArea
            Gtk.HButtonBox w38 = this.ActionArea;
            w38.Name = "dialog1_ActionArea";
            w38.Spacing = 6;
            w38.BorderWidth = ((uint)(5));
            w38.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w39 = ((Gtk.ButtonBox.ButtonBoxChild)(w38[this.buttonCancel]));
            w39.Expand = false;
            w39.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w40 = ((Gtk.ButtonBox.ButtonBoxChild)(w38[this.buttonOk]));
            w40.Position = 1;
            w40.Expand = false;
            w40.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 458;
            this.DefaultHeight = 496;
            this.Show();
            this.btnStartDateClean.Clicked += new System.EventHandler(this.OnBtnStartDateCleanClicked);
            this.btnStartDate.Clicked += new System.EventHandler(this.OnBtnDateClicked);
            this.btnEndDateClean.Clicked += new System.EventHandler(this.OnBtnEndDateCleanClicked);
            this.btnEndDate.Clicked += new System.EventHandler(this.OnBtnDateClicked);
        }
    }
}
