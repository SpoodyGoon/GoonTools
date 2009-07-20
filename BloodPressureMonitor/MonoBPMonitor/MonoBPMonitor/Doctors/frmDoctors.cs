
using System;

namespace MonoBPMonitor
{
	
	
	public partial class frmDoctors : Gtk.Dialog
	{

		public frmDoctors()
		{
			this.Build();
		}

		protected virtual void OnBtnDeleteClicked (object sender, System.EventArgs e)
		{
		}
		
		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnBtnAddClicked (object sender, System.EventArgs e)
		{
		}

		protected virtual void OnBtnClearClicked (object sender, System.EventArgs e)
		{
		}
	}
}
