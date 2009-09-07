
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
				SetHour();
				SetMinute();
				spnSystolic.Value = _CurrentEntry.Systolic;
				spnDiastolic.Value = _CurrentEntry.Diastolic;
				spnHeartRate.Value = _CurrentEntry.HeartRate;
				txtNotes.Buffer.Text = _CurrentEntry.Notes;
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
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
				_CurrentEntry.EntryDateTime = GetDateTime();
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
				Common.EnvData.HandleError(ex);
			}
		}

		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		private void SetHour()
		{
			if(_CurrentEntry != null)
			{
				switch(_CurrentEntry.EntryDateTime.Minute)
				{
					case 00:
						cboMinutes.Active = 0;
						break;
					case 05:
						cboMinutes.Active = 1;
						break;
					case 10:
						cboMinutes.Active = 2;
						break;
					case 15:
						cboMinutes.Active = 3;
						break;
					case 20:
						cboMinutes.Active = 4;
						break;
					case 25:
						cboMinutes.Active = 5;
						break;
					case 30:
						cboMinutes.Active = 6;
						break;
					case 35:
						cboMinutes.Active = 7;
						break;
					case 40:
						cboMinutes.Active = 8;
						break;
					case 45:
						cboMinutes.Active = 9;
						break;
					case 50:
						cboMinutes.Active = 10;
						break;
					case 55:
						cboMinutes.Active = 11;
						break;
					default:
						cboMinutes.Active = 0;
						break;
				}
			}
		}
		
		private void SetMinute()
		{
			if(_CurrentEntry != null)
			{
				if(_CurrentEntry.EntryDateTime.Hour > 12)
				{
					cboHours.Active = _CurrentEntry.EntryDateTime.Hour - 13;
					rbnPM.Active = true;
					rbnAM.Active = false;
				}
				else
				{
					cboHours.Active = _CurrentEntry.EntryDateTime.Hour - 1;	
					rbnPM.Active = false;
					rbnAM.Active = true;
				}
			}
		}
		
		private DateTime GetDateTime()
		{
			int Hour;
			if(rbnPM.Active == true)
				return Convert.ToDateTime(txtReadingDate + " " + (Convert.ToInt16(cboHours.ActiveText) + 12).ToString() + ":" + cboMinutes.ActiveText);
			else
				return Convert.ToDateTime(txtReadingDate + " " + cboHours.ActiveText + ":" + cboMinutes.ActiveText);			
				                     
		}
		
	}
}
