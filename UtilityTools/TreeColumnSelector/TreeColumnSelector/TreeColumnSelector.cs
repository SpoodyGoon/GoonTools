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
		private TreeViewColumnCollection _Columns = new TreeViewColumnCollection();
		private Gdk.Pixbuf _WidgetImage = null;
		private string _WidgetImageFile = null;
		private GoonTools.ColumnSelector.TreeColumnSelector _ColumnSelect = new GoonTools.ColumnSelector.TreeColumnSelector();
		public TreeColumnSelector()
		{			
			
		}

		public TreeColumnSelector(Gtk.TreeViewColumn[] cols) 
		{
			for(int i = 0; i < cols.Length; i++)
			{
				_Columns.Add(cols[i]); 
			} 
			//this.TreeView.Shown += new EventHandler(TreeColumnSelector_Shown);
		}

		private void TreeColumnSelector_Shown(object sender, EventArgs e)
		{
			
			Console.WriteLine("PreLoad");
			Console.Read();
		}
		
		private void TreeColumnSelector_PreLoad(object sender, IntPtr meth)
		{
			Console.WriteLine("PreLoad");
			Console.Read();
		}
		
		public TreeColumnSelector(Gtk.TreeViewColumn[] cols, Gdk.Pixbuf pix)
		{
			for(int i = 0; i < cols.Length; i++)
			{
				_Columns.Add(cols[i]);
			}
			_WidgetImage = pix;
			//this.TreeView.Realized += new EventHandler(TreeColumnSelector_Realized);
		}
		
		public TreeColumnSelector(Gtk.TreeViewColumn[] cols, string imagefile)
		{
			for(int i = 0; i < cols.Length; i++)
			{
				_Columns.Add(cols[i]);
			}
			_WidgetImageFile = imagefile;
			//this.TreeView.Realized += new EventHandler(TreeColumnSelector_Realized);
		}

		public void TreeColumnSelector_Realized(object sender, EventArgs e)
		{
			try
			{
				this.FixedWidth = 25;
				this.Clickable=true;
				this.Resizable = false;
				Gtk.Image img = GetWidgetImage();
				img.SetPadding(3,0);
				Gtk.Fixed fx = new Gtk.Fixed();
				fx.SizeAllocate(img.Allocation);
				fx.Put(img, 0,0);
				fx.ShowAll();
				this.Widget = (Gtk.Widget)fx;
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
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
				PopupWindow pop = new PopupWindow(_Columns, new Gdk.Rectangle(x, y, width, height));
				for(int i = 0; i< _Columns.Count; i++)
				{
					if(((Gtk.TreeViewColumn)_Columns[i]).Title != "")
						pop.AddColumn(i, ((Gtk.TreeViewColumn)_Columns[i]).Visible, ((Gtk.TreeViewColumn)_Columns[i]).Title);
				}
				pop.ShowPopUp();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
		private Gtk.Image GetWidgetImage()
		{
			try
			{
				if(_WidgetImage != null)
				{
					return new Gtk.Image(_WidgetImage);
				}
				else if(_WidgetImageFile != null && _WidgetImageFile.Trim() != string.Empty)
				{
					System.IO.FileInfo fi = new System.IO.FileInfo(_WidgetImageFile);
					if(fi.Exists)
						return new Gtk.Image(fi.FullName);
					else
						return new Gtk.Image(Gdk.Pixbuf.LoadFromResource("columnpicker.png")); // default image resource
				}
				else
				{
					// default image resource
					return new Gtk.Image(Gdk.Pixbuf.LoadFromResource("columnpicker.png"));
				}
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
			return null;
		}
		
		#region Public Properties
		
		public Gdk.Pixbuf WidgetImage
		{
			set{_WidgetImage=value;}
			get{return _WidgetImage;}
		}
		
		public string WidgetImageFile
		{
			set{_WidgetImageFile=value;}
			get{return _WidgetImageFile;}
		}
		
		#endregion Public Properties
	}
}
