// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace BookmarkSharpClient {
    
    
    public partial class frmOptions {
        
        private Gtk.VBox vbox2;
        
        private Gtk.Label label1;
        
        private Gtk.HSeparator hseparator2;
        
        private Gtk.Notebook notebook1;
        
        private Gtk.Table table1;
        
        private Gtk.Label label4;
        
        private Gtk.Label label8;
        
        private Gtk.Label label9;
        
        private Gtk.Entry txtLastBookmarkUpdate;
        
        private Gtk.Entry txtLastTagUpdate;
        
        private Gtk.Entry txtPassword;
        
        private Gtk.Label label2;
        
        private Gtk.VBox vbox4;
        
        private Gtk.Label label7;
        
        private Gtk.HSeparator hseparator4;
        
        private Gtk.ScrolledWindow swTags;
        
        private Gtk.HButtonBox hbuttonbox3;
        
        private Gtk.Button cmdOpenTagsEditor;
        
        private Gtk.Label label6;
        
        private Gtk.VBox vbox3;
        
        private Gtk.Label label5;
        
        private Gtk.HSeparator hseparator3;
        
        private Gtk.ScrolledWindow swBrowserList;
        
        private Gtk.HButtonBox hbuttonbox2;
        
        private Gtk.Button cmdAddBrowser;
        
        private Gtk.Button cmdRemoveBrowser;
        
        private Gtk.Label label3;
        
        private Gtk.HSeparator hseparator1;
        
        private Gtk.Button buttonCancel;
        
        private Gtk.Button buttonOk;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget BookmarkSharpClient.frmOptions
            this.Name = "BookmarkSharpClient.frmOptions";
            this.Title = Mono.Unix.Catalog.GetString("Options");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            this.HasSeparator = false;
            // Internal child BookmarkSharpClient.frmOptions.VBox
            Gtk.VBox w1 = this.VBox;
            w1.Name = "dialog1_VBox";
            w1.BorderWidth = ((uint)(2));
            // Container child dialog1_VBox.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("<big><b>Options</b></big>");
            this.label1.UseMarkup = true;
            this.vbox2.Add(this.label1);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox2[this.label1]));
            w2.Position = 0;
            w2.Expand = false;
            w2.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hseparator2 = new Gtk.HSeparator();
            this.hseparator2.Name = "hseparator2";
            this.vbox2.Add(this.hseparator2);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.vbox2[this.hseparator2]));
            w3.Position = 1;
            w3.Expand = false;
            w3.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.notebook1 = new Gtk.Notebook();
            this.notebook1.CanFocus = true;
            this.notebook1.Name = "notebook1";
            this.notebook1.CurrentPage = 0;
            this.notebook1.Scrollable = true;
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.table1 = new Gtk.Table(((uint)(3)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            this.table1.BorderWidth = ((uint)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Last Bookmark Update:");
            this.table1.Add(this.label4);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.label4]));
            w4.TopAttach = ((uint)(2));
            w4.BottomAttach = ((uint)(3));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Password:");
            this.table1.Add(this.label8);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.label8]));
            w5.XPadding = ((uint)(11));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label9 = new Gtk.Label();
            this.label9.Name = "label9";
            this.label9.LabelProp = Mono.Unix.Catalog.GetString("Last Tag Update:");
            this.table1.Add(this.label9);
            Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.label9]));
            w6.TopAttach = ((uint)(1));
            w6.BottomAttach = ((uint)(2));
            w6.XOptions = ((Gtk.AttachOptions)(4));
            w6.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.txtLastBookmarkUpdate = new Gtk.Entry();
            this.txtLastBookmarkUpdate.CanFocus = true;
            this.txtLastBookmarkUpdate.Name = "txtLastBookmarkUpdate";
            this.txtLastBookmarkUpdate.IsEditable = false;
            this.txtLastBookmarkUpdate.InvisibleChar = '●';
            this.table1.Add(this.txtLastBookmarkUpdate);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.txtLastBookmarkUpdate]));
            w7.TopAttach = ((uint)(2));
            w7.BottomAttach = ((uint)(3));
            w7.LeftAttach = ((uint)(1));
            w7.RightAttach = ((uint)(2));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.txtLastTagUpdate = new Gtk.Entry();
            this.txtLastTagUpdate.CanFocus = true;
            this.txtLastTagUpdate.Name = "txtLastTagUpdate";
            this.txtLastTagUpdate.IsEditable = false;
            this.txtLastTagUpdate.InvisibleChar = '●';
            this.table1.Add(this.txtLastTagUpdate);
            Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.txtLastTagUpdate]));
            w8.TopAttach = ((uint)(1));
            w8.BottomAttach = ((uint)(2));
            w8.LeftAttach = ((uint)(1));
            w8.RightAttach = ((uint)(2));
            w8.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.txtPassword = new Gtk.Entry();
            this.txtPassword.CanFocus = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.IsEditable = true;
            this.txtPassword.InvisibleChar = '●';
            this.table1.Add(this.txtPassword);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.txtPassword]));
            w9.LeftAttach = ((uint)(1));
            w9.RightAttach = ((uint)(2));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            this.notebook1.Add(this.table1);
            // Notebook tab
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Set Up");
            this.notebook1.SetTabLabel(this.table1, this.label2);
            this.label2.ShowAll();
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            this.vbox4.BorderWidth = ((uint)(5));
            // Container child vbox4.Gtk.Box+BoxChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("<b>Filtering Tags</b>");
            this.label7.UseMarkup = true;
            this.vbox4.Add(this.label7);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.vbox4[this.label7]));
            w11.Position = 0;
            w11.Expand = false;
            w11.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hseparator4 = new Gtk.HSeparator();
            this.hseparator4.Name = "hseparator4";
            this.vbox4.Add(this.hseparator4);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.vbox4[this.hseparator4]));
            w12.Position = 1;
            w12.Expand = false;
            w12.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.swTags = new Gtk.ScrolledWindow();
            this.swTags.CanFocus = true;
            this.swTags.Name = "swTags";
            this.swTags.ShadowType = ((Gtk.ShadowType)(1));
            this.vbox4.Add(this.swTags);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.vbox4[this.swTags]));
            w13.Position = 2;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hbuttonbox3 = new Gtk.HButtonBox();
            this.hbuttonbox3.Name = "hbuttonbox3";
            // Container child hbuttonbox3.Gtk.ButtonBox+ButtonBoxChild
            this.cmdOpenTagsEditor = new Gtk.Button();
            this.cmdOpenTagsEditor.CanFocus = true;
            this.cmdOpenTagsEditor.Name = "cmdOpenTagsEditor";
            this.cmdOpenTagsEditor.UseUnderline = true;
            this.cmdOpenTagsEditor.Label = Mono.Unix.Catalog.GetString("Tag Editor...");
            this.hbuttonbox3.Add(this.cmdOpenTagsEditor);
            Gtk.ButtonBox.ButtonBoxChild w14 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox3[this.cmdOpenTagsEditor]));
            w14.Expand = false;
            w14.Fill = false;
            this.vbox4.Add(this.hbuttonbox3);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox4[this.hbuttonbox3]));
            w15.Position = 3;
            w15.Expand = false;
            w15.Fill = false;
            this.notebook1.Add(this.vbox4);
            Gtk.Notebook.NotebookChild w16 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox4]));
            w16.Position = 1;
            // Notebook tab
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Tags");
            this.notebook1.SetTabLabel(this.vbox4, this.label6);
            this.label6.ShowAll();
            // Container child notebook1.Gtk.Notebook+NotebookChild
            this.vbox3 = new Gtk.VBox();
            this.vbox3.Name = "vbox3";
            this.vbox3.Spacing = 6;
            this.vbox3.BorderWidth = ((uint)(5));
            // Container child vbox3.Gtk.Box+BoxChild
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("<b>Browser List</b>");
            this.label5.UseMarkup = true;
            this.vbox3.Add(this.label5);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox3[this.label5]));
            w17.Position = 0;
            w17.Expand = false;
            w17.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hseparator3 = new Gtk.HSeparator();
            this.hseparator3.Name = "hseparator3";
            this.vbox3.Add(this.hseparator3);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.vbox3[this.hseparator3]));
            w18.Position = 1;
            w18.Expand = false;
            w18.Fill = false;
            // Container child vbox3.Gtk.Box+BoxChild
            this.swBrowserList = new Gtk.ScrolledWindow();
            this.swBrowserList.CanFocus = true;
            this.swBrowserList.Name = "swBrowserList";
            this.swBrowserList.ShadowType = ((Gtk.ShadowType)(1));
            this.vbox3.Add(this.swBrowserList);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.vbox3[this.swBrowserList]));
            w19.Position = 2;
            // Container child vbox3.Gtk.Box+BoxChild
            this.hbuttonbox2 = new Gtk.HButtonBox();
            this.hbuttonbox2.Name = "hbuttonbox2";
            this.hbuttonbox2.LayoutStyle = ((Gtk.ButtonBoxStyle)(1));
            // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
            this.cmdAddBrowser = new Gtk.Button();
            this.cmdAddBrowser.CanFocus = true;
            this.cmdAddBrowser.Name = "cmdAddBrowser";
            this.cmdAddBrowser.UseStock = true;
            this.cmdAddBrowser.UseUnderline = true;
            this.cmdAddBrowser.Label = "gtk-add";
            this.hbuttonbox2.Add(this.cmdAddBrowser);
            Gtk.ButtonBox.ButtonBoxChild w20 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.cmdAddBrowser]));
            w20.Expand = false;
            w20.Fill = false;
            // Container child hbuttonbox2.Gtk.ButtonBox+ButtonBoxChild
            this.cmdRemoveBrowser = new Gtk.Button();
            this.cmdRemoveBrowser.CanFocus = true;
            this.cmdRemoveBrowser.Name = "cmdRemoveBrowser";
            this.cmdRemoveBrowser.UseStock = true;
            this.cmdRemoveBrowser.UseUnderline = true;
            this.cmdRemoveBrowser.Label = "gtk-remove";
            this.hbuttonbox2.Add(this.cmdRemoveBrowser);
            Gtk.ButtonBox.ButtonBoxChild w21 = ((Gtk.ButtonBox.ButtonBoxChild)(this.hbuttonbox2[this.cmdRemoveBrowser]));
            w21.Position = 1;
            w21.Expand = false;
            w21.Fill = false;
            this.vbox3.Add(this.hbuttonbox2);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox3[this.hbuttonbox2]));
            w22.Position = 3;
            w22.Expand = false;
            w22.Fill = false;
            this.notebook1.Add(this.vbox3);
            Gtk.Notebook.NotebookChild w23 = ((Gtk.Notebook.NotebookChild)(this.notebook1[this.vbox3]));
            w23.Position = 2;
            // Notebook tab
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Browsers");
            this.notebook1.SetTabLabel(this.vbox3, this.label3);
            this.label3.ShowAll();
            this.vbox2.Add(this.notebook1);
            Gtk.Box.BoxChild w24 = ((Gtk.Box.BoxChild)(this.vbox2[this.notebook1]));
            w24.Position = 2;
            // Container child vbox2.Gtk.Box+BoxChild
            this.hseparator1 = new Gtk.HSeparator();
            this.hseparator1.Name = "hseparator1";
            this.vbox2.Add(this.hseparator1);
            Gtk.Box.BoxChild w25 = ((Gtk.Box.BoxChild)(this.vbox2[this.hseparator1]));
            w25.Position = 3;
            w25.Expand = false;
            w25.Fill = false;
            w1.Add(this.vbox2);
            Gtk.Box.BoxChild w26 = ((Gtk.Box.BoxChild)(w1[this.vbox2]));
            w26.Position = 0;
            // Internal child BookmarkSharpClient.frmOptions.ActionArea
            Gtk.HButtonBox w27 = this.ActionArea;
            w27.Name = "dialog1_ActionArea";
            w27.Spacing = 6;
            w27.BorderWidth = ((uint)(5));
            w27.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonCancel = new Gtk.Button();
            this.buttonCancel.CanDefault = true;
            this.buttonCancel.CanFocus = true;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseStock = true;
            this.buttonCancel.UseUnderline = true;
            this.buttonCancel.Label = "gtk-cancel";
            this.AddActionWidget(this.buttonCancel, -6);
            Gtk.ButtonBox.ButtonBoxChild w28 = ((Gtk.ButtonBox.ButtonBoxChild)(w27[this.buttonCancel]));
            w28.Expand = false;
            w28.Fill = false;
            // Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
            this.buttonOk = new Gtk.Button();
            this.buttonOk.CanDefault = true;
            this.buttonOk.CanFocus = true;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseStock = true;
            this.buttonOk.UseUnderline = true;
            this.buttonOk.Label = "gtk-ok";
            this.AddActionWidget(this.buttonOk, -5);
            Gtk.ButtonBox.ButtonBoxChild w29 = ((Gtk.ButtonBox.ButtonBoxChild)(w27[this.buttonOk]));
            w29.Position = 1;
            w29.Expand = false;
            w29.Fill = false;
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 473;
            this.DefaultHeight = 436;
            this.Show();
            this.cmdAddBrowser.Clicked += new System.EventHandler(this.OnCmdAddBrowserClicked);
            this.cmdRemoveBrowser.Clicked += new System.EventHandler(this.OnCmdRemoveBrowserClicked);
            this.buttonCancel.Clicked += new System.EventHandler(this.OnButtonCancelClicked);
            this.buttonOk.Clicked += new System.EventHandler(this.OnButtonOkClicked);
        }
    }
}
