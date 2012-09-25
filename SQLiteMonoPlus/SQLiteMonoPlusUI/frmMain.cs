using System;
using System.IO;
using Mono.Data.SqliteClient;
using SQLiteMonoPlus.Schema;
using SQLiteMonoPlusUI.Editors.Events;
using SQLiteMonoPlusUI.Editors.SQL;
using SQLiteMonoPlusUI.Editors.Pages;
using Gtk;
using libGlobalTools;

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
			ev.SQLEditor.ConnectionChanged += delegate(object sender, ConnectionChangeEventArgs args)
			{
				frmDatabaseConnect frm = new frmDatabaseConnect ();			
				if ((Gtk.ResponseType)frm.Run () == Gtk.ResponseType.Ok)
				{
					SQLEditorView edt = (SQLEditorView)sender;
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
				frmDatabaseConnect fm = new frmDatabaseConnect ();			
				if ((Gtk.ResponseType)fm.Run () == Gtk.ResponseType.Ok)
				{
					conn = fm.SelectedConnection;
				}
				fm.Destroy ();
			
				if (conn != null)
				{
					if(conn.CanConnect)
					{
						Database db = conn.DatabaseOpen();
						SchemaView.AddDatabase(db);
						AddEditorTab (conn);
					}
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

		protected void OnExecuteActionActivated (object sender, EventArgs e)
		{
			MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, "Execute Fired", "Execute Fired");
			md.Run();
			md.Destroy();
		}
	}
}
