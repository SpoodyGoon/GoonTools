
// This file has been generated by the GUI designer. Do not modify.
namespace libMonoTools.ErrorManager
{
	internal partial class dlgErrorMessage
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Label label1;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.Label lblErrorMessage;
		private global::Gtk.Alignment alignment5;
		private global::Gtk.Expander expDetails;
		private global::Gtk.Alignment alignment6;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView txtErrorDetails;
		private global::Gtk.Label GtkLabel1;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.Alignment alignment7;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Alignment alignment8;
		private global::libMonoTools.UI.Custom.URLButton ubnBugTracker;
		private global::Gtk.VSeparator vseparator1;
		private global::Gtk.Alignment alignment9;
		private global::libMonoTools.LinkButton lbnShowErrorLog;
		private global::Gtk.Button btnClose;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget libMonoTools.ErrorManager.dlgErrorMessage
			this.Name = "libMonoTools.ErrorManager.dlgErrorMessage";
			this.Title = global::Mono.Unix.Catalog.GetString ("An Error Has Occured");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("Resources.Images.dialog-error.png");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(3));
			this.Modal = true;
			this.AllowShrink = true;
			// Internal child libMonoTools.ErrorManager.dlgErrorMessage.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.TopPadding = ((uint)(2));
			this.alignment2.BorderWidth = ((uint)(2));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"x-large\" font_family=\"Verdana\"><b>An Error Has Occured</b></span>");
			this.label1.UseMarkup = true;
			this.alignment2.Add (this.label1);
			this.vbox2.Add (this.alignment2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.TopPadding = ((uint)(4));
			this.alignment3.BottomPadding = ((uint)(4));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.alignment3.Add (this.hseparator1);
			this.vbox2.Add (this.alignment3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment3]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.01F, 0.01F, 0.01F, 0.01F);
			this.alignment4.Name = "alignment4";
			this.alignment4.LeftPadding = ((uint)(3));
			this.alignment4.RightPadding = ((uint)(3));
			this.alignment4.BorderWidth = ((uint)(5));
			// Container child alignment4.Gtk.Container+ContainerChild
			this.lblErrorMessage = new global::Gtk.Label ();
			this.lblErrorMessage.Name = "lblErrorMessage";
			this.lblErrorMessage.LabelProp = global::Mono.Unix.Catalog.GetString ("Error Message");
			this.lblErrorMessage.Wrap = true;
			this.alignment4.Add (this.lblErrorMessage);
			this.vbox2.Add (this.alignment4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment4]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.expDetails = new global::Gtk.Expander (null);
			this.expDetails.CanFocus = true;
			this.expDetails.Name = "expDetails";
			// Container child expDetails.Gtk.Container+ContainerChild
			this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.txtErrorDetails = new global::Gtk.TextView ();
			this.txtErrorDetails.Sensitive = false;
			this.txtErrorDetails.CanFocus = true;
			this.txtErrorDetails.Name = "txtErrorDetails";
			this.txtErrorDetails.Editable = false;
			this.txtErrorDetails.CursorVisible = false;
			this.txtErrorDetails.AcceptsTab = false;
			this.txtErrorDetails.WrapMode = ((global::Gtk.WrapMode)(2));
			this.txtErrorDetails.PixelsAboveLines = 3;
			this.txtErrorDetails.PixelsBelowLines = 3;
			this.txtErrorDetails.LeftMargin = 5;
			this.txtErrorDetails.RightMargin = 5;
			this.GtkScrolledWindow.Add (this.txtErrorDetails);
			this.alignment6.Add (this.GtkScrolledWindow);
			this.expDetails.Add (this.alignment6);
			this.GtkLabel1 = new global::Gtk.Label ();
			this.GtkLabel1.Name = "GtkLabel1";
			this.GtkLabel1.Xpad = 8;
			this.GtkLabel1.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Details</b>");
			this.GtkLabel1.UseMarkup = true;
			this.GtkLabel1.UseUnderline = true;
			this.expDetails.LabelWidget = this.GtkLabel1;
			this.alignment5.Add (this.expDetails);
			this.vbox2.Add (this.alignment5);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment5]));
			w12.Position = 3;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.alignment1.Add (this.hseparator2);
			this.vbox2.Add (this.alignment1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment1]));
			w14.Position = 4;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment7 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment7.Name = "alignment7";
			this.alignment7.LeftPadding = ((uint)(20));
			this.alignment7.TopPadding = ((uint)(1));
			this.alignment7.BottomPadding = ((uint)(3));
			// Container child alignment7.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 9;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment8 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment8.Name = "alignment8";
			// Container child alignment8.Gtk.Container+ContainerChild
			this.ubnBugTracker = new global::libMonoTools.UI.Custom.URLButton ();
			this.ubnBugTracker.Name = "ubnBugTracker";
			this.ubnBugTracker.LabelProp = global::Mono.Unix.Catalog.GetString ("Bug Tracking Site");
			this.ubnBugTracker.DisplayText = "Bug Tracking Site";
			this.ubnBugTracker.URL = "www.google.com";
			this.ubnBugTracker.FontName = "Arial";
			this.ubnBugTracker.FontColor = "#CC0000";
			this.ubnBugTracker.Size = "10";
			this.ubnBugTracker.Bold = false;
			this.ubnBugTracker.Underlined = true;
			this.ubnBugTracker.Italic = false;
			this.ubnBugTracker.HoverFontName = "Arial";
			this.ubnBugTracker.HoverFontColor = "#003399";
			this.ubnBugTracker.HoverSize = "10";
			this.ubnBugTracker.HoverBold = false;
			this.ubnBugTracker.HoverUnderlined = true;
			this.ubnBugTracker.HoverItalic = false;
			this.alignment8.Add (this.ubnBugTracker);
			this.hbox1.Add (this.alignment8);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment8]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator1]));
			w17.Position = 1;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment9 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment9.Name = "alignment9";
			// Container child alignment9.Gtk.Container+ContainerChild
			this.lbnShowErrorLog = new global::libMonoTools.LinkButton ();
			this.lbnShowErrorLog.Name = "lbnShowErrorLog";
			this.lbnShowErrorLog.LabelProp = global::Mono.Unix.Catalog.GetString ("Show Error Log");
			this.lbnShowErrorLog.UseMarkup = true;
			this.lbnShowErrorLog.DisplayText = "Show Error Log";
			this.lbnShowErrorLog.MouseOverHand = true;
			this.lbnShowErrorLog.FontName = "Arial";
			this.lbnShowErrorLog.FontColor = "#CC0000";
			this.lbnShowErrorLog.Size = "10";
			this.lbnShowErrorLog.Bold = false;
			this.lbnShowErrorLog.Underlined = true;
			this.lbnShowErrorLog.Italic = false;
			this.lbnShowErrorLog.HoverFontName = "Arial";
			this.lbnShowErrorLog.HoverFontColor = "#003399";
			this.lbnShowErrorLog.HoverSize = "10";
			this.lbnShowErrorLog.HoverBold = false;
			this.lbnShowErrorLog.HoverUnderlined = true;
			this.lbnShowErrorLog.HoverItalic = false;
			this.alignment9.Add (this.lbnShowErrorLog);
			this.hbox1.Add (this.alignment9);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment9]));
			w19.Position = 2;
			w19.Expand = false;
			w19.Fill = false;
			this.alignment7.Add (this.hbox1);
			this.vbox2.Add (this.alignment7);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment7]));
			w21.Position = 5;
			w21.Expand = false;
			w21.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w22.Position = 0;
			// Internal child libMonoTools.ErrorManager.dlgErrorMessage.ActionArea
			global::Gtk.HButtonBox w23 = this.ActionArea;
			w23.Name = "dialog1_ActionArea";
			w23.Spacing = 10;
			w23.BorderWidth = ((uint)(5));
			w23.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(1));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnClose = new global::Gtk.Button ();
			this.btnClose.CanDefault = true;
			this.btnClose.CanFocus = true;
			this.btnClose.Name = "btnClose";
			this.btnClose.UseStock = true;
			this.btnClose.UseUnderline = true;
			this.btnClose.Label = "gtk-close";
			this.AddActionWidget (this.btnClose, -7);
			global::Gtk.ButtonBox.ButtonBoxChild w24 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w23 [this.btnClose]));
			w24.Expand = false;
			w24.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 648;
			this.DefaultHeight = 342;
			this.Show ();
			this.expDetails.Activated += new global::System.EventHandler (this.OnExpDetailsActivated);
			this.lbnShowErrorLog.Clicked += new global::libMonoTools.UI.Custom.Click (this.OnShowErrorLogClicked);
			this.btnClose.Clicked += new global::System.EventHandler (this.OnBtnCloseClicked);
		}
	}
}
