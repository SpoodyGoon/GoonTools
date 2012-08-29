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
using Mono.Data.SqliteClient;

namespace SQLiteMonoPlusEditor
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class SQLTextEditor : Gtk.Bin
	{
		public SQLTextEditor ()
		{
			this.Build ();
			sqleditorview1.SQLExecuted += SQLEditor_SQLExecuted;
		}

		protected void SQLEditor_SQLExecuted (object sender, SQLiteMonoPlusEditor.Events.SQLExecutedEventArgs args)
		{
			SqliteDataAdapter sqlDA = new SqliteDataAdapter (args.SQLStatement, args.CurrentConnection.ConnectionString);
			DataTable dt = new DataTable ();
			sqlDA.Fill (dt);
			int intColumnCount = dt.Columns.Count;
			System.Type[] typs = new System.Type[intColumnCount];
			for (int i = 0; i< dt.Columns.Count; i++)
			{
				typs [i] = dt.Columns [i].DataType;
			}
			Gtk.ListStore ls = new Gtk.ListStore (typs);
			foreach (DataRow dr in dt.Rows)
			{
				ls.AppendValues(dr.ItemArray);
			}
			Gtk.TreeView tv = new Gtk.TreeView(ls);
			algResults.Add(tv);
			this.ShowAll();
		}

		public SQLiteMonoPlusEditor.SQLEditor.SQLEditorView SQLEditor
		{
			get{ return this.sqleditorview1;}
		}
	}
}

