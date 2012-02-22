
// This file has been generated by the GUI designer. Do not modify.
namespace SQLiteMonoPlusUI
{
	public partial class TabLabel
	{
		private global::Gtk.Alignment alignment2;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Alignment alignment3;
		private global::Gtk.Label lblTabLabel;
		private global::Gtk.Alignment alignment4;
		private global::Gtk.EventBox evtClose;
		private global::Gtk.Image imgClose;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget SQLiteMonoPlusUI.TabLabel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "SQLiteMonoPlusUI.TabLabel";
			// Container child SQLiteMonoPlusUI.TabLabel.Gtk.Container+ContainerChild
			this.alignment2 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment2.Name = "alignment2";
			// Container child alignment2.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment3 = new global::Gtk.Alignment (0.01F, 0.5F, 0.02F, 1F);
			this.alignment3.Name = "alignment3";
			// Container child alignment3.Gtk.Container+ContainerChild
			this.lblTabLabel = new global::Gtk.Label ();
			this.lblTabLabel.Name = "lblTabLabel";
			this.lblTabLabel.Xpad = 4;
			this.lblTabLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Tab Label");
			this.alignment3.Add (this.lblTabLabel);
			this.hbox1.Add (this.alignment3);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment3]));
			w2.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.alignment4 = new global::Gtk.Alignment (0.5F, 0.5F, 1F, 1F);
			this.alignment4.Name = "alignment4";
			// Container child alignment4.Gtk.Container+ContainerChild
			this.evtClose = new global::Gtk.EventBox ();
			this.evtClose.Name = "evtClose";
			// Container child evtClose.Gtk.Container+ContainerChild
			this.imgClose = new global::Gtk.Image ();
			this.imgClose.WidthRequest = 12;
			this.imgClose.HeightRequest = 12;
			this.imgClose.Name = "imgClose";
			this.imgClose.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("TabClose.png");
			this.evtClose.Add (this.imgClose);
			this.alignment4.Add (this.evtClose);
			this.hbox1.Add (this.alignment4);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.alignment4]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.alignment2.Add (this.hbox1);
			this.Add (this.alignment2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.evtClose.EnterNotifyEvent += new global::Gtk.EnterNotifyEventHandler (this.OnEvtCloseEnterNotifyEvent);
			this.evtClose.LeaveNotifyEvent += new global::Gtk.LeaveNotifyEventHandler (this.OnEvtCloseLeaveNotifyEvent);
			this.evtClose.ButtonReleaseEvent += new global::Gtk.ButtonReleaseEventHandler (this.OnEvtCloseButtonReleaseEvent);
		}
	}
}
