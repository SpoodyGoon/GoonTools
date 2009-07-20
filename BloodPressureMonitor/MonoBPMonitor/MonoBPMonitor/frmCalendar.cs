
using System;

namespace MonoBPMonitor
{
	
	
	public partial class frmCalendar : Gtk.Dialog
	{
		
		private string _SelectedDate = null;
		public frmCalendar()
		{
			this.Build();
		}
		
		public string SelectedDate
		{
			set{_SelectedDate = value;}
			get{ return _SelectedDate;}
		}
		
		public void SetDate(DateTime dtmDateSet)
		{
			calendar2.Date = dtmDateSet;
		}
		
		protected virtual void OnCalendar2DaySelectedDoubleClick (object sender, System.EventArgs e)
		{
			_SelectedDate = this.calendar2.Date.ToShortDateString();
			this.Respond(Gtk.ResponseType.Ok);
			this.Hide();
		}
		
		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			_SelectedDate = this.calendar2.Date.ToShortDateString();
			this.Hide();
		}
	}
}
