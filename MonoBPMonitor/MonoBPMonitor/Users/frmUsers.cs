
using System;

namespace MonoBPMonitor
{
	
	
	public partial class frmUsers : Gtk.Dialog
	{

		public frmUsers()
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
	}
}
