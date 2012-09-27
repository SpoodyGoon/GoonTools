using System;
using System.Data;
using Gtk;
using Mono.Data.SqliteClient;

namespace SQLiteMonoPlusUI.Editors.Pages
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SQLTextEditor : Gtk.Bin
	{
		private Gtk.ListStore _ResultStore = new Gtk.ListStore(IntPtr.Zero);
		public SQLTextEditor ()
		{
			this.Build ();
			tvExecuteResults.Model = _ResultStore;
			sqleditorview1.SQLExecuted += SQLEditor_SQLExecuted;
		}
		
		protected void SQLEditor_SQLExecuted (object sender, Editors.Events.SQLExecutedEventArgs args)
		{
			for (int i = 0; i< tvExecuteResults.Columns.Length; i++)
			{
				tvExecuteResults.RemoveColumn (tvExecuteResults.Columns [i]);
			}
			txtResultMessage.Buffer.Text = "";
			try
			{
				SqliteDataAdapter sqlDA = new SqliteDataAdapter (args.SQLStatement, args.CurrentConnection.ConnectionString);
				DataTable dt = new DataTable ();
				sqlDA.Fill (dt);
				int intColumnCount = dt.Columns.Count;
				int intRowCount = dt.Rows.Count;
			
				GLib.GType[] typs = new GLib.GType[intColumnCount];
				for (int i = 0; i< intColumnCount; i++)
				{
					tvExecuteResults.AppendColumn (dt.Columns [i].ColumnName, new CellRendererText (), "text", i);
					typs [i] = GLib.GType.String;
				}
			
				_ResultStore = new Gtk.ListStore (typs);
				Gtk.TreeIter iter = Gtk.TreeIter.Zero;
				foreach (DataRow dr in dt.Rows)
				{
					iter = _ResultStore.Append ();
					for (int i = 0; i< intColumnCount; i++)
					{
						_ResultStore.SetValue (iter, i, dr [i].ToString ());
					}
				}
				tvExecuteResults.ColumnsAutosize ();
				tvExecuteResults.CheckResize ();
				tvExecuteResults.RulesHint = true;
				tvExecuteResults.EnableGridLines = Gtk.TreeViewGridLines.Both;
				tvExecuteResults.Model = _ResultStore;
				tvExecuteResults.QueueDraw ();
				tvExecuteResults.ShowAll ();
				txtResultMessage.SuccessMessage = "(" + intRowCount.ToString() + " row(s) affected)";
				nbkResults.CurrentPage = 0;
			}
			catch (Exception ex)
			{
				txtResultMessage.ErrorMessage = ex.Message.ToString();
				nbkResults.CurrentPage = 1;
			}
			this.ShowAll();
		}

		
		public SQLiteMonoPlusUI.Editors.SQL.SQLEditorView SQLEditor
		{
			get
			{ 
				return this.sqleditorview1;
			}
		}

	}
}

