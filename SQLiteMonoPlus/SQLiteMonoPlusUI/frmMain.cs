using System;
using Mono.Data.Sqlite;
using Gtk;

namespace SQLiteMonoPlusUI
{
	public partial class frmMain: Gtk.Window
	{	
		public frmMain (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
		}
		
		#region Application Shutdown
	
		protected void Quit_Clicked (object sender, System.EventArgs e)
		{
			SqliteConnection sqlCN = new SqliteConnection(UserConfig.Default.DBLocation);
			//ShutdownApp();
		}
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			ShutdownApp();
			a.RetVal = true;
		}
		
		private void ShutdownApp()
		{
			Application.Quit();
		}
		#endregion Application Shutdown
	
		protected void btnConnect_Clicked (object sender, System.EventArgs e)
		{
			frmDatabaseConnect fm = new frmDatabaseConnect();
			fm.Run();
			fm.Destroy();
		}
	}
}
