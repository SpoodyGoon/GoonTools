using System;
using Mono.Data.SqliteClient;
using SQLiteMonoPlus;
using SQLiteMonoPlusUI.GlobalData;
using libGlobalTools;

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
		/// 
		/// 
	 
		private Connection _SelectedConnection = null;

		public frmDatabaseConnect ()
		{
			this.Build ();
			this.Response += frmDatabaseConnect_Response;
		}
		
		public string SelectedDatabaseName
		{
			get
			{
				if (string.IsNullOrEmpty (fcDBFile.Filename))
					return null;
				else
					return fcDBFile.Filename;
			}
		}

		public Connection SelectedConnection
		{
			get{ return _SelectedConnection;}
		}

		protected void cbxPooling_Clicked (object sender, System.EventArgs e)
		{
			lblMaxPool.Visible = cbxPooling.Active;
			spnMaxPool.Visible = cbxPooling.Active;
		}

		protected void btnTestConnection_Clicked (object sender, System.EventArgs e)
		{
			if (Utilities.DatabaseTryConnect (fcDBFile.Filename))
			{
				lblTestResult.Text = "Connection Success";
			}
			else
			{
				lblTestResult.Text = "Connection Failure";
			}
		}

		protected void OnCbxAdvancedToggled (object sender, System.EventArgs e)
		{
			algAdvanced.Visible = cbxAdvanced.Active;
		}

		protected void OnFcDBFileSelectionChanged (object sender, System.EventArgs e)
		{
			if (!string.IsNullOrEmpty (fcDBFile.Filename))
			{
				System.IO.FileInfo fi = new System.IO.FileInfo (fcDBFile.Filename);
				if (cboConnectName.CurrentConnection == null)
				{
					cboConnectName.Entry.Text = fi.Name.Replace (fi.Extension, "");
					lblFilePath.Text = fi.Directory.FullName;
				}
			}
		}
		
		protected void OnCboConnectNameChanged (object sender, EventArgs e)
		{
			if (cboConnectName.CurrentConnection != null)
			{
				lblTestResult.Text = "";
				System.IO.FileInfo fi = new System.IO.FileInfo (cboConnectName.CurrentConnection.FilePath);
				fcDBFile.SetUri (fi.FullName);
				cboConnectName.Entry.Text = cboConnectName.ActiveText;
				lblFilePath.Text = fi.Directory.FullName;				
			}
		}

		protected void frmDatabaseConnect_Response (object sender, Gtk.ResponseArgs args)
		{
			try
			{
				if (args.ResponseId == Gtk.ResponseType.Ok)
				{
					// Start by getting the selected Connection
					// or creating a new one from the information provided
					if (cboConnectName.CurrentConnection != null)
						_SelectedConnection = cboConnectName.CurrentConnection;
					else
						_SelectedConnection = new Connection (cboConnectName.Entry.Text.Trim (), fcDBFile.Filename);				

					StaticDataAccess.RecentConnections.AppendValues (_SelectedConnection);
					StaticDataAccess.RecentConnections.Save ();
				}
			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
			}
		}
	}
}

