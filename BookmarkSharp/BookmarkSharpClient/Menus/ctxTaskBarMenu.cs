/*
 * Created by SharpDevelop.
 * User: Andrew York
 * Date: 7/31/2008
 * Time: 6:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Gtk;

namespace BookmarkSharpClient.Menus
{
	/// <summary>
	/// Description of ctxTaskBarMenu.
	/// </summary>
	public class ctxTaskBarMenu: Gtk.Menu
	{
		private DataTable dt;
		public ctxTaskBarMenu()
		{
			MenuItem menuRestore = new MenuItem("Show BookMarks");
			menuRestore.Activated += new EventHandler(menuRestore_Activated);
			this.Add(menuRestore);
			MenuItem mnuOptions = new MenuItem("Options");
			mnuOptions.Activated += new EventHandler(mnuOptions_Activated);
			this.Add(mnuOptions);
			ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
			Gtk.Image appimg = new Gtk.Image(Stock.Quit, IconSize.Menu);
			menuItemQuit.Image = appimg;
			this.Add(menuItemQuit);
			// Quit the application when quit has been clicked.
			menuItemQuit.Activated += delegate { Application.Quit(); };
			MenuItem mnuBookmarks = new MenuItem("Bookmarks");
			
//				dt = (DataTable)BookmarkSharpClient.MainClass.dtBookmarks;
//				mnuBookmarks.Submenu = GetSubMenu(dt.Select(" PathDepth = 0"));
			
			this.Add(mnuBookmarks);
		}
		
		private Gtk.Menu GetSubMenu(DataRow[] dr)
		{
			Gtk.Menu mnu = new Gtk.Menu();
			Gtk.MenuItem mnuItem;
			for(int i = 0; i < dr.Length; i++)
			{
				if(dr[i]["URL"].ToString()=="")
				{
					mnuItem = new MenuItem(dr[i]["Title"].ToString());
					mnuItem.Submenu = GetSubMenu(dt.Select(" ParentID = " + dr[i]["BookmarkID"].ToString()));
					mnu.Add(mnuItem);
					
				}
				else
				{
					mnuItem = new MenuItem(dr[i]["Title"].ToString());
					mnuItem.Activated += delegate { StartBrowser(dr[i]["URL"].ToString()); };
					mnu.Add(mnuItem);
				}
			}
			
			return mnu;
		}

		void menuRestore_Activated(object sender, EventArgs e)
		{
			frmBookmarkList fm = new BookmarkSharpClient.frmBookmarkList();
			fm.Run();
			fm.Destroy();
		}
		
		private void mnuOptions_Activated(object sender, EventArgs e)
		{
			frmOptions fm = new frmOptions();
			fm.Run();
			fm.Destroy();
		}
		
		private void StartBrowser(string strURL)
		{
			System.Diagnostics.Process.Start(strURL);
			
		}
		
	}
}
