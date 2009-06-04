
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	
	public class PopupWindow : Gtk.Window
	{
		private Gtk.TreeViewColumn[] _Columns;
		private Gdk.Rectangle _TreeViewColumnArea;
		private Gtk.ScrolledWindow swColumnSelector;
		private GoonTools.ColumnSelectorTreeView _ColumnSelectorTreeView;
		private int _Width = 100;
		private int _Height = 200;
		public PopupWindow(Gtk.TreeViewColumn[] col, Gdk.Rectangle ColHeaderRec) : base(Gtk.WindowType.Popup)
		{
			Build();
			_Columns = col;
			_TreeViewColumnArea = ColHeaderRec;		
			
			//System.Diagnostics.Debug.WriteLine(_Left.ToString() + " - " + _Top.ToString());
			this.WidthRequest = _Width;
			this.HeightRequest = _Height;
			this.Move(ColHeaderRec.Left - _Width, ColHeaderRec.Top + 3);
			_ColumnSelectorTreeView = new ColumnSelectorTreeView(this);
			swColumnSelector.Add(_ColumnSelectorTreeView);
			this.ShowAll();
			
		}
		
		#region Build GUI
		
		private void Build()
		{
			this.CanFocus = true;
			this.Name = "GoonTools.ColumnSelector.PopupWindow";
			this.BorderWidth = ((uint)(2));
			this.Resizable = false;
			this.AllowGrow = false;
			this.DestroyWithParent = true;
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			this.Visible = false;
			// Container child MonoToDo.CustomWidgets.ColumnSelector.Gtk.Container+ContainerChild
			Gtk.Frame frame1 = new Gtk.Frame();
			frame1.Name = "frame1";
			// Container child frame1.Gtk.Container+ContainerChild
			Gtk.Alignment GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
			GtkAlignment.Name = "GtkAlignment";
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			Gtk.VBox vbox2 = new Gtk.VBox();
			vbox2.Name = "vbox2";
			// Container child vbox2.Gtk.Box+BoxChild
			Gtk.HButtonBox hbuttonbox1 = new Gtk.HButtonBox();
			hbuttonbox1.HeightRequest = 16;
			hbuttonbox1.Name = "hbuttonbox1";
			hbuttonbox1.LayoutStyle = ((Gtk.ButtonBoxStyle)(4));
			// Container child hbuttonbox1.Gtk.ButtonBox+ButtonBoxChild
			Gtk.Button btnClose = new Gtk.Button();
			btnClose.WidthRequest = 6;
			btnClose.HeightRequest = 16;
			btnClose.CanFocus = true;
			btnClose.ResizeMode = ResizeMode.Immediate;
			btnClose.Name = "btnClose";
			btnClose.Relief = ((Gtk.ReliefStyle)(2));
			// Container child btnClose.Gtk.Container+ContainerChild
			Gtk.Alignment alignment1 = new Gtk.Alignment(1F, 0.5F, 0.01F, 0.01F);
			alignment1.WidthRequest = 16;
			alignment1.HeightRequest = 16;
			alignment1.Name = "alignment1";
			alignment1.LeftPadding = ((uint)(1));
			alignment1.RightPadding = ((uint)(1));
			// Container child alignment1.Gtk.Container+ContainerChild
			Gtk.Label lblClose = new Gtk.Label();
			lblClose.Name = "lblClose";
			lblClose.Xalign = 1F;
			lblClose.Yalign = 0.01F;
			lblClose.LabelProp = Mono.Unix.Catalog.GetString("<span color=\"black\" size=\"small\"><b>X</b></span>");
			lblClose.UseMarkup = true;
			lblClose.Justify = ((Gtk.Justification)(1));
			lblClose.WidthChars = 5;
			lblClose.MaxWidthChars = 5;
			alignment1.Add(lblClose);
			btnClose.Add(alignment1);
			btnClose.Label = null;
			hbuttonbox1.Add(btnClose);
			Gtk.ButtonBox.ButtonBoxChild w3 = ((Gtk.ButtonBox.ButtonBoxChild)(hbuttonbox1[btnClose]));
			w3.Expand = false;
			w3.Fill = false;
			vbox2.Add(hbuttonbox1);
			Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(vbox2[hbuttonbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			Gtk.HSeparator hseparator1 = new Gtk.HSeparator();
			hseparator1.Name = "hseparator1";
			vbox2.Add(hseparator1);
			Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(vbox2[hseparator1]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			Gtk.Alignment GtkAlignment1 = new Gtk.Alignment(0F, 0F, 1F, 1F);
			GtkAlignment1.Name = "GtkAlignment1";
			// Container child GtkAlignment1.Gtk.Container+ContainerChild
			this.swColumnSelector = new Gtk.ScrolledWindow();
			this.swColumnSelector.CanFocus = true;
			this.swColumnSelector.Name = "swColumnSelector";
			this.swColumnSelector.ShadowType = ((Gtk.ShadowType)(1));
			GtkAlignment1.Add(this.swColumnSelector);
			vbox2.Add(GtkAlignment1);
			Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(vbox2[GtkAlignment1]));
			w7.Position = 2;
			GtkAlignment.Add(vbox2);
			frame1.Add(GtkAlignment);
			this.Add(frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show();
			btnClose.EnterNotifyEvent += new EnterNotifyEventHandler(btnClose_EnterNotifyEvent);
			btnClose.LeaveNotifyEvent += new LeaveNotifyEventHandler(btnClose_LeaveNotifyEvent);
			btnClose.Clicked += new System.EventHandler(this.OnBtnCloseClicked);
		}
		
		#endregion Build GUI
		
		internal Gtk.TreeViewColumn[] Columns
		{
			get{return _Columns;}
		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			base.OnExposeEvent (evnt);
			int winWidth, winHeight;
			this.GetSize (out winWidth, out winHeight);
			
			this.GdkWindow.DrawRectangle (this.Style.ForegroundGC (Gtk.StateType.Insensitive), false, 0, 0, winWidth-1, winHeight-1);
			return false;
		}

		
		internal void ShowPopUp()
		{
			this.Visible = true;
			//this.HeightRequest = (_ColumnSelectorTreeView.Allocation.Bottom - _ColumnSelectorTreeView.Allocation.Top) + 45;
			HollyLibrary.GrabUtil.GrabWindow(this);
			this.ShowAll();
		}
		
		internal void AddColumn(int Index, bool IsVisible, string ColumnTitle)
		{
			_ColumnSelectorTreeView.ColumnStore.AppendValues(Index, IsVisible, ColumnTitle);
		}

		private void Close()
		{
			HollyLibrary.GrabUtil.RemoveGrab(this);
			this.Destroy();
		}

		[GLib.DefaultSignalHandlerAttribute()]
		protected override bool OnButtonPressEvent(Gdk.EventButton evnt)
		{
			this.Close();
			return base.OnButtonPressEvent(evnt);
		}	
		
		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Close();
		}

		protected void btnClose_EnterNotifyEvent(object sender, EnterNotifyEventArgs args)
		{
			Gtk.Button btn = (Gtk.Button)sender;
			btn.State = StateType.Normal;
		}		

		private void btnClose_LeaveNotifyEvent(object sender, LeaveNotifyEventArgs args)
		{
			Gtk.Button btn = (Gtk.Button)sender;
			btn.State = StateType.Normal;
		}
	}
}
