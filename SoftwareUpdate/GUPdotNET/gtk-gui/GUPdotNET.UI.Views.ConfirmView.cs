
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
		private global::Gtk.Alignment releaseNotesAlignment;
		private global::Gtk.Alignment alignment5;
		private global::Gtk.HSeparator hseparator2;
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
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.LeftPadding = ((uint)(8));
			this.alignment3.BottomPadding = ((uint)(4));
			// Container child alignment3.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 14;
			// Container child hbox2.Gtk.Box+BoxChild
			this.releaseNotesAlignment = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.releaseNotesAlignment.Name = "releaseNotesAlignment";
			this.hbox2.Add (this.releaseNotesAlignment);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.releaseNotesAlignment]));
			w8.Position = 0;
			this.alignment3.Add (this.hbox2);
			this.vbox2.Add (this.alignment3);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment3]));
			w10.Position = 3;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment5.Name = "alignment5";
			this.alignment5.TopPadding = ((uint)(2));
			this.alignment5.BottomPadding = ((uint)(2));
			// Container child alignment5.Gtk.Container+ContainerChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.alignment5.Add (this.hseparator2);
			this.vbox2.Add (this.alignment5);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment5]));
			w12.Position = 4;
			w12.Expand = false;
			w12.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w13.Position = 0;
			// Internal child GUPdotNET.UI.Views.ConfirmView.ActionArea
			global::Gtk.HButtonBox w14 = this.ActionArea;
			w14.Name = "dialog1_ActionArea";
			w14.Spacing = 14;
			w14.BorderWidth = ((uint)(5));
			w14.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
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
			global::Gtk.ButtonBox.ButtonBoxChild w15 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w14 [this.noConfirmButton]));
			w15.Expand = false;
			w15.Fill = false;
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
			global::Gtk.ButtonBox.ButtonBoxChild w16 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w14 [this.yesConfirmButton]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 492;
			this.DefaultHeight = 211;
			this.Show ();
		}
	}
}
