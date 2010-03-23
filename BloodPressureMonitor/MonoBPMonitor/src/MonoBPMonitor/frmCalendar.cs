
using System;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmCalendar : Gtk.Dialog
	{
		
		private DateTime _SelectedDate = DateTime.Now;
		private bool _ShowTime = true;
		public frmCalendar(DateTime selecteddate)
		{
			this.Build();
			try
			{
				_ShowTime= true;
				_SelectedDate = selecteddate;
				calendar2.Date = selecteddate.Date;
				SetUpTime();
				ShowAll();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public frmCalendar(DateTime selecteddate, bool showtime)
		{
			this.Build();
			_ShowTime= showtime;
			_SelectedDate = selecteddate;
			calendar2.Date = selecteddate.Date;
			if(_ShowTime)
			{
				SetUpTime();
			}
			else
			{				
            	algTime.Destroy();
			}
			
			algTime.ShowNow();
			ShowAll();
		}
		
		public frmCalendar()
		{
			this.Build();
			
		}
		
		private void SetUpTime()
		{
			try
			{
				if(_SelectedDate.Hour < 11)
				{
					spnHour.Value = (double)_SelectedDate.Hour;
					rbnAM.Active = true;
					rbnPM.Active = false;
				}
				else if(_SelectedDate.Hour == 0)
				{
					spnHour.Value = 12;
					rbnAM.Active = true;
					rbnPM.Active = false;
				}
				else
				{
					spnHour.Value = ((double)_SelectedDate.Hour) - 12;
					rbnAM.Active = false;
					rbnPM.Active = true;
				}
				
				spnMinute.Value = (double)_SelectedDate.Minute;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public DateTime SelectedDate
		{
			set{_SelectedDate = value;}
			get{ return _SelectedDate;}
		}
		
		protected virtual void OnCalendar2DaySelectedDoubleClick (object sender, System.EventArgs e)
		{
			if(rbnAM.Active == true && spnHour.ValueAsInt == 12)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, 00, spnMinute.ValueAsInt, 0) ;
			if(rbnAM.Active == true)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt, spnMinute.ValueAsInt, 0) ;
			else
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt + 12, spnMinute.ValueAsInt, 0) ;
			this.Respond(Gtk.ResponseType.Ok);
			this.Hide();
		}
		
		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			if(rbnAM.Active == true && spnHour.ValueAsInt == 12)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, 0, spnMinute.ValueAsInt, 0) ;
			if(rbnAM.Active == true)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt, spnMinute.ValueAsInt, 0) ;
			else
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt + 12, spnMinute.ValueAsInt, 0) ;
			this.Respond(Gtk.ResponseType.Ok);
			this.Hide();
		}
		protected virtual void OnEvntDateTimeNowEnterNotifyEvent (object o, Gtk.EnterNotifyEventArgs args)
		{			
			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Hand1);
			lblNow.Text = "<span size=\"8750\" face=\"san serif\"  color=\"#920000\"><u><b>Set Date &#38; Time to Now.</b></u></span>";
			lblNow.UseMarkup = true;
			lblNow.ShowNow();
		}
		
		protected virtual void OnEvntDateTimeNowLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
			this.GdkWindow.Cursor = new Gdk.Cursor(Gdk.CursorType.Arrow);
			lblNow.Text = "<span size=\"8750\" face=\"san serif\" color=\"#000000\"><u><b>Set Date &#38; Time to Now.</b></u></span>";
			lblNow.UseMarkup = true;
			lblNow.ShowNow();
		}
		
		protected virtual void OnEvntDateTimeNowButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
		}
		
		
		
		
	}
}
