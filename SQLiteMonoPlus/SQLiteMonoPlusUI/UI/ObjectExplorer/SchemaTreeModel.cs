using System;
using Gtk;
using sc = SQLiteMonoPlusUI.Schema;

namespace SQLiteMonoPlusUI.UI.ObjectExplorer
{
	/// <summary>
	/// Description of SchemaTreeModel.
	/// </summary>
	public class SchemaTreeModel : Gtk.TreeStore, Gtk.TreeModel
	{
		public SchemaTreeModel() : base(typeof(SchemaDisplay))
		{
		}
		
		public void Load()
		{
			Gtk.TreeIter DBIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBLIter = Gtk.TreeIter.Zero;
			sc.Database db;
			sc.Table tbl;
			sc.Column col;
			sc.Index idx;
			sc.ForeignKey fk;
			for(int d = 0; d < sc.OpenObjects.Databases.Count; d++)
			{
				db = (sc.Database)sc.OpenObjects.Databases[d];
				DBIter = this.AppendValues(new SchemaDisplay(sc.DBObjectType.Database, db.DatabaseName));
				for(int t = 0; t < db.Tables.Count; t++)
				{
					tbl = (sc.Table)db.Tables[t];
					TBLIter = this.AppendValues(DBIter, new SchemaDisplay(sc.DBObjectType.Table, tbl.TableName));
					// Columns
					for(int tbo = 0; tbo < tbl.Columns.Count; tbo++)
					{				
						col = (sc.Column)tbl.Columns[tbo];
						this.AppendValues(DBIter, new SchemaDisplay(sc.DBObjectType.Column, col.ColumnName));
					}
					for(int tbo = 0; tbo < tbl.Indexes.Count; tbo++)
					{				
						idx = (sc.Index)tbl.Indexes[tbo];
						this.AppendValues(DBIter, new SchemaDisplay(sc.DBObjectType.Column, idx.IndexName));
					}
				}
				
			}
		}
	}
	
	public struct SchemaDisplay
	{
		public sc.DBObjectType ObjectType;
		public string ObjectName;
		public SchemaDisplay(sc.DBObjectType type, string name)
		{
			ObjectType = type;
			ObjectName = name;
		}
	}
}
