
// This file has been generated by the GUI designer. Do not modify.
namespace libGUPdotNET
{
	public partial class frmOptions
	{
		private global::Gtk.Fixed fixed1;
		private global::Gtk.Frame fraCheckLimits;
		private global::Gtk.Alignment GtkAlignment1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.Label label3;
		private global::Gtk.Alignment alignment1;
		private global::libGUPdotNET.UpdateTimeCombo cboUpdateTime;
		private global::Gtk.Label label4;
		private global::Gtk.Label lblLastCheck;
		private global::Gtk.Label label5;
		private global::Gtk.Label lblLastUpdate;
		private global::Gtk.Label label2;
		private global::Gtk.EventBox ebxAbout;
		private global::Gtk.Label lblAbout;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.CheckButton cbxAutoUpdate;
		private global::Gtk.Button btnCheckNow;
		private global::Gtk.Button btnCancel;
		private global::Gtk.Button btnOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget libGUPdotNET.frmOptions
			this.HeightRequest = 275;
			this.Name = "libGUPdotNET.frmOptions";
			this.Title = global::Mono.Unix.Catalog.GetString ("Update Options");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("update_small.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.Modal = true;
			this.BorderWidth = ((uint)(4));
			this.Resizable = false;
			this.AllowGrow = false;
			// Internal child libGUPdotNET.frmOptions.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.WidthRequest = 460;
			this.fixed1.HeightRequest = 168;
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.fraCheckLimits = new global::Gtk.Frame ();
			this.fraCheckLimits.WidthRequest = 375;
			this.fraCheckLimits.Name = "fraCheckLimits";
			// Container child fraCheckLimits.Gtk.Container+ContainerChild
			this.GtkAlignment1 = new global::Gtk.Alignment (0F, 0F, 0.5F, 0.5F);
			this.GtkAlignment1.Name = "GtkAlignment1";
			this.GtkAlignment1.LeftPadding = ((uint)(17));
			this.GtkAlignment1.BorderWidth = ((uint)(4));
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(3));
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Check for updates every:");
			this.alignment4.Add (this.label3);
			this.hbox1.Add (this.alignment4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment4]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.cboUpdateTime = null;
			this.alignment1.Add (this.cboUpdateTime);
			this.hbox1.Add (this.alignment1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.GtkAlignment1.Add (this.hbox1);
			this.fraCheckLimits.Add (this.GtkAlignment1);
			this.fixed1.Add (this.fraCheckLimits);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.fraCheckLimits]));
			w8.X = 17;
			w8.Y = 88;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Last Update Check:");
			this.fixed1.Add (this.label4);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label4]));
			w9.X = 71;
			w9.Y = 140;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.lblLastCheck = new global::Gtk.Label ();
			this.lblLastCheck.Name = "lblLastCheck";
			this.lblLastCheck.LabelProp = global::Mono.Unix.Catalog.GetString ("None");
			this.fixed1.Add (this.lblLastCheck);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblLastCheck]));
			w10.X = 190;
			w10.Y = 140;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Last Update:");
			this.fixed1.Add (this.label5);
			global::Gtk.Fixed.FixedChild w11 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label5]));
			w11.X = 104;
			w11.Y = 164;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.lblLastUpdate = new global::Gtk.Label ();
			this.lblLastUpdate.Name = "lblLastUpdate";
			this.lblLastUpdate.LabelProp = global::Mono.Unix.Catalog.GetString ("None");
			this.fixed1.Add (this.lblLastUpdate);
			global::Gtk.Fixed.FixedChild w12 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.lblLastUpdate]));
			w12.X = 190;
			w12.Y = 164;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"x-large\"><b>Update Options</b></span>");
			this.label2.UseMarkup = true;
			this.fixed1.Add (this.label2);
			global::Gtk.Fixed.FixedChild w13 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.label2]));
			w13.X = 160;
			w13.Y = 6;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.ebxAbout = new global::Gtk.EventBox ();
			this.ebxAbout.Name = "ebxAbout";
			this.ebxAbout.AboveChild = true;
			this.ebxAbout.BorderWidth = ((uint)(2));
			// Container child ebxAbout.Gtk.Container+ContainerChild
			this.lblAbout = new global::Gtk.Label ();
			this.lblAbout.Name = "lblAbout";
			this.lblAbout.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"8750\" face=\"san serif\" color=\"#000000\"><u><b>About GUPdotNET</b></u><" +
				"/span>");
			this.lblAbout.UseMarkup = true;
			this.ebxAbout.Add (this.lblAbout);
			this.fixed1.Add (this.ebxAbout);
			global::Gtk.Fixed.FixedChild w15 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.ebxAbout]));
			w15.X = 325;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.WidthRequest = 432;
			this.hseparator2.Name = "hseparator2";
			this.fixed1.Add (this.hseparator2);
			global::Gtk.Fixed.FixedChild w16 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.hseparator2]));
			w16.X = 7;
			w16.Y = 36;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.cbxAutoUpdate = new global::Gtk.CheckButton ();
			this.cbxAutoUpdate.CanFocus = true;
			this.cbxAutoUpdate.Name = "cbxAutoUpdate";
			this.cbxAutoUpdate.Label = global::Mono.Unix.Catalog.GetString ("Check for updates automatically");
			this.cbxAutoUpdate.Active = true;
			this.cbxAutoUpdate.DrawIndicator = true;
			this.cbxAutoUpdate.UseUnderline = true;
			this.fixed1.Add (this.cbxAutoUpdate);
			global::Gtk.Fixed.FixedChild w17 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.cbxAutoUpdate]));
			w17.X = 43;
			w17.Y = 50;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.btnCheckNow = new global::Gtk.Button ();
			this.btnCheckNow.WidthRequest = 112;
			this.btnCheckNow.HeightRequest = 40;
			this.btnCheckNow.CanFocus = true;
			this.btnCheckNow.Name = "btnCheckNow";
			this.btnCheckNow.BorderWidth = ((uint)(4));
			this.btnCheckNow.Label = global::Mono.Unix.Catalog.GetString ("Check Now...");
			this.fixed1.Add (this.btnCheckNow);
			global::Gtk.Fixed.FixedChild w18 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.btnCheckNow]));
			w18.X = 278;
			w18.Y = 39;
			w1.Add (this.fixed1);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(w1 [this.fixed1]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Internal child libGUPdotNET.frmOptions.ActionArea
			global::Gtk.HButtonBox w20 = this.ActionArea;
			w20.Name = "dialog1_ActionArea";
			w20.Spacing = 6;
			w20.BorderWidth = ((uint)(5));
			w20.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(1));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanDefault = true;
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseStock = true;
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.btnCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w21 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w20 [this.btnCancel]));
			w21.Expand = false;
			w21.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnOk = new global::Gtk.Button ();
			this.btnOk.CanDefault = true;
			this.btnOk.CanFocus = true;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseStock = true;
			this.btnOk.UseUnderline = true;
			this.btnOk.Label = "gtk-ok";
			this.AddActionWidget (this.btnOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w22 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w20 [this.btnOk]));
			w22.Position = 1;
			w22.Expand = false;
			w22.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 472;
			this.DefaultHeight = 275;
			this.Hide ();
			this.ebxAbout.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler (this.OnEbxAboutButtonPressEvent);
			this.ebxAbout.EnterNotifyEvent += new global::Gtk.EnterNotifyEventHandler (this.OnEbxAboutEnterNotifyEvent);
			this.ebxAbout.LeaveNotifyEvent += new global::Gtk.LeaveNotifyEventHandler (this.OnEbxAboutLeaveNotifyEvent);
			this.cbxAutoUpdate.Toggled += new global::System.EventHandler (this.OnCbxAutoUpdateToggled);
			this.btnCheckNow.Clicked += new global::System.EventHandler (this.OnBtnCheckNowClicked);
			this.btnCancel.Clicked += new global::System.EventHandler (this.OnBtnCancelClicked);
			this.btnOk.Clicked += new global::System.EventHandler (this.OnBtnOkClicked);
		}
	}
}