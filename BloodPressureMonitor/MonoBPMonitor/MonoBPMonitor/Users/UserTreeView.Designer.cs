/*************************************************************************
 *                      UserTreeView.Designer.cs
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
using System.Data;
using System.Collections;
using Gtk;

namespace MonoBPMonitor.Users
{
	/// <summary>
	/// Description of UserTreeView_Designer.
	/// </summary>
	public partial class  UserTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _UserListsStore = new ListStore(typeof(User));
		private void Build()
		{
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			Gtk.TreeViewColumn colUserID = new Gtk.TreeViewColumn ();
			colUserID.Visible = false;
			colUserID.Title = "ID";
			Gtk.CellRendererText cellUserID = new Gtk.CellRendererText ();
			cellUserID.Width=25;
			cellUserID.Xalign = 0.5f;
			colUserID.PackStart (cellUserID, false);
			
			Gtk.TreeViewColumn colUserName = new Gtk.TreeViewColumn ();
			colUserName.Expand = true;
			colUserName.Resizable = true;
			colUserName.Visible = true;
			colUserName.Alignment = 0.05f;
			colUserName.Title = "User";
			Gtk.CellRendererText cellUserName = new Gtk.CellRendererText ();
			cellUserName.Width=200;
			cellUserName.Editable = true;
			cellUserName.Edited += cellUserName_Edited;
			colUserName.PackStart (cellUserName, true);
			
			Gtk.TreeViewColumn colDateAdded = new Gtk.TreeViewColumn ();
			colDateAdded.Visible = true;
			colDateAdded.Alignment=0.5f;
			colDateAdded.Title = "Date Added";
			Gtk.CellRendererText cellDateAdded = new Gtk.CellRendererText ();
			cellDateAdded.Width=80;
			colDateAdded.PackStart (cellDateAdded, false);
			
			Gtk.TreeViewColumn colIsActive = new Gtk.TreeViewColumn ();
			colIsActive.Visible = true;
			colIsActive.Alignment=0.5f;
			colIsActive.Title = "Active";
			Gtk.CellRendererToggle cellIsActive = new Gtk.CellRendererToggle ();
			cellIsActive.Width=45;
			cellIsActive.Sensitive = true;
			cellIsActive.Toggled += new Gtk.ToggledHandler(this.cellIsActive_Toggled);
			colIsActive.PackStart (cellIsActive, false);
			
			this.AppendColumn(colUserID);
			this.AppendColumn (colUserName);
			this.AppendColumn (colDateAdded);
			this.AppendColumn(colIsActive);
			//this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			colUserID.SetCellDataFunc(cellUserID, new Gtk.TreeCellDataFunc(RenderUserID));
			colUserName.SetCellDataFunc(cellUserName, new Gtk.TreeCellDataFunc(RenderUserName));
			colDateAdded.SetCellDataFunc(cellDateAdded, new Gtk.TreeCellDataFunc(RenderDateAdded));
			colIsActive.SetCellDataFunc(cellIsActive, new Gtk.TreeCellDataFunc(RenderIsActive));
			
			this.Model =_UserListsStore;
		}
	}	
	
	enum UserColumns
	{
		UserID,
		UserName,
		DateAdded,
		IsActive
	}
}
