//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.VBox vbox1;
    
    private Gtk.Alignment alignment3;
    
    private Gtk.Label label1;
    
    private Gtk.Alignment alignment5;
    
    private Gtk.HSeparator hseparator3;
    
    private Gtk.Alignment alignment1;
    
    private Gtk.Table table1;
    
    private Gtk.Alignment alignment10;
    
    private Gtk.Entry txtProgramName;
    
    private Gtk.Alignment alignment12;
    
    private Gtk.Label label5;
    
    private Gtk.Alignment alignment13;
    
    private Gtk.ComboBox cboInstallType;
    
    private Gtk.Alignment alignment14;
    
    private Gtk.SpinButton spnMajor;
    
    private Gtk.Alignment alignment15;
    
    private Gtk.SpinButton spnMinorVersion;
    
    private Gtk.Alignment alignment16;
    
    private Gtk.Label label7;
    
    private Gtk.Alignment alignment17;
    
    private Gtk.Label label6;
    
    private Gtk.Alignment alignment2;
    
    private Gtk.CheckButton cbxSilent;
    
    private Gtk.Alignment alignment6;
    
    private Gtk.Label label2;
    
    private Gtk.Alignment alignment7;
    
    private Gtk.Label label3;
    
    private Gtk.Alignment alignment8;
    
    private Gtk.Label label4;
    
    private Gtk.Alignment alignment9;
    
    private Gtk.Entry txtProgramTitle;
    
    private Gtk.Alignment alignment4;
    
    private Gtk.HSeparator hseparator1;
    
    private Gtk.VButtonBox vbuttonbox1;
    
    private Gtk.Button btnTest;
    
    private Gtk.Alignment alignment11;
    
    private Gtk.HSeparator hseparator2;
    
    private Gtk.HButtonBox hbuttonbox2;
    
    private Gtk.Button btnQuit;
    
    private Gtk.HButtonBox hbuttonbox1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        this.AllowShrink = true;
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 6;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment3.Name = "alignment3";
        this.alignment3.TopPadding = ((uint)(8));
        this.alignment3.BottomPadding = ((uint)(4));
        // Container child alignment3.Gtk.Container+ContainerChild
        this.label1 = new Gtk.Label();
        this.label1.Name = "label1";
        this.label1.LabelProp = Mono.Unix.Catalog.GetString("<span size=\"large\"><b>Test Dialog for GUPdotNET</b></span>");
        this.label1.UseMarkup = true;
        this.alignment3.Add(this.label1);
        this.vbox1.Add(this.alignment3);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment3]));
        w2.Position = 0;
        w2.Expand = false;
        w2.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment5.Name = "alignment5";
        // Container child alignment5.Gtk.Container+ContainerChild
        this.hseparator3 = new Gtk.HSeparator();
        this.hseparator3.Name = "hseparator3";
        this.alignment5.Add(this.hseparator3);
        this.vbox1.Add(this.alignment5);
        Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment5]));
        w4.Position = 1;
        w4.Expand = false;
        w4.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment1.Name = "alignment1";
        this.alignment1.LeftPadding = ((uint)(15));
        this.alignment1.RightPadding = ((uint)(15));
        // Container child alignment1.Gtk.Container+ContainerChild
        this.table1 = new Gtk.Table(((uint)(6)), ((uint)(2)), false);
        this.table1.Name = "table1";
        this.table1.RowSpacing = ((uint)(6));
        this.table1.ColumnSpacing = ((uint)(6));
        this.table1.BorderWidth = ((uint)(8));
        // Container child table1.Gtk.Table+TableChild
        this.alignment10 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment10.Name = "alignment10";
        // Container child alignment10.Gtk.Container+ContainerChild
        this.txtProgramName = new Gtk.Entry();
        this.txtProgramName.CanFocus = true;
        this.txtProgramName.Name = "txtProgramName";
        this.txtProgramName.Text = Mono.Unix.Catalog.GetString("GUPdotNET_Testing");
        this.txtProgramName.IsEditable = true;
        this.alignment10.Add(this.txtProgramName);
        this.table1.Add(this.alignment10);
        Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.alignment10]));
        w6.TopAttach = ((uint)(1));
        w6.BottomAttach = ((uint)(2));
        w6.LeftAttach = ((uint)(1));
        w6.RightAttach = ((uint)(2));
        w6.XOptions = ((Gtk.AttachOptions)(4));
        w6.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment12 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment12.Name = "alignment12";
        // Container child alignment12.Gtk.Container+ContainerChild
        this.label5 = new Gtk.Label();
        this.label5.Name = "label5";
        this.label5.LabelProp = Mono.Unix.Catalog.GetString("Minor Version:");
        this.alignment12.Add(this.label5);
        this.table1.Add(this.alignment12);
        Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.alignment12]));
        w8.TopAttach = ((uint)(4));
        w8.BottomAttach = ((uint)(5));
        w8.XOptions = ((Gtk.AttachOptions)(4));
        w8.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment13 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment13.Name = "alignment13";
        // Container child alignment13.Gtk.Container+ContainerChild
        this.cboInstallType = Gtk.ComboBox.NewText();
        this.cboInstallType.AppendText(Mono.Unix.Catalog.GetString("Win32"));
        this.cboInstallType.AppendText(Mono.Unix.Catalog.GetString("Win64"));
        this.cboInstallType.AppendText(Mono.Unix.Catalog.GetString("LinuxRPM"));
        this.cboInstallType.AppendText(Mono.Unix.Catalog.GetString("LinuxDeb"));
        this.cboInstallType.AppendText(Mono.Unix.Catalog.GetString("LinuxBin"));
        this.cboInstallType.AppendText(Mono.Unix.Catalog.GetString("LinuxSrc"));
        this.cboInstallType.Name = "cboInstallType";
        this.cboInstallType.Active = 0;
        this.alignment13.Add(this.cboInstallType);
        this.table1.Add(this.alignment13);
        Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.alignment13]));
        w10.TopAttach = ((uint)(2));
        w10.BottomAttach = ((uint)(3));
        w10.LeftAttach = ((uint)(1));
        w10.RightAttach = ((uint)(2));
        w10.XOptions = ((Gtk.AttachOptions)(4));
        w10.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment14 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment14.Name = "alignment14";
        // Container child alignment14.Gtk.Container+ContainerChild
        this.spnMajor = new Gtk.SpinButton(0, 100, 1);
        this.spnMajor.CanFocus = true;
        this.spnMajor.Name = "spnMajor";
        this.spnMajor.Adjustment.PageIncrement = 10;
        this.spnMajor.ClimbRate = 1;
        this.spnMajor.Numeric = true;
        this.alignment14.Add(this.spnMajor);
        this.table1.Add(this.alignment14);
        Gtk.Table.TableChild w12 = ((Gtk.Table.TableChild)(this.table1[this.alignment14]));
        w12.TopAttach = ((uint)(3));
        w12.BottomAttach = ((uint)(4));
        w12.LeftAttach = ((uint)(1));
        w12.RightAttach = ((uint)(2));
        w12.XOptions = ((Gtk.AttachOptions)(4));
        w12.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment15 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment15.Name = "alignment15";
        // Container child alignment15.Gtk.Container+ContainerChild
        this.spnMinorVersion = new Gtk.SpinButton(0, 100, 1);
        this.spnMinorVersion.CanFocus = true;
        this.spnMinorVersion.Name = "spnMinorVersion";
        this.spnMinorVersion.Adjustment.PageIncrement = 10;
        this.spnMinorVersion.ClimbRate = 1;
        this.spnMinorVersion.Numeric = true;
        this.spnMinorVersion.Value = 1;
        this.alignment15.Add(this.spnMinorVersion);
        this.table1.Add(this.alignment15);
        Gtk.Table.TableChild w14 = ((Gtk.Table.TableChild)(this.table1[this.alignment15]));
        w14.TopAttach = ((uint)(4));
        w14.BottomAttach = ((uint)(5));
        w14.LeftAttach = ((uint)(1));
        w14.RightAttach = ((uint)(2));
        w14.XOptions = ((Gtk.AttachOptions)(4));
        w14.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment16 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment16.Name = "alignment16";
        // Container child alignment16.Gtk.Container+ContainerChild
        this.label7 = new Gtk.Label();
        this.label7.Name = "label7";
        this.label7.LabelProp = Mono.Unix.Catalog.GetString("Install Type:");
        this.alignment16.Add(this.label7);
        this.table1.Add(this.alignment16);
        Gtk.Table.TableChild w16 = ((Gtk.Table.TableChild)(this.table1[this.alignment16]));
        w16.TopAttach = ((uint)(2));
        w16.BottomAttach = ((uint)(3));
        w16.XOptions = ((Gtk.AttachOptions)(4));
        w16.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment17 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment17.Name = "alignment17";
        // Container child alignment17.Gtk.Container+ContainerChild
        this.label6 = new Gtk.Label();
        this.label6.Name = "label6";
        this.label6.LabelProp = Mono.Unix.Catalog.GetString("Program Title:");
        this.alignment17.Add(this.label6);
        this.table1.Add(this.alignment17);
        Gtk.Table.TableChild w18 = ((Gtk.Table.TableChild)(this.table1[this.alignment17]));
        w18.XOptions = ((Gtk.AttachOptions)(4));
        w18.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment2 = new Gtk.Alignment(0.02F, 0.5F, 0.01F, 1F);
        this.alignment2.Name = "alignment2";
        // Container child alignment2.Gtk.Container+ContainerChild
        this.cbxSilent = new Gtk.CheckButton();
        this.cbxSilent.CanFocus = true;
        this.cbxSilent.Name = "cbxSilent";
        this.cbxSilent.Label = "";
        this.cbxSilent.DrawIndicator = true;
        this.cbxSilent.UseUnderline = true;
        this.alignment2.Add(this.cbxSilent);
        this.table1.Add(this.alignment2);
        Gtk.Table.TableChild w20 = ((Gtk.Table.TableChild)(this.table1[this.alignment2]));
        w20.TopAttach = ((uint)(5));
        w20.BottomAttach = ((uint)(6));
        w20.LeftAttach = ((uint)(1));
        w20.RightAttach = ((uint)(2));
        w20.XOptions = ((Gtk.AttachOptions)(4));
        w20.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment6.Name = "alignment6";
        // Container child alignment6.Gtk.Container+ContainerChild
        this.label2 = new Gtk.Label();
        this.label2.Name = "label2";
        this.label2.LabelProp = Mono.Unix.Catalog.GetString("Program Name:");
        this.alignment6.Add(this.label2);
        this.table1.Add(this.alignment6);
        Gtk.Table.TableChild w22 = ((Gtk.Table.TableChild)(this.table1[this.alignment6]));
        w22.TopAttach = ((uint)(1));
        w22.BottomAttach = ((uint)(2));
        w22.XOptions = ((Gtk.AttachOptions)(4));
        w22.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment7 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment7.Name = "alignment7";
        // Container child alignment7.Gtk.Container+ContainerChild
        this.label3 = new Gtk.Label();
        this.label3.Name = "label3";
        this.label3.LabelProp = Mono.Unix.Catalog.GetString("Major Version:");
        this.alignment7.Add(this.label3);
        this.table1.Add(this.alignment7);
        Gtk.Table.TableChild w24 = ((Gtk.Table.TableChild)(this.table1[this.alignment7]));
        w24.TopAttach = ((uint)(3));
        w24.BottomAttach = ((uint)(4));
        w24.XOptions = ((Gtk.AttachOptions)(4));
        w24.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment8 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment8.Name = "alignment8";
        // Container child alignment8.Gtk.Container+ContainerChild
        this.label4 = new Gtk.Label();
        this.label4.Name = "label4";
        this.label4.LabelProp = Mono.Unix.Catalog.GetString("Silent Update:");
        this.alignment8.Add(this.label4);
        this.table1.Add(this.alignment8);
        Gtk.Table.TableChild w26 = ((Gtk.Table.TableChild)(this.table1[this.alignment8]));
        w26.TopAttach = ((uint)(5));
        w26.BottomAttach = ((uint)(6));
        w26.XOptions = ((Gtk.AttachOptions)(4));
        w26.YOptions = ((Gtk.AttachOptions)(4));
        // Container child table1.Gtk.Table+TableChild
        this.alignment9 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment9.Name = "alignment9";
        // Container child alignment9.Gtk.Container+ContainerChild
        this.txtProgramTitle = new Gtk.Entry();
        this.txtProgramTitle.CanFocus = true;
        this.txtProgramTitle.Name = "txtProgramTitle";
        this.txtProgramTitle.Text = Mono.Unix.Catalog.GetString("GUPdotNET Testing Program");
        this.txtProgramTitle.IsEditable = true;
        this.alignment9.Add(this.txtProgramTitle);
        this.table1.Add(this.alignment9);
        Gtk.Table.TableChild w28 = ((Gtk.Table.TableChild)(this.table1[this.alignment9]));
        w28.LeftAttach = ((uint)(1));
        w28.RightAttach = ((uint)(2));
        w28.XOptions = ((Gtk.AttachOptions)(4));
        w28.YOptions = ((Gtk.AttachOptions)(4));
        this.alignment1.Add(this.table1);
        this.vbox1.Add(this.alignment1);
        Gtk.Box.BoxChild w30 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
        w30.Position = 2;
        w30.Expand = false;
        w30.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment4.Name = "alignment4";
        // Container child alignment4.Gtk.Container+ContainerChild
        this.hseparator1 = new Gtk.HSeparator();
        this.hseparator1.Name = "hseparator1";
        this.alignment4.Add(this.hseparator1);
        this.vbox1.Add(this.alignment4);
        Gtk.Box.BoxChild w32 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment4]));
        w32.Position = 3;
        w32.Expand = false;
        w32.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.vbuttonbox1 = new Gtk.VButtonBox();
        this.vbuttonbox1.Name = "vbuttonbox1";
        this.vbuttonbox1.Spacing = 11;
        this.vbuttonbox1.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
        // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnTest = new Gtk.Button();
        this.btnTest.WidthRequest = 136;
        this.btnTest.CanFocus = true;
        this.btnTest.Name = "btnTest";
        this.btnTest.UseUnderline = true;
        this.btnTest.Label = Mono.Unix.Catalog.GetString("Run Test");
        this.vbuttonbox1.Add(this.btnTest);
        Gtk.ButtonBox.ButtonBoxChild w33 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.btnTest]));
        w33.Expand = false;
        w33.Fill = false;
        this.vbox1.Add(this.vbuttonbox1);
        Gtk.Box.BoxChild w34 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbuttonbox1]));
        w34.Position = 4;
        w34.Padding = ((uint)(1));
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment11 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment11.Name = "alignment11";
        // Container child alignment11.Gtk.Container+ContainerChild
        this.hseparator2 = new Gtk.HSeparator();
        this.hseparator2.Name = "hseparator2";
        this.alignment11.Add(this.hseparator2);
        this.vbox1.Add(this.alignment11);
        Gtk.Box.BoxChild w36 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment11]));
        w36.Position = 5;
        w36.Expand = false;
        w36.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbuttonbox2 = new Gtk.HButtonBox();
        this.hbuttonbox2.Name = "hbuttonbox2";
        // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
        this.btnQuit = new Gtk.Button();
        this.btnQuit.CanFocus = true;
        this.btnQuit.Name = "btnQuit";
        this.btnQuit.UseStock = true;
        this.btnQuit.UseUnderline = true;
        this.btnQuit.Label = "gtk-quit";
        this.hbuttonbox2.Add(this.btnQuit);
        Gtk.ButtonBox.ButtonBoxChild w37 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnQuit]));
        w37.Expand = false;
        w37.Fill = false;
        this.vbox1.Add(this.hbuttonbox2);
        Gtk.Box.BoxChild w38 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox2]));
        w38.Position = 6;
        w38.Expand = false;
        w38.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbuttonbox1 = new Gtk.HButtonBox();
        this.hbuttonbox1.Name = "hbuttonbox1";
        this.vbox1.Add(this.hbuttonbox1);
        Gtk.Box.BoxChild w39 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox1]));
        w39.Position = 7;
        w39.Expand = false;
        w39.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 348;
        this.DefaultHeight = 321;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.btnTest.Clicked += new System.EventHandler(this.OnBtnTestClicked);
        this.btnQuit.Clicked += new System.EventHandler(this.OnBtnQuitClicked);
    }
}
