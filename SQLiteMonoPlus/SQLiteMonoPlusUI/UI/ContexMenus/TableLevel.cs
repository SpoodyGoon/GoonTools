using System;
using Gtk;

namespace SQLiteMonoPlusUI.UI.ContexMenus
{
	public class TableLevel : Gtk.Menu
	{
		SQLiteMonoPlus.Schema.Table _Table;
		public TableLevel (SQLiteMonoPlus.Schema.Table table)
		{
			_Table =table;
			BuildTopLevelMenu();	
		}

		public TableLevel ()
		{
			BuildTopLevelMenu();	
		}

		private void BuildTopLevelMenu()
		{
			Gtk.MenuItem tmpMenu = new Gtk.MenuItem("New Table...");
			tmpMenu.ButtonReleaseEvent += delegate {
				LocalEvent();
			};
			this.Add(tmpMenu); 

			tmpMenu = new Gtk.MenuItem("Design...");
			tmpMenu.ButtonReleaseEvent += delegate {
				LocalEvent();
			};
			this.Add(tmpMenu);
			
			Gtk.MenuItem mnuCreateMenu = new Gtk.MenuItem("Script Table As");
			mnuCreateMenu.Submenu = ScriptMenu();
			this.Add(mnuCreateMenu);


			tmpMenu = new Gtk.MenuItem("Properties");
			tmpMenu.ButtonReleaseEvent += delegate {
				LocalEvent();
			};
			this.Add(tmpMenu);					
		}
		
		#region "SubMenus"
		
		private Gtk.Menu ScriptMenu()
		{
			// tasks menu
			Gtk.Menu mnu = new Gtk.Menu();
			Gtk.MenuItem mnuLevel2 = new Gtk.MenuItem("Create To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Alter To");
			mnuLevel2.Sensitive = false;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Drop To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Drop & Create To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnu.Add(new SeparatorMenuItem());
			mnuLevel2 = new Gtk.MenuItem("Select To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Insert To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Update To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Delete To");
			mnuLevel2.Sensitive = true;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			mnu.Add(new SeparatorMenuItem());
			mnuLevel2 = new Gtk.MenuItem("Execute To");
			mnuLevel2.Sensitive = false;
			mnuLevel2.Submenu = ScriptToMenu ();
			mnu.Add(mnuLevel2);
			return mnu;
		}

		private Gtk.Menu ScriptToMenu ()
		{
			Gtk.Menu mnu = new Gtk.Menu();
			Gtk.MenuItem mnuLevel3 = new Gtk.MenuItem("New Query Editor Window");
			mnuLevel3.ButtonReleaseEvent += delegate {
				// TODO: add event to script table
			};
			mnu.Add(mnuLevel3);
			mnu.Add(new SeparatorMenuItem());
			mnuLevel3 = new Gtk.MenuItem("File...");
			mnu.Add(mnuLevel3);
			mnuLevel3 = new Gtk.MenuItem("Clipboard");
			mnu.Add(mnuLevel3);
			return mnu;

		}
		
		#endregion "SubMenus"
		
		#region "Local Events"
		
		/// <summary>
		///  Gets the selected iter/row and any children if theys exist
		///  and update the database to mark those tasks as archived
		/// </summary>
		private void LocalEvent()
		{
			try
			{				
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Sorry Archiving Disabled.");
				md.Run();
				md.Destroy();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		#endregion "Local Events"
	}
}

