//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonoPad {
    
    
    public partial class MonoPad {
        
        private Gtk.UIManager UIManager;
        
        private Gtk.Action FileAction;
        
        private Gtk.Action NewAction;
        
        private Gtk.Action SaveAction;
        
        private Gtk.Action OpenAction;
        
        private Gtk.Action SaveAsAction;
        
        private Gtk.Action QuitAction;
        
        private Gtk.Action HelpAction;
        
        private Gtk.Action aboutAction;
        
        private Gtk.Action EditAction;
        
        private Gtk.Action copyAction;
        
        private Gtk.Action cutAction;
        
        private Gtk.Action pasteAction;
        
        private Gtk.Action ClearAction;
        
        private Gtk.Action BoldAction;
        
        private Gtk.Action ItalicAction;
        
        private Gtk.Action UnderlineAction;
        
        private Gtk.Action StrikeThroughAction;
        
        private Gtk.Action BlockAction;
        
        private Gtk.Action AlignLeftAction;
        
        private Gtk.Action selectAllAction;
        
        private Gtk.Action ViewAction;
        
        private Gtk.ToggleAction ToolbarAction;
        
        private Gtk.ToggleAction FormatBarAction;
        
        private Gtk.ToggleAction MiscAction;
        
        private Gtk.Action AlignLeftAction1;
        
        private Gtk.Action AlignCenterAction;
        
        private Gtk.Action AlignRightAction;
        
        private Gtk.Action FontSelectionAction;
        
        private Gtk.Action ToolsAction;
        
        private Gtk.Action OptionsAction;
        
        private Gtk.Action ToolbarsAction;
        
        private Gtk.Action EditorLayoutAction;
        
        private Gtk.RadioAction SimpleTextAction;
        
        private Gtk.Action iconsmallPngAction;
        
        private Gtk.Action Action;
        
        private Gtk.VBox vbox1;
        
        private Gtk.Alignment alignment1;
        
        private Gtk.MenuBar menubar1;
        
        private Gtk.Alignment alignment2;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Alignment alignment3;
        
        private Gtk.Toolbar tbrToolbar;
        
        private Gtk.Alignment alignment4;
        
        private Gtk.Toolbar tbrFormatBar;
        
        private Gtk.Alignment alignment6;
        
        private Gtk.Toolbar tbrMisc;
        
        private Gtk.Alignment alignment5;
        
        private Gtk.ScrolledWindow swEditor;
        
        private Gtk.Alignment algEditor;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget MonoPad.MonoPad
            Stetic.BinContainer w1 = Stetic.BinContainer.Attach(this);
            this.UIManager = new Gtk.UIManager();
            Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
            this.FileAction = new Gtk.Action("FileAction", Mono.Unix.Catalog.GetString("File"), null, null);
            this.FileAction.ShortLabel = Mono.Unix.Catalog.GetString("File");
            w2.Add(this.FileAction, null);
            this.NewAction = new Gtk.Action("NewAction", Mono.Unix.Catalog.GetString("_New"), null, "filenew.png");
            this.NewAction.ShortLabel = Mono.Unix.Catalog.GetString("_New");
            w2.Add(this.NewAction, null);
            this.SaveAction = new Gtk.Action("SaveAction", Mono.Unix.Catalog.GetString("_Save"), null, "filesave.png");
            this.SaveAction.ShortLabel = Mono.Unix.Catalog.GetString("_Save");
            w2.Add(this.SaveAction, null);
            this.OpenAction = new Gtk.Action("OpenAction", Mono.Unix.Catalog.GetString("_Open"), null, "fileopen.png");
            this.OpenAction.ShortLabel = Mono.Unix.Catalog.GetString("_Open");
            w2.Add(this.OpenAction, null);
            this.SaveAsAction = new Gtk.Action("SaveAsAction", Mono.Unix.Catalog.GetString("Save  _As"), null, "filesaveas.png");
            this.SaveAsAction.ShortLabel = Mono.Unix.Catalog.GetString("Save  _As");
            w2.Add(this.SaveAsAction, null);
            this.QuitAction = new Gtk.Action("QuitAction", Mono.Unix.Catalog.GetString("_Quit"), null, "exit.png");
            this.QuitAction.ShortLabel = Mono.Unix.Catalog.GetString("_Quit");
            w2.Add(this.QuitAction, null);
            this.HelpAction = new Gtk.Action("HelpAction", Mono.Unix.Catalog.GetString("_Help"), null, null);
            this.HelpAction.ShortLabel = Mono.Unix.Catalog.GetString("_Help");
            w2.Add(this.HelpAction, null);
            this.aboutAction = new Gtk.Action("aboutAction", Mono.Unix.Catalog.GetString("_About"), null, "gtk-about");
            this.aboutAction.ShortLabel = Mono.Unix.Catalog.GetString("_About");
            w2.Add(this.aboutAction, null);
            this.EditAction = new Gtk.Action("EditAction", Mono.Unix.Catalog.GetString("_Edit"), null, null);
            this.EditAction.ShortLabel = Mono.Unix.Catalog.GetString("_Edit");
            w2.Add(this.EditAction, null);
            this.copyAction = new Gtk.Action("copyAction", Mono.Unix.Catalog.GetString("_Copy"), null, "gtk-copy");
            this.copyAction.ShortLabel = Mono.Unix.Catalog.GetString("_Copy");
            w2.Add(this.copyAction, null);
            this.cutAction = new Gtk.Action("cutAction", Mono.Unix.Catalog.GetString("Cu_t"), null, "gtk-cut");
            this.cutAction.ShortLabel = Mono.Unix.Catalog.GetString("Cu_t");
            w2.Add(this.cutAction, null);
            this.pasteAction = new Gtk.Action("pasteAction", Mono.Unix.Catalog.GetString("_Paste"), null, "gtk-paste");
            this.pasteAction.ShortLabel = Mono.Unix.Catalog.GetString("_Paste");
            w2.Add(this.pasteAction, null);
            this.ClearAction = new Gtk.Action("ClearAction", Mono.Unix.Catalog.GetString("_Clear"), null, "edit-clear.png");
            this.ClearAction.ShortLabel = Mono.Unix.Catalog.GetString("_Clear");
            w2.Add(this.ClearAction, null);
            this.BoldAction = new Gtk.Action("BoldAction", Mono.Unix.Catalog.GetString("_Bold"), null, "format-text-bold.png");
            this.BoldAction.ShortLabel = Mono.Unix.Catalog.GetString("_Bold");
            w2.Add(this.BoldAction, null);
            this.ItalicAction = new Gtk.Action("ItalicAction", Mono.Unix.Catalog.GetString("_Italic"), null, "format-text-italic.png");
            this.ItalicAction.ShortLabel = Mono.Unix.Catalog.GetString("_Italic");
            w2.Add(this.ItalicAction, null);
            this.UnderlineAction = new Gtk.Action("UnderlineAction", Mono.Unix.Catalog.GetString("_Underline"), null, "format-text-underline.png");
            this.UnderlineAction.ShortLabel = Mono.Unix.Catalog.GetString("_Underline");
            w2.Add(this.UnderlineAction, null);
            this.StrikeThroughAction = new Gtk.Action("StrikeThroughAction", Mono.Unix.Catalog.GetString("Strike Through"), null, "format-text-strikethrough.png");
            this.StrikeThroughAction.ShortLabel = Mono.Unix.Catalog.GetString("Strike Through");
            w2.Add(this.StrikeThroughAction, null);
            this.BlockAction = new Gtk.Action("BlockAction", Mono.Unix.Catalog.GetString("Block"), null, "text_block.png");
            this.BlockAction.ShortLabel = Mono.Unix.Catalog.GetString("Block");
            w2.Add(this.BlockAction, null);
            this.AlignLeftAction = new Gtk.Action("AlignLeftAction", Mono.Unix.Catalog.GetString("Align Left"), null, "text_left.png");
            this.AlignLeftAction.ShortLabel = Mono.Unix.Catalog.GetString("Align Left");
            w2.Add(this.AlignLeftAction, null);
            this.selectAllAction = new Gtk.Action("selectAllAction", null, null, "gtk-select-all");
            w2.Add(this.selectAllAction, null);
            this.ViewAction = new Gtk.Action("ViewAction", Mono.Unix.Catalog.GetString("View"), null, null);
            this.ViewAction.ShortLabel = Mono.Unix.Catalog.GetString("View");
            w2.Add(this.ViewAction, null);
            this.ToolbarAction = new Gtk.ToggleAction("ToolbarAction", Mono.Unix.Catalog.GetString("Toolbar"), null, null);
            this.ToolbarAction.Active = true;
            this.ToolbarAction.ShortLabel = Mono.Unix.Catalog.GetString("Toolbar");
            w2.Add(this.ToolbarAction, null);
            this.FormatBarAction = new Gtk.ToggleAction("FormatBarAction", Mono.Unix.Catalog.GetString("Format Bar"), null, null);
            this.FormatBarAction.Active = true;
            this.FormatBarAction.ShortLabel = Mono.Unix.Catalog.GetString("Format Bar");
            w2.Add(this.FormatBarAction, null);
            this.MiscAction = new Gtk.ToggleAction("MiscAction", Mono.Unix.Catalog.GetString("Misc"), null, null);
            this.MiscAction.Active = true;
            this.MiscAction.ShortLabel = Mono.Unix.Catalog.GetString("Misc");
            w2.Add(this.MiscAction, null);
            this.AlignLeftAction1 = new Gtk.Action("AlignLeftAction1", Mono.Unix.Catalog.GetString("Align Left"), null, "text_left.png");
            this.AlignLeftAction1.ShortLabel = Mono.Unix.Catalog.GetString("Align Left");
            w2.Add(this.AlignLeftAction1, null);
            this.AlignCenterAction = new Gtk.Action("AlignCenterAction", Mono.Unix.Catalog.GetString("Align Center"), null, "text_center.png");
            this.AlignCenterAction.ShortLabel = Mono.Unix.Catalog.GetString("Align Center");
            w2.Add(this.AlignCenterAction, null);
            this.AlignRightAction = new Gtk.Action("AlignRightAction", Mono.Unix.Catalog.GetString("Align Right"), null, "text_right.png");
            this.AlignRightAction.ShortLabel = Mono.Unix.Catalog.GetString("Align Right");
            w2.Add(this.AlignRightAction, null);
            this.FontSelectionAction = new Gtk.Action("FontSelectionAction", Mono.Unix.Catalog.GetString("Font Selection"), null, "font_select.png");
            this.FontSelectionAction.ShortLabel = Mono.Unix.Catalog.GetString("Font Selection");
            w2.Add(this.FontSelectionAction, null);
            this.ToolsAction = new Gtk.Action("ToolsAction", Mono.Unix.Catalog.GetString("Tools"), null, null);
            this.ToolsAction.ShortLabel = Mono.Unix.Catalog.GetString("Tools");
            w2.Add(this.ToolsAction, null);
            this.OptionsAction = new Gtk.Action("OptionsAction", Mono.Unix.Catalog.GetString("Options"), null, "configure.png");
            this.OptionsAction.ShortLabel = Mono.Unix.Catalog.GetString("Options");
            w2.Add(this.OptionsAction, null);
            this.ToolbarsAction = new Gtk.Action("ToolbarsAction", Mono.Unix.Catalog.GetString("Toolbars"), null, null);
            this.ToolbarsAction.ShortLabel = Mono.Unix.Catalog.GetString("Toolbars");
            w2.Add(this.ToolbarsAction, null);
            this.EditorLayoutAction = new Gtk.Action("EditorLayoutAction", Mono.Unix.Catalog.GetString("Editor Layout"), null, null);
            this.EditorLayoutAction.ShortLabel = Mono.Unix.Catalog.GetString("Editor Layout");
            w2.Add(this.EditorLayoutAction, null);
            this.SimpleTextAction = new Gtk.RadioAction("SimpleTextAction", Mono.Unix.Catalog.GetString("Simple Text"), null, "simple_text.png", 1);
            this.SimpleTextAction.Group = new GLib.SList(System.IntPtr.Zero);
            this.SimpleTextAction.ShortLabel = Mono.Unix.Catalog.GetString("Simple Text");
            w2.Add(this.SimpleTextAction, null);
            this.iconsmallPngAction = new Gtk.Action("iconsmallPngAction", null, null, "icon_small.png");
            w2.Add(this.iconsmallPngAction, null);
            this.Action = new Gtk.Action("Action", null, null, null);
            w2.Add(this.Action, null);
            this.UIManager.InsertActionGroup(w2, 0);
            this.Name = "MonoPad.MonoPad";
            // Container child MonoPad.MonoPad.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 1;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment1 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment1.Name = "alignment1";
            // Container child alignment1.Gtk.Container+ContainerChild
            this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='NewAction' action='NewAction'/><menuitem name='OpenAction' action='OpenAction'/><menuitem name='SaveAction' action='SaveAction'/><menuitem name='SaveAsAction' action='SaveAsAction'/><separator/><menuitem name='QuitAction' action='QuitAction'/></menu><menu name='EditAction' action='EditAction'><menuitem name='copyAction' action='copyAction'/><menuitem name='cutAction' action='cutAction'/><menuitem name='pasteAction' action='pasteAction'/><separator/><menuitem name='selectAllAction' action='selectAllAction'/><menuitem name='ClearAction' action='ClearAction'/></menu><menu name='ViewAction' action='ViewAction'><menu name='ToolbarsAction' action='ToolbarsAction'><menuitem name='FormatBarAction' action='FormatBarAction'/><menuitem name='ToolbarAction' action='ToolbarAction'/><menuitem name='MiscAction' action='MiscAction'/></menu><menu name='EditorLayoutAction' action='EditorLayoutAction'/></menu><menu name='ToolsAction' action='ToolsAction'><menuitem name='OptionsAction' action='OptionsAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='aboutAction' action='aboutAction'/></menu></menubar></ui>");
            this.menubar1 = ((Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
            this.menubar1.CanFocus = true;
            this.menubar1.Name = "menubar1";
            this.alignment1.Add(this.menubar1);
            this.vbox1.Add(this.alignment1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment2 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment2.Name = "alignment2";
            // Container child alignment2.Gtk.Container+ContainerChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 1;
            this.vbox2.BorderWidth = ((uint)(2));
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment3 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment3.Name = "alignment3";
            // Container child alignment3.Gtk.Container+ContainerChild
            this.UIManager.AddUiFromString(@"<ui><toolbar name='tbrToolbar'><toolitem name='NewAction' action='NewAction'/><toolitem name='OpenAction' action='OpenAction'/><toolitem name='SaveAction' action='SaveAction'/><toolitem name='SaveAsAction' action='SaveAsAction'/><separator/><toolitem name='OptionsAction' action='OptionsAction'/><toolitem name='aboutAction' action='aboutAction'/><toolitem name='QuitAction' action='QuitAction'/></toolbar></ui>");
            this.tbrToolbar = ((Gtk.Toolbar)(this.UIManager.GetWidget("/tbrToolbar")));
            this.tbrToolbar.Name = "tbrToolbar";
            this.tbrToolbar.ShowArrow = false;
            this.tbrToolbar.ToolbarStyle = ((Gtk.ToolbarStyle)(2));
            this.tbrToolbar.IconSize = ((Gtk.IconSize)(2));
            this.alignment3.Add(this.tbrToolbar);
            this.vbox2.Add(this.alignment3);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment3]));
            w6.Position = 0;
            w6.Expand = false;
            w6.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment4 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment4.Name = "alignment4";
            // Container child alignment4.Gtk.Container+ContainerChild
            this.UIManager.AddUiFromString(@"<ui><toolbar name='tbrFormatBar'><toolitem name='BoldAction' action='BoldAction'/><toolitem name='ItalicAction' action='ItalicAction'/><toolitem name='UnderlineAction' action='UnderlineAction'/><toolitem name='StrikeThroughAction' action='StrikeThroughAction'/><separator/><toolitem name='BlockAction' action='BlockAction'/><toolitem name='AlignLeftAction' action='AlignLeftAction'/><toolitem name='AlignCenterAction' action='AlignCenterAction'/><toolitem name='AlignRightAction' action='AlignRightAction'/><separator/><toolitem name='selectAllAction' action='selectAllAction'/><toolitem name='ClearAction' action='ClearAction'/></toolbar></ui>");
            this.tbrFormatBar = ((Gtk.Toolbar)(this.UIManager.GetWidget("/tbrFormatBar")));
            this.tbrFormatBar.Name = "tbrFormatBar";
            this.tbrFormatBar.ShowArrow = false;
            this.tbrFormatBar.ToolbarStyle = ((Gtk.ToolbarStyle)(2));
            this.tbrFormatBar.IconSize = ((Gtk.IconSize)(2));
            this.alignment4.Add(this.tbrFormatBar);
            this.vbox2.Add(this.alignment4);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment4]));
            w8.Position = 1;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.alignment6 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment6.Name = "alignment6";
            // Container child alignment6.Gtk.Container+ContainerChild
            this.UIManager.AddUiFromString("<ui><toolbar name=\'tbrMisc\'><toolitem name=\'FontSelectionAction\' action=\'FontSele" +
                    "ctionAction\'/><separator/><toolitem name=\'iconsmallPngAction\' action=\'iconsmallP" +
                    "ngAction\'/><toolitem name=\'Action\' action=\'Action\'/></toolbar></ui>");
            this.tbrMisc = ((Gtk.Toolbar)(this.UIManager.GetWidget("/tbrMisc")));
            this.tbrMisc.Name = "tbrMisc";
            this.tbrMisc.ShowArrow = false;
            this.tbrMisc.ToolbarStyle = ((Gtk.ToolbarStyle)(2));
            this.tbrMisc.IconSize = ((Gtk.IconSize)(2));
            this.alignment6.Add(this.tbrMisc);
            this.vbox2.Add(this.alignment6);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox2[this.alignment6]));
            w10.PackType = ((Gtk.PackType)(1));
            w10.Position = 2;
            w10.Expand = false;
            w10.Fill = false;
            this.alignment2.Add(this.vbox2);
            this.vbox1.Add(this.alignment2);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment2]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.alignment5 = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.alignment5.Name = "alignment5";
            // Container child alignment5.Gtk.Container+ContainerChild
            this.swEditor = new Gtk.ScrolledWindow();
            this.swEditor.CanFocus = true;
            this.swEditor.Name = "swEditor";
            this.swEditor.ShadowType = ((Gtk.ShadowType)(3));
            this.swEditor.BorderWidth = ((uint)(4));
            // Container child swEditor.Gtk.Container+ContainerChild
            Gtk.Viewport w13 = new Gtk.Viewport();
            w13.ShadowType = ((Gtk.ShadowType)(0));
            // Container child GtkViewport.Gtk.Container+ContainerChild
            this.algEditor = new Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
            this.algEditor.Name = "algEditor";
            w13.Add(this.algEditor);
            this.swEditor.Add(w13);
            this.alignment5.Add(this.swEditor);
            this.vbox1.Add(this.alignment5);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox1[this.alignment5]));
            w17.Position = 2;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            w1.SetUiManager(UIManager);
            this.Hide();
            this.NewAction.Activated += new System.EventHandler(this.OnNewActionActivated);
            this.SaveAction.Activated += new System.EventHandler(this.OnSaveActionActivated);
            this.OpenAction.Activated += new System.EventHandler(this.OnOpenActionActivated);
            this.SaveAsAction.Activated += new System.EventHandler(this.OnSaveAsActionActivated);
            this.QuitAction.Activated += new System.EventHandler(this.OnQuitActionActivated);
            this.aboutAction.Activated += new System.EventHandler(this.OnAboutActionActivated);
            this.copyAction.Activated += new System.EventHandler(this.OnCopyActionActivated);
            this.cutAction.Activated += new System.EventHandler(this.OnCutActionActivated);
            this.pasteAction.Activated += new System.EventHandler(this.OnPasteActionActivated);
            this.ClearAction.Activated += new System.EventHandler(this.OnClearActionActivated);
            this.BoldAction.Activated += new System.EventHandler(this.OnBoldActionActivated);
            this.ItalicAction.Activated += new System.EventHandler(this.OnItalicActionActivated);
            this.UnderlineAction.Activated += new System.EventHandler(this.OnUnderlineActionActivated);
            this.StrikeThroughAction.Activated += new System.EventHandler(this.OnStrikeThroughActionActivated);
            this.BlockAction.Activated += new System.EventHandler(this.OnBlockActionActivated);
            this.selectAllAction.Activated += new System.EventHandler(this.OnSelectAllActionActivated);
            this.ToolbarAction.Toggled += new System.EventHandler(this.OnToolbarActionToggled);
            this.FormatBarAction.Toggled += new System.EventHandler(this.OnFormatBarActionToggled);
            this.MiscAction.Toggled += new System.EventHandler(this.OnMiscActionToggled);
            this.AlignLeftAction1.Activated += new System.EventHandler(this.OnAlignLeftActionActivated);
            this.AlignCenterAction.Activated += new System.EventHandler(this.OnAlignCenterActionActivated);
            this.AlignRightAction.Activated += new System.EventHandler(this.OnAlignRightActionActivated);
            this.FontSelectionAction.Activated += new System.EventHandler(this.OnFontSelectionActionActivated);
            this.OptionsAction.Activated += new System.EventHandler(this.OnOptionsActionActivated);
        }
    }
}
