
using System;

namespace MonoBPMonitor
{
	
	
	public partial class frmBPEntry : Gtk.Dialog
	{

		public frmBPEntry()
		{
			this.Build();
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
			// TODO: add insert update here
			
			this.Hide();
		}
		
		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
				{
			this.Hide();
				}		
		
	}
}
