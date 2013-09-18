
// This file has been generated by the GUI designer. Do not modify.
namespace GUPdotNET.UI.Views
{
	internal partial class MainView
	{
		private global::Gtk.UIManager UIManager;
		private global::Gtk.Action QuitAction;
		private global::Gtk.Action AboutGUPdotNETAction;
		private global::Gtk.VBox vbox2;
		private global::Gtk.MenuBar menubar1;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Label updateTitleLabel;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.Label label1;
		private global::Gtk.Alignment updateCheckAlignment;
		private global::Gtk.Alignment alignment9;
		private global::Gtk.Button checkUpdateButton;
		private global::Gtk.Alignment alignment7;
		private global::Gtk.Label feedbackMessageLabel;
		private global::Gtk.Alignment alignment6;
		private global::Gtk.HButtonBox hbuttonbox2;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget GUPdotNET.UI.Views.MainView
			this.UIManager = new global::Gtk.UIManager ();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
			this.QuitAction = new global::Gtk.Action ("QuitAction", global::Mono.Unix.Catalog.GetString ("Quit"), null, "Quit.png");
			this.QuitAction.HideIfEmpty = false;
			this.QuitAction.IsImportant = true;
			this.QuitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Quit");
			this.QuitAction.VisibleOverflown = false;
			w1.Add (this.QuitAction, null);
			this.AboutGUPdotNETAction = new global::Gtk.Action ("AboutGUPdotNETAction", global::Mono.Unix.Catalog.GetString ("About GUPdotNET"), null, "About.png");
			this.AboutGUPdotNETAction.HideIfEmpty = false;
			this.AboutGUPdotNETAction.IsImportant = true;
			this.AboutGUPdotNETAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About GUPdotNET");
			this.AboutGUPdotNETAction.VisibleOverflown = false;
			w1.Add (this.AboutGUPdotNETAction, null);
			this.UIManager.InsertActionGroup (w1, 0);
			this.AddAccelGroup (this.UIManager.AccelGroup);
			this.Name = "GUPdotNET.UI.Views.MainView";
			this.Title = global::Mono.Unix.Catalog.GetString ("GUPdotNET");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.update_small.png");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(3));
			this.Modal = true;
			this.Resizable = false;
			// Internal child GUPdotNET.UI.Views.MainView.VBox
			global::Gtk.VBox w2 = this.VBox;
			w2.Name = "dialog1_VBox";
			w2.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString ("<ui><menubar name=\'menubar1\'><menuitem name=\'QuitAction\' action=\'QuitAction\'/><me" +
				"nuitem name=\'AboutGUPdotNETAction\' action=\'AboutGUPdotNETAction\'/></menubar></ui" +
				">");
			this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
			this.menubar1.CanDefault = true;
			this.menubar1.CanFocus = true;
			this.menubar1.Name = "menubar1";
			this.vbox2.Add (this.menubar1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.menubar1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.TopPadding = ((uint)(5));
			this.alignment1.BottomPadding = ((uint)(5));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			// Container child alignment2.Gtk.Container+ContainerChild
			this.updateTitleLabel = new global::Gtk.Label ();
			this.updateTitleLabel.Name = "updateTitleLabel";
			this.updateTitleLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"12000\" weight=\"bold\">Update tools for YahtzeeSharp.</span>");
			this.updateTitleLabel.UseMarkup = true;
			this.alignment2.Add (this.updateTitleLabel);
			this.hbox1.Add (this.alignment2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment2]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			this.alignment1.Add (this.hbox1);
			this.vbox2.Add (this.alignment1);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment1]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.LeftPadding = ((uint)(15));
			this.alignment3.RightPadding = ((uint)(10));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Check For Updates:");
			this.alignment4.Add (this.label1);
			this.hbox3.Add (this.alignment4);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.alignment4]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.updateCheckAlignment = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 0.01F);
			this.updateCheckAlignment.Name = "updateCheckAlignment";
			this.updateCheckAlignment.RightPadding = ((uint)(35));
			this.hbox3.Add (this.updateCheckAlignment);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.updateCheckAlignment]));
			w10.Position = 1;
			// Container child hbox3.Gtk.Box+BoxChild
			this.alignment9 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment9.Name = "alignment9";
			// Container child alignment9.Gtk.Container+ContainerChild
			this.checkUpdateButton = new global::Gtk.Button ();
			this.checkUpdateButton.WidthRequest = 133;
			this.checkUpdateButton.HeightRequest = 32;
			this.checkUpdateButton.CanFocus = true;
			this.checkUpdateButton.Name = "checkUpdateButton";
			this.checkUpdateButton.UseUnderline = true;
			// Container child checkUpdateButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w11 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w12 = new global::Gtk.HBox ();
			w12.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w13 = new global::Gtk.Image ();
			w13.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.CheckMark.png");
			w12.Add (w13);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w15 = new global::Gtk.Label ();
			w15.LabelProp = global::Mono.Unix.Catalog.GetString ("Check Now");
			w15.UseUnderline = true;
			w12.Add (w15);
			w11.Add (w12);
			this.checkUpdateButton.Add (w11);
			this.alignment9.Add (this.checkUpdateButton);
			this.hbox3.Add (this.alignment9);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.alignment9]));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			this.alignment3.Add (this.hbox3);
			this.vbox2.Add (this.alignment3);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment3]));
			w22.Position = 2;
			w22.Expand = false;
			w22.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment7 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment7.Name = "alignment7";
			this.alignment7.LeftPadding = ((uint)(15));
			// Container child alignment7.Gtk.Container+ContainerChild
			this.feedbackMessageLabel = new global::Gtk.Label ();
			this.feedbackMessageLabel.Name = "feedbackMessageLabel";
			this.feedbackMessageLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Feedback Messages");
			this.alignment7.Add (this.feedbackMessageLabel);
			this.vbox2.Add (this.alignment7);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment7]));
			w24.Position = 3;
			w24.Expand = false;
			w24.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.hbuttonbox2 = new global::Gtk.HButtonBox ();
			this.hbuttonbox2.Name = "hbuttonbox2";
			this.alignment6.Add (this.hbuttonbox2);
			this.vbox2.Add (this.alignment6);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment6]));
			w26.Position = 4;
			w26.Expand = false;
			w26.Fill = false;
			w2.Add (this.vbox2);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(w2 [this.vbox2]));
			w27.Position = 0;
			w27.Expand = false;
			w27.Fill = false;
			// Internal child GUPdotNET.UI.Views.MainView.ActionArea
			global::Gtk.HButtonBox w28 = this.ActionArea;
			w28.Name = "dialog1_ActionArea";
			w28.Spacing = 10;
			w28.BorderWidth = ((uint)(5));
			w28.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w29 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w28 [this.buttonCancel]));
			w29.Expand = false;
			w29.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w30 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w28 [this.buttonOk]));
			w30.Position = 1;
			w30.Expand = false;
			w30.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 478;
			this.DefaultHeight = 283;
			this.menubar1.HasDefault = true;
			this.Show ();
			this.QuitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
			this.AboutGUPdotNETAction.Activated += new global::System.EventHandler (this.OnAboutGUPdotNETActionActivated);
			this.checkUpdateButton.Clicked += new global::System.EventHandler (this.OnCheckUpdateButtonClicked);
		}
	}
}
