using System;

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

		protected void btnConnect_Clicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void btnCancel_Clicked (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}

