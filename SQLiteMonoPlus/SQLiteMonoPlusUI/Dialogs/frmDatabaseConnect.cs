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
		
		public string SelectedDatabase
		{
			get
			{
				if(string.IsNullOrEmpty(fcDBFile.Filename))
					return null;
				else
					return fcDBFile.Filename;
			}
		}
		

		protected void cbxPooling_Clicked (object sender, System.EventArgs e)
		{
			lblMaxPool.Visible = cbxPooling.Active;
			spnMaxPool.Visible = cbxPooling.Active;
		}

		protected void btnTestConnection_Clicked (object sender, System.EventArgs e)
		{
			if(Common.DatabaseTryConnect(fcDBFile.Filename))
			{
				lblTestResult.Text = "Connection Success";
			}
			else
			{
				lblTestResult.Text = "Connection Failure";
			}
		}

		protected void OnBtnSaveConnectClicked (object sender, System.EventArgs e)
		{
			Connection cn;
			if (cboConnectName.ConnectionID != null) 
			{
				cn = Common.RecentConnections.Find ((int)cboConnectName.ConnectionID);
				cn.ConnectionName = cboConnectName.ActiveText;
				cn.FilePath = fcDBFile.Filename;
			} 
			else 
			{
				cn = new Connection (cboConnectName.Entry.Text.Trim(), fcDBFile.Filename);
				
			}
				
			if(cbxAdvanced.Active)
			{
				cn.Password = txtPassword.Text.Trim ();
				cn.Pooling = cbxPooling.Active;
				if (cbxPooling.Active)
					cn.MaxPoolSize = spnMaxPool.ValueAsInt;
				cn.Timeout = spnTimeout.ValueAsInt;
			}
			cn.LastUsedDate = DateTime.Now;
			Common.RecentConnections.AppendValues(cn);
			Common.RecentConnections.Save();
			cboConnectName.Refresh();
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

