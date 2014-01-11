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
using SQLiteDataHelper;

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
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				DataTable dt = shp.ExecuteDataTable("SELECT MedicineID, MedicineName, Dosage, StartDate, EndDate, DoctorID, UserID FROM tb_Medicine");
				foreach(DataRow dr in dt.Rows)
				{
					Medication m = new Medication(Convert.ToInt32(dr["MedicineID"]), dr["MedicineName"].ToString(), dr["Dosage"].ToString(), Convert.ToDateTime(dr["StartDate"].ToString()), Convert.ToDateTime(dr["EndDate"].ToString()), Convert.ToInt32(dr["DoctorID"]), Convert.ToInt32(dr["UserID"]));
					_MedicationListsStore.AppendValues(m);
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void Refresh()
		{
			LoadData();
		}
		
		public Medication SelectedMedication(TreeIter iter)
		{
			return _MedicationListsStore.GetValue(iter, 0) as Medication;
		}
		
		#region TreeView Cell Events
		
		private void cellMedicineName_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_MedicationListsStore.GetIterFromString (out iter, args.Path))
				{
					Medication m = (Medication)_MedicationListsStore.GetValue(iter, 0);
					m.MedicineName = args.NewText;
					m.Update();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private void cellDosage_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_MedicationListsStore.GetIterFromString (out iter, args.Path))
				{
					Medication m = (Medication)_MedicationListsStore.GetValue(iter, 0);
					m.Dosage = args.NewText;
					m.Update();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		
		private void cellStartDate_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_MedicationListsStore.GetIterFromString (out iter, args.Path))
				{
					Medication m = (Medication)_MedicationListsStore.GetValue(iter, 0);
					m.StartDate = Convert.ToDateTime(args.NewText);
					m.Update();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		
		private void cellEndDate_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_MedicationListsStore.GetIterFromString (out iter, args.Path))
				{
					Medication m = (Medication)_MedicationListsStore.GetValue(iter, 0);
					m.EndDate = Convert.ToDateTime(args.NewText);
					m.Update();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		private void cellDoctorID_Edited(object sender, EditedArgs args)
		{
			try
			{
				Doctors.DoctorRendererCombo drc = (Doctors.DoctorRendererCombo)sender;
				Gtk.TreeIter iter;
				if (_MedicationListsStore.GetIterFromString (out iter, args.Path))
				{
					Medication m = (Medication)_MedicationListsStore.GetValue(iter, 0);
					drc.SetDoctor(args.NewText);
					m.DoctorID = drc.DoctorID;
					m.Update();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		private void cellUserID_Edited(object sender, EditedArgs args)
		{
			try
			{
				Users.UserRendererCombo urc = (Users.UserRendererCombo)sender;
				Gtk.TreeIter iter;
				if (_MedicationListsStore.GetIterFromString (out iter, args.Path))
				{
					Medication m = (Medication)_MedicationListsStore.GetValue(iter, 0);
					urc.SetUser(args.NewText);
					m.UserID = urc.UserID;
					m.Update();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		#endregion TreeView Cell Events
		
		#region Cell Data Functions
		
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
			if(m.StartDate > _CompairDate)
				(cell as Gtk.CellRendererText).Text = m.StartDate.ToShortDateString();
		}
		
		private void RenderEndDate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Medication m = (Medication)model.GetValue(iter, 0);
			if(m.EndDate > _CompairDate)
				(cell as Gtk.CellRendererText).Text = m.EndDate.ToShortDateString();
		}
		
		private void RenderDoctorID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Doctors.DoctorRendererCombo).SetDoctor(d.DoctorID);
		}
		
		private void RenderUserID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Users.UserRendererCombo).SetUser(d.UserID);
		}
		
		#endregion Cell Data Functions
	}
}
