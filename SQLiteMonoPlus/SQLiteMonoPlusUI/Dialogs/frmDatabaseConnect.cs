using System;
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
			throw new System.NotImplementedException ();
		}

		protected void OnBtnConnectClicked (object sender, System.EventArgs e)
		{
			if(cbxSaveConnection.Active)
			{
				Connection cn = Common.RecentConnections.Find("");
				cn.ConnectionName = comboboxentry1.ActiveText;
				cn.FilePath = fcDBFile.Filename;
				cn.Password = txtPassword.Text.Trim();
				cn.Pooling = cbxPooling.Active;
				cn.MaxPoolSize = spnMaxPool.ValueAsInt;
				cn.LastUsedDate = DateTime.Now;
			}
		}
	}
}

