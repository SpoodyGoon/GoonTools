
// This file has been generated by the GUI designer. Do not modify.
namespace libGlobalTools
{
	public partial class dlgErrorMessage
	{
		private global::Gtk.Alignment alignment1;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Label label1;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Alignment alignment5;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView txtErrorMessage;
		private global::Gtk.Button buttonCancel;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget libGlobalTools.dlgErrorMessage
			this.Name = "libGlobalTools.dlgErrorMessage";
			this.Title = global::Mono.Unix.Catalog.GetString ("An Error Has Occured");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-dialog-error", global::Gtk.IconSize.Menu);
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Internal child libGlobalTools.dlgErrorMessage.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			this.alignment1.BottomPadding = ((uint)(3));
			// Container child alignment1.Gtk.Container+ContainerChild
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
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"x-large\" font_family=\"Verdana\"><b>Error Message</b></span>");
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
			this.alignment5 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment5.Name = "alignment5";
			// Container child alignment5.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.txtErrorMessage = new global::Gtk.TextView ();
			this.txtErrorMessage.CanFocus = true;
			this.txtErrorMessage.Name = "txtErrorMessage";
			this.txtErrorMessage.Editable = false;
			this.txtErrorMessage.CursorVisible = false;
			this.txtErrorMessage.WrapMode = ((global::Gtk.WrapMode)(2));
			this.txtErrorMessage.PixelsAboveLines = 3;
			this.txtErrorMessage.PixelsBelowLines = 3;
			this.txtErrorMessage.LeftMargin = 5;
			this.txtErrorMessage.RightMargin = 5;
			this.GtkScrolledWindow.Add (this.txtErrorMessage);
			this.alignment5.Add (this.GtkScrolledWindow);
			this.vbox2.Add (this.alignment5);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment5]));
			w8.Position = 2;
			this.alignment1.Add (this.vbox2);
			w1.Add (this.alignment1);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(w1 [this.alignment1]));
			w10.Position = 0;
			// Internal child libGlobalTools.dlgErrorMessage.ActionArea
			global::Gtk.HButtonBox w11 = this.ActionArea;
			w11.Name = "dialog1_ActionArea";
			w11.Spacing = 10;
			w11.BorderWidth = ((uint)(5));
			w11.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(1));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-close";
			this.AddActionWidget (this.buttonCancel, -7);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.buttonCancel]));
			w12.Expand = false;
			w12.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 886;
			this.DefaultHeight = 695;
			this.Show ();
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
		}
	}
}
