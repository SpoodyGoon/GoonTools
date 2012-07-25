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
			this.Clear();
			Gtk.TreeIter DBIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBLabelIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBOLabelIter = Gtk.TreeIter.Zero;
			//sc.ForeignKey fk;
			foreach(sc.Database db in sc.OpenObjects.Databases)
			{
				DBIter = this.AppendValues(new SchemaDisplay(sc.DBObjectType.Database, db.DatabaseName, null));
				TBLabelIter = this.AppendValues(DBIter, new SchemaDisplay(sc.DBObjectType.Label, "Tables", null));
				foreach(sc.Table tbl in db.Tables)
				{	
					TBIter = this.AppendValues(TBLabelIter, new SchemaDisplay(sc.DBObjectType.Table, tbl.TableName, null));
					TBOLabelIter = this.AppendValues(TBIter, new SchemaDisplay(sc.DBObjectType.Label, "Columns", null));
					foreach(sc.Column col in tbl.Columns)
					{
						this.AppendValues(TBOLabelIter, new SchemaDisplay(sc.DBObjectType.Column, col.ColumnName, col.DisplayFormat));
					}
					TBOLabelIter = this.AppendValues(TBIter, new SchemaDisplay(sc.DBObjectType.Label, "Indexes", null));
					foreach(sc.Index idx in tbl.Indexes)
					{				
						this.AppendValues(TBOLabelIter, new SchemaDisplay(sc.DBObjectType.Column, idx.IndexName, null));
					}
				}

				TBLabelIter = this.AppendValues(DBIter, new SchemaDisplay(sc.DBObjectType.Label, "Views", null));
				foreach(sc.View vw in db.Views)
				{
					TBIter = this.AppendValues(TBLabelIter, new SchemaDisplay(sc.DBObjectType.View, vw.ViewName, null));
				}
				
			}
		}
	}
	
	public struct SchemaDisplay
	{
		public sc.DBObjectType ObjectType;
		public string ObjectName;
		public string ObjectDisplay;
		public SchemaDisplay(sc.DBObjectType type, string name, string display)
		{
			ObjectType = type;
			ObjectName = name;
			if(!string.IsNullOrEmpty(display))
				ObjectDisplay = display;
			else
				ObjectDisplay = name;
		}
	}
}
