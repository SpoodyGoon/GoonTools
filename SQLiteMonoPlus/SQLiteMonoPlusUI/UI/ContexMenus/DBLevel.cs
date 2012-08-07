using System;
using Gtk;

namespace SQLiteMonoPlusUI.UI.ContexMenus
{
	public class DBLevel : Gtk.Menu
	{
		public DBLevel ()
		{
			BuildTopLevelMenu();	
		}

		private void BuildTopLevelMenu()
		{
			Gtk.MenuItem tmpMenu = new Gtk.MenuItem("New Database...");
			tmpMenu.ButtonReleaseEvent += delegate {
				LocalEvent();
			};
			this.Add(tmpMenu); 

			tmpMenu = new Gtk.MenuItem("New Query");
			tmpMenu.ButtonReleaseEvent += delegate {
				LocalEvent();
			};
			this.Add(tmpMenu);
			
			Gtk.MenuItem mnuCreateMenu = new Gtk.MenuItem("Script Database As");
			mnuCreateMenu.Submenu = ScriptMenu();
			this.Add(mnuCreateMenu);


			tmpMenu = new Gtk.MenuItem("Pragmas");
			tmpMenu.ButtonReleaseEvent += delegate {
				///frmPragmas fm = new frmPragmas();
			};
			this.Add(tmpMenu);	


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
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Alter To");
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Drop To");
			mnu.Add(mnuLevel2);
			mnuLevel2 = new Gtk.MenuItem("Drop & Create To");
			mnu.Add(mnuLevel2);
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

