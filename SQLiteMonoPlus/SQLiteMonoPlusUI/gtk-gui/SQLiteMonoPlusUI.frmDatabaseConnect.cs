
// This file has been generated by the GUI designer. Do not modify.
namespace SQLiteMonoPlusUI
{
	public partial class frmDatabaseConnect
	{
		private global::Gtk.Alignment alignment1;
		private global::Gtk.VBox vbox2;
		private global::Gtk.Alignment alignment2;
		private global::Gtk.Label lblTitle;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.HSeparator hseparator1;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.Table table1;
		private global::Gtk.Alignment alignment12;
		private global::Gtk.FileChooserButton fcDBFile;
		private global::Gtk.Alignment alignment13;
		private global::Gtk.Label label2;
		private global::Gtk.Alignment alignment14;
		private global::Gtk.Label label6;
		private global::Gtk.Alignment alignment15;
		private global::SQLiteMonoPlusUI.ConnectionComboBoxEntry cboConnectName;
		private global::Gtk.Alignment alignment19;
		private global::Gtk.Label label3;
		private global::Gtk.Alignment alignment20;
		private global::Gtk.Label lblFilePath;
		private global::Gtk.Alignment alignment21;
		private global::Gtk.CheckButton cbxAdvanced;
		private global::Gtk.Alignment algAdvanced;
		private global::Gtk.Frame fraAdvanced;
		private global::Gtk.Alignment GtkAlignment3;
		private global::Gtk.Table table2;
		private global::Gtk.Alignment alignment16;
		private global::Gtk.SpinButton spnMaxPool;
		private global::Gtk.Alignment alignment22;
		private global::Gtk.Entry txtPassword;
		private global::Gtk.Alignment alignment23;
		private global::Gtk.Label label5;
		private global::Gtk.Alignment alignment24;
		private global::Gtk.SpinButton spnTimeout;
		private global::Gtk.Alignment alignment25;
		private global::Gtk.Label label7;
		private global::Gtk.Alignment alignment26;
		private global::Gtk.Label label8;
		private global::Gtk.Alignment alignment27;
		private global::Gtk.CheckButton cbxPooling;
		private global::Gtk.Alignment alignment9;
		private global::Gtk.Label lblMaxPool;
		private global::Gtk.Alignment alignment10;
		private global::Gtk.HSeparator hseparator2;
		private global::Gtk.Alignment alignment11;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Alignment alignment17;
		private global::Gtk.Button btnTestConnection;
		private global::Gtk.Alignment alignment18;
		private global::Gtk.Label lblTestResult;
		private global::Gtk.Button btnCancel;
		private global::Gtk.Button btnConnect;
		private global::Gtk.Button btnSaveConnect;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget SQLiteMonoPlusUI.frmDatabaseConnect
			this.Name = "SQLiteMonoPlusUI.frmDatabaseConnect";
			this.Title = global::Mono.Unix.Catalog.GetString ("Database Connect");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-connect", global::Gtk.IconSize.Menu);
			this.TypeHint = ((global::Gdk.WindowTypeHint)(1));
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			this.Modal = true;
			this.AllowGrow = false;
			this.DestroyWithParent = true;
			// Internal child SQLiteMonoPlusUI.frmDatabaseConnect.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.Spacing = 2;
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.alignment1 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment1.Name = "alignment1";
			// Container child alignment1.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			this.alignment2.TopPadding = ((uint)(3));
			this.alignment2.BottomPadding = ((uint)(3));
			// Container child alignment2.Gtk.Container+ContainerChild
			this.lblTitle = new global::Gtk.Label ();
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"12000\"><b>Database Connection</b></span>");
			this.lblTitle.UseMarkup = true;
			this.lblTitle.Justify = ((global::Gtk.Justification)(2));
			this.alignment2.Add (this.lblTitle);
			this.vbox2.Add (this.alignment2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment3.Name = "alignment3";
			this.alignment3.BottomPadding = ((uint)(6));
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
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			this.alignment4.LeftPadding = ((uint)(17));
			// Container child alignment4.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(3)), ((uint)(4)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(11));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.alignment12 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment12.Name = "alignment12";
			this.alignment12.RightPadding = ((uint)(10));
			// Container child alignment12.Gtk.Container+ContainerChild
			this.fcDBFile = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Select A File"), ((global::Gtk.FileChooserAction)(0)));
			this.fcDBFile.WidthRequest = 350;
			this.fcDBFile.Name = "fcDBFile";
			this.alignment12.Add (this.fcDBFile);
			this.table1.Add (this.alignment12);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignment12]));
			w7.TopAttach = ((uint)(1));
			w7.BottomAttach = ((uint)(2));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(4));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.alignment13 = new global::Gtk.Alignment (0.98F, 0.5F, 0.01F, 1F);
			this.alignment13.Name = "alignment13";
			// Container child alignment13.Gtk.Container+ContainerChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("File:");
			this.alignment13.Add (this.label2);
			this.table1.Add (this.alignment13);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignment13]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.alignment14 = new global::Gtk.Alignment (0.98F, 0.5F, 0.01F, 1F);
			this.alignment14.Name = "alignment14";
			// Container child alignment14.Gtk.Container+ContainerChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Connection Name:");
			this.alignment14.Add (this.label6);
			this.table1.Add (this.alignment14);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignment14]));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.alignment15 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment15.WidthRequest = 150;
			this.alignment15.Name = "alignment15";
			// Container child alignment15.Gtk.Container+ContainerChild
			this.cboConnectName = null;
			this.alignment15.Add (this.cboConnectName);
			this.table1.Add (this.alignment15);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignment15]));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.alignment19 = new global::Gtk.Alignment (0.98F, 0.5F, 0.01F, 1F);
			this.alignment19.Name = "alignment19";
			// Container child alignment19.Gtk.Container+ContainerChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("File Directory:");
			this.alignment19.Add (this.label3);
			this.table1.Add (this.alignment19);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignment19]));
			w15.TopAttach = ((uint)(2));
			w15.BottomAttach = ((uint)(3));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.alignment20 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment20.Name = "alignment20";
			// Container child alignment20.Gtk.Container+ContainerChild
			this.lblFilePath = new global::Gtk.Label ();
			this.lblFilePath.WidthRequest = 400;
			this.lblFilePath.Name = "lblFilePath";
			this.lblFilePath.Xalign = 0.01F;
			this.lblFilePath.Ellipsize = ((global::Pango.EllipsizeMode)(2));
			this.lblFilePath.SingleLineMode = true;
			this.alignment20.Add (this.lblFilePath);
			this.table1.Add (this.alignment20);
			global::Gtk.Table.TableChild w17 = ((global::Gtk.Table.TableChild)(this.table1 [this.alignment20]));
			w17.TopAttach = ((uint)(2));
			w17.BottomAttach = ((uint)(3));
			w17.LeftAttach = ((uint)(1));
			w17.RightAttach = ((uint)(4));
			w17.XOptions = ((global::Gtk.AttachOptions)(4));
			w17.YOptions = ((global::Gtk.AttachOptions)(4));
			this.alignment4.Add (this.table1);
			this.vbox2.Add (this.alignment4);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment4]));
			w19.Position = 2;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment21 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment21.Name = "alignment21";
			this.alignment21.LeftPadding = ((uint)(17));
			// Container child alignment21.Gtk.Container+ContainerChild
			this.cbxAdvanced = new global::Gtk.CheckButton ();
			this.cbxAdvanced.CanFocus = true;
			this.cbxAdvanced.Name = "cbxAdvanced";
			this.cbxAdvanced.Label = global::Mono.Unix.Catalog.GetString ("Advanced Settings");
			this.cbxAdvanced.DrawIndicator = true;
			this.cbxAdvanced.UseUnderline = true;
			this.alignment21.Add (this.cbxAdvanced);
			this.vbox2.Add (this.alignment21);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment21]));
			w21.Position = 3;
			w21.Expand = false;
			w21.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.algAdvanced = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.algAdvanced.Name = "algAdvanced";
			this.algAdvanced.LeftPadding = ((uint)(32));
			this.algAdvanced.RightPadding = ((uint)(32));
			// Container child algAdvanced.Gtk.Container+ContainerChild
			this.fraAdvanced = new global::Gtk.Frame ();
			this.fraAdvanced.Name = "fraAdvanced";
			// Container child fraAdvanced.Gtk.Container+ContainerChild
			this.GtkAlignment3 = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment3.Name = "GtkAlignment3";
			this.GtkAlignment3.BorderWidth = ((uint)(6));
			// Container child GtkAlignment3.Gtk.Container+ContainerChild
			this.table2 = new global::Gtk.Table (((uint)(3)), ((uint)(4)), false);
			this.table2.Name = "table2";
			this.table2.RowSpacing = ((uint)(11));
			this.table2.ColumnSpacing = ((uint)(6));
			// Container child table2.Gtk.Table+TableChild
			this.alignment16 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment16.Name = "alignment16";
			// Container child alignment16.Gtk.Container+ContainerChild
			this.spnMaxPool = new global::Gtk.SpinButton (1D, 1000D, 1D);
			this.spnMaxPool.CanFocus = true;
			this.spnMaxPool.Name = "spnMaxPool";
			this.spnMaxPool.Adjustment.PageIncrement = 1D;
			this.spnMaxPool.ClimbRate = 1D;
			this.spnMaxPool.Numeric = true;
			this.spnMaxPool.SnapToTicks = true;
			this.spnMaxPool.UpdatePolicy = ((global::Gtk.SpinButtonUpdatePolicy)(1));
			this.spnMaxPool.Value = 100D;
			this.alignment16.Add (this.spnMaxPool);
			this.table2.Add (this.alignment16);
			global::Gtk.Table.TableChild w23 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment16]));
			w23.TopAttach = ((uint)(2));
			w23.BottomAttach = ((uint)(3));
			w23.LeftAttach = ((uint)(3));
			w23.RightAttach = ((uint)(4));
			w23.XOptions = ((global::Gtk.AttachOptions)(4));
			w23.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment22 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment22.Name = "alignment22";
			// Container child alignment22.Gtk.Container+ContainerChild
			this.txtPassword = new global::Gtk.Entry ();
			this.txtPassword.WidthRequest = 200;
			this.txtPassword.CanFocus = true;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.IsEditable = true;
			this.txtPassword.InvisibleChar = '●';
			this.alignment22.Add (this.txtPassword);
			this.table2.Add (this.alignment22);
			global::Gtk.Table.TableChild w25 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment22]));
			w25.LeftAttach = ((uint)(1));
			w25.RightAttach = ((uint)(4));
			w25.XOptions = ((global::Gtk.AttachOptions)(4));
			w25.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment23 = new global::Gtk.Alignment (0.98F, 0.5F, 0.01F, 1F);
			this.alignment23.Name = "alignment23";
			// Container child alignment23.Gtk.Container+ContainerChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Password:");
			this.alignment23.Add (this.label5);
			this.table2.Add (this.alignment23);
			global::Gtk.Table.TableChild w27 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment23]));
			w27.XOptions = ((global::Gtk.AttachOptions)(4));
			w27.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment24 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment24.Name = "alignment24";
			// Container child alignment24.Gtk.Container+ContainerChild
			this.spnTimeout = new global::Gtk.SpinButton (1000D, 50000D, 10D);
			this.spnTimeout.CanFocus = true;
			this.spnTimeout.Name = "spnTimeout";
			this.spnTimeout.Adjustment.PageIncrement = 1D;
			this.spnTimeout.ClimbRate = 1D;
			this.spnTimeout.Numeric = true;
			this.spnTimeout.SnapToTicks = true;
			this.spnTimeout.UpdatePolicy = ((global::Gtk.SpinButtonUpdatePolicy)(1));
			this.spnTimeout.Value = 1000D;
			this.alignment24.Add (this.spnTimeout);
			this.table2.Add (this.alignment24);
			global::Gtk.Table.TableChild w29 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment24]));
			w29.TopAttach = ((uint)(1));
			w29.BottomAttach = ((uint)(2));
			w29.LeftAttach = ((uint)(1));
			w29.RightAttach = ((uint)(4));
			w29.XOptions = ((global::Gtk.AttachOptions)(4));
			w29.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment25 = new global::Gtk.Alignment (0.98F, 0.5F, 0.01F, 1F);
			this.alignment25.Name = "alignment25";
			// Container child alignment25.Gtk.Container+ContainerChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Connection Timeout:");
			this.alignment25.Add (this.label7);
			this.table2.Add (this.alignment25);
			global::Gtk.Table.TableChild w31 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment25]));
			w31.TopAttach = ((uint)(1));
			w31.BottomAttach = ((uint)(2));
			w31.XOptions = ((global::Gtk.AttachOptions)(4));
			w31.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment26 = new global::Gtk.Alignment (0.98F, 0.5F, 0.01F, 1F);
			this.alignment26.Name = "alignment26";
			// Container child alignment26.Gtk.Container+ContainerChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Connection Pooling:");
			this.alignment26.Add (this.label8);
			this.table2.Add (this.alignment26);
			global::Gtk.Table.TableChild w33 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment26]));
			w33.TopAttach = ((uint)(2));
			w33.BottomAttach = ((uint)(3));
			w33.XOptions = ((global::Gtk.AttachOptions)(4));
			w33.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment27 = new global::Gtk.Alignment (0.01F, 0.5F, 0.01F, 1F);
			this.alignment27.Name = "alignment27";
			// Container child alignment27.Gtk.Container+ContainerChild
			this.cbxPooling = new global::Gtk.CheckButton ();
			this.cbxPooling.CanFocus = true;
			this.cbxPooling.Name = "cbxPooling";
			this.cbxPooling.Label = "";
			this.cbxPooling.DrawIndicator = true;
			this.cbxPooling.UseUnderline = true;
			this.alignment27.Add (this.cbxPooling);
			this.table2.Add (this.alignment27);
			global::Gtk.Table.TableChild w35 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment27]));
			w35.TopAttach = ((uint)(2));
			w35.BottomAttach = ((uint)(3));
			w35.LeftAttach = ((uint)(1));
			w35.RightAttach = ((uint)(2));
			w35.XOptions = ((global::Gtk.AttachOptions)(4));
			w35.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table2.Gtk.Table+TableChild
			this.alignment9 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment9.Name = "alignment9";
			// Container child alignment9.Gtk.Container+ContainerChild
			this.lblMaxPool = new global::Gtk.Label ();
			this.lblMaxPool.Name = "lblMaxPool";
			this.lblMaxPool.LabelProp = global::Mono.Unix.Catalog.GetString ("Max Pool Connections:");
			this.alignment9.Add (this.lblMaxPool);
			this.table2.Add (this.alignment9);
			global::Gtk.Table.TableChild w37 = ((global::Gtk.Table.TableChild)(this.table2 [this.alignment9]));
			w37.TopAttach = ((uint)(2));
			w37.BottomAttach = ((uint)(3));
			w37.LeftAttach = ((uint)(2));
			w37.RightAttach = ((uint)(3));
			w37.XOptions = ((global::Gtk.AttachOptions)(4));
			w37.YOptions = ((global::Gtk.AttachOptions)(4));
			this.GtkAlignment3.Add (this.table2);
			this.fraAdvanced.Add (this.GtkAlignment3);
			this.algAdvanced.Add (this.fraAdvanced);
			this.vbox2.Add (this.algAdvanced);
			global::Gtk.Box.BoxChild w41 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.algAdvanced]));
			w41.Position = 4;
			w41.Expand = false;
			w41.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment10 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment10.Name = "alignment10";
			this.alignment10.TopPadding = ((uint)(3));
			this.alignment10.BottomPadding = ((uint)(3));
			// Container child alignment10.Gtk.Container+ContainerChild
			this.hseparator2 = new global::Gtk.HSeparator ();
			this.hseparator2.Name = "hseparator2";
			this.alignment10.Add (this.hseparator2);
			this.vbox2.Add (this.alignment10);
			global::Gtk.Box.BoxChild w43 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment10]));
			w43.Position = 5;
			w43.Expand = false;
			w43.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.alignment11 = new global::Gtk.Alignment (0.5F, 0.5F, 0.01F, 1F);
			this.alignment11.Name = "alignment11";
			this.alignment11.TopPadding = ((uint)(6));
			this.alignment11.BottomPadding = ((uint)(7));
			// Container child alignment11.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 74;
			// Container child hbox2.Gtk.Box+BoxChild
			this.alignment17 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment17.Name = "alignment17";
			// Container child alignment17.Gtk.Container+ContainerChild
			this.btnTestConnection = new global::Gtk.Button ();
			this.btnTestConnection.CanFocus = true;
			this.btnTestConnection.Name = "btnTestConnection";
			// Container child btnTestConnection.Gtk.Container+ContainerChild
			global::Gtk.Alignment w44 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w45 = new global::Gtk.HBox ();
			w45.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w46 = new global::Gtk.Image ();
			w46.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-connect", global::Gtk.IconSize.Button);
			w45.Add (w46);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w48 = new global::Gtk.Label ();
			w48.LabelProp = global::Mono.Unix.Catalog.GetString ("Test Connection");
			w45.Add (w48);
			w44.Add (w45);
			this.btnTestConnection.Add (w44);
			this.alignment17.Add (this.btnTestConnection);
			this.hbox2.Add (this.alignment17);
			global::Gtk.Box.BoxChild w53 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.alignment17]));
			w53.Position = 0;
			w53.Expand = false;
			w53.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.alignment18 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment18.WidthRequest = 175;
			this.alignment18.Name = "alignment18";
			// Container child alignment18.Gtk.Container+ContainerChild
			this.lblTestResult = new global::Gtk.Label ();
			this.lblTestResult.Name = "lblTestResult";
			this.alignment18.Add (this.lblTestResult);
			this.hbox2.Add (this.alignment18);
			global::Gtk.Box.BoxChild w55 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.alignment18]));
			w55.Position = 1;
			w55.Expand = false;
			w55.Fill = false;
			this.alignment11.Add (this.hbox2);
			this.vbox2.Add (this.alignment11);
			global::Gtk.Box.BoxChild w57 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.alignment11]));
			w57.Position = 6;
			w57.Expand = false;
			w57.Fill = false;
			this.alignment1.Add (this.vbox2);
			w1.Add (this.alignment1);
			global::Gtk.Box.BoxChild w59 = ((global::Gtk.Box.BoxChild)(w1 [this.alignment1]));
			w59.Position = 0;
			w59.Expand = false;
			w59.Fill = false;
			// Internal child SQLiteMonoPlusUI.frmDatabaseConnect.ActionArea
			global::Gtk.HButtonBox w60 = this.ActionArea;
			w60.Name = "dialog1_ActionArea";
			w60.Spacing = 10;
			w60.BorderWidth = ((uint)(7));
			w60.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(1));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnCancel = new global::Gtk.Button ();
			this.btnCancel.CanDefault = true;
			this.btnCancel.CanFocus = true;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseStock = true;
			this.btnCancel.UseUnderline = true;
			this.btnCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.btnCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w61 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w60 [this.btnCancel]));
			w61.Expand = false;
			w61.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnConnect = new global::Gtk.Button ();
			this.btnConnect.CanDefault = true;
			this.btnConnect.CanFocus = true;
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.UseStock = true;
			this.btnConnect.UseUnderline = true;
			this.btnConnect.Label = "gtk-connect";
			this.AddActionWidget (this.btnConnect, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w62 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w60 [this.btnConnect]));
			w62.Position = 1;
			w62.Expand = false;
			w62.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnSaveConnect = new global::Gtk.Button ();
			this.btnSaveConnect.CanFocus = true;
			this.btnSaveConnect.Name = "btnSaveConnect";
			this.btnSaveConnect.UseUnderline = true;
			this.btnSaveConnect.Label = global::Mono.Unix.Catalog.GetString ("Save & Connect");
			this.AddActionWidget (this.btnSaveConnect, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w63 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w60 [this.btnSaveConnect]));
			w63.Position = 2;
			w63.Expand = false;
			w63.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 624;
			this.DefaultHeight = 464;
			this.spnMaxPool.Hide ();
			this.alignment22.Hide ();
			this.alignment23.Hide ();
			this.lblMaxPool.Hide ();
			this.algAdvanced.Hide ();
			this.Show ();
			this.fcDBFile.SelectionChanged += new global::System.EventHandler (this.OnFcDBFileSelectionChanged);
			this.cbxAdvanced.Toggled += new global::System.EventHandler (this.OnCbxAdvancedToggled);
			this.cbxPooling.Clicked += new global::System.EventHandler (this.cbxPooling_Clicked);
			this.btnTestConnection.Clicked += new global::System.EventHandler (this.btnTestConnection_Clicked);
		}
	}
}
