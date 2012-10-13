using System;
using Gtk;
using SQLiteMonoPlus;

namespace SQLiteMonoPlusUI.UI.ContexMenus
{
	public abstract class ScriptAsMenu : Gtk.Menu
	{
		protected string TypeLabel = "Database";
		protected DBObjectType SchemaObjectType = DBObjectType.Database;
		public ScriptAsMenu (string mnuTypeLabel, DBObjectType mnuType) : base() 
		{
			TypeLabel = mnuTypeLabel;
			SchemaObjectType = mnuType;
			Build ();
		}

		protected virtual void Build()
		{			
			Gtk.MenuItem mnuItem = new Gtk.MenuItem("Create To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.Create);
			this.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Alter To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.Alter);
			this.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Drop To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.Drop);
			this.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Drop & Create To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.DropCreate);
			this.Add(mnuItem);
			this.Add(new SeparatorMenuItem());
			mnuItem = new Gtk.MenuItem("Select To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.Select);
			this.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Insert To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.Insert);
			this.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Update To");
			mnuItem.Submenu = ScriptToSubMenu(ScriptToAction.Update);
			this.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Delete To");
			mnuItem.Submenu = ScriptToSubMenu(ScriptToAction.Delete);
			this.Add(mnuItem);
			this.Add(new SeparatorMenuItem());
			mnuItem = new Gtk.MenuItem("Execute To");
			mnuItem.Submenu = ScriptToSubMenu (ScriptToAction.Execute);
			this.Add(mnuItem);
		}		
		
		private Gtk.Menu ScriptToSubMenu (ScriptToAction action)
		{
			Gtk.Menu mnu = new Gtk.Menu();
			Gtk.MenuItem mnuItem = new Gtk.MenuItem("New Query Editor Window");
			mnuItem.ButtonReleaseEvent += delegate {
				OnScriptToClicked(action ,ScriptToLocation.QueryWindow);
			};
			mnu.Add(mnuItem);
			mnu.Add(new SeparatorMenuItem());
			mnuItem = new Gtk.MenuItem("File...");
			mnuItem.ButtonReleaseEvent += delegate {
				OnScriptToClicked(action ,ScriptToLocation.File);
			};
			mnu.Add(mnuItem);
			mnuItem = new Gtk.MenuItem("Clipboard");
			mnuItem.ButtonReleaseEvent += delegate {
				OnScriptToClicked(action ,ScriptToLocation.Clipboard);
			};
			mnu.Add(mnuItem);
			return mnu;
			
		}
		
		protected virtual void OnScriptToClicked (ScriptToAction action, ScriptToLocation location)
		{
//			switch (_ObjectType)
//			{
//				case DBObjectType.Database:
//					SQLiteMonoPlus.Schema.Database db = (SQLiteMonoPlus.Schema.Database)_DBSchemaObject;
//					
//					break;
//				case DBObjectType.Table:
//					SQLiteMonoPlus.Schema.Table tbl = (SQLiteMonoPlus.Schema.Table)_DBSchemaObject;
//					break;
//			}
		}
	}
}

