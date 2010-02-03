
using System;
using System.Data;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor
{
	public partial class frmEntry : Gtk.Dialog
	{
		private Entry _CurrentEntry = null;
		private int _CurrentEntryID = -1;
		public frmEntry()
		{
			this.Build();
			txtNotes.WidthRequest = 375;
			// this starts a new entry there is nothing to delete
			// so we don't want the delete button.
			algDelete.Destroy();
			// Start a new Entry
			_CurrentEntry = new Entry();
			txtReadingDate.Text = _CurrentEntry.EntryDateTime.ToString("g");
			this.HasSeparator = false;
			this.ShowAll();
		}
		
		public frmEntry(int entryid)
		{
			this.Build();
			try
			{
				_CurrentEntryID = entryid;
				// open an existing Entry
				_CurrentEntry = new Entry(_CurrentEntryID, true);
				cboUser.SetUser(_CurrentEntry.UserID);
				txtReadingDate.Text = _CurrentEntry.EntryDateTime.ToString("g");
				spnSystolic.Value = _CurrentEntry.Systolic;
				spnDiastolic.Value = _CurrentEntry.Diastolic;
				spnHeartRate.Value = _CurrentEntry.HeartRate;
				txtNotes.Buffer.Text = _CurrentEntry.Notes;
				this.ShowAll();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public frmEntry(MonoBPMonitor.Entry entry)
		{
			this.Build();
			try
			{
				_CurrentEntry = entry;
				_CurrentEntryID = _CurrentEntry.EntryID;
				cboUser.SetUser(_CurrentEntry.UserID);
				txtReadingDate.Text = _CurrentEntry.EntryDateTime.ToString("g");
				spnSystolic.Value = _CurrentEntry.Systolic;
				spnDiastolic.Value = _CurrentEntry.Diastolic;
				spnHeartRate.Value = _CurrentEntry.HeartRate;
				txtNotes.Buffer.Text = _CurrentEntry.Notes;
				this.ShowAll();
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
			frmCalendar fm = new frmCalendar(_CurrentEntry.EntryDateTime);
			if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
			{
				_CurrentEntry.EntryDateTime = fm.SelectedDate;
				this.txtReadingDate.Text = _CurrentEntry.EntryDateTime.ToString("g");
			}
			
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
				this.Respond(Gtk.ResponseType.Ok);
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
		
		
		protected virtual void OnBtnDeleteReadingClicked (object sender, System.EventArgs e)
		{
			_CurrentEntry.Remove();
			this.Respond(ResponseType.Ok);
			this.Hide();
		}
	}
}
