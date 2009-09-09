//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3082
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonoBPMonitor {
    
    
    public partial class MainWindow {
        
        private Gtk.UIManager UIManager;
        
        private Gtk.Action FileAction;
        
        private Gtk.Action NewAction;
        
        private Gtk.Action MedicationAction;
        
        private Gtk.Action DoctorsAction;
        
        private Gtk.Action NewEntryAction;
        
        private Gtk.Action UsersAction;
        
        private Gtk.Action HelpAction;
        
        private Gtk.Action AboutAction;
        
        private Gtk.Action editaddPngAction;
        
        private Gtk.Action edituserPngAction;
        
        private Gtk.Action exitPngAction;
        
        private Gtk.Action aboutAction;
        
        private Gtk.Action QuitAction;
        
        private Gtk.Action preferencesAction;
        
        private Gtk.Action doctorPngAction;
        
        private Gtk.Action rxPngAction;
        
        private Gtk.Action ErrorLogAction;
        
        private Gtk.Action ToolsAction;
        
        private Gtk.Action BackupAction;
        
        private Gtk.Action RestoreAction;
        
        private Gtk.VBox vbox1;
        
        private Gtk.MenuBar menubar1;
        
        private Gtk.Toolbar toolbar1;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Label label1;
        
        private Gtk.Alignment alignment5;
        
        private MonoBPMonitor.Users.UserComboBox cboUser;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.ScrolledWindow swEntityRpt;
        
        private Gtk.Statusbar statusbar1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoBPMonitor.MainWindow
            this.UIManager = new Gtk.UIManager();
            Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
            this.FileAction = new Gtk.Action("FileAction", Mono.Unix.Catalog.GetString("File"), null, null);
            this.FileAction.ShortLabel = Mono.Unix.Catalog.GetString("File");
            w1.Add(this.FileAction, null);
            this.NewAction = new Gtk.Action("NewAction", Mono.Unix.Catalog.GetString("New"), null, null);
            this.NewAction.ShortLabel = Mono.Unix.Catalog.GetString("New");
            w1.Add(this.NewAction, null);
            this.MedicationAction = new Gtk.Action("MedicationAction", Mono.Unix.Catalog.GetString("Medication..."), null, "rx.png");
            this.MedicationAction.ShortLabel = Mono.Unix.Catalog.GetString("Medication...");
            w1.Add(this.MedicationAction, null);
            this.DoctorsAction = new Gtk.Action("DoctorsAction", Mono.Unix.Catalog.GetString("Doctors..."), null, "doctor.png");
            this.DoctorsAction.ShortLabel = Mono.Unix.Catalog.GetString("Doctors...");
            w1.Add(this.DoctorsAction, null);
            this.NewEntryAction = new Gtk.Action("NewEntryAction", Mono.Unix.Catalog.GetString("New Entry..."), null, "edit_add.png");
            this.NewEntryAction.ShortLabel = Mono.Unix.Catalog.GetString("New Entry...");
            w1.Add(this.NewEntryAction, null);
            this.UsersAction = new Gtk.Action("UsersAction", Mono.Unix.Catalog.GetString("Users..."), null, "edit_user.png");
            this.UsersAction.ShortLabel = Mono.Unix.Catalog.GetString("Users...");
            w1.Add(this.UsersAction, null);
            this.HelpAction = new Gtk.Action("HelpAction", Mono.Unix.Catalog.GetString("Help"), null, null);
            this.HelpAction.ShortLabel = Mono.Unix.Catalog.GetString("Help");
            w1.Add(this.HelpAction, null);
            this.AboutAction = new Gtk.Action("AboutAction", Mono.Unix.Catalog.GetString("About"), null, "gtk-about");
            this.AboutAction.ShortLabel = Mono.Unix.Catalog.GetString("About");
            w1.Add(this.AboutAction, null);
            this.editaddPngAction = new Gtk.Action("editaddPngAction", null, null, "edit_add.png");
            w1.Add(this.editaddPngAction, null);
            this.edituserPngAction = new Gtk.Action("edituserPngAction", null, null, "edit_user.png");
            w1.Add(this.edituserPngAction, null);
            this.exitPngAction = new Gtk.Action("exitPngAction", null, null, "exit.png");
            w1.Add(this.exitPngAction, null);
            this.aboutAction = new Gtk.Action("aboutAction", null, null, "gtk-about");
            w1.Add(this.aboutAction, null);
            this.QuitAction = new Gtk.Action("QuitAction", Mono.Unix.Catalog.GetString("Quit"), null, "exit.png");
            this.QuitAction.ShortLabel = Mono.Unix.Catalog.GetString("Quit");
            w1.Add(this.QuitAction, null);
            this.preferencesAction = new Gtk.Action("preferencesAction", null, null, "gtk-preferences");
            w1.Add(this.preferencesAction, null);
            this.doctorPngAction = new Gtk.Action("doctorPngAction", null, null, "doctor.png");
            w1.Add(this.doctorPngAction, null);
            this.rxPngAction = new Gtk.Action("rxPngAction", null, null, "rx.png");
            w1.Add(this.rxPngAction, null);
            this.ErrorLogAction = new Gtk.Action("ErrorLogAction", Mono.Unix.Catalog.GetString("Error Log"), null, "gtk-dialog-error");
            this.ErrorLogAction.ShortLabel = Mono.Unix.Catalog.GetString("Error Log");
            w1.Add(this.ErrorLogAction, null);
            this.ToolsAction = new Gtk.Action("ToolsAction", Mono.Unix.Catalog.GetString("Tools"), null, null);
            this.ToolsAction.ShortLabel = Mono.Unix.Catalog.GetString("Tools");
            w1.Add(this.ToolsAction, null);
            this.BackupAction = new Gtk.Action("BackupAction", Mono.Unix.Catalog.GetString("Backup"), null, null);
            this.BackupAction.ShortLabel = Mono.Unix.Catalog.GetString("Backup");
            w1.Add(this.BackupAction, null);
            this.RestoreAction = new Gtk.Action("RestoreAction", Mono.Unix.Catalog.GetString("Restore"), null, null);
            this.RestoreAction.ShortLabel = Mono.Unix.Catalog.GetString("Restore");
            w1.Add(this.RestoreAction, null);
            this.UIManager.InsertActionGroup(w1, 0);
            this.AddAccelGroup(this.UIManager.AccelGroup);
            this.WidthRequest = 750;
            this.HeightRequest = 575;
            this.Name = "MonoBPMonitor.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("Blood Presure Monitor");
            this.Icon = Gdk.Pixbuf.LoadFromResource("icon_small.png");
            this.WindowPosition = ((Gtk.WindowPosition)(1));
            this.BorderWidth = ((uint)(3));
            this.AllowShrink = true;
            this.DefaultWidth = 750;
            this.DefaultHeight = 575;
            // Container child MonoBPMonitor.MainWindow.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='NewEntryAction' action='NewEntryAction'/><menuitem name='MedicationAction' action='MedicationAction'/><menuitem name='DoctorsAction' action='DoctorsAction'/><menuitem name='UsersAction' action='UsersAction'/><menuitem name='QuitAction' action='QuitAction'/></menu><menu name='ToolsAction' action='ToolsAction'><menuitem name='BackupAction' action='BackupAction'/><menuitem name='RestoreAction' action='RestoreAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='ErrorLogAction' action='ErrorLogAction'/><menuitem name='AboutAction' action='AboutAction'/></menu></menubar></ui>");
            this.menubar1 = ((Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
            this.menubar1.Name = "menubar1";
            this.vbox1.Add(this.menubar1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.UIManager.AddUiFromString(@"<ui><toolbar name='toolbar1'><toolitem name='editaddPngAction' action='editaddPngAction'/><toolitem name='edituserPngAction' action='edituserPngAction'/><toolitem name='rxPngAction' action='rxPngAction'/><toolitem name='doctorPngAction' action='doctorPngAction'/><separator/><toolitem name='preferencesAction' action='preferencesAction'/><toolitem name='aboutAction' action='aboutAction'/><separator/><toolitem name='exitPngAction' action='exitPngAction'/></toolbar></ui>");
            this.toolbar1 = ((Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.ShowArrow = false;
            this.toolbar1.ToolbarStyle = ((Gtk.ToolbarStyle)(0));
            this.toolbar1.IconSize = ((Gtk.IconSize)(2));
            this.vbox1.Add(this.toolbar1);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox1[this.toolbar1]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            this.alignment1.TopPadding = ((uint)(2));
            this.alignment1.BottomPadding = ((uint)(2));
            // Container child alignment1.Gtk.Container+ContainerChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.alignment1.Add(this.hseparator1);
            this.vbox1.Add(this.alignment1);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
            w5.Position = 2;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Homogeneous = true;
            this.hbox1.Spacing = 57;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.05F, 0.5F, 0.01F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("<b>Double Click on an reading to change it.</b>");
            this.label1.UseMarkup = true;
            this.label1.SingleLineMode = true;
            this.alignment4.Add(this.label1);
            this.hbox1.Add(this.alignment4);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment4]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.alignment5 = new Gtk.Alignment(0.98F, 0.5F, 0.01F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.cboUser = new MonoBPMonitor.Users.UserComboBox();
            this.cboUser.WidthRequest = 200;
            this.cboUser.Name = "cboUser";
            this.alignment5.Add(this.cboUser);
            this.hbox1.Add(this.alignment5);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.hbox1[this.alignment5]));
            w9.Position = 1;
            w9.Expand = false;
            w9.Fill = false;
            this.alignment2.Add(this.hbox1);
            this.vbox1.Add(this.alignment2);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment2]));
            w11.Position = 3;
            w11.Expand = false;
            w11.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.swEntityRpt = new Gtk.ScrolledWindow();
            this.swEntityRpt.CanFocus = true;
            this.swEntityRpt.Name = "swEntityRpt";
            this.swEntityRpt.ShadowType = ((Gtk.ShadowType)(1));
            this.alignment3.Add(this.swEntityRpt);
            this.vbox1.Add(this.alignment3);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment3]));
            w13.Position = 4;
            // Container child vbox1.Gtk.Box+BoxChild
            this.statusbar1 = new Gtk.Statusbar();
            this.statusbar1.Name = "statusbar1";
            this.statusbar1.Spacing = 6;
            this.vbox1.Add(this.statusbar1);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
            w14.Position = 5;
            w14.Expand = false;
            w14.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Show();
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.MedicationAction.Activated += new System.EventHandler(this.OnMedicationActionActivated);
            this.DoctorsAction.Activated += new System.EventHandler(this.OnDoctorsActionActivated);
            this.NewEntryAction.Activated += new System.EventHandler(this.OnNewEntryActionActivated);
            this.UsersAction.Activated += new System.EventHandler(this.OnUsersActionActivated);
            this.AboutAction.Activated += new System.EventHandler(this.OnAboutActionActivated);
            this.editaddPngAction.Activated += new System.EventHandler(this.OnEditaddPngActionActivated);
            this.edituserPngAction.Activated += new System.EventHandler(this.OnEdituserPngActionActivated);
            this.exitPngAction.Activated += new System.EventHandler(this.OnExitPngActionActivated);
            this.aboutAction.Activated += new System.EventHandler(this.OnAboutActionActivated);
            this.QuitAction.Activated += new System.EventHandler(this.OnQuitActionActivated);
            this.preferencesAction.Activated += new System.EventHandler(this.OnPreferencesActionActivated);
            this.doctorPngAction.Activated += new System.EventHandler(this.OnDoctorPngActionActivated);
            this.rxPngAction.Activated += new System.EventHandler(this.OnRxPngActionActivated);
            this.ErrorLogAction.Activated += new System.EventHandler(this.OnErrorLogActionActivated);
            this.BackupAction.Activated += new System.EventHandler(this.OnBackupActionActivated);
            this.RestoreAction.Activated += new System.EventHandler(this.OnRestoreActionActivated);
        }
    }
}
