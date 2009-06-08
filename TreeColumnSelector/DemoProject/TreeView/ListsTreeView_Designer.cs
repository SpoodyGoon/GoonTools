/*************************************************************************
 *                      ListTreeView_Designer.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <MonoToDo@brdstudio.net>
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
using System.Collections;
using Gtk;

namespace TaskList
{
	
	public partial class ListsTreeView : Gtk.TreeView
	{
		private Gtk.Window _Parent;
		private string _FilterText = "";
		private bool _ShowOnlyActive = false;
		private bool _FilterActive = true;
		private Gtk.TreeModelFilter filter;
		private Gtk.ListStore ls = new Gtk.ListStore(typeof(int), typeof(string), typeof(string), typeof(bool));
		private void Build()
		{
			this.HeadersClickable = true;
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			// treeview set up
			// Create a column for the List ID
			Gtk.TreeViewColumn colListID = new Gtk.TreeViewColumn ();
			colListID.Alignment=0.5f;
			colListID.Visible = false;
			colListID.Title = "ID";
			
			// Create a column for the list name
			Gtk.TreeViewColumn colListName = new Gtk.TreeViewColumn ();
			colListName.Expand = true;
			colListName.Resizable = true;
			colListName.Visible = true;
			colListName.Title = "  List Name";
			
			// Create a column for the date
			Gtk.TreeViewColumn colDate = new Gtk.TreeViewColumn ();
			colDate.Resizable = true;
			colDate.Visible = true;
			colDate.Title = "  Date";
			
			// Create a column for the Archive
			Gtk.TreeViewColumn colIsActive = new Gtk.TreeViewColumn ();
			colIsActive.Alignment=0.5f;
			colIsActive.Resizable = false;
			colIsActive.Title = "Active";
			colIsActive.Visible = true;			
			
			// Add the columns to the TreeView
			this.AppendColumn(colListID);
			this.AppendColumn (colListName);
			this.AppendColumn (colDate);
			this.AppendColumn (colIsActive);
			this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			// set up the columns
			Gtk.CellRendererText cellListID = new Gtk.CellRendererText ();
			cellListID.Width=25;
			cellListID.Xalign = 0.5f;
			colListID.PackStart (cellListID, false);
			
			Gtk.CellRendererText cellListName = new Gtk.CellRendererText ();
			cellListName.Width=250;
			cellListName.Xalign=0.9f;
			cellListName.Editable = true;
			colListName.PackStart (cellListName, true);
			
			Gtk.CellRendererText cellDate = new Gtk.CellRendererText ();
			cellDate.Xalign = 0.9f;
			cellDate.Width=70;
			colDate.PackStart (cellDate, true);
			
			Gtk.CellRendererToggle cellIsActive = new Gtk.CellRendererToggle ();
			cellIsActive.Xalign=0.9f;
			cellIsActive.Width=30;
			colIsActive.PackStart (cellIsActive, false);
			
			// Tell the Cell Renderers which item(frmMain)s in the model to display
			colListID.AddAttribute (cellListID, "text", 0);
			colListName.AddAttribute (cellListName, "text", 1);
			colDate.AddAttribute (cellDate, "text", 2);
			colIsActive.AddAttribute(cellIsActive, "active", 3);
			this.Model = ls;
			
		}
	}
}