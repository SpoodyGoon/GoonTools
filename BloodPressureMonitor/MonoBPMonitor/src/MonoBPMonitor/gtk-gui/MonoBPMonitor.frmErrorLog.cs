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
    
    
    public partial class frmErrorLog {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HSeparator hseparator3;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TextView txtErrorLog;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.HButtonBox hbuttonbox2;
        
        private Gtk.Button btnClearLog;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.frmErrorLog
            this.WidthRequest = 550;
            this.HeightRequest = 450;
            this.Name = "MonoBPMonitor.frmErrorLog";
            this.Title = Mono.Unix.Catalog.GetString("Error Log Dump");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.BorderWidth = ((uint)(3));
            this.DefaultWidth = 550;
            this.DefaultHeight = 450;
            // Internal child MonoBPMonitor.frmErrorLog.VBox
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
            // Container child alignment1.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"large\"><b>Raw dump of the error log</b></span>");
            this.label2.UseMarkup = true;
            this.alignment1.Add(this.label2);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hseparator3 = new Gtk.HSeparator();
            this.hseparator3.Name = "hseparator3";
            this.alignment2.Add(this.hseparator3);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.txtErrorLog = new Gtk.TextView();
            this.txtErrorLog.CanFocus = true;
            this.txtErrorLog.Name = "txtErrorLog";
            this.txtErrorLog.Editable = false;
            this.txtErrorLog.CursorVisible = false;
            this.txtErrorLog.AcceptsTab = false;
            this.txtErrorLog.PixelsAboveLines = 3;
            this.txtErrorLog.PixelsBelowLines = 3;
            this.txtErrorLog.PixelsInsideWrap = 3;
            this.txtErrorLog.LeftMargin = 3;
            this.txtErrorLog.RightMargin = 3;
            this.txtErrorLog.Indent = 5;
            this.GtkScrolledWindow.Add(this.txtErrorLog);
            this.alignment4.Add(this.GtkScrolledWindow);
            this.vbox2.Add(this.alignment4);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment4]));
            w8.Position = 2;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment3.Add(this.hseparator1);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w10.Position = 3;
            w10.Expand = false;
            w10.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            this.alignment5.LeftPadding = ((uint)(20));
            this.alignment5.TopPadding = ((uint)(2));
            this.alignment5.BottomPadding = ((uint)(2));
            // Container child alignment5.Gtk.Container+ContainerChild
            this.hbuttonbox2 = new Gtk.HButtonBox();
            this.hbuttonbox2.Name = "hbuttonbox2";
            this.hbuttonbox2.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
            // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
            this.btnClearLog = new Gtk.Button();
            this.btnClearLog.CanFocus = true;
            this.btnClearLog.Name = "btnClearLog";
            // Container child btnClearLog.Gtk.Container+ContainerChild
            Gtk.Alignment w11 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w12 = new Gtk.HBox();
            w12.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w13 = new Gtk.Image();
            w13.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-clear", Gtk.IconSize.Menu, 16);
            w12.Add(w13);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w15 = new Gtk.Label();
            w15.LabelProp = Mono.Unix.Catalog.GetString("_Clear Error Log");
            w12.Add(w15);
            w11.Add(w12);
            this.btnClearLog.Add(w11);
            this.hbuttonbox2.Add(this.btnClearLog);
            Gtk.ButtonBox.ButtonBoxChild w19 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnClearLog]));
            w19.Expand = false;
            w19.Fill = false;
            this.alignment5.Add(this.hbuttonbox2);
            this.vbox2.Add(this.alignment5);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment5]));
            w21.Position = 4;
            w21.Expand = false;
            w21.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment6.Add(this.hseparator2);
            this.vbox2.Add(this.alignment6);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment6]));
            w23.Position = 5;
            w23.Expand = false;
            w23.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w24.Position = 0;
            // Internal child MonoBPMonitor.frmErrorLog.ActionArea
            Gtk.HButtonBox w25 = this.ActionArea;
            w25.Name = "dialog1_ActionArea";
            w25.Spacing = 6;
            w25.BorderWidth = ((uint)(5));
            w25.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w26 = ((Gtk.ButtonBox.ButtonBoxChild)(w25[this.buttonOk]));
            w26.Expand = false;
            w26.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.btnClearLog.Clicked += new System.EventHandler(this.OnBtnClearLogClicked);
        }
    }
}
