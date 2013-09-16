
// This file has been generated by the GUI designer. Do not modify.
namespace GUPdotNET.UI.Views
{
	internal partial class DownloadView
	{
		private global::Gtk.Alignment alignment4;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Alignment alignment7;
		private global::Gtk.ProgressBar downloadingProgressbar;
		private global::Gtk.Alignment alignment5;
		private global::Gtk.Button cancelButton;
		private global::Gtk.Alignment alignment6;
		private global::Gtk.Button hideWindowButton;
		private global::Gtk.Button buttonCancel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget GUPdotNET.UI.Views.DownloadView
			this.Name = "GUPdotNET.UI.Views.DownloadView";
			this.Title = global::Mono.Unix.Catalog.GetString ("Downloading");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.downloading.png");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(3));
			this.Modal = true;
			this.Resizable = false;
			this.AllowShrink = true;
			this.DestroyWithParent = true;
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			// Internal child GUPdotNET.UI.Views.DownloadView.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment4.Name = "alignment4";
			this.alignment4.TopPadding = ((uint)(3));
			this.alignment4.BottomPadding = ((uint)(3));
			this.alignment4.BorderWidth = ((uint)(4));
			// Container child alignment4.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment7 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 0.01F);
			this.alignment7.Name = "alignment7";
			this.alignment7.RightPadding = ((uint)(5));
			// Container child alignment7.Gtk.Container+ContainerChild
			this.downloadingProgressbar = new global::Gtk.ProgressBar ();
			this.downloadingProgressbar.WidthRequest = 300;
			this.downloadingProgressbar.Name = "downloadingProgressbar";
			this.downloadingProgressbar.Text = global::Mono.Unix.Catalog.GetString ("Downloading");
			this.alignment7.Add (this.downloadingProgressbar);
			this.hbox1.Add (this.alignment7);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment7]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.cancelButton = new global::Gtk.Button ();
			this.cancelButton.WidthRequest = 90;
			this.cancelButton.HeightRequest = 30;
			this.cancelButton.CanFocus = true;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseUnderline = true;
			// Container child cancelButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w4 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w5 = new global::Gtk.HBox ();
			w5.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w6 = new global::Gtk.Image ();
			w6.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.cancel.png");
			w5.Add (w6);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w8 = new global::Gtk.Label ();
			w8.LabelProp = global::Mono.Unix.Catalog.GetString ("Cancel");
			w8.UseUnderline = true;
			w5.Add (w8);
			w4.Add (w5);
			this.cancelButton.Add (w4);
			this.alignment5.Add (this.cancelButton);
			this.hbox1.Add (this.alignment5);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment5]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.hideWindowButton = new global::Gtk.Button ();
			this.hideWindowButton.WidthRequest = 90;
			this.hideWindowButton.HeightRequest = 30;
			this.hideWindowButton.CanFocus = true;
			this.hideWindowButton.Name = "hideWindowButton";
			this.hideWindowButton.UseUnderline = true;
			// Container child hideWindowButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w14 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w15 = new global::Gtk.HBox ();
			w15.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w16 = new global::Gtk.Image ();
			w16.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.hide.png");
			w15.Add (w16);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w18 = new global::Gtk.Label ();
			w18.LabelProp = global::Mono.Unix.Catalog.GetString ("Hide");
			w18.UseUnderline = true;
			w15.Add (w18);
			w14.Add (w15);
			this.hideWindowButton.Add (w14);
			this.alignment6.Add (this.hideWindowButton);
			this.hbox1.Add (this.alignment6);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment6]));
			w23.Position = 2;
			w23.Expand = false;
			w23.Fill = false;
			this.alignment4.Add (this.hbox1);
			w1.Add (this.alignment4);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(w1 [this.alignment4]));
			w25.Position = 0;
			w25.Expand = false;
			w25.Fill = false;
			// Internal child GUPdotNET.UI.Views.DownloadView.ActionArea
			global::Gtk.HButtonBox w26 = this.ActionArea;
			w26.Sensitive = false;
			w26.Name = "dialog1_ActionArea";
			w26.Spacing = 10;
			w26.BorderWidth = ((uint)(5));
			w26.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(1));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.Sensitive = false;
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-close";
			this.AddActionWidget (this.buttonCancel, -7);
			global::Gtk.ButtonBox.ButtonBoxChild w27 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w26 [this.buttonCancel]));
			w27.Expand = false;
			w27.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 544;
			this.DefaultHeight = 125;
			this.buttonCancel.Hide ();
			w26.Hide ();
			this.Show ();
			this.cancelButton.Clicked += new global::System.EventHandler (this.OnCancelButtonClicked);
			this.hideWindowButton.Clicked += new global::System.EventHandler (this.OnHideWindowButtonClicked);
		}
	}
}
