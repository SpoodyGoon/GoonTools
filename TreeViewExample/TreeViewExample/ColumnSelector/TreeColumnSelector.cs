
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	
	public class TreeColumnSelector : Gtk.TreeViewColumn
	{
		private Gtk.Fixed fx = new Gtk.Fixed();
		private Gtk.Image img = new Gtk.Image(Gdk.Pixbuf.LoadFromResource("columnpicker.png"));
		private Gtk.TreeViewColumn[] _Columns;
		private Gdk.Rectangle _TreeViewArea;
		public TreeColumnSelector(Gtk.TreeViewColumn[] cols, Gdk.Rectangle rec)
		{
			_Columns = cols;
			_TreeViewArea = rec;
			this.MinWidth = 25;
			this.Clickable = true;
			this.Resizable = false;
			this.Visible = true;
			
			img.SetPadding(3,0);			
			fx.SizeAllocate(img.Allocation);
			fx.Put(img, 0,0);
			fx.ShowAll();
			this.Widget = (Gtk.Widget)fx;
			this.Clicked += new EventHandler(TreeColumnSelector_Clicked);
			
		}

		private void TreeColumnSelector_Clicked(object sender, EventArgs e)
		{
			PopupWindow pop = new PopupWindow(_Columns, _TreeViewArea, fx.Allocation);
		}
	}
}
