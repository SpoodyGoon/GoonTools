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
	
	internal partial class ListsTreeView : Gtk.TreeView
	{
		private Gtk.Window _Parent;
		private string _FilterText = "";
		private bool _ShowOnlyActive = false;
		private bool _FilterActive = true;
		private Gtk.TreeModelFilter filter;
		private Gtk.ListStore ls = new Gtk.ListStore(typeof(String), typeof(String), typeof(String), typeof(Boolean));
		private void Build()
		{
			this.HeadersClickable = true;
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			// treeview set up
			// Create a column for the List ID
			Gtk.TreeViewColumn colListID = new Gtk.TreeViewColumn ();
			colListID.Clickable = true;
			colListID.Reorderable = true;
			colListID.Clicked +=  new EventHandler (Column_Clicked);
			colListID.Visible = false;
			colListID.Title = "ID";
			
			// Create a column for the list name
			Gtk.TreeViewColumn colListName = new Gtk.TreeViewColumn ();
			colListName.Clickable = true;
			colListName.Clicked +=  new EventHandler (Column_Clicked);
			colListName.Expand = true;
			colListID.Reorderable = true;
			colListName.Resizable = true;
			colListName.Visible = true;
			colListName.Title = "List Name";
			
			// Create a column for the date
			Gtk.TreeViewColumn colDate = new Gtk.TreeViewColumn ();
			colDate.Clickable = true;
			colDate.Reorderable = true;
			colDate.Clicked +=  new EventHandler (Column_Clicked);
			colDate.Resizable = true;
			colDate.Visible = true;
			colDate.Title = "Date";
			
			// Create a column for the Archive
			Gtk.TreeViewColumn colIsActive = new Gtk.TreeViewColumn ();
			colIsActive.Clickable = true;
			colIsActive.Reorderable = true;
			colIsActive.Clicked +=  new EventHandler (Column_Clicked);
			colIsActive.Resizable = false;
			colIsActive.Title = "Active";
			colIsActive.Visible = true;			
			
			// Add the columns to the TreeView
			this.AppendColumn(colListID);
			this.AppendColumn (colListName);
			this.AppendColumn (colDate);
			this.AppendColumn (colIsActive);
			this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns, this.Allocation));
			
			// set up the columns
			Gtk.CellRendererText cellListID = new Gtk.CellRendererText ();
			cellListID.Width=25;
			cellListID.Xalign = 0.5f;
			colListID.PackStart (cellListID, false);
			
			Gtk.CellRendererText cellListName = new Gtk.CellRendererText ();
			cellListName.Width=250;
			cellListName.Editable = true;
			cellListName.Edited += cellListName_Edited;
			colListName.PackStart (cellListName, true);
			
			Gtk.CellRendererText cellDate = new Gtk.CellRendererText ();
			cellDate.Width=30;
			colDate.PackStart (cellDate, true);
			
			Gtk.CellRendererToggle cellIsActive = new Gtk.CellRendererToggle ();
			cellIsActive.Width=30;
			cellIsActive.Toggled += new Gtk.ToggledHandler(this.cellIsActive_Toggled);
			colIsActive.PackStart (cellIsActive, false);
			
			// Tell the Cell Renderers which item(frmMain)s in the model to display
			colListID.AddAttribute (cellListID, "text", 0);
			colListName.AddAttribute (cellListName, "text", 1);
			colDate.AddAttribute (cellDate, "text", 2);
			colIsActive.AddAttribute(cellIsActive, "active", 3);
			
			// Create the filter and tell it to use the liststore as it's base Model
			filter = new Gtk.TreeModelFilter (ls, null);
			// Specify the function that determines which rows to filter out and which ones to display
			filter.VisibleFunc = new TreeModelFilterVisibleFunc(filter_VisibleFunc);
			
			//this.RowActivated += ListTreeView_RowActivated;
			this.Model = filter;
		}
	}
	
	enum ListColumns
	{
		ListID,
		ListName,
		DateCreated,
		IsActive
	}
}