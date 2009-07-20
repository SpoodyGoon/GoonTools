/*************************************************************************
 *                      ColumnSelectorTreeView.cs
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
	/// <summary>
	/// Description of ColumnSelectorTreeView.
	/// </summary>
	public partial class ColumnSelectorTreeView : Gtk.TreeView
	{
		public ColumnSelectorTreeView(GoonTools.ColumnSelector.PopupWindow parent)
		{
			this.Build();
			_Parent = parent;
		}
		
		internal ListStore ColumnStore
		{
			get{return _ColumnStore;}
		}
		
		[GLib.DefaultSignalHandlerAttribute()]
		protected override bool OnButtonPressEvent(Gdk.EventButton evnt)
		{
			Gtk.TreePath path;
			Gtk.TreeIter iter;
			Gtk.TreeViewColumn col;
			int x_out;
			int y_out;
			
			if(evnt.Button == 1)
			{
				this.GetPathAtPos((int)evnt.X, (int)evnt.Y, out path, out col, out x_out, out y_out);
				if(col.Title == "IsVisible")
				{
					if(_ColumnStore.GetIterFromString(out iter, path.ToString()))
					{
						bool blnIsChecked = Convert.ToBoolean(_ColumnStore.GetValue(iter, 1)) ? false:true;
						_Parent.Columns[Convert.ToInt16(_ColumnStore.GetValue(iter, 0))].Visible = blnIsChecked;
						_ColumnStore.SetValue(iter, 1, blnIsChecked);
					}
				}
			}
			return base.OnButtonPressEvent(evnt);
		}
	}
}
