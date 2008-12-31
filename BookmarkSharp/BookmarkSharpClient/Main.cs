// Main.cs created with MonoDevelop
// User: spoodygoon at 9:17 PM 7/29/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;
using System.Data;
using www.brdstudio.net_BookmarkSharp;
using BookmarkSharpClient.DataSets;
using System.Collections;
using Global;
using Gtk;

namespace BookmarkSharpClient
{
	class MainClass
	{
		// The tray Icon
		private static Gtk.StatusIcon trayIcon;
		private static DataSet dsBookmarks = null;
		private static dsTags dsTags = new dsTags();
		
		public static void Main (string[] args)
		{
			Application.Init ();
			// load the options
			Options.Load();
			if(Options.GetOption("Password") == string.Empty)
			{
				frmOptions fm = new frmOptions();
				fm.Run();
				fm.Dispose();
			}
			
			// load the tags
			dsTags.LoadTags();
			
			// Creation of the Icon
			trayIcon = new StatusIcon(Gdk.Pixbuf.LoadFromResource("SearchWebHS.png"));
			trayIcon.Visible = true;
			
			// Show/Hide the window (even from the Panel/Taskbar) when the TrayIcon has been clicked.
			//trayIcon.Activate += delegate { this.Visible = !this.Visible; };
			// Show a pop up menu when the icon has been right clicked.
			trayIcon.PopupMenu += OnTrayIconPopup;
			// A Tooltip for the Icon
			trayIcon.Tooltip = "Bookmark Sharp";
			
			BookmarkSharp bs = new BookmarkSharp();
			bs.Login(Options.GetOption("Password"));
			DataSet ds = bs.LastUpdateGet();
			if(Options.GetOption("BookmarkUpdate") != string.Empty)
			{
				if(DateTime.Parse(Options.GetOption("BookmarkUpdate")) < DateTime.Parse(ds.Tables[0].Rows[0]["BookmarkUpdate"].ToString()))
				{
					GetBookmarksFromWeb();
				}
				else
				{
					ds.ReadXml(Common.GetWorkingFolder() + "dsBookmarks.xml");
				}
			}
			else
			{
				GetBookmarksFromWeb();
			}
			if(Options.GetOption("TagUpdate") != string.Empty)
			{
				if(DateTime.Parse(Options.GetOption("TagUpdate")) < DateTime.Parse(ds.Tables[0].Rows[0]["TagUpdate"].ToString()))
				{
					GetTagsFromWeb();
				}
				else
				{
					ds.ReadXml(Common.GetWorkingFolder() + "dsTags.xml");
				}
			}
			else
			{
				GetTagsFromWeb();
			}
			Application.Run ();
			
		}
		
		// Create the popup menu, on right click.
		private static void OnTrayIconPopup (object o, EventArgs args)
		{
			Gtk.Menu popupMenu = new BookmarkSharpClient.Menus.ctxTaskBarMenu();
			popupMenu.ShowAll();
			popupMenu.Popup();
		}
		
		public static DataTable dtBookmarks
		{
			get{ return (DataTable)dsBookmarks.Tables["dtBookmarks"];}
		}
		
		public static DataTable dtTags
		{
			get{ return (DataTable)dsTags.Tables["dtTags"];}
		}
		
		public static void GetBookmarksFromWeb()
		{
			if(Options.GetOption("Password") != string.Empty)
			{
				if(dsBookmarks != null)
					dsBookmarks.Clear();
				BookmarkSharp bs = new BookmarkSharp();
				bs.Login(Options.GetOption("Password"));
				dsBookmarks = bs.GetBookMarks();
				dsBookmarks.WriteXml(Common.GetWorkingFolder() + "dsBookmarks.xml");
				Options.SetOption("BookmarkUpdate", DateTime.Now.ToString());
			}
		}
		
		public static void GetTagsFromWeb()
		{
			if(Options.GetOption("Password") != string.Empty)
			{
				
				BookmarkSharp bs = new BookmarkSharp();
				bs.Login(Options.GetOption("Password"));
				DataSet ds = bs.GetTags();
				if(ds.Tables.Count > 0)
				{
					dsTags.UpdateTags(ds.Tables[0]);
				}
				Options.SetOption("TagUpdate", DateTime.Now.ToString());
			}
		}
		
	}
}
