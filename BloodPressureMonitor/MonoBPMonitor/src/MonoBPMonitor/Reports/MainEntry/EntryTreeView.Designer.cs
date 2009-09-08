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
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor.Reports
{
	/// <summary>
	/// Description of EntryTreeView_Designer.
	/// </summary>
	public partial class EntryRptTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _EntryRptListsStore = new ListStore(typeof(int), typeof(string),typeof(string),typeof(string),typeof(string),typeof(string));
		private int _CurrentUser = 1; // this is the default user
		private int _CurrentHistoryLimit = 30;// this is the assumed default
		private void Build()
		{
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableSearch = false;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			Gtk.TreeViewColumn colEntryID = new Gtk.TreeViewColumn ();
			colEntryID.MinWidth=25;
			colEntryID.Visible = false;
			colEntryID.Title = "ID";
			Gtk.CellRendererText cellEntryID = new Gtk.CellRendererText ();
			cellEntryID.Width=25;
			cellEntryID.Xalign = 0.5f;
			colEntryID.PackStart (cellEntryID, false);
			
			Gtk.TreeViewColumn colEntryDate = new Gtk.TreeViewColumn ();
			colEntryDate.Visible = true;
			colEntryDate.MinWidth = 150;
			colEntryDate.Alignment = 0.15f;
			colEntryDate.Title = "Date";
			Gtk.CellRendererText cellEntryDate = new Gtk.CellRendererText ();
			cellEntryDate.Width=100;
			cellEntryDate.Xalign=0.5f;
			colEntryDate.PackStart (cellEntryDate, true);
			
			Gtk.TreeViewColumn colBPReading = new Gtk.TreeViewColumn ();
			colBPReading.Visible = true;
			colBPReading.MinWidth= 150;
			colBPReading.Alignment=0.5f;
			colBPReading.Title = "Blood Pressure";
			Gtk.CellRendererText cellBPReading = new Gtk.CellRendererText ();
			cellBPReading.Width=150;
			cellBPReading.Xalign=0.5f;
			colBPReading.PackStart (cellBPReading, true);
			
			Gtk.TreeViewColumn colHeartRate = new Gtk.TreeViewColumn ();
			colHeartRate.Visible = true;
			colHeartRate.MinWidth = 75;
			colHeartRate.Alignment=0.5f;
			colHeartRate.Title = "Heart Rate";
			Gtk.CellRendererText cellHeartRate = new Gtk.CellRendererText ();
			cellHeartRate.Width=75;
			cellHeartRate.Xalign=0.5f;
			colHeartRate.PackStart (cellHeartRate, true);
			
			Gtk.TreeViewColumn colAvgBPReading = new Gtk.TreeViewColumn ();
			colAvgBPReading.Visible = true;
			colAvgBPReading.MinWidth = 150;
			colAvgBPReading.Alignment=0.5f;
			colAvgBPReading.Title = "Avg Blood Pressure";
			Gtk.CellRendererText cellAvgBPReading = new Gtk.CellRendererText ();
			cellAvgBPReading.Width=150;
			cellAvgBPReading.Xalign=0.5f;
			colAvgBPReading.PackStart (cellAvgBPReading, true);
			
			Gtk.TreeViewColumn colAvgHeartRate = new Gtk.TreeViewColumn ();
			colAvgHeartRate.Visible = true;
			colAvgHeartRate.MinWidth = 75;
			colAvgHeartRate.Alignment=0.5f;
			colAvgHeartRate.Title = "Avg Heart Rate";
			Gtk.CellRendererText cellAvgHeartRate = new Gtk.CellRendererText ();
			cellAvgHeartRate.Width=75;
			cellAvgHeartRate.Xalign=0.5f;
			colAvgHeartRate.PackStart (cellAvgHeartRate, true);
			
			Gtk.TreeViewColumn colEmpty = new Gtk.TreeViewColumn();
			colEmpty.Expand = true;
			
			this.AppendColumn(colEntryID);
			this.AppendColumn (colEntryDate);
			this.AppendColumn(colBPReading);
			this.AppendColumn (colHeartRate);
			this.AppendColumn (colAvgBPReading);
			this.AppendColumn (colAvgHeartRate);
			this.AppendColumn(colEmpty);
			colEntryID.AddAttribute(cellEntryID, "text", 0);
			colEntryDate.AddAttribute(cellEntryDate, "text", 1);
			colBPReading.AddAttribute(cellBPReading, "text", 2);
			colHeartRate.AddAttribute(cellHeartRate, "text", 3);
			colAvgBPReading.AddAttribute(cellAvgBPReading, "text", 4);
			colAvgHeartRate.AddAttribute(cellAvgHeartRate, "text", 5);
			//this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			this.RowActivated += EntryRptTreeView_RowActivated;
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
