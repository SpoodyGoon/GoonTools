//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThudSharp {
    
    
    public partial class MainWindow {
        
        private Gtk.UIManager UIManager;
        
        private Gtk.Action GameAction;
        
        private Gtk.Action NewAction;
        
        private Gtk.Action QuitAction;
        
        private Gtk.Action HelpAction;
        
        private Gtk.Action AboutAction;
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Image imgLogo;
        
        private Gtk.MenuBar mbrMain;
        
        private Gtk.VSeparator vseparator1;
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.Fixed fixGameArea;
        
        private ThudSharp.GameBoard gameboard1;
        
        private Gtk.Statusbar stbMain;
        
        private Gtk.Label label3;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget ThudSharp.MainWindow
            this.UIManager = new Gtk.UIManager();
            Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
            this.GameAction = new Gtk.Action("GameAction", Mono.Unix.Catalog.GetString("Game"), null, null);
            this.GameAction.ShortLabel = Mono.Unix.Catalog.GetString("Game");
            w1.Add(this.GameAction, null);
            this.NewAction = new Gtk.Action("NewAction", Mono.Unix.Catalog.GetString("_New"), null, "gtk-new");
            this.NewAction.ShortLabel = Mono.Unix.Catalog.GetString("_New");
            w1.Add(this.NewAction, null);
            this.QuitAction = new Gtk.Action("QuitAction", Mono.Unix.Catalog.GetString("_Quit"), null, "gtk-quit");
            this.QuitAction.ShortLabel = Mono.Unix.Catalog.GetString("_Quit");
            w1.Add(this.QuitAction, null);
            this.HelpAction = new Gtk.Action("HelpAction", Mono.Unix.Catalog.GetString("Help"), null, null);
            this.HelpAction.ShortLabel = Mono.Unix.Catalog.GetString("Help");
            w1.Add(this.HelpAction, null);
            this.AboutAction = new Gtk.Action("AboutAction", Mono.Unix.Catalog.GetString("_About"), null, "gtk-about");
            this.AboutAction.ShortLabel = Mono.Unix.Catalog.GetString("_About");
            w1.Add(this.AboutAction, null);
            this.UIManager.InsertActionGroup(w1, 0);
            this.AddAccelGroup(this.UIManager.AccelGroup);
            this.Name = "ThudSharp.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("MainWindow");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child ThudSharp.MainWindow.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.imgLogo = new Gtk.Image();
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Pixbuf = Gdk.Pixbuf.LoadFromResource("InGameLogo.png");
            this.vbox2.Add(this.imgLogo);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.imgLogo]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.UIManager.AddUiFromString(@"<ui><menubar name='mbrMain'><menu name='GameAction' action='GameAction'><menuitem name='NewAction' action='NewAction'/><menuitem name='QuitAction' action='QuitAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='AboutAction' action='AboutAction'/></menu></menubar></ui>");
            this.mbrMain = ((Gtk.MenuBar)(this.UIManager.GetWidget("/mbrMain")));
            this.mbrMain.Name = "mbrMain";
            this.vbox2.Add(this.mbrMain);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.mbrMain]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            this.hbox1.Add(this.vbox2);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.vseparator1 = new Gtk.VSeparator();
            this.vseparator1.Name = "vseparator1";
            this.hbox1.Add(this.vseparator1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.hbox1[this.vseparator1]));
            w5.Position = 1;
            w5.Expand = false;
            w5.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.BorderWidth = ((uint)(2));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.BorderWidth = ((uint)(3));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.fixGameArea = new Gtk.Fixed();
            this.fixGameArea.Name = "fixGameArea";
            this.fixGameArea.HasWindow = false;
            // Container child fixGameArea.Gtk.Fixed+FixedChild
            this.gameboard1 = new ThudSharp.GameBoard();
            this.gameboard1.Events = ((Gdk.EventMask)(256));
            this.gameboard1.Name = "gameboard1";
            this.fixGameArea.Add(this.gameboard1);
            Gtk.Fixed.FixedChild w6 = ((Gtk.Fixed.FixedChild)(this.fixGameArea[this.gameboard1]));
            w6.X = 5;
            w6.Y = 5;
            this.GtkAlignment.Add(this.fixGameArea);
            this.frame1.Add(this.GtkAlignment);
            this.hbox1.Add(this.frame1);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox1[this.frame1]));
            w9.Position = 2;
            w9.Expand = false;
            w9.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w10.Position = 0;
            // Container child vbox1.Gtk.Box+BoxChild
            this.stbMain = new Gtk.Statusbar();
            this.stbMain.Name = "stbMain";
            this.stbMain.Spacing = 6;
            // Container child stbMain.Gtk.Box+BoxChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("label3");
            this.stbMain.Add(this.label3);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.stbMain[this.label3]));
            w11.Position = 1;
            w11.Expand = false;
            w11.Fill = false;
            this.vbox1.Add(this.stbMain);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.stbMain]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            w12.Padding = ((uint)(2));
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 1016;
            this.DefaultHeight = 773;
            this.Show();
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.NewAction.Activated += new System.EventHandler(this.OnNewActionActivated);
            this.QuitAction.Activated += new System.EventHandler(this.OnQuitActionActivated);
            this.AboutAction.Activated += new System.EventHandler(this.OnAboutActionActivated);
        }
    }
}
