// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace GUPdotNET {
    
    
    public partial class frmUpdateDownload {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label lblProgramTitle;
        
        private Gtk.Label lblUpdateMessage;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.ProgressBar progressbar1;
        
        private Gtk.Button buttonCancel;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmUpdateDownload
            this.Name = "GUPdotNET.frmUpdateDownload";
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.AllowShrink = true;
            // Internal child GUPdotNET.frmUpdateDownload.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.lblProgramTitle = new Gtk.Label();
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.LabelProp = Mono.Unix.Catalog.GetString("null");
            this.lblProgramTitle.UseMarkup = true;
            this.vbox2.Add(this.lblProgramTitle);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.lblProgramTitle]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.lblUpdateMessage = new Gtk.Label();
            this.lblUpdateMessage.Name = "lblUpdateMessage";
            this.lblUpdateMessage.LabelProp = Mono.Unix.Catalog.GetString("null");
            this.lblUpdateMessage.Justify = ((Gtk.Justification)(2));
            this.vbox2.Add(this.lblUpdateMessage);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.lblUpdateMessage]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            w3.Padding = ((uint)(5));
            // Container child vbox2.Gtk.Box+BoxChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.vbox2.Add(this.hseparator1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox2[this.hseparator1]));
            w4.Position = 2;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.progressbar1 = new Gtk.ProgressBar();
            this.progressbar1.WidthRequest = 98;
            this.progressbar1.Name = "progressbar1";
            this.progressbar1.Ellipsize = ((Pango.EllipsizeMode)(1));
            this.vbox2.Add(this.progressbar1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox2[this.progressbar1]));
            w5.Position = 3;
            w5.Expand = false;
            w5.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Internal child GUPdotNET.frmUpdateDownload.ActionArea
            Gtk.HButtonBox w7 = this.ActionArea;
            w7.Name = "dialog1_ActionArea";
            w7.Spacing = 6;
            w7.BorderWidth = ((uint)(5));
            w7.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w8 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.buttonCancel]));
            w8.Expand = false;
            w8.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 373;
            this.DefaultHeight = 177;
            this.Show();
        }
    }
}
