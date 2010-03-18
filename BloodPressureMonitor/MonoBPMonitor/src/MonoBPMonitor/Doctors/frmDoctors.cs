
using System;
using System.Data;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmDoctors : Gtk.Dialog
	{
		private Doctors.DoctorTreeView tvDoctor;
		public frmDoctors()
		{
			this.Build();
			
			tvDoctor = new MonoBPMonitor.Doctors.DoctorTreeView();
			swDoctor.Add(tvDoctor);
			this.ShowAll();
		}

		protected virtual void OnBtnDeleteClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			if(tvDoctor.Selection.GetSelected(out iter))
			{
				Doctor d = (Doctor)tvDoctor.SelectedDoctor(iter);
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Question, Gtk.ButtonsType.YesNo, false, "Are you sure you want to delete " + d.DoctorName + " ?", "Delete Doctor?");
				if((Gtk.ResponseType)md.Run() == Gtk.ResponseType.Yes)
				{
					d.Remove();
					tvDoctor.Refresh();
				}
				md.Destroy();
			}
			else
			{
				Gtk.MessageDialog md2 = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "You need to select a doctor to delete.", "No Row Selected");
				md2.Run();
				md2.Destroy();
			}
		}
		
		public int UserID
		{
			set{cboUser.SetUser(value);}
		}
		
		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnBtnAddClicked (object sender, System.EventArgs e)
		{
			if(txtDoctor.Text.Trim() != "")
			{
				Doctor d = new Doctor(txtDoctor.Text, txtLocation.Text, txtPhone.Text, cboUser.UserID);
				d.Add();
				tvDoctor.Refresh();
				txtDoctor.Text = "";
				txtLocation.Text = "";
				txtPhone.Text = "";
			}
			else
			{
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "A doctors name is required.", "Missing Doctor Name");
				md.Run();
				md.Destroy();
			}
		}
	}
}
