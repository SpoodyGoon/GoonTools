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
    
    
    public partial class frmInstallDialog {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Label lblTitle;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Label lblMessage;
        
        private Gtk.Expander expander1;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment2;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TextView textview1;
        
        private Gtk.Label GtkLabel3;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmInstallDialog
            this.Name = "GUPdotNET.frmInstallDialog";
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.AllowShrink = true;
            this.HasSeparator = false;
            // Internal child GUPdotNET.frmInstallDialog.VBox
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
            this.lblTitle = new Gtk.Label();
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.LabelProp = Mono.Unix.Catalog.GetString("null");
            this.lblTitle.UseMarkup = true;
            this.alignment1.Add(this.lblTitle);
            this.vbox2.Add(this.alignment1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment2.Add(this.hseparator1);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.lblMessage = new Gtk.Label();
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.LabelProp = Mono.Unix.Catalog.GetString("null");
            this.lblMessage.UseMarkup = true;
            this.alignment3.Add(this.lblMessage);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w7.Position = 2;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.expander1 = new Gtk.Expander(null);
            this.expander1.CanFocus = true;
            this.expander1.Name = "expander1";
            // Container child expander1.Gtk.Container+ContainerChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment2 = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment2.Name = "GtkAlignment2";
            this.GtkAlignment2.LeftPadding = ((uint)(12));
            // Container child GtkAlignment2.Gtk.Container+ContainerChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.textview1 = new Gtk.TextView();
            this.textview1.CanFocus = true;
            this.textview1.Name = "textview1";
            this.GtkScrolledWindow.Add(this.textview1);
            this.alignment4.Add(this.GtkScrolledWindow);
            this.GtkAlignment2.Add(this.alignment4);
            this.frame1.Add(this.GtkAlignment2);
            this.expander1.Add(this.frame1);
            this.GtkLabel3 = new Gtk.Label();
            this.GtkLabel3.Name = "GtkLabel3";
            this.GtkLabel3.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"small\"><b>Details</b></span>");
            this.GtkLabel3.UseMarkup = true;
            this.GtkLabel3.UseUnderline = true;
            this.expander1.LabelWidget = this.GtkLabel3;
            this.vbox2.Add(this.expander1);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox2[this.expander1]));
            w13.Position = 3;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment5.Add(this.hseparator2);
            this.vbox2.Add(this.alignment5);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment5]));
            w15.Position = 4;
            w15.Expand = false;
            w15.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w16.Position = 0;
            // Internal child GUPdotNET.frmInstallDialog.ActionArea
            Gtk.HButtonBox w17 = this.ActionArea;
            w17.Name = "dialog1_ActionArea";
            w17.Spacing = 6;
            w17.BorderWidth = ((uint)(5));
            w17.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w18 = ((Gtk.ButtonBox.ButtonBoxChild)(w17[this.buttonOk]));
            w18.Expand = false;
            w18.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 467;
            this.DefaultHeight = 172;
            this.Show();
        }
    }
}
