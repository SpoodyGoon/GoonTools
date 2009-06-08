
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	
	public class TreeColumnSelector : Gtk.TreeViewColumn
	{
		private Gtk.Fixed fx = new Gtk.Fixed();
		private Gtk.Image img = new Gtk.Image(Gdk.Pixbuf.LoadFromResource("columnpicker.png"));
		private Gtk.TreeViewColumn[] _Columns;
		public TreeColumnSelector(Gtk.TreeViewColumn[] cols)
		{
			_Columns = cols;
			this.MinWidth = 25;
			this.MaxWidth = 25;
			this.FixedWidth = 25;
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
				int x, y, width = 100, height = 200;
				// get the position of the parent window
				this.TreeView.ParentWindow.GetPosition( out x, out y );	
				// now find the treeview
				x = x + this.TreeView.Allocation.Right;
				y += this.TreeView.Allocation.Top + fx.Allocation.Bottom;
				PopupWindow pop = new PopupWindow(_Columns, new Gdk.Rectangle(x, y, width, height));
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
