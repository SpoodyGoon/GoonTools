//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUPdotNET {
    
    
    public partial class MainWindow {
        
        private Gtk.Alignment alignment1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Alignment alignment9;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment10;
        
        private Gtk.Button btnAbout;
        
        private Gtk.Label label4;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment13;
        
        private Gtk.HBox hbox3;
        
        private Gtk.Alignment alignment11;
        
        private Gtk.CheckButton cbxAutoUpdate;
        
        private Gtk.Alignment alignment12;
        
        private Gtk.Button btnCheckNow;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment14;
        
        private Gtk.Label label2;
        
        private Gtk.Alignment alignment8;
        
        private GUPdotNET.UpdateTimeCombo cboUpdateTimeType;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Table table1;
        
        private Gtk.Alignment alignment15;
        
        private Gtk.Label label3;
        
        private Gtk.Alignment alignment16;
        
        private Gtk.Label lblLastUpdate;
        
        private Gtk.Alignment alignment17;
        
        private Gtk.Label label5;
        
        private Gtk.Alignment alignment19;
        
        private Gtk.Label lblLastCheck;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Alignment alignment7;
        
        private Gtk.HButtonBox hbuttonbox2;
        
        private Gtk.Button btnClose;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget GUPdotNET.MainWindow
            this.Name = "GUPdotNET.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("Update Options");
            this.Icon = Gdk.Pixbuf.LoadFromResource("update_small.png");
            this.WindowPosition = ((Gtk.WindowPosition)(1));
            this.BorderWidth = ((uint)(2));
            this.AllowShrink = true;
            this.SkipPagerHint = true;
            this.SkipTaskbarHint = true;
            // Container child GUPdotNET.MainWindow.Gtk.Container+ContainerChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.BottomPadding = ((uint)(8));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.01F, 1F, 0.01F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.alignment9 = new Gtk.Alignment(0.8F, 0.5F, 0.01F, 1F);
            this.alignment9.Name = "alignment9";
            this.alignment9.TopPadding = ((uint)(8));
            // Container child alignment9.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"x-large\"><b>Update Options</b></span>");
            this.label1.UseMarkup = true;
            this.alignment9.Add(this.label1);
            this.hbox2.Add(this.alignment9);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox2[this.alignment9]));
            w2.Position = 0;
            // Container child hbox2.Gtk.Box+BoxChild
            this.alignment10 = new Gtk.Alignment(0.99F, 0.01F, 0.01F, 0.01F);
            this.alignment10.Name = "alignment10";
            // Container child alignment10.Gtk.Container+ContainerChild
            this.btnAbout = new Gtk.Button();
            this.btnAbout.CanFocus = true;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Relief = ((Gtk.ReliefStyle)(2));
            this.btnAbout.Xalign = 1F;
            this.btnAbout.Yalign = 0.01F;
            // Container child btnAbout.Gtk.Container+ContainerChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.Xalign = 1F;
            this.label4.Yalign = 0.01F;
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"7500\" color=\"#00006B\"><b><u><tt>About GUPdotNET</tt></u></b></span>");
            this.label4.UseMarkup = true;
            this.btnAbout.Add(this.label4);
            this.btnAbout.Label = null;
            this.alignment10.Add(this.btnAbout);
            this.hbox2.Add(this.alignment10);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.alignment10]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            this.alignment2.Add(this.hbox2);
            this.vbox2.Add(this.alignment2);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment2]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment3.Add(this.hseparator1);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment13 = new Gtk.Alignment(0.5F, 0.5F, 0.5F, 1F);
            this.alignment13.Name = "alignment13";
            this.alignment13.LeftPadding = ((uint)(10));
            this.alignment13.RightPadding = ((uint)(10));
            // Container child alignment13.Gtk.Container+ContainerChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 10;
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment11 = new Gtk.Alignment(0.5F, 0.5F, 0.5F, 1F);
            this.alignment11.Name = "alignment11";
            this.alignment11.TopPadding = ((uint)(5));
            this.alignment11.BottomPadding = ((uint)(5));
            // Container child alignment11.Gtk.Container+ContainerChild
            this.cbxAutoUpdate = new Gtk.CheckButton();
            this.cbxAutoUpdate.CanFocus = true;
            this.cbxAutoUpdate.Name = "cbxAutoUpdate";
            this.cbxAutoUpdate.Label = Mono.Unix.Catalog.GetString("Check for updates automatically.");
            this.cbxAutoUpdate.Active = true;
            this.cbxAutoUpdate.DrawIndicator = true;
            this.cbxAutoUpdate.UseUnderline = true;
            this.alignment11.Add(this.cbxAutoUpdate);
            this.hbox3.Add(this.alignment11);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment11]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child hbox3.Gtk.Box+BoxChild
            this.alignment12 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment12.Name = "alignment12";
            this.alignment12.LeftPadding = ((uint)(5));
            this.alignment12.RightPadding = ((uint)(5));
            // Container child alignment12.Gtk.Container+ContainerChild
            this.btnCheckNow = new Gtk.Button();
            this.btnCheckNow.HeightRequest = 14;
            this.btnCheckNow.CanFocus = true;
            this.btnCheckNow.Name = "btnCheckNow";
            this.btnCheckNow.UseUnderline = true;
            this.btnCheckNow.Label = Mono.Unix.Catalog.GetString("  Check Now...  ");
            this.alignment12.Add(this.btnCheckNow);
            this.hbox3.Add(this.alignment12);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.hbox3[this.alignment12]));
            w13.Position = 1;
            w13.Expand = false;
            w13.Fill = false;
            this.alignment13.Add(this.hbox3);
            this.vbox2.Add(this.alignment13);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment13]));
            w15.Position = 2;
            w15.Expand = false;
            w15.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.BorderWidth = ((uint)(4));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment2 = new Gtk.Alignment(0.5F, 0.5F, 0.5F, 0.5F);
            this.GtkAlignment2.Name = "GtkAlignment2";
            this.GtkAlignment2.LeftPadding = ((uint)(7));
            this.GtkAlignment2.TopPadding = ((uint)(4));
            this.GtkAlignment2.BottomPadding = ((uint)(4));
            // Container child GtkAlignment2.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment14 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment14.Name = "alignment14";
            // Container child alignment14.Gtk.Container+ContainerChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Check for updates every:");
            this.alignment14.Add(this.label2);
            this.hbox1.Add(this.alignment14);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment14]));
            w17.Position = 0;
            w17.Expand = false;
            w17.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment8 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment8.Name = "alignment8";
            // Container child alignment8.Gtk.Container+ContainerChild
            this.cboUpdateTimeType = new GUPdotNET.UpdateTimeCombo();
            this.cboUpdateTimeType.WidthRequest = 150;
            this.cboUpdateTimeType.Name = "cboUpdateTimeType";
            this.alignment8.Add(this.cboUpdateTimeType);
            this.hbox1.Add(this.alignment8);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment8]));
            w19.Position = 1;
            w19.Expand = false;
            w19.Fill = false;
            this.GtkAlignment2.Add(this.hbox1);
            this.frame1.Add(this.GtkAlignment2);
            this.vbox2.Add(this.frame1);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
            w22.Position = 3;
            w22.Expand = false;
            w22.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            this.alignment4.LeftPadding = ((uint)(30));
            // Container child alignment4.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(2)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.alignment15 = new Gtk.Alignment(0.01F, 0.5F, 0.98F, 1F);
            this.alignment15.Name = "alignment15";
            // Container child alignment15.Gtk.Container+ContainerChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.Xalign = 0.98F;
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Last Check for Updates:");
            this.alignment15.Add(this.label3);
            this.table1.Add(this.alignment15);
            Gtk.Table.TableChild w24 = ((Gtk.Table.TableChild)(this.table1[this.alignment15]));
            w24.XOptions = ((Gtk.AttachOptions)(4));
            w24.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment16 = new Gtk.Alignment(0.01F, 0.5F, 0.02F, 1F);
            this.alignment16.Name = "alignment16";
            // Container child alignment16.Gtk.Container+ContainerChild
            this.lblLastUpdate = new Gtk.Label();
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.LabelProp = Mono.Unix.Catalog.GetString("None");
            this.alignment16.Add(this.lblLastUpdate);
            this.table1.Add(this.alignment16);
            Gtk.Table.TableChild w26 = ((Gtk.Table.TableChild)(this.table1[this.alignment16]));
            w26.TopAttach = ((uint)(1));
            w26.BottomAttach = ((uint)(2));
            w26.LeftAttach = ((uint)(1));
            w26.RightAttach = ((uint)(2));
            w26.XOptions = ((Gtk.AttachOptions)(4));
            w26.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment17 = new Gtk.Alignment(0.01F, 0.5F, 0.98F, 1F);
            this.alignment17.Name = "alignment17";
            // Container child alignment17.Gtk.Container+ContainerChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.Xalign = 0.98F;
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Last Update:");
            this.label5.Justify = ((Gtk.Justification)(1));
            this.alignment17.Add(this.label5);
            this.table1.Add(this.alignment17);
            Gtk.Table.TableChild w28 = ((Gtk.Table.TableChild)(this.table1[this.alignment17]));
            w28.TopAttach = ((uint)(1));
            w28.BottomAttach = ((uint)(2));
            w28.XOptions = ((Gtk.AttachOptions)(4));
            w28.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.alignment19 = new Gtk.Alignment(0.01F, 0.5F, 0.02F, 1F);
            this.alignment19.Name = "alignment19";
            // Container child alignment19.Gtk.Container+ContainerChild
            this.lblLastCheck = new Gtk.Label();
            this.lblLastCheck.Name = "lblLastCheck";
            this.lblLastCheck.LabelProp = Mono.Unix.Catalog.GetString("None");
            this.alignment19.Add(this.lblLastCheck);
            this.table1.Add(this.alignment19);
            Gtk.Table.TableChild w30 = ((Gtk.Table.TableChild)(this.table1[this.alignment19]));
            w30.LeftAttach = ((uint)(1));
            w30.RightAttach = ((uint)(2));
            w30.XOptions = ((Gtk.AttachOptions)(4));
            w30.YOptions = ((Gtk.AttachOptions)(4));
            this.alignment4.Add(this.table1);
            this.vbox2.Add(this.alignment4);
            Gtk.Box.BoxChild w32 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment4]));
            w32.Position = 4;
            w32.Expand = false;
            w32.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.alignment6.Add(this.hseparator2);
            this.vbox2.Add(this.alignment6);
            Gtk.Box.BoxChild w34 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment6]));
            w34.Position = 5;
            w34.Expand = false;
            w34.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment7 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment7.Name = "alignment7";
            // Container child alignment7.Gtk.Container+ContainerChild
            this.hbuttonbox2 = new Gtk.HButtonBox();
            this.hbuttonbox2.Name = "hbuttonbox2";
            this.hbuttonbox2.BorderWidth = ((uint)(2));
            // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
            this.btnClose = new Gtk.Button();
            this.btnClose.CanFocus = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseStock = true;
            this.btnClose.UseUnderline = true;
            this.btnClose.Label = "gtk-close";
            this.hbuttonbox2.Add(this.btnClose);
            Gtk.ButtonBox.ButtonBoxChild w35 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnClose]));
            w35.Expand = false;
            w35.Fill = false;
            this.alignment7.Add(this.hbuttonbox2);
            this.vbox2.Add(this.alignment7);
            Gtk.Box.BoxChild w37 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment7]));
            w37.Position = 6;
            w37.Expand = false;
            w37.Fill = false;
            this.alignment1.Add(this.vbox2);
            this.Add(this.alignment1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 445;
            this.DefaultHeight = 254;
            this.Show();
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.btnAbout.Clicked += new System.EventHandler(this.OnBtnAboutClicked);
            this.btnAbout.Entered += new System.EventHandler(this.OnBtnAboutEntered);
            this.btnAbout.Pressed += new System.EventHandler(this.OnBtnAboutPressed);
            this.btnAbout.Activated += new System.EventHandler(this.OnBtnAboutActivated);
            this.btnAbout.Released += new System.EventHandler(this.OnBtnAboutReleased);
            this.cbxAutoUpdate.Toggled += new System.EventHandler(this.OnCbxAutoUpdateToggled);
            this.btnCheckNow.Clicked += new System.EventHandler(this.OnBtnCheckNowClicked);
            this.btnClose.Clicked += new System.EventHandler(this.OnbtnCloseClicked);
        }
    }
}
