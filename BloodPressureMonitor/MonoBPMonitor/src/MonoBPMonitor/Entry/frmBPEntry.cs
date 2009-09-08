
using System;
using System.Data;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor
{
	public partial class frmBPEntry : Gtk.Dialog
	{
		private Entry _CurrentEntry = null;
		private int _CurrentEntryID = -1;
		public frmBPEntry()
		{
			this.Build();
			// Start a new Entry
			_CurrentEntry = new Entry();
			txtReadingDate.Text = DateTime.Now.ToShortDateString();
		}
		
		public frmBPEntry(int entryid)
		{
			this.Build();
			try
			{
				_CurrentEntryID = entryid;
				// open an existing Entry
				_CurrentEntry = new Entry(_CurrentEntryID, true);
				cboUser.SetUser(_CurrentEntry.UserID);
				txtReadingDate.Text = _CurrentEntry.EntryDateTime.ToShortDateString();
				spnSystolic.Value = _CurrentEntry.Systolic;
				spnDiastolic.Value = _CurrentEntry.Diastolic;
				spnHeartRate.Value = _CurrentEntry.HeartRate;
				txtNotes.Buffer.Text = _CurrentEntry.Notes;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public int UserID
		{
			set{cboUser.SetUser(value);}
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
				//_CurrentEntry.EntryDateTime = GetDateTime();
				_CurrentEntry.Systolic = spnSystolic.ValueAsInt;
				_CurrentEntry.Diastolic = spnDiastolic.ValueAsInt;
				_CurrentEntry.HeartRate = spnHeartRate.ValueAsInt;
				_CurrentEntry.Notes = txtNotes.Buffer.Text;
				_CurrentEntry.UserID = cboUser.UserID;
				_CurrentEntry.AddUpdate();
				
				this.Hide();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
	}
}
