
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
			try
			{
				PopupWindow pop = new PopupWindow(_Columns, _TreeViewArea, fx.Allocation);
				for(int i = 0; i< _Columns.Length; i++)
				{
					if(_Columns[i].Title != "")
						pop.AddColumn(i, _Columns[i].Visible, _Columns[i].Title);
				}
				pop.ShowPopUp();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
	}
}
