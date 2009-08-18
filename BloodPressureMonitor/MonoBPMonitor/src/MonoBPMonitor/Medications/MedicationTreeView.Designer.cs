/*************************************************************************
 *                      MedicationTreeView.Designer.cs
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

namespace MonoBPMonitor.Medications
{
	/// <summary>
	/// Description of MedicationTreeView_Designer.
	/// </summary>
	public partial class MedicationTreeView : Gtk.TreeView
	{
		private Gtk.ListStore _MedicationListsStore = new ListStore(typeof(Medication));
		private DateTime _CompairDate = new DateTime(1990, 1,1);
		private void Build()
		{
			this.HeadersVisible = true;
			this.RulesHint = true;
			this.EnableGridLines = Gtk.TreeViewGridLines.Both;
			
			// treeview set up
			// Create a column for the List ID
			Gtk.TreeViewColumn colMedicineID = new Gtk.TreeViewColumn ();
			colMedicineID.Visible = false;
			colMedicineID.Title = "ID";
			// Cell for the column
			Gtk.CellRendererText cellMedicineID = new Gtk.CellRendererText ();
			cellMedicineID.Width=25;
			cellMedicineID.Xalign = 0.5f;
			colMedicineID.PackStart (cellMedicineID, false);
			
			// Create a column for the list name
			Gtk.TreeViewColumn colMedicineName = new Gtk.TreeViewColumn ();
			colMedicineName.Expand = true;
			colMedicineName.Resizable = true;
			colMedicineName.Visible = true;
			colMedicineName.Title = "Medication";
			Gtk.CellRendererText cellMedicineName = new Gtk.CellRendererText ();
			cellMedicineName.Width=250;
			cellMedicineName.Editable = true;
			cellMedicineName.Edited += cellMedicineName_Edited;
			colMedicineName.PackStart (cellMedicineName, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colDosage = new Gtk.TreeViewColumn ();
			colDosage.Resizable = true;
			colDosage.Visible = true;
			colDosage.Title = "Dosage";
			Gtk.CellRendererText cellDosage = new Gtk.CellRendererText ();
			cellDosage.Width=70;
			cellDosage.Editable = true;
			cellDosage.Edited += cellDosage_Edited;
			colDosage.PackStart (cellDosage, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colStartDate = new Gtk.TreeViewColumn ();
			colStartDate.Resizable = true;
			colStartDate.Visible = true;
			colStartDate.Title = "Start Date";
			Gtk.CellRendererText cellStartDate = new Gtk.CellRendererText ();
			cellStartDate.Width=70;
			cellStartDate.Editable = true;
			cellStartDate.Edited += cellStartDate_Edited;
			colStartDate.PackStart (cellStartDate, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colEndDate = new Gtk.TreeViewColumn ();
			colEndDate.Resizable = true;
			colEndDate.Visible = true;
			colEndDate.Title = "End Date";
			Gtk.CellRendererText cellEndDate = new Gtk.CellRendererText ();
			cellEndDate.Width=70;
			cellEndDate.Editable = true;
			cellEndDate.Edited += cellEndDate_Edited;
			colEndDate.PackStart (cellEndDate, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colDoctorID = new Gtk.TreeViewColumn ();
			colDoctorID.Resizable = true;
			colDoctorID.Visible = true;
			colDoctorID.Title = "Doctor";
			Doctors.DoctorRendererCombo cellDoctorID = new Doctors.DoctorRendererCombo();
			cellDoctorID.Width=120;
			cellDoctorID.Edited += cellDoctorID_Edited;
			colDoctorID.PackStart (cellDoctorID, true);
			
			// Create a column for the date
			Gtk.TreeViewColumn colUserID = new Gtk.TreeViewColumn ();
			colUserID.Resizable = true;
			colUserID.Visible = true;
			colUserID.Title = "User";
			Users.UserRendererCombo cellUserID = new Users.UserRendererCombo();
			cellUserID.Width=120;
			cellUserID.Edited += cellUserID_Edited;
			colUserID.PackStart (cellUserID, true);
			
			// Add the columns to the TreeView
			this.AppendColumn(colMedicineID);
			this.AppendColumn (colMedicineName);
			this.AppendColumn (colDosage);
			this.AppendColumn(colStartDate);
			this.AppendColumn(colEndDate);
			this.AppendColumn(colDoctorID);
			this.AppendColumn (colUserID);
			//this.AppendColumn(new GoonTools.ColumnSelector.TreeColumnSelector(this.Columns));
			
			colMedicineID.SetCellDataFunc(cellMedicineID, new Gtk.TreeCellDataFunc(RenderMedicineID));
			colMedicineName.SetCellDataFunc(cellMedicineName, new Gtk.TreeCellDataFunc(RenderMedicineName));
			colDosage.SetCellDataFunc(cellDosage, new Gtk.TreeCellDataFunc(RenderDosage));
			colStartDate.SetCellDataFunc(cellStartDate, new Gtk.TreeCellDataFunc(RenderStartDate));
			colEndDate.SetCellDataFunc(cellEndDate, new Gtk.TreeCellDataFunc(RenderEndDate));
			colDoctorID.SetCellDataFunc(cellDoctorID, new Gtk.TreeCellDataFunc(RenderDoctorID));
			colUserID.SetCellDataFunc(cellUserID, new Gtk.TreeCellDataFunc(RenderUserID));
			
			this.Model = _MedicationListsStore;
		}
	}
	
	enum MedicationColumns
	{
		MedicineID,
		MedicineName,
		Dosage,
		StartDate,
		EndDate,
		DoctorID,
		UserID
	}
}
