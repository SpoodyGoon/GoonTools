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
			Gdk.Pixbuf pxDatabase = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Database.png");
			Gdk.Pixbuf pxTable = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Table.png");
			Gdk.Pixbuf pxColumn = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Column.png");
			Gdk.Pixbuf pxIndex = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Index.png");
			Gdk.Pixbuf pxPriKey = Gdk.Pixbuf.LoadFromResource("DatabaseTree.PrimaryKey.png");
			Gdk.Pixbuf pxFolder = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Folder.png");
			Gdk.Pixbuf pxForeignKey = Gdk.Pixbuf.LoadFromResource("DatabaseTree.ForeignKey.png");
			Gdk.Pixbuf pxView = Gdk.Pixbuf.LoadFromResource("DatabaseTree.View.png");

			Gtk.TreeIter DBIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBLabelIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBIter = Gtk.TreeIter.Zero;
			Gtk.TreeIter TBOLabelIter = Gtk.TreeIter.Zero;
			//sc.ForeignKey fk;
			foreach(sc.Database db in sc.OpenObjects.Databases)
			{
				DBIter = this.AppendValues(new SchemaDisplay(pxDatabase, sc.DBObjectType.Database, db.DatabaseName, null));
				TBLabelIter = this.AppendValues(DBIter, new SchemaDisplay(pxFolder, sc.DBObjectType.Label, "Tables", null));
				foreach(sc.Table tbl in db.Tables)
				{	
					TBIter = this.AppendValues(TBLabelIter, new SchemaDisplay(pxTable, sc.DBObjectType.Table, tbl.TableName, null));
					TBOLabelIter = this.AppendValues(TBIter, new SchemaDisplay(pxFolder, sc.DBObjectType.Label, "Columns", null));
					foreach(sc.Column col in tbl.Columns)
					{
						if(col.PrimaryKey)
							this.AppendValues(TBOLabelIter, new SchemaDisplay(pxPriKey, sc.DBObjectType.Column, col.ColumnName, col.DisplayFormat));
						else
							this.AppendValues(TBOLabelIter, new SchemaDisplay(pxColumn, sc.DBObjectType.Column, col.ColumnName, col.DisplayFormat));
					}
					TBOLabelIter = this.AppendValues(TBIter, new SchemaDisplay(pxFolder, sc.DBObjectType.Label, "Indexes", null));
					foreach(sc.Index idx in tbl.Indexes)
					{				
						this.AppendValues(TBOLabelIter, new SchemaDisplay(pxIndex, sc.DBObjectType.Column, idx.IndexName, null));
					}
				}

				TBLabelIter = this.AppendValues(DBIter, new SchemaDisplay(pxFolder, sc.DBObjectType.Label, "Views", null));
				foreach(sc.View vw in db.Views)
				{
					TBIter = this.AppendValues(TBLabelIter, new SchemaDisplay(pxView, sc.DBObjectType.View, vw.ViewName, null));
				}
				
			}
		}
	}
	
	public struct SchemaDisplay
	{
		public sc.DBObjectType ObjectType;
		public string ObjectName;
		public string ObjectDisplay;
		public Gdk.Pixbuf ObjectImage;
		public SchemaDisplay(Gdk.Pixbuf px, sc.DBObjectType type, string name, string display)
		{
			ObjectType = type;
			ObjectName = name;
			ObjectImage = px;
			if(!string.IsNullOrEmpty(display))
				ObjectDisplay = display;
			else
				ObjectDisplay = name;
		}
	}
}
