
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
		public frmDoctors()
		{
			this.Build();
			
			// set up the user combo box
			LoadUsers();
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			cboUser.PackStart(ct, true);
			cboUser.AddAttribute(ct, "text", 1);
			cboUser.Model = lsUser;
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
		}
		
		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnBtnAddClicked (object sender, System.EventArgs e)
		{
			// TODO: validate entry
			Gtk.TreeIter iter;
			cboUser.GetActiveIter(out iter);
			
			Doctor d = new Doctor(txtDoctor.Text, txtLocation.Text, txtPhone.Text,Convert.ToInt32(lsUser.GetValue(iter, 0).ToString()));
			d.Add();
			
			                      
		}

		protected virtual void OnBtnClearClicked (object sender, System.EventArgs e)
		{
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
