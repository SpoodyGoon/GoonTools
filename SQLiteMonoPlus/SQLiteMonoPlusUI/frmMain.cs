using System;
using System.IO;
using Mono.Data.SqliteClient;
using SQLiteMonoPlusEditor;
using SQLiteMonoPlus.Schema;
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
			SQLiteMonoPlusEditor.SQLEditor.EditorView ev = new SQLiteMonoPlusEditor.SQLEditor.EditorView();
			nbkEditor.Add(ev);


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
			try {
				string strDBFile = null;
				frmDatabaseConnect fm = new frmDatabaseConnect ();			
				if ((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok) {
					strDBFile = fm.SelectedDatabase;
				}
				fm.Destroy ();
			
				if (!string.IsNullOrEmpty (strDBFile)) {
					FileInfo fi = new FileInfo (strDBFile);
					if (!fi.Exists)
						throw new System.IO.FileNotFoundException ("Unable to load SQLite Database.", strDBFile);

					string strConnString = Constants.ConnectionString.Simple.Replace ("[DBPATH]", fi.FullName);
					string strDBName = fi.Name.Replace (fi.Extension, "");

					Database db = new Database (strConnString, strDBName);
					OpenObjects.Databases.Add (db);
					db.LoadSchema ();   
					SchemaView.Load ();
					this.ShowAll ();
				}
			}
			catch (Exception ex) {
				GlobalTools.Common.HandleError(ex);
			}
		}

		protected void OnAboutActionActivated (object sender, System.EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

		protected void OnNewQueryActionActivated (object sender, EventArgs e)
		{
			throw new System.NotImplementedException ();
		}

	}
}
