//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.UIManager UIManager;
    
    private Gtk.Action TreeViewRelatedAction;
    
    private Gtk.Action TreeViewColumnSelectorAction;
    
    private Gtk.Action DateTimeReleatedAction;
    
    private Gtk.VBox vbox1;
    
    private Gtk.Alignment alignment1;
    
    private Gtk.Label label1;
    
    private Gtk.Alignment alignment2;
    
    private Gtk.HSeparator hseparator1;
    
    private Gtk.Alignment alignment3;
    
    private Gtk.Notebook notebook1;
    
    private Gtk.VBox vbox2;
    
    private CMYControls.QuickDate2 quickdate21;
    
    private Gtk.Label label2;
    
    private Gtk.Statusbar statusbar1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.UIManager = new Gtk.UIManager();
        Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
        this.TreeViewRelatedAction = new Gtk.Action("TreeViewRelatedAction", Mono.Unix.Catalog.GetString("TreeView Related"), null, null);
        this.TreeViewRelatedAction.ShortLabel = Mono.Unix.Catalog.GetString("TreeView Related");
        w1.Add(this.TreeViewRelatedAction, null);
        this.TreeViewColumnSelectorAction = new Gtk.Action("TreeViewColumnSelectorAction", Mono.Unix.Catalog.GetString("TreeView Column Selector"), null, null);
        this.TreeViewColumnSelectorAction.ShortLabel = Mono.Unix.Catalog.GetString("TreeView Column Selector");
        w1.Add(this.TreeViewColumnSelectorAction, null);
        this.DateTimeReleatedAction = new Gtk.Action("DateTimeReleatedAction", Mono.Unix.Catalog.GetString("Date Time Releated"), null, null);
        this.DateTimeReleatedAction.ShortLabel = Mono.Unix.Catalog.GetString("Date Time Releated");
        w1.Add(this.DateTimeReleatedAction, null);
        this.UIManager.InsertActionGroup(w1, 0);
        this.AddAccelGroup(this.UIManager.AccelGroup);
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("MainWindow");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 6;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment1.Name = "alignment1";
        // Container child alignment1.Gtk.Container+ContainerChild
        this.label1 = new Gtk.Label();
        this.label1.Name = "label1";
        this.label1.LabelProp = Mono.Unix.Catalog.GetString("<big><b>CMYControls Testing Application</b></big>");
        this.label1.UseMarkup = true;
        this.alignment1.Add(this.label1);
        this.vbox1.Add(this.alignment1);
        Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
        w3.Position = 0;
        w3.Expand = false;
        w3.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment2.Name = "alignment2";
        // Container child alignment2.Gtk.Container+ContainerChild
        this.hseparator1 = new Gtk.HSeparator();
        this.hseparator1.Name = "hseparator1";
        this.alignment2.Add(this.hseparator1);
        this.vbox1.Add(this.alignment2);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment2]));
        w5.Position = 1;
        w5.Expand = false;
        w5.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
        this.alignment3.Name = "alignment3";
        // Container child alignment3.Gtk.Container+ContainerChild
        this.notebook1 = new Gtk.Notebook();
        this.notebook1.CanFocus = true;
        this.notebook1.Name = "notebook1";
        this.notebook1.CurrentPage = 0;
        // Container child notebook1.Gtk.Notebook+NotebookChild
        this.vbox2 = new Gtk.VBox();
        this.vbox2.Name = "vbox2";
        this.vbox2.Spacing = 6;
        // Container child vbox2.Gtk.Box+BoxChild
        this.quickdate21 = new CMYControls.QuickDate2();
        this.quickdate21.Name = "quickdate21";
        this.vbox2.Add(this.quickdate21);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox2[this.quickdate21]));
        w6.Position = 0;
        w6.Expand = false;
        w6.Fill = false;
        this.notebook1.Add(this.vbox2);
        // Notebook tab
        this.label2 = new Gtk.Label();
        this.label2.Name = "label2";
        this.label2.LabelProp = Mono.Unix.Catalog.GetString("page1");
        this.notebook1.SetTabLabel(this.vbox2, this.label2);
        this.label2.ShowAll();
        this.alignment3.Add(this.notebook1);
        this.vbox1.Add(this.alignment3);
        Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment3]));
        w9.Position = 2;
        // Container child vbox1.Gtk.Box+BoxChild
        this.statusbar1 = new Gtk.Statusbar();
        this.statusbar1.Name = "statusbar1";
        this.statusbar1.Spacing = 6;
        this.vbox1.Add(this.statusbar1);
        Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
        w10.Position = 3;
        w10.Expand = false;
        w10.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 594;
        this.DefaultHeight = 300;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
    }
}
