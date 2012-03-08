using System;
using Mono.Data.SqliteClient;
using Gtk;

namespace SQLiteMonoPlusUI
{
	public partial class frmMain: Gtk.Window
	{	
		protected SQLiteMonoPlusUI.UI.ObjectExplorer.SchemaTreeView SchemaView;
		public frmMain (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
			SchemaView = new SQLiteMonoPlusUI.UI.ObjectExplorer.SchemaTreeView(this);
			swObjectExplorer.Add(SchemaView);
			this.ShowAll();
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
			string strDBFile = null;
			frmDatabaseConnect fm = new frmDatabaseConnect();			
			if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
			{
				strDBFile = fm.SelectedDatabase;
			}
			fm.Destroy();
			
			if(!string.IsNullOrEmpty(strDBFile))
			{
				Schema.Database db = new Schema.Database(strDBFile);
				Schema.OpenObjects.Databases.Add(db);
				db.LoadSchema();   
				SchemaView.Load();
				this.ShowAll();
			}
		}

		protected void OnAboutActionActivated (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}
	}
}
