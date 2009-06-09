/*************************************************************************
 *                      ColumnSelectorTreeView.designer.cs
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
	public partial class ColumnSelectorTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _ColumnStore = new Gtk.ListStore(typeof(int),typeof(bool), typeof(string));
		private GoonTools.ColumnSelector.PopupWindow _Parent;
		private void Build()
		{
			this.HeadersVisible = false;
			this.Sensitive = true;
			//this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Horizontal;
			
			Gtk.TreeViewColumn colIndex = new Gtk.TreeViewColumn();
			colIndex.Title = "Index";
			colIndex.Visible = false;
			
			Gtk.TreeViewColumn colIsVisible = new Gtk.TreeViewColumn ();
			colIsVisible.Title = "IsVisible";
			colIsVisible.Clickable = true;
			
			Gtk.TreeViewColumn colColumnTitle = new Gtk.TreeViewColumn ();
			colColumnTitle.Title="Title";
			colColumnTitle.Expand = true;
			
			this.AppendColumn(colIndex);
			this.AppendColumn(colIsVisible);
			this.AppendColumn (colColumnTitle);
			
			Gtk.CellRendererText cellIndex = new Gtk.CellRendererText ();
			colIndex.PackStart (cellIndex, false);
			
			Gtk.CellRendererToggle cellIsVisible = new Gtk.CellRendererToggle ();
			cellIsVisible.Mode = CellRendererMode.Editable;
			cellIsVisible.Sensitive = true;
			cellIsVisible.Activatable = true;
			cellIsVisible.Xalign = 0.5f;
			cellIsVisible.Width = 20;			
			colIsVisible.PackStart (cellIsVisible, false);
			
			Gtk.CellRendererText cellColumnTitle = new Gtk.CellRendererText ();
			cellColumnTitle.Width = 50;
			colColumnTitle.PackStart (cellColumnTitle, true);
			
			colIndex.AddAttribute(cellIndex, "text", 0);
			colIsVisible.AddAttribute(cellIsVisible, "active", 1);
			colColumnTitle.AddAttribute (cellColumnTitle, "text", 2);
			this.Sensitive = true;
			this.CanFocus= true;
			this.HoverSelection = true;
			this.Model = _ColumnStore;
		}
	}
}
