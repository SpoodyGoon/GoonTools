//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonoBPMonitor {
    
    
    public partial class QuickDoctor {
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Table table1;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Entry txtDoctorName;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment5;
        
        private MonoBPMonitor.Users.UserComboBox cboUser;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.QuickDoctor
            this.Name = "MonoBPMonitor.QuickDoctor";
            this.Title = Mono.Unix.Catalog.GetString("Add Doctor");
            this.Icon = Gdk.Pixbuf.LoadFromResource("doctor.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.BorderWidth = ((uint)(4));
            // Internal child MonoBPMonitor.QuickDoctor.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.LeftPadding = ((uint)(5));
            this.alignment1.RightPadding = ((uint)(5));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            this.table1.BorderWidth = ((uint)(8));
            // Container child table1.Gtk.Table+TableChild
            this.alignment2 = new Gtk.Alignment(0.98F, 0.5F, 0.01F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Doctor Name:");
            this.alignment2.Add(this.label1);
            this.table1.Add(this.alignment2);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.alignment2]));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.txtDoctorName = new Gtk.Entry();
            this.txtDoctorName.CanFocus = true;
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.IsEditable = true;
            this.txtDoctorName.InvisibleChar = '●';
            this.alignment3.Add(this.txtDoctorName);
            this.table1.Add(this.alignment3);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.alignment3]));
            w5.LeftAttach = ((uint)(1));
            w5.RightAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment4 = new Gtk.Alignment(0.98F, 0.5F, 0.01F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("User Name:");
            this.alignment4.Add(this.label2);
            this.table1.Add(this.alignment4);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.alignment4]));
            w7.TopAttach = ((uint)(1));
            w7.BottomAttach = ((uint)(2));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.cboUser = new MonoBPMonitor.Users.UserComboBox();
            this.cboUser.WidthRequest = 200;
            this.cboUser.Name = "cboUser";
            this.alignment5.Add(this.cboUser);
            this.table1.Add(this.alignment5);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.alignment5]));
            w9.TopAttach = ((uint)(1));
            w9.BottomAttach = ((uint)(2));
            w9.LeftAttach = ((uint)(1));
            w9.RightAttach = ((uint)(2));
            w9.XOptions = ((Gtk.AttachOptions)(4));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment1.Add(this.table1);
            w1.Add(this.alignment1);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(w1[this.alignment1]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment6.Add(this.hseparator1);
            w1.Add(this.alignment6);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(w1[this.alignment6]));
            w13.Position = 1;
            w13.Expand = false;
            w13.Fill = false;
            // Internal child MonoBPMonitor.QuickDoctor.ActionArea
            Gtk.HButtonBox w14 = this.ActionArea;
            w14.Name = "dialog1_ActionArea";
            w14.Spacing = 6;
            w14.BorderWidth = ((uint)(5));
            w14.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w15 = ((Gtk.ButtonBox.ButtonBoxChild)(w14[this.buttonCancel]));
            w15.Expand = false;
            w15.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w16 = ((Gtk.ButtonBox.ButtonBoxChild)(w14[this.buttonOk]));
            w16.Position = 1;
            w16.Expand = false;
            w16.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 364;
            this.DefaultHeight = 142;
            this.Show();
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
