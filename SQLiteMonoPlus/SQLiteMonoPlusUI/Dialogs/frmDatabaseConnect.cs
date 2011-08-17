using System;

namespace SQLiteMonoPlusUI
{
	public partial class frmDatabaseConnect : Gtk.Dialog
	{
		//Data Source=filename;Version=3;Pooling=False;Max Pool Size=100;
		private string _FilePath = string.Empty;
		private string _Password = string.Empty;
		private int _Version = 3;
		private bool _Pooling = false;
		private int _MaxPoolSize = 0;
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

