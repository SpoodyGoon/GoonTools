//
//  SQLEditor.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2012 Andy York 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Data;
using Gtk;
using Mono.Data.SqliteClient;

namespace SQLiteMonoPlusEditor
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

		protected void SQLEditor_SQLExecuted (object sender, SQLiteMonoPlusEditor.Events.SQLExecutedEventArgs args)
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

		public SQLiteMonoPlusEditor.SQLEditor.SQLEditorView SQLEditor
		{
			get{ return this.sqleditorview1;}
		}
	}
}

