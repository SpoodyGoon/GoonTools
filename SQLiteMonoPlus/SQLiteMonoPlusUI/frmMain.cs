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
			
			SchemaView = new SQLiteMonoPlusUI.UI.ObjectExplorer.SchemaTreeView (this);
			swObjectExplorer.Add (SchemaView);
			// clear all the existing pages 
			// being displayed at startup
			int intPages = nbkEditor.NPages;
			for (int i =0; i<intPages; i++)
			{
				nbkEditor.Remove (nbkEditor.GetNthPage (i));
			}

			
			//SQLiteMonoPlusEditor.SQLEditor.SQLEditorView ev = new SQLiteMonoPlusEditor.SQLEditor.SQLEditorView();

			this.ShowAll ();
		}
		
		#region Application Shutdown
	
		protected void Quit_Clicked (object sender, System.EventArgs e)
		{
			SqliteConnection sqlCN = new SqliteConnection (UserConfig.Default.DBLocation);
			//ShutdownApp();
		}

		private void AddEditorTab (SQLiteMonoPlus.Connection conn)
		{			
			SQLTextEditor ev = new SQLTextEditor ();
			ev.SQLEditor.CurrentConnection = conn;
			ev.SQLEditor.ConnectionChanged += delegate(object sender, SQLiteMonoPlusEditor.Events.ConnectionChangeEventArgs args)
			{
				frmDatabaseConnect frm = new frmDatabaseConnect ();			
				if ((Gtk.ResponseType)frm.Run () == Gtk.ResponseType.Ok)
				{
					SQLiteMonoPlusEditor.SQLEditor.SQLEditorView edt = (SQLiteMonoPlusEditor.SQLEditor.SQLEditorView)sender;
					edt.CurrentConnection = frm.SelectedConnection;
				}
				frm.Destroy ();
			};
			nbkEditor.AppendPage (ev, new TabLabel ("SQL Editor"));
			this.ShowAll ();
		}
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			ShutdownApp ();
			a.RetVal = true;
		}
		
		private void ShutdownApp ()
		{
			Application.Quit ();
		}
		#endregion Application Shutdown
	
		protected void btnConnect_Clicked (object sender, System.EventArgs e)
		{
			try
			{
				SQLiteMonoPlus.Connection conn = null;
				Database db = null;
				frmDatabaseConnect fm = new frmDatabaseConnect ();			
				if ((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok)
				{
					conn = fm.SelectedConnection;
				}
				fm.Destroy ();
			
				if (conn != null)
				{
					FileInfo fi = new FileInfo (conn.FilePath);
					if (!fi.Exists)
						throw new System.IO.FileNotFoundException ("Unable to load SQLite Database.", conn.FilePath);

					db = new Database (conn);
					OpenObjects.Databases.Add (db);
					db.LoadSchema ();   
					SchemaView.Load ();
					AddEditorTab (conn);
					this.ShowAll ();
				}

			}
			catch (Exception ex)
			{
				Common.HandleError (ex);
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
