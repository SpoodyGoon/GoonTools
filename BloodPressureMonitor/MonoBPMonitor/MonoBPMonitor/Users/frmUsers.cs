
using System;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmUsers : Gtk.Dialog
	{
		Users.UserTreeView tvUser = new Users.UserTreeView();
		public frmUsers()
		{
			this.Build();
			// TODO: Move this event to the xml
			txtName.KeyReleaseEvent += new KeyReleaseEventHandler(txtName_KeyReleaseEvent);
			// TODO: create a better format for the textbox and add button
			swUsers.Add(tvUser);
			this.ShowAll();
		}

		private void txtName_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
		{
			if(args.Event.Key == Gdk.Key.Return)
				btnAdd.Activate();
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
			if(txtName.Text.Trim() != "")
			{
				User u = new User(txtName.Text);
				u.Add();
				tvUser.Refresh();
				txtName.Text = "";
			}
			else
			{
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "A user name is required.", "Missing User Name");
				md.Run();
				md.Destroy();
				// TODO: how to focus on an entry
				txtName.SelectRegion(0, txtName.Text.Length);
			}
		}
	}
}
