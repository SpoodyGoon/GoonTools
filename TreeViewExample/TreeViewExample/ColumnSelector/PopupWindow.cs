
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	
	public partial class PopupWindow : Gtk.Window
	{
		private Gtk.TreeViewColumn[] _Columns;
		private Gdk.Rectangle _TreeViewArea;
		private Gdk.Rectangle _TreeViewColumnArea;
		public PopupWindow(Gtk.TreeViewColumn[] col, Gdk.Rectangle TreeViewRec, Gdk.Rectangle ColHeaderRec) : base(Gtk.WindowType.Popup)
		{
			_Columns = col;
			_TreeViewArea = TreeViewRec;
			_TreeViewColumnArea = ColHeaderRec;
			
			this.Resizable = true;
			this.Visible = false;
//			this.WidthRequest = width;
//			this.HeightRequest = height;
//			this.Move(x - width, y);
//			_ColumnSelectorTreeView = new ColumnSelectorTreeView(this);
//			swColumnSelector.Add(_ColumnSelectorTreeView);
			this.ShowAll();
			
		}
		
//		internal Gtk.TreeView ParentTree
//		{
//			get{return _CallingTreeView;}
//		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			base.OnExposeEvent (evnt);
			int winWidth, winHeight;
			this.GetSize (out winWidth, out winHeight);
			
			this.GdkWindow.DrawRectangle (this.Style.ForegroundGC (Gtk.StateType.Insensitive), false, 0, 0, winWidth-1, winHeight-1);
			return false;
		}

		
		public void ShowPopUp()
		{			
//			this.Visible = true;
//			this.HeightRequest = (_ColumnSelectorTreeView.Allocation.Bottom - _ColumnSelectorTreeView.Allocation.Top) + 45;			
//			HollyLibrary.GrabUtil.GrabWindow(this);
//			this.ShowAll();
		}
		
		public void AddColumn(int Index, bool IsVisible, string ColumnTitle)
		{
//			((Gtk.ListStore)_ColumnSelectorTreeView.Model).AppendValues(Index, IsVisible, ColumnTitle);
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
		}	protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{this.Close();
		}





	}
}
