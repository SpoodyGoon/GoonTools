// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.VBox vbox1;
    
    private Gtk.Alignment alignment3;
    
    private Gtk.Label label1;
    
    private Gtk.Alignment alignment5;
    
    private Gtk.HSeparator hseparator3;
    
    private Gtk.Alignment alignment1;
    
    private Gtk.Alignment alignment2;
    
    private Gtk.HBox hbox1;
    
    private Gtk.FileChooserButton GUPdotNETFile;
    
    private Gtk.Alignment alignment4;
    
    private Gtk.HSeparator hseparator1;
    
    private Gtk.VButtonBox vbuttonbox1;
    
    private Gtk.Button btnTest;
    
    private Gtk.Button btnOptions;
    
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
        this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment2.Name = "alignment2";
        // Container child alignment2.Gtk.Container+ContainerChild
        this.hbox1 = new Gtk.HBox();
        this.hbox1.Name = "hbox1";
        this.hbox1.Spacing = 6;
        // Container child hbox1.Gtk.Box+BoxChild
        this.GUPdotNETFile = new Gtk.FileChooserButton(Mono.Unix.Catalog.GetString("Select A File"), ((Gtk.FileChooserAction)(0)));
        this.GUPdotNETFile.Name = "GUPdotNETFile";
        this.hbox1.Add(this.GUPdotNETFile);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.GUPdotNETFile]));
        w5.Position = 0;
        this.alignment2.Add(this.hbox1);
        this.alignment1.Add(this.alignment2);
        this.vbox1.Add(this.alignment1);
        Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
        w8.Position = 2;
        w8.Expand = false;
        w8.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment4.Name = "alignment4";
        // Container child alignment4.Gtk.Container+ContainerChild
        this.hseparator1 = new Gtk.HSeparator();
        this.hseparator1.Name = "hseparator1";
        this.alignment4.Add(this.hseparator1);
        this.vbox1.Add(this.alignment4);
        Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment4]));
        w10.Position = 3;
        w10.Expand = false;
        w10.Fill = false;
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
        Gtk.ButtonBox.ButtonBoxChild w11 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.btnTest]));
        w11.Expand = false;
        w11.Fill = false;
        // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnOptions = new Gtk.Button();
        this.btnOptions.CanFocus = true;
        this.btnOptions.Name = "btnOptions";
        this.btnOptions.UseUnderline = true;
        this.btnOptions.Label = Mono.Unix.Catalog.GetString("Options");
        this.vbuttonbox1.Add(this.btnOptions);
        Gtk.ButtonBox.ButtonBoxChild w12 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.btnOptions]));
        w12.Position = 1;
        w12.Expand = false;
        w12.Fill = false;
        this.vbox1.Add(this.vbuttonbox1);
        Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbuttonbox1]));
        w13.Position = 4;
        w13.Padding = ((uint)(1));
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment11 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment11.Name = "alignment11";
        // Container child alignment11.Gtk.Container+ContainerChild
        this.hseparator2 = new Gtk.HSeparator();
        this.hseparator2.Name = "hseparator2";
        this.alignment11.Add(this.hseparator2);
        this.vbox1.Add(this.alignment11);
        Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment11]));
        w15.Position = 5;
        w15.Expand = false;
        w15.Fill = false;
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
        Gtk.ButtonBox.ButtonBoxChild w16 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnQuit]));
        w16.Expand = false;
        w16.Fill = false;
        this.vbox1.Add(this.hbuttonbox2);
        Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox2]));
        w17.Position = 6;
        w17.Expand = false;
        w17.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbuttonbox1 = new Gtk.HButtonBox();
        this.hbuttonbox1.Name = "hbuttonbox1";
        this.vbox1.Add(this.hbuttonbox1);
        Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox1]));
        w18.Position = 7;
        w18.Expand = false;
        w18.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 402;
        this.DefaultHeight = 234;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.btnTest.Clicked += new System.EventHandler(this.OnBtnTestClicked);
        this.btnOptions.Clicked += new System.EventHandler(this.OnBtnOptionsClicked);
        this.btnQuit.Clicked += new System.EventHandler(this.OnBtnQuitClicked);
    }
}