// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
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
    
    private Gtk.VButtonBox vbuttonbox1;
    
    private Gtk.Button btnTestAssembly;
    
    private Gtk.Button btnTestProcWithArgs;
    
    private Gtk.Button btnTestProcNoArgs;
    
    private Gtk.Alignment alignment4;
    
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
        this.vbuttonbox1 = new Gtk.VButtonBox();
        this.vbuttonbox1.Name = "vbuttonbox1";
        this.vbuttonbox1.Spacing = 11;
        this.vbuttonbox1.LayoutStyle = ((Gtk.ButtonBoxStyle)(3));
        // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnTestAssembly = new Gtk.Button();
        this.btnTestAssembly.CanFocus = true;
        this.btnTestAssembly.Name = "btnTestAssembly";
        this.btnTestAssembly.UseUnderline = true;
        this.btnTestAssembly.Label = Mono.Unix.Catalog.GetString("Test Assembly");
        this.vbuttonbox1.Add(this.btnTestAssembly);
        Gtk.ButtonBox.ButtonBoxChild w5 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.btnTestAssembly]));
        w5.Expand = false;
        w5.Fill = false;
        // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnTestProcWithArgs = new Gtk.Button();
        this.btnTestProcWithArgs.CanFocus = true;
        this.btnTestProcWithArgs.Name = "btnTestProcWithArgs";
        this.btnTestProcWithArgs.UseUnderline = true;
        this.btnTestProcWithArgs.Label = Mono.Unix.Catalog.GetString("Process w/ Args");
        this.vbuttonbox1.Add(this.btnTestProcWithArgs);
        Gtk.ButtonBox.ButtonBoxChild w6 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.btnTestProcWithArgs]));
        w6.Position = 1;
        w6.Expand = false;
        w6.Fill = false;
        // Container child vbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnTestProcNoArgs = new Gtk.Button();
        this.btnTestProcNoArgs.CanFocus = true;
        this.btnTestProcNoArgs.Name = "btnTestProcNoArgs";
        this.btnTestProcNoArgs.UseUnderline = true;
        this.btnTestProcNoArgs.Label = Mono.Unix.Catalog.GetString("Process w/o Args");
        this.vbuttonbox1.Add(this.btnTestProcNoArgs);
        Gtk.ButtonBox.ButtonBoxChild w7 = ((Gtk.ButtonBox.ButtonBoxChild)(this.vbuttonbox1[this.btnTestProcNoArgs]));
        w7.Position = 2;
        w7.Expand = false;
        w7.Fill = false;
        this.vbox1.Add(this.vbuttonbox1);
        Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.vbuttonbox1]));
        w8.Position = 2;
        w8.Padding = ((uint)(1));
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment4.Name = "alignment4";
        // Container child alignment4.Gtk.Container+ContainerChild
        this.hseparator2 = new Gtk.HSeparator();
        this.hseparator2.Name = "hseparator2";
        this.alignment4.Add(this.hseparator2);
        this.vbox1.Add(this.alignment4);
        Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment4]));
        w10.Position = 3;
        w10.Expand = false;
        w10.Fill = false;
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
        Gtk.ButtonBox.ButtonBoxChild w11 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.btnQuit]));
        w11.Expand = false;
        w11.Fill = false;
        this.vbox1.Add(this.hbuttonbox2);
        Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox2]));
        w12.Position = 4;
        w12.Expand = false;
        w12.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbuttonbox1 = new Gtk.HButtonBox();
        this.vbox1.Add(this.hbuttonbox1);
        Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox1]));
        w13.Position = 5;
        w13.Expand = false;
        w13.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 400;
        this.DefaultHeight = 257;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.btnTestAssembly.Clicked += new System.EventHandler(this.OnBtnTestAssemblyClicked);
        this.btnTestProcWithArgs.Clicked += new System.EventHandler(this.OnBtnTestProcWithArgsClicked);
        this.btnTestProcNoArgs.Clicked += new System.EventHandler(this.OnBtnTestProcNoArgsClicked);
        this.btnQuit.Clicked += new System.EventHandler(this.OnBtnQuitClicked);
    }
}