/*************************************************************************
 *                      PopupWindow.cs
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
	
	public class PopupWindow : Gtk.Window
	{
		private Gtk.TreeViewColumn[] _Columns;
		private ColumnSelectorTreeView _ColumnSelectorTreeView;
		// the padding is just used to help fine tune the format of the popup window
		private int _Padding = 3;
		public PopupWindow(Gtk.TreeViewColumn[] col, Gdk.Rectangle ColHeaderRec) : base(Gtk.WindowType.Popup)
		{
			Build();
			_Columns = col;
			this.WidthRequest = ColHeaderRec.Width;
			this.HeightRequest = ColHeaderRec.Height;
			this.Move(ColHeaderRec.Left - ColHeaderRec.Width + _Padding, ColHeaderRec.Top + 5);
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
			// add the child treeview to the window
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
		
		/// <summary>
		///  this property gives access to the columns
		///  for the child treeview
		/// </summary>
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
		
		/// <summary>
		///  This add the columns from the treeview we are adjusting
		///  to the child treeview that will display 
		///  and control the visiblity of the columns on the parent treeivew
		/// </summary>
		/// <param name="Index"></param>
		/// <param name="IsVisible"></param>
		/// <param name="ColumnTitle"></param>
		internal void AddColumn(int Index, bool IsVisible, string ColumnTitle)
		{
			_ColumnSelectorTreeView.ColumnStore.AppendValues(Index, IsVisible, ColumnTitle);
		}

		private void Close()
		{
			HollyLibrary.GrabUtil.RemoveGrab(this);
			this.Destroy();
		}

		/// <summary>
		///  this event lets us close the popup window
		///  and release the grab we got through the HollyLibrary
		///  without this event getting the focus back from this window
		///  in a Linux/Gnome enviroment is very hard. lol
		/// </summary>
		/// <param name="evnt"></param>
		/// <returns></returns>
		[GLib.DefaultSignalHandlerAttribute()]
		protected override bool OnButtonPressEvent(Gdk.EventButton evnt)
		{
			this.Close();
			return base.OnButtonPressEvent(evnt);
		}
	}
}
