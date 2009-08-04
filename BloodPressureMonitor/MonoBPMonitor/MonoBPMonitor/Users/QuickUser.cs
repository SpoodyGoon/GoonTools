
using System;
using Gtk;

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
		
		public int UserID
		{
			get{return _CurrentUserID;}
		}
		
		public string UserName
		{
			get{return _CurrentUserName;}
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
				this.Respond(Gtk.ResponseType.Ok);
				this.Hide();
			}
			else
			{
				Gtk.MessageDialog md2 = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "You need to enter a user name.", "User Name Missing");
				md2.Run();
				md2.Destroy();	
			}
		}

		protected virtual void OnTxtUserNameKeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
		{
			if(args.Event.Key == Gdk.Key.Return)
			{				
				if(txtUserName.Text.Trim() != "")
				{
					User u = new User(txtUserName.Text);
					u.Add();
					_CurrentUserID = u.UserID;
					_CurrentUserName = u.UserName;
					this.Respond(Gtk.ResponseType.Ok);
					this.Hide();
				}
				else
				{
					Gtk.MessageDialog md2 = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "You need to enter a user name.", "User Name Missing");
					md2.Run();
					md2.Destroy();	
				}
			}
		}
	}
}
