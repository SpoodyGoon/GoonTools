//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUPdotNET {
    
    
    public partial class frmConfirm {
        
        private Gtk.VBox vbox3;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.Label lblProgramTitle;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.Label lblUpdateMessage;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Button btnNo;
        
        private Gtk.Button btnYes;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.frmConfirm
            this.Name = "GUPdotNET.frmConfirm";
            this.Title = Mono.Unix.Catalog.GetString("Update Available");
            this.Icon = Gdk.Pixbuf.LoadFromResource("update_small.png");
            this.TypeHint = ((Gdk.WindowTypeHint)(1));
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.Modal = true;
            this.BorderWidth = ((uint)(3));
            this.Resizable = false;
            this.AllowGrow = false;
            this.DestroyWithParent = true;
            // Internal child GUPdotNET.frmConfirm.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.Spacing = 2;
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            // Container child vbox3.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.TopPadding = ((uint)(3));
            this.alignment1.BottomPadding = ((uint)(2));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.lblProgramTitle = new Gtk.Label();
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.LabelProp = Mono.Unix.Catalog.GetString("Title");
            this.lblProgramTitle.UseMarkup = true;
            this.alignment1.Add(this.lblProgramTitle);
            this.vbox3.Add(this.alignment1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox3[this.alignment1]));
            w3.Position = 0;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.vbox3.Add(this.hseparator1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox3[this.hseparator1]));
            w4.Position = 1;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.lblUpdateMessage = new Gtk.Label();
            this.lblUpdateMessage.WidthRequest = 375;
            this.lblUpdateMessage.Name = "lblUpdateMessage";
            this.lblUpdateMessage.Xpad = 10;
            this.lblUpdateMessage.LabelProp = Mono.Unix.Catalog.GetString("Message");
            this.lblUpdateMessage.UseMarkup = true;
            this.lblUpdateMessage.Wrap = true;
            this.alignment2.Add(this.lblUpdateMessage);
            this.vbox3.Add(this.alignment2);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox3[this.alignment2]));
            w6.Position = 2;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            this.alignment3.LeftPadding = ((uint)(2));
            this.alignment3.BottomPadding = ((uint)(4));
            // Container child alignment3.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment3.Add(this.hseparator2);
            this.vbox3.Add(this.alignment3);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox3[this.alignment3]));
            w8.Position = 3;
            w8.Expand = false;
            w8.Fill = false;
            w1.Add(this.vbox3);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(w1[this.vbox3]));
            w9.Position = 0;
            w9.Expand = false;
            w9.Fill = false;
            // Internal child GUPdotNET.frmConfirm.ActionArea
            Gtk.HButtonBox w10 = this.ActionArea;
            w10.Name = "dialog1_ActionArea";
            w10.Spacing = 6;
            w10.BorderWidth = ((uint)(5));
            w10.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnNo = new Gtk.Button();
            this.btnNo.CanDefault = true;
            this.btnNo.CanFocus = true;
            this.btnNo.Name = "btnNo";
            this.btnNo.UseStock = true;
            this.btnNo.UseUnderline = true;
            this.btnNo.Label = "gtk-no";
            this.AddActionWidget(this.btnNo, -9);
            Gtk.ButtonBox.ButtonBoxChild w11 = ((Gtk.ButtonBox.ButtonBoxChild)(w10[this.btnNo]));
            w11.Expand = false;
            w11.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.btnYes = new Gtk.Button();
            this.btnYes.CanDefault = true;
            this.btnYes.CanFocus = true;
            this.btnYes.Name = "btnYes";
            this.btnYes.UseStock = true;
            this.btnYes.UseUnderline = true;
            this.btnYes.Label = "gtk-yes";
            this.AddActionWidget(this.btnYes, -8);
            Gtk.ButtonBox.ButtonBoxChild w12 = ((Gtk.ButtonBox.ButtonBoxChild)(w10[this.btnYes]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 129;
            this.Show();
            this.btnNo.Clicked += new System.EventHandler(this.OnBtnNoClicked);
            this.btnYes.Clicked += new System.EventHandler(this.OnBtnYesClicked);
        }
    }
}