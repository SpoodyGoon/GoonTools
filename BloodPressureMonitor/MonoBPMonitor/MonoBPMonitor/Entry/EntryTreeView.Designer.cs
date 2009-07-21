/*************************************************************************
 *                      EntryTreeView.Designer.cs
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

namespace MonoBPMonitor.Entrys
{
	/// <summary>
	/// Description of EntryTreeView_Designer.
	/// </summary>
	public partial class EntryTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _EntryListsStore = new ListStore(typeof(Entry));
		private void Build()
		{
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			Gtk.TreeViewColumn colEntryID = new Gtk.TreeViewColumn ();
			colEntryID.Visible = false;
			colEntryID.Title = "ID";
			// Cell for the column
			Gtk.CellRendererText cellEntryID = new Gtk.CellRendererText ();
			cellEntryID.Width=25;
			cellEntryID.Xalign = 0.5f;
			colEntryID.PackStart (cellEntryID, false);
			
			// Create a column for the list name
			Gtk.TreeViewColumn colEntryDate = new Gtk.TreeViewColumn ();
			colEntryDate.Expand = true;
			colEntryDate.Visible = true;
			colEntryDate.Title = "Date";
			Gtk.CellRendererText cellEntryDate = new Gtk.CellRendererText ();
			cellEntryDate.Width=75;
			cellEntryDate.Editable = true;
			//cellEntryDate.Edited += cellEntryDate_Edited;
			colEntryDate.PackStart (cellEntryDate, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colSystolic = new Gtk.TreeViewColumn ();
			colSystolic.Visible = true;
			colSystolic.Title = "Systolic";
			Gtk.CellRendererText cellSystolic = new Gtk.CellRendererText ();
			cellSystolic.Width=50;
			colSystolic.PackStart (cellSystolic, false);
			
			// Create a column for the date
			Gtk.TreeViewColumn colDiastolic = new Gtk.TreeViewColumn ();
			colDiastolic.Visible = true;
			colDiastolic.Title = "Diastolic";
			Gtk.CellRendererText cellDiastolic = new Gtk.CellRendererText ();
			cellDiastolic.Width=50;
			colDiastolic.PackStart (cellDiastolic, false);
			
			// Create a column for the date
			Gtk.TreeViewColumn colHeartRate = new Gtk.TreeViewColumn ();
			colHeartRate.Visible = true;
			colHeartRate.Title = "Heart Rate";
			Gtk.CellRendererText cellHeartRate = new Gtk.CellRendererText ();
			cellHeartRate.Width=50;
			colHeartRate.PackStart (cellHeartRate, false);
			
			// Create a column for the date
			Gtk.TreeViewColumn colNotes = new Gtk.TreeViewColumn ();
			colNotes.Visible = true;
			colNotes.Resizable = true;
			colNotes.Title = "Notes";
			Gtk.CellRendererText cellNotes = new Gtk.CellRendererText ();
			cellNotes.Width=50;
			colNotes.PackStart (cellNotes, false);
			
			// Create a column for the date
			Gtk.TreeViewColumn colUserID = new Gtk.TreeViewColumn ();
			colUserID.Resizable = true;
			colUserID.Visible = true;
			colUserID.Title = "User";
			Gtk.CellRendererText cellUserID = new Gtk.CellRendererText ();
			cellUserID.Width=120;
			colUserID.PackStart (cellUserID, true);
			
			// Add the columns to the TreeView
			this.AppendColumn(colEntryID);
			this.AppendColumn (colEntryDate);
			this.AppendColumn (colSystolic);
			this.AppendColumn(colDiastolic);
			this.AppendColumn (colHeartRate);
			this.AppendColumn (colNotes);
			this.AppendColumn (colUserID);
			//this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			colEntryID.SetCellDataFunc(cellEntryID, new Gtk.TreeCellDataFunc(RenderEntryID));
			colEntryDate.SetCellDataFunc(cellEntryDate, new Gtk.TreeCellDataFunc(RenderEntryDate));
			colSystolic.SetCellDataFunc(cellSystolic, new Gtk.TreeCellDataFunc(RenderSystolic));
			colDiastolic.SetCellDataFunc(cellDiastolic, new Gtk.TreeCellDataFunc(RenderDiastolic));
			colHeartRate.SetCellDataFunc(cellHeartRate, new Gtk.TreeCellDataFunc(RenderHeartRate));
			colNotes.SetCellDataFunc(cellNotes, new Gtk.TreeCellDataFunc(RenderNotes));
			colUserID.SetCellDataFunc(cellUserID, new Gtk.TreeCellDataFunc(RenderUserID));
			
			this.Model =_EntryListsStore;
		}
	}
	enum EntryColumns
	{
		EntryID,
		EntryDate,
		Systolic,
		HeartRate,
		Notes,
		UserID
	}
}
