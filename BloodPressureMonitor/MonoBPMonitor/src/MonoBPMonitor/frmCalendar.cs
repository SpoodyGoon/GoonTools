
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
				SetUpTime();
			else
				frame2.Visible = false;
			
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
			if(rbnPM.Active == true)
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt, spnMinute.ValueAsInt, 0) ;
			else
				_SelectedDate = new DateTime(this.calendar2.Date.Year,this.calendar2.Date.Month, this.calendar2.Date.Day, spnHour.ValueAsInt, spnMinute.ValueAsInt, 0) ;
			this.Hide();
		}
	}
}
