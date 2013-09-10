
// This file has been generated by the GUI designer. Do not modify.
namespace GUPdotNET.UI.Views
{
	internal partial class ConfirmView
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.Alignment alignment1;
		private global::Gtk.Label titleLabel;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Label updateMessageLabel;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Alignment alignment6;
		private global::Gtk.Button fileListDetailsButton;
		private global::Gtk.Alignment alignment5;
		private global::Gtk.Button releaseNotesButton;
		private global::Gtk.Button noConfirmButton;
		private global::Gtk.Button yesConfirmButton;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget GUPdotNET.UI.Views.ConfirmView
			this.Name = "GUPdotNET.UI.Views.ConfirmView";
			this.Title = global::Mono.Unix.Catalog.GetString ("Update Available");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.update_needed.png");
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(3));
			this.Modal = true;
			this.Resizable = false;
			// Internal child GUPdotNET.UI.Views.ConfirmView.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.TopPadding = ((uint)(4));
			this.alignment1.BottomPadding = ((uint)(2));
			// Container child alignment1.Gtk.Container+ContainerChild
			this.titleLabel = new global::Gtk.Label ();
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b><big>Update Available</big></b>");
			this.titleLabel.UseMarkup = true;
			this.alignment1.Add (this.titleLabel);
			this.vbox2.Add (this.alignment1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.hseparator1 = new global::Gtk.HSeparator ();
			this.hseparator1.Name = "hseparator1";
			this.alignment4.Add (this.hseparator1);
			this.vbox2.Add (this.alignment4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment4]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.BottomPadding = ((uint)(4));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.updateMessageLabel = new global::Gtk.Label ();
			this.updateMessageLabel.Name = "updateMessageLabel";
			this.updateMessageLabel.Xpad = 5;
			this.updateMessageLabel.Ypad = 5;
			this.updateMessageLabel.LabelProp = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. ";
			this.updateMessageLabel.Wrap = true;
			this.alignment2.Add (this.updateMessageLabel);
			this.vbox2.Add (this.alignment2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment2]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.LeftPadding = ((uint)(8));
			this.alignment3.BottomPadding = ((uint)(4));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 14;
			// Container child hbox2.Gtk.Box+BoxChild
			this.alignment6 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment6.Name = "alignment6";
			// Container child alignment6.Gtk.Container+ContainerChild
			this.fileListDetailsButton = new global::Gtk.Button ();
			this.fileListDetailsButton.CanFocus = true;
			this.fileListDetailsButton.Name = "fileListDetailsButton";
			this.fileListDetailsButton.UseUnderline = true;
			// Container child fileListDetailsButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w8 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w9 = new global::Gtk.HBox ();
			w9.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w10 = new global::Gtk.Image ();
			w10.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.PackageDetails.png");
			w9.Add (w10);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w12 = new global::Gtk.Label ();
			w12.LabelProp = global::Mono.Unix.Catalog.GetString ("File List Details...");
			w12.UseUnderline = true;
			w9.Add (w12);
			w8.Add (w9);
			this.fileListDetailsButton.Add (w8);
			this.alignment6.Add (this.fileListDetailsButton);
			this.hbox2.Add (this.alignment6);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.alignment6]));
			w17.Position = 0;
			w17.Expand = false;
			w17.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.releaseNotesButton = new global::Gtk.Button ();
			this.releaseNotesButton.CanFocus = true;
			this.releaseNotesButton.Name = "releaseNotesButton";
			this.releaseNotesButton.UseUnderline = true;
			// Container child releaseNotesButton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w18 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w19 = new global::Gtk.HBox ();
			w19.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w20 = new global::Gtk.Image ();
			w20.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("GUPdotNET.Resources.Images.ReleaseNotes.png");
			w19.Add (w20);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w22 = new global::Gtk.Label ();
			w22.LabelProp = global::Mono.Unix.Catalog.GetString ("Release Notes...");
			w22.UseUnderline = true;
			w19.Add (w22);
			w18.Add (w19);
			this.releaseNotesButton.Add (w18);
			this.alignment5.Add (this.releaseNotesButton);
			this.hbox2.Add (this.alignment5);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.alignment5]));
			w27.Position = 1;
			w27.Expand = false;
			w27.Fill = false;
			this.alignment3.Add (this.hbox2);
			this.vbox2.Add (this.alignment3);
			global::Gtk.Box.BoxChild w29 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment3]));
			w29.Position = 3;
			w29.Expand = false;
			w29.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w30 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w30.Position = 0;
			w30.Expand = false;
			w30.Fill = false;
			// Internal child GUPdotNET.UI.Views.ConfirmView.ActionArea
			global::Gtk.HButtonBox w31 = this.ActionArea;
			w31.Name = "dialog1_ActionArea";
			w31.Spacing = 14;
			w31.BorderWidth = ((uint)(5));
			w31.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.noConfirmButton = new global::Gtk.Button ();
			this.noConfirmButton.WidthRequest = 100;
			this.noConfirmButton.HeightRequest = 32;
			this.noConfirmButton.CanDefault = true;
			this.noConfirmButton.CanFocus = true;
			this.noConfirmButton.Name = "noConfirmButton";
			this.noConfirmButton.UseStock = true;
			this.noConfirmButton.UseUnderline = true;
			this.noConfirmButton.Label = "gtk-no";
			this.AddActionWidget (this.noConfirmButton, -9);
			global::Gtk.ButtonBox.ButtonBoxChild w32 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w31 [this.noConfirmButton]));
			w32.Expand = false;
			w32.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.yesConfirmButton = new global::Gtk.Button ();
			this.yesConfirmButton.WidthRequest = 100;
			this.yesConfirmButton.HeightRequest = 32;
			this.yesConfirmButton.CanDefault = true;
			this.yesConfirmButton.CanFocus = true;
			this.yesConfirmButton.Name = "yesConfirmButton";
			this.yesConfirmButton.UseStock = true;
			this.yesConfirmButton.UseUnderline = true;
			this.yesConfirmButton.Label = "gtk-yes";
			this.AddActionWidget (this.yesConfirmButton, -8);
			global::Gtk.ButtonBox.ButtonBoxChild w33 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w31 [this.yesConfirmButton]));
			w33.Position = 1;
			w33.Expand = false;
			w33.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 488;
			this.DefaultHeight = 178;
			this.fileListDetailsButton.Hide ();
			this.releaseNotesButton.Hide ();
			this.Show ();
			this.fileListDetailsButton.Clicked += new global::System.EventHandler (this.OnFileListDetailsButtonClicked);
			this.releaseNotesButton.Clicked += new global::System.EventHandler (this.OnReleaseNotesButtonClicked);
		}
	}
}
