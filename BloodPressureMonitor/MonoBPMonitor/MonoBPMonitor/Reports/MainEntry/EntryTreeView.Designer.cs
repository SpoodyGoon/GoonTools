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

namespace MonoBPMonitor.Reports
{
	/// <summary>
	/// Description of EntryTreeView_Designer.
	/// </summary>
	public partial class EntryRptTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _EntryRptListsStore = new ListStore(typeof(int), typeof(string),typeof(string),typeof(string),typeof(string),typeof(string));
		private int _CurrentUser = 1;
		private void Build()
		{
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			Gtk.TreeViewColumn colEntryID = new Gtk.TreeViewColumn ();
			colEntryID.Visible = false;
			colEntryID.Title = "ID";
			Gtk.CellRendererText cellEntryID = new Gtk.CellRendererText ();
			cellEntryID.Width=25;
			cellEntryID.Xalign = 0.5f;
			colEntryID.PackStart (cellEntryID, false);
			
			Gtk.TreeViewColumn colEntryDate = new Gtk.TreeViewColumn ();
			colEntryDate.Visible = true;
			colEntryDate.Title = "Date";
			Gtk.CellRendererText cellEntryDate = new Gtk.CellRendererText ();
			cellEntryDate.Width=75;
			cellEntryDate.Editable = true;
			colEntryDate.PackStart (cellEntryDate, true);
			
			Gtk.TreeViewColumn colBPReading = new Gtk.TreeViewColumn ();
			colBPReading.Visible = true;
			colBPReading.Title = "Blood Pressure";
			Gtk.CellRendererText cellBPReading = new Gtk.CellRendererText ();
			cellBPReading.Width=150;
			colBPReading.PackStart (cellBPReading, true);
			
			Gtk.TreeViewColumn colHeartRate = new Gtk.TreeViewColumn ();
			colHeartRate.Visible = true;
			colHeartRate.Title = "Heart Rate";
			Gtk.CellRendererText cellHeartRate = new Gtk.CellRendererText ();
			cellHeartRate.Width=50;
			colHeartRate.PackStart (cellHeartRate, false);
			
			Gtk.TreeViewColumn colAvgBPReading = new Gtk.TreeViewColumn ();
			colAvgBPReading.Visible = true;
			colAvgBPReading.Title = "Avg Blood Pressure";
			Gtk.CellRendererText cellAvgBPReading = new Gtk.CellRendererText ();
			cellAvgBPReading.Width=150;
			colAvgBPReading.PackStart (cellAvgBPReading, true);
			
			Gtk.TreeViewColumn colAvgHeartRate = new Gtk.TreeViewColumn ();
			colAvgHeartRate.Visible = true;
			colAvgHeartRate.Title = "Avg Heart Rate";
			Gtk.CellRendererText cellAvgHeartRate = new Gtk.CellRendererText ();
			cellAvgHeartRate.Width=50;
			colAvgHeartRate.PackStart (cellAvgHeartRate, false);
			
			this.AppendColumn(colEntryID);
			this.AppendColumn (colEntryDate);
			this.AppendColumn(colBPReading);
			this.AppendColumn (colHeartRate);
			this.AppendColumn (colAvgBPReading);
			this.AppendColumn (colAvgHeartRate);
			//this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			
			this.Model =_EntryRptListsStore;
		}
	}
	enum EntryColumns
	{
		EntryID,
		EntryDate,
		BPReading,
		HeartRate,
		AvgBPReading,
		AvgHeartRate
	}
}
