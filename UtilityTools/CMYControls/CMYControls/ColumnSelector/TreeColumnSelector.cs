/*************************************************************************
 *                      TreeColumnSelector.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using CMYControls;
using Gtk;

namespace CMYControls.ColumnSelector
{
	
	
	public class TreeColumnSelector : Gtk.TreeViewColumn
	{
		private Gtk.TreeViewColumn[] _Columns;
		public TreeColumnSelector(Gtk.TreeViewColumn[] cols)
		{
			_Columns = cols;
			this.FixedWidth = 25;
			this.Clickable=true;
			this.Resizable = false;
			Gtk.Image img = new Gtk.Image(Gdk.Pixbuf.LoadFromResource("columnpicker.png"));
			img.SetPadding(3,0);
			Gtk.Fixed fx = new Gtk.Fixed();
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
				int x, y, width = 120, height = 175;
				// get the position of the parent window
				this.TreeView.ParentWindow.GetPosition( out x, out y );
				// now find the treeviews allocation
				x = x + this.TreeView.Allocation.Right;
				y += this.TreeView.Allocation.Top + this.Widget.Allocation.Bottom;
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
				Common.HandleError(ex, "TreeView Column Selector");
			}
			
		}
	}
}
