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
			tvResults.Model = _ResultStore;
			sqleditorview1.SQLExecuted += SQLEditor_SQLExecuted;
		}
		
		protected void SQLEditor_SQLExecuted (object sender, Editors.Events.SQLExecutedEventArgs args)
		{
			for (int i = 0; i< tvResults.Columns.Length; i++)
			{
				tvResults.RemoveColumn (tvResults.Columns [i]);
			}
			
			SqliteDataAdapter sqlDA = new SqliteDataAdapter (args.SQLStatement, args.CurrentConnection.ConnectionString);
			DataTable dt = new DataTable ();
			sqlDA.Fill (dt);
			int intColumnCount = dt.Columns.Count;
			
			GLib.GType[] typs = new GLib.GType[intColumnCount];
			for (int i = 0; i< intColumnCount; i++)
			{
				tvResults.AppendColumn(dt.Columns [i].ColumnName, new CellRendererText(), "text", i);
				typs [i] = GLib.GType.String;
			}
			
			_ResultStore = new Gtk.ListStore (typs);
			Gtk.TreeIter iter = Gtk.TreeIter.Zero;
			foreach (DataRow dr in dt.Rows)
			{
				iter = _ResultStore.Append();
				for (int i = 0; i< intColumnCount; i++)
				{
					_ResultStore.SetValue(iter, i, dr[i].ToString());
				}
			}
			tvResults.ColumnsAutosize ();
			tvResults.CheckResize();
			tvResults.RulesHint = true;
			tvResults.EnableGridLines = Gtk.TreeViewGridLines.Both;
			tvResults.Model = _ResultStore;
			tvResults.QueueDraw();
			tvResults.ShowAll();
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

