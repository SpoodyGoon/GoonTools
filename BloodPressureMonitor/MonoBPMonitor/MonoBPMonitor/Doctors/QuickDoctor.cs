
using System;

namespace MonoBPMonitor
{
	
	
	public partial class QuickDoctor : Gtk.Dialog
	{
		private int _CurrentDoctorID = -1;
		private string _CurrentDoctorName = "";
		public QuickDoctor()
		{
			this.Build();
		}

		public QuickDoctor(int userid)
		{
			this.Build();
			cboUser.SetUser(userid);
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			if(txtDoctorName.Text.Trim() != "")
			{
				Doctor d = new Doctor(txtDoctorName.Text.Trim(), cboUser.UserID);
				d.Add();
				_CurrentDoctorID = d.DoctorID;
				_CurrentDoctorName = d.DoctorName;
				this.Hide();
			}
		}	
		
		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
