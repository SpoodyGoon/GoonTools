using System;

namespace SQLiteMonoPlusUI
{
	public class ScriptAsLevel : Gtk.Menu
	{
		public ScriptAsLevel () :  base()
		{
			BuildTopLevelMenu();	
		}

		private void BuildTopLevelMenu()
		{
			Gtk.MenuItem mnuLevel2 = new Gtk.MenuItem("Create To");
			this.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Alter To");
			this.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Drop To");
			this.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Drop & Create To");
			this.Add(mnuLevel2);					
		}
	}
}

