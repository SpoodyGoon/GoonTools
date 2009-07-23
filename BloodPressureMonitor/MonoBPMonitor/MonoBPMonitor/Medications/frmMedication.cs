
using System;

namespace MonoBPMonitor
{
	
	
	public partial class frmMedication : Gtk.Dialog
	{

		public frmMedication()
		{
			this.Build();
		}
		
		protected virtual void OnBtnDateClicked (object sender, System.EventArgs e)
		{
			Gtk.Button btn = (Gtk.Button)sender;
			frmCalendar fm = new frmCalendar();
			if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
			{
				if(btn.Name=="btnStartDate")
					txtStartDate.Text = fm.SelectedDate;
				else
					txtEndDate.Text = fm.SelectedDate;
			}
			
			fm.Destroy();
		}

		protected virtual void OnBtnEndDateCleanClicked (object sender, System.EventArgs e)
		{
			txtEndDate.Text = "";
		}

		protected virtual void OnBtnStartDateCleanClicked (object sender, System.EventArgs e)
		{
			txtStartDate.Text = "";
		}

		protected virtual void OnBtnAddClicked (object sender, System.EventArgs e)
				{
				}

		protected virtual void OnBtnDeleteClicked (object sender, System.EventArgs e)
				{
				}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
				{
				}		
		
	}
}
