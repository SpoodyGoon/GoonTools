using System;
using Gtk;
using SQLiteMonoPlus;
using sc = SQLiteMonoPlus.Schema;

namespace SQLiteMonoPlusUI.UI.ObjectExplorer
{
	/// <summary>
	/// Description of SchemaTreeModel.
	/// </summary>
	public class SchemaTreeModel : Gtk.TreeStore, Gtk.TreeModel
	{
		private Gdk.Pixbuf pxDatabase = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Database.png");
		private Gdk.Pixbuf pxTable = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Table.png");
		private Gdk.Pixbuf pxColumn = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Column.png");
		private Gdk.Pixbuf pxIndex = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Index.png");
		private Gdk.Pixbuf pxPriKey = Gdk.Pixbuf.LoadFromResource("DatabaseTree.PrimaryKey.png");
		private Gdk.Pixbuf pxFolder = Gdk.Pixbuf.LoadFromResource("DatabaseTree.Folder.png");
		private Gdk.Pixbuf pxForeignKey = Gdk.Pixbuf.LoadFromResource("DatabaseTree.ForeignKey.png");
		private Gdk.Pixbuf pxView = Gdk.Pixbuf.LoadFromResource("DatabaseTree.View.png");
		
		private Gtk.TreeIter DBIter = Gtk.TreeIter.Zero;
		private Gtk.TreeIter TBLabelIter = Gtk.TreeIter.Zero;
		private Gtk.TreeIter TBIter = Gtk.TreeIter.Zero;
		private Gtk.TreeIter TBOLabelIter = Gtk.TreeIter.Zero;
		public SchemaTreeModel() : base(typeof(SchemaDisplay))
		{
		}
		
		public void LoadOpenConnections()
		{
			this.Clear();
			foreach(sc.Database db in SQLiteMonoPlus.OpenConnections.Databases)
			{
				if(db.ObjectExporerDisplay)
				{
					AddDatabase(db);
				}
			}
		}

		public void RefreshAll()
		{
			LoadOpenConnections();
		}
	
		public void AddDatabase(sc.Database db)
		{
			DBIter = this.AppendValues(new SchemaDisplay(pxDatabase, DBObjectType.Database, db.DBConnection.ConnectionName, null, db));
			TBLabelIter = this.AppendValues(DBIter, new SchemaDisplay(pxFolder, DBObjectType.Label, "Tables", null, null));
			foreach(sc.Table tbl in db.Tables)
			{	
				TBIter = this.AppendValues(TBLabelIter, new SchemaDisplay(pxTable, DBObjectType.Table, tbl.TableName, null, tbl));
				TBOLabelIter = this.AppendValues(TBIter, new SchemaDisplay(pxFolder, DBObjectType.Label, "Columns", null, null));
				foreach(sc.Column col in tbl.Columns)
				{
					if(col.PrimaryKey)
						this.AppendValues(TBOLabelIter, new SchemaDisplay(pxPriKey, DBObjectType.Column, col.ColumnName, col.DisplayFormat, col));
					else if(col.ForeingKey)
						this.AppendValues(TBOLabelIter, new SchemaDisplay(pxForeignKey, DBObjectType.Column, col.ColumnName, col.DisplayFormat, col));
					else
						this.AppendValues(TBOLabelIter, new SchemaDisplay(pxColumn, DBObjectType.Column, col.ColumnName, col.DisplayFormat, col));
				}
				TBOLabelIter = this.AppendValues(TBIter, new SchemaDisplay(pxFolder, DBObjectType.Label, "Indexes", null, null));
				foreach(sc.Index idx in tbl.Indexes)
				{				
					this.AppendValues(TBOLabelIter, new SchemaDisplay(pxIndex, DBObjectType.Column, idx.IndexName, null, idx));
				}
			}
			
			TBLabelIter = this.AppendValues(DBIter, new SchemaDisplay(pxFolder, DBObjectType.Label, "Views", null, null));
			foreach(sc.View vw in db.Views)
			{
				TBIter = this.AppendValues(TBLabelIter, new SchemaDisplay(pxView, DBObjectType.View, vw.ViewName, null, vw));
			}
		}
	
	}

	public struct SchemaDisplay
	{
		public DBObjectType ObjectType;
		public string ObjectName;
		public string ObjectDisplay;
		public Gdk.Pixbuf ObjectImage;
		public object SchemaItem;
		public SchemaDisplay(Gdk.Pixbuf px, DBObjectType type, string name, string display, object DBItem)
		{
			ObjectType = type;
			ObjectName = name;
			ObjectImage = px;
			if(!string.IsNullOrEmpty(display))
				ObjectDisplay = display;
			else
				ObjectDisplay = name;

			SchemaItem = DBItem;
		}
	}
}
