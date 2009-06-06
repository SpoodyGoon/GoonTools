
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{	
	
	public class PopupWindow : Gtk.Window
	{
		private Gtk.TreeViewColumn[] _Columns;
		private Gdk.Rectangle _TreeViewColumnArea;
		private GoonTools.ColumnSelectorTreeView _ColumnSelectorTreeView;
		private int _Width = 100;
		private int _Height = 200;
		public PopupWindow(Gtk.TreeViewColumn[] col, Gdk.Rectangle ColHeaderRec) : base(Gtk.WindowType.Popup)
		{
			Build();
			_Columns = col;
			_TreeViewColumnArea = ColHeaderRec;		
			
			this.WidthRequest = _Width;
			this.HeightRequest = _Height;
			this.Move(ColHeaderRec.Left - _Width + 3, ColHeaderRec.Top + 3);
			this.ShowAll();
		}
		
		#region Build GUI
		
		private void Build()
		{
			this.CanFocus = true;
			this.BorderWidth = 2;
			this.AllowGrow = false;
			this.DestroyWithParent = true;
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			// initialize the window with it not being visible
			// we'll set it to visible after the treeview has been populated
			this.Visible = false;
			Gtk.Frame frame1 = new Gtk.Frame();
			frame1.BorderWidth = 1;
			Gtk.Alignment GtkAlignment1 = new Gtk.Alignment(0F, 0F, 1F, 1F);
			Gtk.ScrolledWindow  GtkScrolledWindow1 = new Gtk.ScrolledWindow();
			GtkScrolledWindow1.ShadowType = Gtk.ShadowType.EtchedOut;
			_ColumnSelectorTreeView = new ColumnSelectorTreeView(this);
			GtkScrolledWindow1.Add(_ColumnSelectorTreeView);
			GtkAlignment1.Add(GtkScrolledWindow1);			
			frame1.Add(GtkAlignment1);
			this.Add(frame1);
			this.AppPaintable = true;
			this.ModifyBg(Gtk.StateType.Normal, new Gdk.Color(0, 0,0));
			this.Show();
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
	}
}
