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
    
    
    public partial class frmUpdateConfirm {
        
        private Gtk.VBox vbox2;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Label lblProgramTitle;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Label lblUpdateMessage;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmUpdateConfirm
            this.Name = "GUPdotNET.frmUpdateConfirm";
            this.Title = Mono.Unix.Catalog.GetString("window1");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.AllowShrink = true;
            this.DefaultWidth = 350;
            this.DefaultHeight = 150;
            // Internal child GUPdotNET.frmUpdateConfirm.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 3;
            // Container child vbox2.Gtk.Box+BoxChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.lblProgramTitle = new Gtk.Label();
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.LabelProp = Mono.Unix.Catalog.GetString("Title");
            this.lblProgramTitle.UseMarkup = true;
            this.vbox3.Add(this.lblProgramTitle);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox3[this.lblProgramTitle]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.vbox3.Add(this.hseparator1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox3[this.hseparator1]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.lblUpdateMessage = new Gtk.Label();
            this.lblUpdateMessage.Name = "lblUpdateMessage";
            this.lblUpdateMessage.LabelProp = Mono.Unix.Catalog.GetString("Message");
            this.lblUpdateMessage.UseMarkup = true;
            this.lblUpdateMessage.Wrap = true;
            this.vbox3.Add(this.lblUpdateMessage);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox3[this.lblUpdateMessage]));
            w4.Position = 2;
            this.vbox2.Add(this.vbox3);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox2[this.vbox3]));
            w5.Position = 0;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w6.Position = 0;
            // Internal child GUPdotNET.frmUpdateConfirm.ActionArea
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
            this.buttonCancel.Label = "gtk-no";
            this.AddActionWidget(this.buttonCancel, -9);
            Gtk.ButtonBox.ButtonBoxChild w8 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.buttonCancel]));
            w8.Expand = false;
            w8.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-yes";
            this.AddActionWidget(this.buttonOk, -8);
            Gtk.ButtonBox.ButtonBoxChild w9 = ((Gtk.ButtonBox.ButtonBoxChild)(w7[this.buttonOk]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
