/*************************************************************************
 *                      MedicationTreeView.cs
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

namespace MonoBPMonitor.Medications
{
	/// <summary>
	/// Description of MedicationTreeView.
	/// </summary>
	public partial class MedicationTreeView : Gtk.TreeView
	{
		public MedicationTreeView()
		{
			Build();
			LoadData();
		}
		
		private void LoadData()
		{
			try
			{
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID FROM tb_Medicine");
				foreach(DataRow dr in dt.Rows)
				{
					Medication m = new Medication(Convert.ToInt32(dr["MedicineID"]), dr["MedicineName"].ToString(), dr["Dosage"].ToString(), Convert.ToDateTime(dr["StartDate"].ToString()), Convert.ToDateTime(dr["EndDate"].ToString()), Convert.ToInt32(dr["DoctorID"]), Convert.ToInt32(dr["UserID"]));
					_MedicationListsStore.AppendValues(m);
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public Medication IterTaskList(TreeIter iter)
		{
			return _MedicationListsStore.GetValue(iter, 0) as Medication;
		}
		
		private void RenderMedicineID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.MedicineID.ToString();
		}
		
		private void RenderMedicineName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.MedicineName;
		}
		
		private void RenderDosage (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.Dosage;
		}
		
		private void RenderStartDate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.StartDate.ToShortDateString();
		}
		
		private void RenderEndDate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.EndDate.ToShortDateString();
		}
		
		private void RenderDoctorID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.DoctorID.ToString();
		}
		
		private void RenderUserID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.UserID.ToString();
		}
	}
}