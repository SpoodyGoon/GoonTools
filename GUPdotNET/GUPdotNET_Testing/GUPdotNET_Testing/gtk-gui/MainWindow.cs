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
    
    private Gtk.HBox hbox1;
    
    private Gtk.Label label1;
    
    private Gtk.SpinButton spinbutton1;
    
    private Gtk.HBox hbox2;
    
    private Gtk.Label label2;
    
    private Gtk.SpinButton spinbutton2;
    
    private Gtk.HButtonBox hbuttonbox1;
    
    private Gtk.Button btnTest;
    
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
        this.hbox1 = new Gtk.HBox();
        this.hbox1.Name = "hbox1";
        this.hbox1.Spacing = 6;
        // Container child hbox1.Gtk.Box+BoxChild
        this.label1 = new Gtk.Label();
        this.label1.Name = "label1";
        this.label1.Xpad = 12;
        this.label1.LabelProp = Mono.Unix.Catalog.GetString("Major Version");
        this.hbox1.Add(this.label1);
        Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.label1]));
        w1.Position = 0;
        w1.Expand = false;
        w1.Fill = false;
        // Container child hbox1.Gtk.Box+BoxChild
        this.spinbutton1 = new Gtk.SpinButton(0, 100, 1);
        this.spinbutton1.CanFocus = true;
        this.spinbutton1.Name = "spinbutton1";
        this.spinbutton1.Adjustment.PageIncrement = 10;
        this.spinbutton1.ClimbRate = 1;
        this.spinbutton1.Numeric = true;
        this.hbox1.Add(this.spinbutton1);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.spinbutton1]));
        w2.Position = 1;
        w2.Expand = false;
        w2.Fill = false;
        this.vbox1.Add(this.hbox1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
        w3.Position = 0;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbox2 = new Gtk.HBox();
        this.hbox2.Name = "hbox2";
        this.hbox2.Spacing = 6;
        // Container child hbox2.Gtk.Box+BoxChild
        this.label2 = new Gtk.Label();
        this.label2.Name = "label2";
        this.label2.Xpad = 12;
        this.label2.LabelProp = Mono.Unix.Catalog.GetString("Minor Version");
        this.hbox2.Add(this.label2);
        Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox2[this.label2]));
        w4.Position = 0;
        w4.Expand = false;
        w4.Fill = false;
        // Container child hbox2.Gtk.Box+BoxChild
        this.spinbutton2 = new Gtk.SpinButton(0, 100, 1);
        this.spinbutton2.CanFocus = true;
        this.spinbutton2.Name = "spinbutton2";
        this.spinbutton2.Adjustment.PageIncrement = 10;
        this.spinbutton2.ClimbRate = 1;
        this.spinbutton2.Numeric = true;
        this.hbox2.Add(this.spinbutton2);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox2[this.spinbutton2]));
        w5.Position = 1;
        w5.Expand = false;
        w5.Fill = false;
        this.vbox1.Add(this.hbox2);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
        w6.Position = 1;
        w6.Expand = false;
        w6.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.hbuttonbox1 = new Gtk.HButtonBox();
        this.hbuttonbox1.Name = "hbuttonbox1";
        // Container child hbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
        this.btnTest = new Gtk.Button();
        this.btnTest.CanFocus = true;
        this.btnTest.Name = "btnTest";
        this.btnTest.UseUnderline = true;
        this.btnTest.Label = Mono.Unix.Catalog.GetString("Test GUPdotNET");
        this.hbuttonbox1.Add(this.btnTest);
        Gtk.ButtonBox.ButtonBoxChild w7 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox1[this.btnTest]));
        w7.Expand = false;
        w7.Fill = false;
        this.vbox1.Add(this.hbuttonbox1);
        Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbuttonbox1]));
        w8.Position = 2;
        w8.Expand = false;
        w8.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 400;
        this.DefaultHeight = 300;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.btnTest.Clicked += new System.EventHandler(this.OnBtnTestClicked);
    }
}