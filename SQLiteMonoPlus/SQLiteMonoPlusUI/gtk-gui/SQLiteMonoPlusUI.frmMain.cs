
// This file has been generated by the GUI designer. Do not modify.
namespace SQLiteMonoPlusUI
{
	public partial class frmMain
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action FileAction;
		private global::Gtk.Action quitAction;
		private global::Gtk.Action NewQueryAction;
		private global::Gtk.Action NewAction;
		private global::Gtk.Action NewQueryAction1;
		private global::Gtk.Action connectAction;
		private global::Gtk.Action ExecuteAction;
		private global::Gtk.VBox vbox1;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.MenuBar menubar1;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Toolbar toolbar1;
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment2;
		private global::Gtk.HPaned hpaned1;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.Frame frame2;
		private global::Gtk.Alignment GtkAlignment3;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Fixed fixed1;
		private global::Gtk.Label label3;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Alignment alignment8;
		private global::Gtk.Toolbar toolbar2;
		private global::Gtk.Alignment algObjectExplorer;
		private global::Gtk.Alignment alignment6;
		private global::Gtk.Frame frame3;
		private global::Gtk.Alignment GtkAlignment5;
		private global::Gtk.Notebook nbQueryEditor;
		private global::Gtk.Label label2;
		private global::Gtk.Alignment alignment5;
		private global::Gtk.Statusbar statusbar1;
        
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget SQLiteMonoPlusUI.frmMain
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
			this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
			w1.Add (this.FileAction, null);
			this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("_Quit"), null, "gtk-quit");
			this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Quit");
			w1.Add (this.quitAction, null);
			this.NewQueryAction = new global::Gtk.Action ("NewQueryAction", global::Mono.Unix.Catalog.GetString ("New Query"), global::Mono.Unix.Catalog.GetString ("New Query"), "NewQuery");
			this.NewQueryAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("New Query");
			w1.Add (this.NewQueryAction, null);
			this.NewAction = new global::Gtk.Action ("NewAction", global::Mono.Unix.Catalog.GetString ("New"), null, null);
			this.NewAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("New");
			w1.Add (this.NewAction, null);
			this.NewQueryAction1 = new global::Gtk.Action ("NewQueryAction1", global::Mono.Unix.Catalog.GetString ("New Query"), null, "NewQuery");
			this.NewQueryAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("New Query");
			w1.Add (this.NewQueryAction1, null);
			this.connectAction = new global::Gtk.Action ("connectAction", null, null, "gtk-connect");
			w1.Add (this.connectAction, null);
			this.ExecuteAction = new global::Gtk.Action ("ExecuteAction", global::Mono.Unix.Catalog.GetString ("Execute"), global::Mono.Unix.Catalog.GetString ("Execute Query"), "ExecuteQuery");
			this.ExecuteAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Execute");
			w1.Add (this.ExecuteAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "SQLiteMonoPlusUI.frmMain";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child SQLiteMonoPlusUI.frmMain.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.UIManager.AddUiFromString ("<ui><menubar name=\'menubar1\'><menu name=\'FileAction\' action=\'FileAction\'><menu na" +
                    "me=\'NewAction\' action=\'NewAction\'><menuitem name=\'NewQueryAction1\' action=\'NewQu" +
                    "eryAction1\'/></menu><menuitem name=\'quitAction\' action=\'quitAction\'/></menu></me" +
                    "nubar></ui>");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.Name = "menubar1";
			this.alignment1.Add (this.menubar1);
			this.vbox1.Add (this.alignment1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.alignment1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			// Container child alignment2.Gtk.Container+ContainerChild
			this.UIManager.AddUiFromString ("<ui><toolbar name=\'toolbar1\'><toolitem name=\'NewQueryAction\' action=\'NewQueryActi" +
                    "on\'/><toolitem name=\'ExecuteAction\' action=\'ExecuteAction\'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.toolbar1.ToolbarStyle = ((global::Gtk.ToolbarStyle)(2));
			this.toolbar1.IconSize = ((global::Gtk.IconSize)(2));
			this.alignment2.Add (this.toolbar1);
			this.vbox1.Add (this.alignment2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.alignment2]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(1));
			this.frame1.BorderWidth = ((uint)(2));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment2.Name = "GtkAlignment2";
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.hpaned1 = new global::Gtk.HPaned ();
			this.hpaned1.CanFocus = true;
			this.hpaned1.Name = "hpaned1";
			this.hpaned1.Position = 320;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.frame2 = new global::Gtk.Frame ();
			this.frame2.Name = "frame2";
			this.frame2.ShadowType = ((global::Gtk.ShadowType)(1));
			this.frame2.BorderWidth = ((uint)(4));
			// Container child frame2.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			// Container child vbox2.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.HeightRequest = 20;
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Object Explorer:");
			this.fixed1.Add (this.label3);
			global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label3]));
			w6.X = 5;
			w6.Y = 3;
			this.vbox2.Add (this.fixed1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.fixed1]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			// Container child alignment3.Gtk.Container+ContainerChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.alignment3.Add (this.hseparator1);
			this.vbox2.Add (this.alignment3);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment3]));
			w9.Position = 1;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment8 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment8.Name = "alignment8";
			// Container child alignment8.Gtk.Container+ContainerChild
			this.UIManager.AddUiFromString ("<ui><toolbar name=\'toolbar2\'><toolitem name=\'connectAction\' action=\'connectAction" +
                    "\'/></toolbar></ui>");
			this.toolbar2 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar2")));
			this.toolbar2.Name = "toolbar2";
			this.toolbar2.ShowArrow = false;
			this.toolbar2.ToolbarStyle = ((global::Gtk.ToolbarStyle)(2));
			this.toolbar2.IconSize = ((global::Gtk.IconSize)(1));
			this.alignment8.Add (this.toolbar2);
			this.vbox2.Add (this.alignment8);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment8]));
			w11.Position = 2;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.algObjectExplorer = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.algObjectExplorer.Name = "algObjectExplorer";
			this.vbox2.Add (this.algObjectExplorer);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.algObjectExplorer]));
			w12.Position = 3;
			this.GtkAlignment3.Add (this.vbox2);
			this.frame2.Add (this.GtkAlignment3);
			this.alignment4.Add (this.frame2);
			this.hpaned1.Add (this.alignment4);
			global::Gtk.Paned.PanedChild w16 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.alignment4]));
			w16.Resize = false;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.frame3 = new global::Gtk.Frame ();
			this.frame3.Name = "frame3";
			this.frame3.ShadowType = ((global::Gtk.ShadowType)(1));
			this.frame3.BorderWidth = ((uint)(2));
			// Container child frame3.Gtk.Container+ContainerChild
			this.GtkAlignment5 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment5.Name = "GtkAlignment5";
			// Container child GtkAlignment5.Gtk.Container+ContainerChild
			this.nbQueryEditor = new global::Gtk.Notebook ();
			this.nbQueryEditor.CanFocus = true;
			this.nbQueryEditor.Name = "nbQueryEditor";
			this.nbQueryEditor.CurrentPage = 0;
			// Notebook tab
			global::Gtk.Label w17 = new global::Gtk.Label ();
			w17.Visible = true;
			this.nbQueryEditor.Add (w17);
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("page1");
			this.nbQueryEditor.SetTabLabel (w17, this.label2);
			this.label2.ShowAll ();
			this.GtkAlignment5.Add (this.nbQueryEditor);
			this.frame3.Add (this.GtkAlignment5);
			this.alignment6.Add (this.frame3);
			this.hpaned1.Add (this.alignment6);
			this.GtkAlignment2.Add (this.hpaned1);
			this.frame1.Add (this.GtkAlignment2);
			this.vbox1.Add (this.frame1);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.frame1]));
			w24.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.statusbar1 = new global::Gtk.Statusbar ();
			this.statusbar1.Name = "statusbar1";
			this.statusbar1.Spacing = 6;
			this.alignment5.Add (this.statusbar1);
			this.vbox1.Add (this.alignment5);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.alignment5]));
			w26.Position = 3;
			w26.Expand = false;
			w26.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 1113;
			this.DefaultHeight = 688;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.quitAction.Activated += new global::System.EventHandler (this.Quit_Clicked);
			this.connectAction.Activated += new global::System.EventHandler (this.btnConnect_Clicked);
		}
	}
}