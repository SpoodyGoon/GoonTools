
using System;

namespace MonoBPMonitor
{
	
	public partial class QuickUser : Gtk.Dialog
	{
		private int _CurrentUserID = -1;
		private string _CurrentUserName = "";
		public QuickUser()
		{
			this.Build();
			
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			if(txtUserName.Text.Trim() != "")
			{
				User u = new User(txtUserName.Text);
				u.Add();
				_CurrentUserID = u.UserID;
				_CurrentUserName = u.UserName;
				this.Hide();
			}
		}
	}
}
