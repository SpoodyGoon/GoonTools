

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
using Gtk;

namespace GoonTools.ColumnSelector
{
	[System.ComponentModel.Category("widget")]
	[System.ComponentModel.ToolboxItem(true)]
	public class TreeColumnSelector : Gtk.TreeViewColumn
	{
		private Gtk.Image _HeaderImage = new Gtk.Image(Gdk.Pixbuf.LoadFromResource("columnpicker.png"));
		public TreeColumnSelector()
		{
			BuildGui();
		}
		
		public TreeColumnSelector(Gdk.Pixbuf pix)
		{
			_HeaderImage = new Gtk.Image(pix);
			BuildGui();
		}
		
		public TreeColumnSelector(string imagefile)
		{
			System.IO.FileInfo fi = new System.IO.FileInfo(imagefile);
			if(fi.Exists)
				_HeaderImage = new Gtk.Image(fi.FullName);
			BuildGui();
		}

		public void BuildGui()
		{
			try
			{
				this.FixedWidth = 25;
				this.Clickable=true;
				this.Resizable = false;
				_HeaderImage.SetPadding(3,0);
				Gtk.Fixed fx = new Gtk.Fixed();
				_HeaderImage.IconSize = (int)Gtk.IconSize.SmallToolbar;
				fx.Put(_HeaderImage, 0,0);
				fx.SizeAllocate(_HeaderImage.Allocation);
				this.Widget = (Gtk.Widget)fx;
				fx.ShowAll();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnClicked()
		{
			try
			{
				int x, y, width = 120, height = 175;
				// get the position of the parent window
				this.TreeView.ParentWindow.GetPosition( out x, out y );
				// now find the treeviews allocation
				x = x + this.TreeView.Allocation.Right;
				y += this.TreeView.Allocation.Top + this.Widget.Allocation.Bottom;
				PopupWindow pop = new PopupWindow(((Gtk.TreeView)this.TreeView).Columns, new Gdk.Rectangle(x, y, width, height));
				pop.ShowPopUp();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
		#region Public Properties
		
		public Gdk.Pixbuf WidgetImage
		{
			set{_HeaderImage = new Gtk.Image(value);}
		}
		
		public string WidgetImageFile
		{
			set
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(value);
				if(fi.Exists)
					_HeaderImage = new Gtk.Image(fi.FullName);
			}
		}
		
		#endregion Public Properties
	}
}
