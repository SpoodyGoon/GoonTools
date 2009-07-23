

using System;
using System.Data;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor
{
	
	
	public partial class frmMedication : Gtk.Dialog
	{
		Medications.MedicationTreeView tvMed;
		public frmMedication()
		{
			this.Build();
			tvMed = new Medications.MedicationTreeView();
			swMedication.Add(tvMed);
			this.ShowAll();
		}
		
		protected virtual void OnBtnDateClicked (object sender, System.EventArgs e)
		{
			Gtk.Button btn = (Gtk.Button)sender;
			frmCalendar fm = new frmCalendar();
			if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
			{
				if(btn.Name=="btnStartDate")
					txtStartDate.Text = fm.SelectedDate;
				else
					txtEndDate.Text = fm.SelectedDate;
			}
			
			fm.Destroy();
		}

		protected virtual void OnBtnEndDateCleanClicked (object sender, System.EventArgs e)
		{
			txtEndDate.Text = "";
		}

		protected virtual void OnBtnStartDateCleanClicked (object sender, System.EventArgs e)
		{
			txtStartDate.Text = "";
		}

		protected virtual void OnBtnAddClicked (object sender, System.EventArgs e)
		{
			if(txtMedicine.Text.Trim() != "")
			{
				Medication m = new Medication(txtMedicine.Text, txtDosage.Text, txtStartDate.Text, txtEndDate.Text, cboDoctor.DoctorID, cboUser.UserID);
				m.Add();
				tvMed.Refresh();
				txtMedicine.Text = "";
				txtDosage.Text = "";
				txtStartDate.Text = "";
				txtEndDate.Text = "";
			}
		}

		protected virtual void OnBtnDeleteClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			if(tvMed.Selection.GetSelected(out iter))
			{
				Medication m = (Medication)tvMed.SelectedMedication(iter);
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Question, Gtk.ButtonsType.YesNo, false, "Are you sure you want to delete " + m.MedicineName + " ?", "Delete Medication?");
				if((Gtk.ResponseType)md.Run() == Gtk.ResponseType.Yes)
				{
					m.Remove();
					tvMed.Refresh();
				}
				md.Destroy();
			}
			else
			{
				Gtk.MessageDialog md2 = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "You need to select a medication to delete.", "No Row Selected");
				md2.Run();
				md2.Destroy();
			}
		}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
	}
}
