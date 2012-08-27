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
			// clear all the existing pages 
			// being displayed at startup
			int intPages = nbkEditor.NPages;
			for (int i =0; i<intPages; i++) {
				nbkEditor.Remove(nbkEditor.GetNthPage(i));
			}

			
			//SQLiteMonoPlusEditor.SQLEditor.SQLEditorView ev = new SQLiteMonoPlusEditor.SQLEditor.SQLEditorView();
			SQLTextEditor ev = new SQLTextEditor();
			ev.SQLEditor.ConnectionChanged += delegate(object sender, SQLiteMonoPlusEditor.Events.ConnectionChangeEventArgs args)
			{
				frmDatabaseConnect frm = new frmDatabaseConnect();			
				if ((Gtk.ResponseType)frm.Run () == Gtk.ResponseType.Ok) {
					SQLTextEditor edt = (SQLTextEditor)sender;
					edt.SQLEditor.CurrentConnection = frm.SelectedConnection;
				}
				frm.Destroy();
			};
			nbkEditor.AppendPage(ev, new TabLabel("SQL Editor"));

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
				Database db = null;
				frmDatabaseConnect fm = new frmDatabaseConnect ();			
				if ((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok) {
					strDBFile = fm.SelectedDatabaseName;
				}
				fm.Destroy ();
			
				if (!string.IsNullOrEmpty (strDBFile)) {
					FileInfo fi = new FileInfo (strDBFile);
					if (!fi.Exists)
						throw new System.IO.FileNotFoundException ("Unable to load SQLite Database.", strDBFile);

					string strConnString = Constants.ConnectionString.Simple.Replace ("[DBPATH]", fi.FullName);
					string strDBName = fi.Name.Replace (fi.Extension, "");

					db = new Database (strConnString, strDBName);
					OpenObjects.Databases.Add (db);
					db.LoadSchema ();   
					SchemaView.Load ();
					this.ShowAll ();
				}

				if(db != null)
				{
					SQLiteMonoPlusEditor.SQLEditor.SQLEditorView ev = new SQLiteMonoPlusEditor.SQLEditor.SQLEditorView();
					nbkEditor.Add(ev);
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
