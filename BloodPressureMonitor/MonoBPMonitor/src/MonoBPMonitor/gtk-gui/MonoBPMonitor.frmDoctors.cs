//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonoBPMonitor {
    
    
    public partial class frmDoctors {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Label label6;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Table table1;
        
        private Gtk.Alignment alignment10;
        
        private MonoBPMonitor.Users.UserComboBox cboUser;
        
        private Gtk.Alignment alignment11;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment13;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment14;
        
        private Gtk.Entry txtDoctor;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Entry txtLocation;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.Label label3;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.Entry txtPhone;
        
        private Gtk.Alignment alignment8;
        
        private Gtk.Label label5;
        
        private Gtk.HButtonBox hbuttonbox2;
        
        private Gtk.Button btnAdd;
        
        private Gtk.Alignment alignment7;
        
        private Gtk.HSeparator hseparator4;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HButtonBox hbuttonbox3;
        
        private Gtk.Button btnDelete;
        
        private Gtk.ScrolledWindow swDoctor;
        
        private Gtk.Button btnClose;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmDoctors
            this.WidthRequest = 650;
            this.HeightRequest = 650;
            this.Name = "MonoBPMonitor.frmDoctors";
            this.Title = Mono.Unix.Catalog.GetString("Doctor Manager");
            this.Icon = Gdk.Pixbuf.LoadFromResource("doctor.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(2));
            this.Modal = true;
            this.BorderWidth = ((uint)(3));
            this.AllowShrink = true;
            this.DefaultWidth = 650;
            this.DefaultHeight = 650;
            this.DestroyWithParent = true;
            // Internal child MonoBPMonitor.frmDoctors.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            this.vbox2.BorderWidth = ((uint)(3));
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            // Container child alignment1.Gtk.Container+ContainerChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("<big><b>Manage Doctors</b></big>");
            this.label6.UseMarkup = true;
            this.alignment1.Add(this.label6);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.9F, 0.5F, 0.5F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(4)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            this.table1.BorderWidth = ((uint)(2));
            // Container child table1.Gtk.Table+TableChild
            this.alignment10 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment10.Name = "alignment10";
            // Container child alignment10.Gtk.Container+ContainerChild
            this.cboUser = new MonoBPMonitor.Users.UserComboBox();
            this.cboUser.WidthRequest = 200;
            this.cboUser.Name = "cboUser";
            this.alignment10.Add(this.cboUser);
            this.table1.Add(this.alignment10);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.alignment10]));
            w5.LeftAttach = ((uint)(1));
            w5.RightAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment11 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment11.Name = "alignment11";
            // Container child alignment11.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Location:");
            this.alignment11.Add(this.label2);
            this.table1.Add(this.alignment11);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.alignment11]));
            w7.TopAttach = ((uint)(2));
            w7.BottomAttach = ((uint)(3));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment13 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment13.Name = "alignment13";
            // Container child alignment13.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Doctor:");
            this.alignment13.Add(this.label1);
            this.table1.Add(this.alignment13);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.alignment13]));
            w9.TopAttach = ((uint)(1));
            w9.BottomAttach = ((uint)(2));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment14 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment14.Name = "alignment14";
            // Container child alignment14.Gtk.Container+ContainerChild
            this.txtDoctor = new Gtk.Entry();
            this.txtDoctor.CanFocus = true;
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.IsEditable = true;
            this.txtDoctor.InvisibleChar = '●';
            this.alignment14.Add(this.txtDoctor);
            this.table1.Add(this.alignment14);
            Gtk.Table.TableChild w11 = ((Gtk.Table.TableChild)(this.table1[this.alignment14]));
            w11.TopAttach = ((uint)(1));
            w11.BottomAttach = ((uint)(2));
            w11.LeftAttach = ((uint)(1));
            w11.RightAttach = ((uint)(2));
            w11.XOptions = ((Gtk.AttachOptions)(4));
            w11.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.txtLocation = new Gtk.Entry();
            this.txtLocation.CanFocus = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.IsEditable = true;
            this.txtLocation.InvisibleChar = '●';
            this.alignment4.Add(this.txtLocation);
            this.table1.Add(this.alignment4);
            Gtk.Table.TableChild w13 = ((Gtk.Table.TableChild)(this.table1[this.alignment4]));
            w13.TopAttach = ((uint)(2));
            w13.BottomAttach = ((uint)(3));
            w13.LeftAttach = ((uint)(1));
            w13.RightAttach = ((uint)(2));
            w13.XOptions = ((Gtk.AttachOptions)(4));
            w13.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment5 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Phone:");
            this.alignment5.Add(this.label3);
            this.table1.Add(this.alignment5);
            Gtk.Table.TableChild w15 = ((Gtk.Table.TableChild)(this.table1[this.alignment5]));
            w15.TopAttach = ((uint)(3));
            w15.BottomAttach = ((uint)(4));
            w15.XOptions = ((Gtk.AttachOptions)(4));
            w15.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.txtPhone = new Gtk.Entry();
            this.txtPhone.CanFocus = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.IsEditable = true;
            this.txtPhone.InvisibleChar = '●';
            this.alignment6.Add(this.txtPhone);
            this.table1.Add(this.alignment6);
            Gtk.Table.TableChild w17 = ((Gtk.Table.TableChild)(this.table1[this.alignment6]));
            w17.TopAttach = ((uint)(3));
            w17.BottomAttach = ((uint)(4));
            w17.LeftAttach = ((uint)(1));
            w17.RightAttach = ((uint)(2));
            w17.XOptions = ((Gtk.AttachOptions)(4));
            w17.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment8 = new Gtk.Alignment(0.99F, 0.5F, 0.01F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("User:");
            this.alignment8.Add(this.label5);
            this.table1.Add(this.alignment8);
            Gtk.Table.TableChild w19 = ((Gtk.Table.TableChild)(this.table1[this.alignment8]));
            w19.XOptions = ((Gtk.AttachOptions)(4));
            w19.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment3.Add(this.table1);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w21.Position = 1;
            w21.Expand = false;
            w21.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hbuttonbox2 = new Gtk.HButtonBox();
            this.hbuttonbox2.Name = "hbuttonbox2";
            this.hbuttonbox2.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
            this.btnAdd = new Gtk.Button();
            this.btnAdd.CanFocus = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseStock = true;
            this.btnAdd.UseUnderline = true;
            this.btnAdd.Label = "gtk-add";
            this.hbuttonbox2.Add(this.btnAdd);
            Gtk.ButtonBox.ButtonBoxChild w22 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnAdd]));
            w22.Expand = false;
            w22.Fill = false;
            this.vbox2.Add(this.hbuttonbox2);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.vbox2[this.hbuttonbox2]));
            w23.Position = 2;
            w23.Expand = false;
            w23.Fill = false;
            w23.Padding = ((uint)(3));
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment7 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.hseparator4 = new Gtk.HSeparator();
            this.hseparator4.Name = "hseparator4";
            this.alignment7.Add(this.hseparator4);
            this.vbox2.Add(this.alignment7);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment7]));
            w25.Position = 3;
            w25.Expand = false;
            w25.Fill = false;
            w25.Padding = ((uint)(1));
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            this.alignment2.LeftPadding = ((uint)(20));
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hbuttonbox3 = new Gtk.HButtonBox();
            this.hbuttonbox3.Name = "hbuttonbox3";
            this.hbuttonbox3.Spacing = 3;
            this.hbuttonbox3.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
            // Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
            this.btnDelete = new Gtk.Button();
            this.btnDelete.CanFocus = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseStock = true;
            this.btnDelete.UseUnderline = true;
            this.btnDelete.Label = "gtk-delete";
            this.hbuttonbox3.Add(this.btnDelete);
            Gtk.ButtonBox.ButtonBoxChild w26 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3[this.btnDelete]));
            w26.Expand = false;
            w26.Fill = false;
            this.alignment2.Add(this.hbuttonbox3);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w28 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w28.Position = 4;
            w28.Expand = false;
            w28.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.swDoctor = new Gtk.ScrolledWindow();
            this.swDoctor.CanFocus = true;
            this.swDoctor.Name = "swDoctor";
            this.swDoctor.ShadowType = ((Gtk.ShadowType)(1));
            this.vbox2.Add(this.swDoctor);
            Gtk.Box.BoxChild w29 = ((Gtk.Box.BoxChild)(this.vbox2[this.swDoctor]));
            w29.Position = 5;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w30 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w30.Position = 0;
            // Internal child MonoBPMonitor.frmDoctors.ActionArea
            Gtk.HButtonBox w31 = this.ActionArea;
            w31.Name = "dialog1_ActionArea";
            w31.Spacing = 6;
            w31.BorderWidth = ((uint)(5));
            w31.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnClose = new Gtk.Button();
            this.btnClose.CanDefault = true;
            this.btnClose.CanFocus = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseStock = true;
            this.btnClose.UseUnderline = true;
            this.btnClose.Label = "gtk-close";
            this.AddActionWidget(this.btnClose, -7);
            Gtk.ButtonBox.ButtonBoxChild w32 = ((Gtk.ButtonBox.ButtonBoxChild)(w31[this.btnClose]));
            w32.Expand = false;
            w32.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.btnAdd.Clicked += new System.EventHandler(this.OnBtnAddClicked);
            this.btnDelete.Clicked += new System.EventHandler(this.OnBtnDeleteClicked);
            this.btnClose.Clicked += new System.EventHandler(this.OnBtnCloseClicked);
        }
    }
}
