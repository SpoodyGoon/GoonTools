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
    
    
    public partial class QuickUser {
        
        private Gtk.Alignment alignment1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Entry txtUserName;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.QuickUser
            this.Name = "MonoBPMonitor.QuickUser";
            this.Title = Mono.Unix.Catalog.GetString("Add User");
            this.Icon = Gdk.Pixbuf.LoadFromResource("edit_user.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.BorderWidth = ((uint)(4));
            // Internal child MonoBPMonitor.QuickUser.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.BorderWidth = ((uint)(5));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("User Name:");
            this.alignment2.Add(this.label1);
            this.hbox1.Add(this.alignment2);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment2]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            this.alignment3.LeftPadding = ((uint)(8));
            this.alignment3.RightPadding = ((uint)(8));
            // Container child alignment3.Gtk.Container+ContainerChild
            this.txtUserName = new Gtk.Entry();
            this.txtUserName.CanFocus = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.IsEditable = true;
            this.txtUserName.InvisibleChar = '●';
            this.alignment3.Add(this.txtUserName);
            this.hbox1.Add(this.alignment3);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment3]));
            w5.Position = 1;
            this.alignment1.Add(this.hbox1);
            w1.Add(this.alignment1);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(w1[this.alignment1]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment4.Add(this.hseparator1);
            w1.Add(this.alignment4);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(w1[this.alignment4]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            // Internal child MonoBPMonitor.QuickUser.ActionArea
            Gtk.HButtonBox w10 = this.ActionArea;
            w10.Name = "dialog1_ActionArea";
            w10.Spacing = 6;
            w10.BorderWidth = ((uint)(5));
            w10.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w11 = ((Gtk.ButtonBox.ButtonBoxChild)(w10[this.buttonCancel]));
            w11.Expand = false;
            w11.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            w10.Add(this.buttonOk);
            Gtk.ButtonBox.ButtonBoxChild w12 = ((Gtk.ButtonBox.ButtonBoxChild)(w10[this.buttonOk]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 94;
            this.Show();
            this.txtUserName.KeyReleaseEvent += new Gtk.KeyReleaseEventHandler(this.OnTxtUserNameKeyReleaseEvent);
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
