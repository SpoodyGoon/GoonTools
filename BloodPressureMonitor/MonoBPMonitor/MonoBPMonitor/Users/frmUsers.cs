
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
			swUsers.Add(tvUser);
			this.ShowAll();
		}


		protected virtual void OnBtnDeleteClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			if(tvUser.Selection.GetSelected(out iter))
			{
				User u = (User)tvUser.SelectedUser(iter);
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Question, Gtk.ButtonsType.YesNo, false, "Are you sure you want to delete " + u.UserName + " ?", "Delete User?");
				if((Gtk.ResponseType)md.Run() == Gtk.ResponseType.Yes)
				{					
					u.Remove();
					tvUser.Refresh();
				}
				md.Destroy();
			}
			else
			{
				Gtk.MessageDialog md2 = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "You need to select a user to delete.", "No Row Selected");
				md2.Run();
				md2.Destroy();
			}
			   
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
		
		
		protected virtual void OnTxtNameKeyPressEvent (object o, Gtk.KeyPressEventArgs args)
		{
			if(args.Event.Key == Gdk.Key.Return)
					btnAdd.Activate();
		}
	}
}