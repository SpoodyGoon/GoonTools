//
//  TableDesignerTreeView.cs
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
using Gtk;

namespace SQLiteMonoPlusUI.Editors.GridDisplays
{
	public class TableDesignerTreeView : Gtk.TreeView
	{
		public TableDesignerTreeModel _TreeModel = new TableDesignerTreeModel ();
		public TableDesignerTreeView () : base()
		{
		}

		private void Build ()
		{
			this.HeadersClickable = false;
			this.HeadersVisible = false;
			this.RulesHint = false;
			this.EnableGridLines = Gtk.TreeViewGridLines.None;

			Gtk.TreeViewColumn colColumnName = new TreeViewColumn ();
			colColumnName.Clickable = false;
			colColumnName.Expand = true;
			colColumnName.Resizable = true;
			colColumnName.Title = "Column Name";
			Gtk.CellRendererText cellColumnName = new Gtk.CellRendererText ();
			cellColumnName.Editable = true;
			colColumnName.PackStart (cellColumnName, true);
			this.AppendColumn (colColumnName);
			
			//colPixbuf.SetCellDataFunc (cellPixbuf, new Gtk.TreeCellDataFunc (RenderPixbuf));
			//colObjectName.SetCellDataFunc (cellObjectName, new Gtk.TreeCellDataFunc (RenderObjectName));
			this.Model = _TreeModel;

		}
		
		private void RenderColumnName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			//SchemaDisplay sd = (SchemaDisplay)model.GetValue (iter, 0);
			//(cell as Gtk.CellRendererText).Text = sd.ObjectDisplay;
		}
	}

	public struct TableDesignerData
	{
		public string ColumnName;
		public string DataType;
		public bool AllowNull;
	}
}

