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
    
    
    public partial class frmOptions {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment GtkAlignment2;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Alignment alignment9;
        
        private Gtk.Label label4;
        
        private Gtk.Alignment alignment13;
        
        private Gtk.CheckButton cbxLogErrors;
        
        private Gtk.Alignment alignment10;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment11;
        
        private Gtk.Label label6;
        
        private Gtk.Alignment alignment12;
        
        private Gtk.SpinButton spnDefaultHistory;
        
        private Gtk.Alignment alignment14;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Button btnClose;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmOptions
            this.Name = "MonoBPMonitor.frmOptions";
            this.Title = Mono.Unix.Catalog.GetString("Options");
            this.Icon = Stetic.IconLoader.LoadIcon(this, "gtk-preferences", Gtk.IconSize.Dialog, 48);
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.BorderWidth = ((uint)(2));
            this.Resizable = false;
            this.AllowGrow = false;
            // Internal child MonoBPMonitor.frmOptions.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.GtkAlignment2 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment2.Name = "GtkAlignment2";
            this.GtkAlignment2.LeftPadding = ((uint)(12));
            // Container child GtkAlignment2.Gtk.Container+ContainerChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.alignment9 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment9.Name = "alignment9";
            this.alignment9.TopPadding = ((uint)(8));
            // Container child alignment9.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("<big><b>Options</b></big>");
            this.label4.UseMarkup = true;
            this.alignment9.Add(this.label4);
            this.vbox3.Add(this.alignment9);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox3[this.alignment9]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.alignment13 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment13.Name = "alignment13";
            this.alignment13.LeftPadding = ((uint)(30));
            // Container child alignment13.Gtk.Container+ContainerChild
            this.cbxLogErrors = new Gtk.CheckButton();
            this.cbxLogErrors.CanFocus = true;
            this.cbxLogErrors.Name = "cbxLogErrors";
            this.cbxLogErrors.Label = Mono.Unix.Catalog.GetString("Save errors locally.");
            this.cbxLogErrors.DrawIndicator = true;
            this.cbxLogErrors.UseUnderline = true;
            this.alignment13.Add(this.cbxLogErrors);
            this.vbox3.Add(this.alignment13);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox3[this.alignment13]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.alignment10 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment10.Name = "alignment10";
            // Container child alignment10.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment11 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment11.Name = "alignment11";
            this.alignment11.LeftPadding = ((uint)(30));
            // Container child alignment11.Gtk.Container+ContainerChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Default history shown at start up.");
            this.alignment11.Add(this.label6);
            this.hbox1.Add(this.alignment11);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment11]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment12 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment12.Name = "alignment12";
            // Container child alignment12.Gtk.Container+ContainerChild
            this.spnDefaultHistory = new Gtk.SpinButton(0, 100, 1);
            this.spnDefaultHistory.CanFocus = true;
            this.spnDefaultHistory.Name = "spnDefaultHistory";
            this.spnDefaultHistory.Adjustment.PageIncrement = 10;
            this.spnDefaultHistory.ClimbRate = 1;
            this.spnDefaultHistory.Numeric = true;
            this.spnDefaultHistory.Value = 30;
            this.alignment12.Add(this.spnDefaultHistory);
            this.hbox1.Add(this.alignment12);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment12]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            this.alignment10.Add(this.hbox1);
            this.vbox3.Add(this.alignment10);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox3[this.alignment10]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            this.GtkAlignment2.Add(this.vbox3);
            this.vbox2.Add(this.GtkAlignment2);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox2[this.GtkAlignment2]));
            w13.Position = 0;
            w13.Expand = false;
            w13.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment14 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment14.Name = "alignment14";
            this.alignment14.TopPadding = ((uint)(8));
            this.alignment14.BottomPadding = ((uint)(3));
            // Container child alignment14.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment14.Add(this.hseparator1);
            this.vbox2.Add(this.alignment14);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment14]));
            w15.Position = 1;
            w15.Expand = false;
            w15.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w16.Position = 0;
            w16.Expand = false;
            w16.Fill = false;
            // Internal child MonoBPMonitor.frmOptions.ActionArea
            Gtk.HButtonBox w17 = this.ActionArea;
            w17.Name = "dialog1_ActionArea";
            w17.Spacing = 6;
            w17.BorderWidth = ((uint)(5));
            w17.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnClose = new Gtk.Button();
            this.btnClose.CanDefault = true;
            this.btnClose.CanFocus = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseStock = true;
            this.btnClose.UseUnderline = true;
            this.btnClose.Label = "gtk-close";
            w17.Add(this.btnClose);
            Gtk.ButtonBox.ButtonBoxChild w18 = ((Gtk.ButtonBox.ButtonBoxChild)(w17[this.btnClose]));
            w18.Expand = false;
            w18.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 149;
            this.label4.Hide();
            this.Show();
            this.Close += new System.EventHandler(this.OnClose);
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.btnClose.Clicked += new System.EventHandler(this.OnBtnCloseClicked);
        }
    }
}
