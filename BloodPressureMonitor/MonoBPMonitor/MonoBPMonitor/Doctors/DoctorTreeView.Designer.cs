/*************************************************************************
 *                      DoctorTreeView.Designer.cs
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

namespace MonoBPMonitor.Doctors
{
	/// <summary>
	/// Description of DoctorTreeView_Designer.
	/// </summary>
	public partial class DoctorTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _DoctorListsStore = new ListStore(typeof(Doctor));
		private void Build()
		{
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			// treeview set up
			// Create a column for the List ID
			Gtk.TreeViewColumn colDoctorID = new Gtk.TreeViewColumn ();
			colDoctorID.Visible = false;
			colDoctorID.Title = "ID";
			// Cell for the column
			Gtk.CellRendererText cellDoctorID = new Gtk.CellRendererText ();
			cellDoctorID.Width=25;
			cellDoctorID.Xalign = 0.5f;
			colDoctorID.PackStart (cellDoctorID, false);
			
			// Create a column for the list name
			Gtk.TreeViewColumn colDoctorName = new Gtk.TreeViewColumn ();
			colDoctorName.Expand = true;
			colDoctorName.Resizable = true;
			colDoctorName.Visible = true;
			colDoctorName.Title = "Doctor";
			Gtk.CellRendererText cellDoctorName = new Gtk.CellRendererText ();
			cellDoctorName.Width=150;
			cellDoctorName.Editable = true;
			cellDoctorName.Edited += cellDoctorName_Edited;
			colDoctorName.PackStart (cellDoctorName, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colLocation = new Gtk.TreeViewColumn ();
			colLocation.Resizable = true;
			colLocation.Visible = true;
			colLocation.Title = "Location";
			Gtk.CellRendererText cellLocation = new Gtk.CellRendererText ();
			cellLocation.Width=120;
			cellLocation.Editable = true;
			cellLocation.Edited += cellLocation_Edited;
			colLocation.PackStart (cellLocation, false);
			
			// Create a column for the date
			Gtk.TreeViewColumn colPhoneNum = new Gtk.TreeViewColumn ();
			colPhoneNum.Resizable = true;
			colPhoneNum.Visible = true;
			colPhoneNum.Title = "Phone";
			Gtk.CellRendererText cellPhoneNum = new Gtk.CellRendererText ();
			cellPhoneNum.Width=120;
			cellPhoneNum.Editable = true;
			cellPhoneNum.Edited += cellPhoneNum_Edited;
			colPhoneNum.PackStart (cellPhoneNum, false);
			
			// Create a column for the date
			Gtk.TreeViewColumn colUserID = new Gtk.TreeViewColumn ();
			colUserID.Resizable = true;
			colUserID.Visible = true;
			colUserID.Title = "User";
			Gtk.CellRendererText cellUserID = new Gtk.CellRendererText ();
			cellUserID.Width=120;
			colUserID.PackStart (cellUserID, true);
			
			// Add the columns to the TreeView
			this.AppendColumn(colDoctorID);
			this.AppendColumn (colDoctorName);
			this.AppendColumn (colLocation);
			this.AppendColumn(colPhoneNum);
			this.AppendColumn (colUserID);
			//this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			colDoctorID.SetCellDataFunc(cellDoctorID, new Gtk.TreeCellDataFunc(RenderDoctorID));
			colDoctorName.SetCellDataFunc(cellDoctorName, new Gtk.TreeCellDataFunc(RenderDoctorName));
			colLocation.SetCellDataFunc(cellLocation, new Gtk.TreeCellDataFunc(RenderLocation));
			colPhoneNum.SetCellDataFunc(cellPhoneNum, new Gtk.TreeCellDataFunc(RenderPhoneNum));
			colUserID.SetCellDataFunc(cellUserID, new Gtk.TreeCellDataFunc(RenderUserID));
			
			this.Model =_DoctorListsStore;
		}
	}	
	
	enum DoctorColumns
	{
		DoctorID,
		DoctorName,
		Location,
		PhoneNum,
		UserID
	}
}
