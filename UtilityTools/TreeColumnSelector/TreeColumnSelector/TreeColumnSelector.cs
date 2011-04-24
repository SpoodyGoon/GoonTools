

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
		private Gdk.Pixbuf _HeaderImage = Gdk.Pixbuf.LoadFromResource("columnpicker.png");
		private Gdk.Pixbuf _HeaderImage_Hover = Gdk.Pixbuf.LoadFromResource("columnpicker_hover.png");
		private Gtk.Image _BaseImage;
		private bool _UseHover = true;
		private const int _MinImageWidth =  16;
		private const int _MinImageHeight =  16;
		
		#region Constructors
		
		public TreeColumnSelector()
		{
			BuildGui();
		}
		
		public TreeColumnSelector(bool usehover)
		{
			_UseHover = usehover;
			BuildGui();
		}
		
		public TreeColumnSelector(Gdk.Pixbuf image)
		{
			try
			{
				if(image == null)
					throw new ArgumentNullException("The image used for column header cannot be null");
				if(image.Width < _MinImageWidth || image.Height < _MinImageHeight)
					throw new Exception("The image for column header is less than minimum requirements of no less than 16 wide and 16 high");
				_HeaderImage = image;
				// REVIEW: making the assumtion that a hover image was not passed in
				// most likely there is no hover image to use.
				_UseHover = false;
				BuildGui();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
		public TreeColumnSelector(Gdk.Pixbuf image, Gdk.Pixbuf image_hover)
		{
			try
			{
				if(image == null)
					throw new ArgumentNullException("The image used for column header cannot be null");
				if(image.Width < _MinImageWidth || image.Height < _MinImageHeight)
					throw new Exception("The image for column header is less than minimum requirements of no less than 16 wide and 16 high");
				if(image_hover == null)
					throw new ArgumentNullException("The hover image for column header cannot be null");
				if(image_hover.Width < _MinImageWidth || image_hover.Height < _MinImageHeight)
					throw new Exception("The hover image for column header is less than minimum requirements of no less than 16 wide and 16 high");
				
				_HeaderImage = image;
				_HeaderImage_Hover = image_hover;
				BuildGui();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
		public TreeColumnSelector(string imagefile)
		{
			try
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(imagefile);
				// check to be sure the image is there
				if(!fi.Exists)
					throw new System.IO.FileNotFoundException("Missing image file for column header.", fi.FullName);
				
				// REVIEW: making the assumtion that a hover image was not passed in
				// most likely there is no hover image to use.
				_UseHover = false;
				_HeaderImage = new Gdk.Pixbuf(imagefile);
				BuildGui();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}
		
		public TreeColumnSelector(string imagefile, string imagefile_hover)
		{
			try
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(imagefile);
				// check to be sure the image is there
				if(!fi.Exists)
					throw new System.IO.FileNotFoundException("Missing image file for column header.", fi.FullName);
				// set the image file
				_HeaderImage = new Gdk.Pixbuf(fi.FullName);
				// check the minimum image hight requriements
				if(_HeaderImage.Width < _MinImageWidth || _HeaderImage.Height < _MinImageHeight)
					throw new Exception("Image for column header is less than minimum requirements of no less than 16 wide and 16 high");
				
				if(_UseHover || String.IsNullOrEmpty(imagefile_hover))
				{
					// REVIEW: making the assumtion that a hover image was not passed in
					// most likely there is no hover image to use.
					_UseHover = false;
					System.IO.FileInfo fi_hover = new System.IO.FileInfo(imagefile_hover);
					if(!fi_hover.Exists)
						throw new System.IO.FileNotFoundException("Missing image file for column header.", fi_hover.FullName);
					_HeaderImage_Hover = new Gdk.Pixbuf(fi_hover.FullName);
					if(_HeaderImage_Hover.Width < _MinImageWidth || _HeaderImage_Hover.Height < _MinImageHeight)
						throw new Exception("Image for column header is less than minimum requirements of no less than 16 wide and 16 high");
				}
				
				BuildGui();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, true, "<b>GoonTools Column Selector</b>\n" + ex.ToString(), "GoonTools Column Selector Error");
				md.Run();
				md.Destroy();
			}
		}

		#endregion Constructors
		
		public void BuildGui()
		{
			try
			{
				// set up the image that everything else will be based around
				_BaseImage = new Image(_HeaderImage);
				_BaseImage.SetPadding(3,0);
				_BaseImage.IconSize = (int)Gtk.IconSize.SmallToolbar;
				this.FixedWidth = _BaseImage.Allocation.Width;
				
				// finish setting up the TreeViewColumn
				this.Clickable = true;
				this.Resizable = false;
				this.Widget = _BaseImage;
				this.Widget.ShowAll();
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
				Gtk.TreeView tv = (Gtk.TreeView)this.TreeView;
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
		
		public Gdk.Pixbuf HeaderImage_Hover
		{
			set{_HeaderImage_Hover = value;}
		}
		
		public Gdk.Pixbuf WidgetImage
		{
			set{_HeaderImage = value;}
		}
		
		public bool UseHover
		{
			set{_UseHover = value;}
			get{return _UseHover;}
		}
		
		#endregion Public Properties
	}
}
