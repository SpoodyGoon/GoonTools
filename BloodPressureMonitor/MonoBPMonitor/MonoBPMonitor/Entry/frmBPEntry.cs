
using System;
using System.Data;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor
{
	
	
	public partial class frmBPEntry : Gtk.Dialog
	{

		public frmBPEntry()
		{
			this.Build();
			txtReadingDate.Text = DateTime.Now.ToShortDateString();
		}
		
		protected virtual void OnBtnDateClicked (object sender, System.EventArgs e)
		{
			frmCalendar fm = new frmCalendar();
			if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
				this.txtReadingDate.Text = fm.SelectedDate;
			
			fm.Destroy();
		}

		protected virtual void OnBtnOkClicked (object sender, System.EventArgs e)
		{
			try
			{
				Entry ent = new Entry(Convert.ToDateTime(txtReadingDate.Text), spnSystolic.ValueAsInt, spnDiastolic.ValueAsInt, spnHeartRate.ValueAsInt, txtNotes.Buffer.Text, cboUser.UserID);
				ent.Add();
				this.Hide();
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
				{
				}		
		
	}
}
