
using System;
using GoonTools;

namespace MonoBPMonitor
{


	public partial class frmCalendar : Gtk.Dialog
	{
		private DateTime _SelectedDate = DateTime.Now;
		private bool _ShowTime = true;
		public frmCalendar (DateTime selecteddate)
		{
			this.Build ();
			try
			{
				_ShowTime = true;
				_SelectedDate = selecteddate;
				calendar2.Date = selecteddate.Date;
				SetUpTime ();
				ShowAll ();
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}

		public frmCalendar (DateTime selecteddate, bool showtime)
		{
			this.Build ();
			_ShowTime = showtime;
			_SelectedDate = selecteddate;
			calendar2.Date = selecteddate.Date;
			if (_ShowTime)
			{
				SetUpTime ();
			}

			else
			{
				algTime.Destroy ();
			}
			
			algTime.ShowNow ();
			ShowAll ();
		}

		public frmCalendar ()
		{
			this.Build ();
			
		}

		private void SetUpTime ()
		{
			try
			{
				if (_SelectedDate.Hour < 11)
				{
					spnHour.Value = (double)_SelectedDate.Hour;
					cbxPM.Active = true;
				}
				else if (_SelectedDate.Hour == 0)
				{
					spnHour.Value = 12;
					cbxPM.Active = false;
				}
				else
				{
					spnHour.Value = ((double)_SelectedDate.Hour) - 12;
					cbxPM.Active = true;
				}
				
				spnMinute.Value = (double)_SelectedDate.Minute;
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}

		public DateTime SelectedDate
		{
			get { return _SelectedDate; }
			set { _SelectedDate = value; }
		}

		protected virtual void OnCalendar2DaySelectedDoubleClick (object sender, System.EventArgs e)
		{
			if(cbxPM.Active && spnHour.ValueAsInt == 12)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, 00, spnMinute.ValueAsInt, 0) ;
			if(!cbxPM.Active)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt, spnMinute.ValueAsInt, 0) ;
			else
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt + 12, spnMinute.ValueAsInt, 0) ;
			this.Respond(Gtk.ResponseType.Ok);
			this.Hide();
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide ();
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			if (cbxPM.Active && spnHour.ValueAsInt == 12)
				_SelectedDate = new DateTime (this.calendar2.Date.Year, this.calendar2.Date.Month, this.calendar2.Date.Day, 0, spnMinute.ValueAsInt, 0);
			if(!cbxPM.Active)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt, spnMinute.ValueAsInt, 0) ;
			else
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt + 12, spnMinute.ValueAsInt, 0) ;
			this.Respond(Gtk.ResponseType.Ok);
			this.Hide();
		}
		protected virtual void OnEvntDateTimeNowEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor (Gdk.CursorType.Hand1);
			lblNow.Text = "<span size=\"8750\" face=\"san serif\"  color=\"#920000\"><u><b>Set Date &#38; Time to Now.</b></u></span>";
			lblNow.UseMarkup = true;
			lblNow.ShowNow ();
		}

		protected virtual void OnEvntDateTimeNowLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor (Gdk.CursorType.Arrow);
			lblNow.Text = "<span size=\"8750\" face=\"san serif\" color=\"#000000\"><u><b>Set Date &#38; Time to Now.</b></u></span>";
			lblNow.UseMarkup = true;
			lblNow.ShowNow ();
		}

		protected virtual void OnEvntDateTimeNowButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
			_SelectedDate = DateTime.Now;
			calendar2.Date = _SelectedDate.Date;
			SetUpTime ();
			ShowAll ();
		}
		
		protected virtual void OnSpnMinuteValueChanged (object sender, System.EventArgs e)
		{
			if (spnMinute.ValueAsInt >= 60)
			{
				// if we are over 60 move to the next hour
				spnMinute.Value = 0.0;
				spnHour.Value = (double)(spnHour.Value + 1);
			}
			else if (spnMinute.ValueAsInt < 0)
			{
				// if we are below zero update to the previous hour
				spnMinute.Value = 55.0;
				spnHour.Value = (double)(spnHour.ValueAsInt - 1);
			}
		}
		
		protected virtual void OnSpnHourValueChanged (object sender, System.EventArgs e)
		{
			bool tmpActive = false;
			// if we have gone over 12 then return to one and
			// set the am/pm flag as needed
			if (spnHour.ValueAsInt > 12)
			{
				// return the value to 1 (i.e. rollover)
				spnHour.Value = 1.0;
				// set the am/pm flag
				tmpActive = cbxPM.Active ? false : true;
				cbxPM.Active = tmpActive;
			}
			else if (spnHour.ValueAsInt < 1)
			{
				// return the value to 12 (i.e. rollover)
				spnHour.Value = 12.0;
				// set the am/pm flag
				tmpActive = cbxPM.Active ? false : true;
				cbxPM.Active = tmpActive;
			}
		}
		
		
		
	}
}
