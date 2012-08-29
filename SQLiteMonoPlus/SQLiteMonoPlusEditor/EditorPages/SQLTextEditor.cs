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
			if (algResults.Children.Length > 0)
			{
				for(int i=0;i< algResults.Children.Length;i++)
				{
					algResults.Remove(algResults.Children[i]);
				}
			}
			Gtk.TreeView tv = new Gtk.TreeView ();
			Gtk.TreeViewColumn tvc;
			Gtk.CellRendererText crt;
			SqliteDataAdapter sqlDA = new SqliteDataAdapter (args.SQLStatement, args.CurrentConnection.ConnectionString);
			DataTable dt = new DataTable ();
			sqlDA.Fill (dt);
			int intColumnCount = dt.Columns.Count;
			//System.Type[] typs = new System.Type[intColumnCount];
			GLib.GType[] typs = new GLib.GType[intColumnCount];
			string[] strValues = new string[intColumnCount];
			for (int i = 0; i< dt.Columns.Count; i++)
			{
				typs [i] = GLib.GType.String;//dt.Columns [i].DataType;
				tvc = new Gtk.TreeViewColumn();
				tvc.Title = dt.Columns[i].ColumnName;
				tvc.Expand = true;
				tvc.Resizable = true;
				tvc.Visible = true;
				crt = new Gtk.CellRendererText();
				crt.Visible = true;
				crt.Editable = true;
				crt.Mode = Gtk.CellRendererMode.Editable;
				crt.Width = 50;
				crt.Xpad = 3;
				tvc.PackStart(crt, true);
				tv.AppendColumn(tvc);
			}
			Gtk.ListStore ls = new Gtk.ListStore(typs);
			Gtk.TreeIter iter;
			foreach (DataRow dr in dt.Rows)
			{
				iter = ls.Append();
				for (int i = 0; i< dt.Columns.Count; i++)
				{
					ls.SetValue(iter, i, dr[i].ToString());
				}
			}
			tv.ColumnsAutosize();
			tv.RulesHint = true;
			tv.EnableGridLines = Gtk.TreeViewGridLines.Both;
			tv.Model = ls;
			algResults.Add(tv);
			this.ShowAll();
		}

		public SQLiteMonoPlusEditor.SQLEditor.SQLEditorView SQLEditor
		{
			get{ return this.sqleditorview1;}
		}
	}
}

