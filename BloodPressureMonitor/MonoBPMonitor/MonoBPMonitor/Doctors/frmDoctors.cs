
using System;
using System.Data;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor
{
	
	
	public partial class frmDoctors : Gtk.Dialog
	{

		private Gtk.ListStore lsUser = new Gtk.ListStore(typeof(int), typeof(string));
		private Doctors.DoctorTreeView tvDoctor;
		public frmDoctors()
		{
			this.Build();
			
			tvDoctor = new MonoBPMonitor.Doctors.DoctorTreeView();
			swDoctor.Add(tvDoctor);
			
			// set up the user combo box
			LoadUsers();
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			cboUser.PackStart(ct, true);
			cboUser.AddAttribute(ct, "text", 1);
			cboUser.Model = lsUser;
			Gtk.TreeIter iter;
			if(lsUser.GetIterFirst(out iter))
				cboUser.SetActiveIter(iter);
			//cboUser.Changed += new EventHandler(cboUser_Changed);
			
			this.ShowAll();
		}

//		[GLib.ConnectBeforeAttribute()]
//		private void cboUser_Changed(object sender, EventArgs e)
//		{
//			Gtk.TreeIter iter;
//			cboUser.GetActiveIter(out iter);
//			Console.WriteLine("got here " + lsUser.GetValue(iter, 0).ToString());
//			if(lsUser.GetValue(iter, 0).ToString() == "-1")
//			{
//				frmUsers fm = new frmUsers();
//				fm.Run();
//				fm.Destroy();
//			}
//		}

		protected virtual void OnBtnDeleteClicked (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			if(tvDoctor.Selection.GetSelected(out iter))
			{
				Doctor d = (Doctor)tvDoctor.SelectedDoctor(iter);
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Question, Gtk.ButtonsType.YesNo, false, "Are you sure you want to delete " + d.DoctorName + " ?", "Delete User?");
				if((Gtk.ResponseType)md.Run() == Gtk.ResponseType.Yes)
				{
					d.Remove();
					tvDoctor.Refresh();
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
			if(txtDoctor.Text.Trim() != "")
			{
				Gtk.TreeIter iter;
				cboUser.GetActiveIter(out iter);
				Doctor d = new Doctor(txtDoctor.Text, txtLocation.Text, txtPhone.Text,Convert.ToInt32(lsUser.GetValue(iter, 0).ToString()));
				d.Add();
				tvDoctor.Refresh();
				txtDoctor.Text = "";
				txtLocation.Text = "";
				txtPhone.Text = "";
			}
			else
			{
				Gtk.MessageDialog md = new MessageDialog(this,DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "A doctors name is required.", "Missing Doctor Name");
				md.Run();
				md.Destroy();
			}
			
			
		}

		protected virtual void OnBtnClearClicked (object sender, System.EventArgs e)
		{
			txtDoctor.Text = "";
			txtLocation.Text = "";
			txtPhone.Text = "";
		}
		
		
		
		private void LoadUsers()
		{
			try
			{
				lsUser.Clear();
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT UserID, UserName FROM tb_User");
				foreach(DataRow dr in dt.Rows)
				{
					lsUser.AppendValues(Convert.ToInt32(dr["UserID"]), dr["UserName"].ToString());
				}
				//lsUser.AppendValues(-1, "New User...");
				
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
	}
}
