using System;

namespace SQLiteMonoPlusUI.Editors.ContexMenus
{
	public class SQLEditorViewMenu : Gtk.Menu
	{
		public event Events.ConnectMenuItemEventHandler ConnectChangeRequested;
		public SQLEditorViewMenu () : base()
		{
			BuildTopLevelMenu();
		}

		private void BuildTopLevelMenu()
		{
			Gtk.MenuItem mi = new Gtk.MenuItem("Cut");
			this.Append(mi); 
			mi = new Gtk.MenuItem("Copy");
			this.Append(mi); 
			mi = new Gtk.MenuItem("Paste");
			this.Append(mi); 
			Gtk.SeparatorMenuItem smi = new Gtk.SeparatorMenuItem();
			this.Append(smi);
			mi = new Gtk.MenuItem("Connection");
			mi.Submenu = ConnectionMenu();
			this.Append(mi); 
			smi = new Gtk.SeparatorMenuItem();
			this.Append(smi);
			mi = new Gtk.MenuItem("Execute");
			this.Append(mi);
			mi = new Gtk.MenuItem("Explain Query");
			this.Append(mi);
		}

		private Gtk.Menu ConnectionMenu ()
		{
			Gtk.Menu mnu = new Gtk.Menu ();
			Gtk.MenuItem mi = new Gtk.MenuItem ("Connect...");
			mi.Activated += delegate
			{
				ConnectChangeRequested();
			};
			mnu.Append (mi); 
			mi = new Gtk.MenuItem ("Disconnect");
			mnu.Append (mi); 
			mi = new Gtk.MenuItem ("Disconnect All Queries");
			mnu.Append (mi); 
			mi = new Gtk.MenuItem ("Change Connection");
			mnu.Append (mi); 
			return mnu;
		}
		
	}
}

