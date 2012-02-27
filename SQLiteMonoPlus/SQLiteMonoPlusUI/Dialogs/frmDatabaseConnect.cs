using System;
using Mono.Data.SqliteClient;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI
{
	public partial class frmDatabaseConnect : Gtk.Dialog
	{
		///<description>
		/// File Name Extentions for windows
		/// sqlite
		/// s3db
		/// db
		///</description>
		public frmDatabaseConnect ()
		{
			this.Build ();
		}

		protected void cbxPooling_Clicked (object sender, System.EventArgs e)
		{
			lblMaxPool.Visible = cbxPooling.Active;
			spnMaxPool.Visible = cbxPooling.Active;
		}

		protected void btnTestConnection_Clicked (object sender, System.EventArgs e)
		{
			if(TestConnection())
			{
				lblTestResult.Text = "Connection Success";
			}
			else
			{
				lblTestResult.Text = "Connection Failure";
			}
		}
		
		private bool TestConnection ()
		{
			bool blnSuccess = true;
			try 
			{
				SqliteConnection sqlCN = new SqliteConnection (Constants.ConnectionString.Simple.Replace ("[DBPATH]", fcDBFile.Filename));
				SqliteCommand sqlCMD = new SqliteCommand(GlobalData.SQL.ConnectionTest, sqlCN);
				sqlCN.Open ();
				sqlCMD.ExecuteNonQuery();
				sqlCN.Close ();
				sqlCMD.Dispose();
				sqlCN.Dispose ();
			} 
			catch (Exception ex) 
			{
				blnSuccess = false;
				Console.WriteLine (ex.ToString ());				
			}
			return blnSuccess;
		}

		protected void OnBtnSaveConnectClicked (object sender, System.EventArgs e)
		{
			Connection cn;
			if (cboConnectName.ConnectionID != null) {
				cn = Common.RecentConnections.Find ((int)cboConnectName.ConnectionID);
				cn.ConnectionName = cboConnectName.ActiveText;
				cn.FilePath = fcDBFile.Filename;
				cn.Password = txtPassword.Text.Trim ();
			} else {
				cn = new Connection (cboConnectName.ActiveText, fcDBFile.Filename, txtPassword.Text.Trim ());
			}
			cn.Pooling = cbxPooling.Active;
			if (cbxPooling.Active)
				cn.MaxPoolSize = spnMaxPool.ValueAsInt;
			cn.LastUsedDate = DateTime.Now;
		}

		protected void OnCbxAdvancedToggled (object sender, System.EventArgs e)
		{
			algAdvanced.Visible = cbxAdvanced.Active;
		}

		protected void OnFcDBFileSelectionChanged (object sender, System.EventArgs e)
		{
			if(!string.IsNullOrEmpty(fcDBFile.Filename))
			{
				System.IO.FileInfo fi = new System.IO.FileInfo(fcDBFile.Filename);
				if(string.IsNullOrEmpty(cboConnectName.ConnectionName))
				{
					cboConnectName.Entry.Text = fi.Name.Replace(fi.Extension, "");
				}
			}
		}
	}
}

