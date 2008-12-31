// frmBookmarkList.cs created with MonoDevelop
// User: spoodygoon at 1:28 PM 8/16/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.IO;
using System.Data;
using www.brdstudio.net_BookmarkSharp;
using System.Collections;
using Gtk;
using BookmarkSharpClient.TreeViews;

namespace BookmarkSharpClient
{
	
	
	public partial class frmBookmarkList : Gtk.Dialog
	{
		private tvwBookmarks tvw = new tvwBookmarks();		
		public frmBookmarkList()
		{
			try
			{
				this.Build ();
				this.WindowStateEvent += delegate(object o, WindowStateEventArgs args) {  if((args.Event.NewWindowState & Gdk.WindowState.Iconified) == 0){ this.Visible = true; }else{this.Visible = false;}; };
				swBookmarkSharp.Add((Gtk.TreeView)tvw);
				swBookmarkSharp.ShowAll();
			}
			catch(Exception ex)
			{
				MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error,  ButtonsType.Ok, ex.ToString(), "ERROR!");
				md.Run();
				md.Destroy();
			}
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

		protected virtual void OnAddActionActivated (object sender, System.EventArgs e)
		{
			BookmarkSharpClient.frmAddNew fm = new frmAddNew();
			ResponseType result = (ResponseType)fm.Run ();
			if(result == ResponseType.Ok)
			{
				tvw.tsBookmarks.AppendValues("",fm.strTitle, fm.strURL);
			}
			
			fm.Destroy();
		}

		protected virtual void OnJumpToActionActivated (object sender, System.EventArgs e)
		{
			ParseGoogleHtml();
		}
		
		protected virtual void OnPreferencesActionActivated (object sender, System.EventArgs e)
		{
			frmOptions fm = new frmOptions();
			fm.Run();
			fm.Destroy();
		}

		protected virtual void OnFloppyActionActivated (object sender, System.EventArgs e)
		{
			Gtk.FileChooserDialog fc = new FileChooserDialog("Save", this, Gtk.FileChooserAction.Save ,Stock.Cancel, ResponseType.Cancel, Stock.Save, ResponseType.Ok);
			Gtk.ResponseType resp = (Gtk.ResponseType)fc.Run();
			if(resp == ResponseType.Ok)
			{
				//MainClass.dsBookmarks.WriteXml(fc.Filename);
			}
			fc.Destroy();
		}

		protected virtual void OnRemoveActionActivated (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			if(tvw.Selection.GetSelected(out iter))
			{
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Question,  ButtonsType.YesNo, "Are you sure you want to delete" + tvw.tsBookmarks.GetValue(iter, 1).ToString() + "?", "DELETE?");
				ResponseType result = (ResponseType)md.Run ();
				if (result == ResponseType.Yes)
				{
					tvw.tsBookmarks.Remove(ref iter);
				}
				md.Destroy();
			}
		}
		
		
		private void ParseGoogleHtml()
		{
			try
			{
				DataTable dtTemp = null;
				Gtk.TreeIter iter = TreeIter.Zero;
				Gtk.FileChooserDialog fc = new FileChooserDialog("Google Bookmark HTML", this, Gtk.FileChooserAction.Open ,Stock.Cancel, ResponseType.Cancel, Stock.Open, ResponseType.Ok);
				Gtk.ResponseType resp = (Gtk.ResponseType)fc.Run();
				if(resp == ResponseType.Ok)
				{
					// use the ClsMozilla classe to put the bookmarks into a datatable
					dtTemp = ImportMozilla.clsMozilla.ReadBookmark(fc.Filename);
				}
				fc.Destroy();
				dtTemp.TableName = "dtBookmark";
				BookmarkSharp bs = new BookmarkSharp();
				if(bs.ImportDataTable(dtTemp)== true)
				{
					MainClass.GetBookmarksFromWeb();
					this.tvw.LoadBookmarks();
				}
				
			}
			catch(Exception ex)
			{
				MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error,  ButtonsType.Ok, ex.ToString(), "ERROR!");
				md.Run();
				md.Destroy();
			}
			
		}

		
	}
}
