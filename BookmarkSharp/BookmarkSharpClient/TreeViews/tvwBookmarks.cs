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
using System.Collections;
using Global;

namespace BookmarkSharpClient.TreeViews
{
	public enum Column
	{
		BookmarkID,
		Title,
		URL,
		IsFolder,
		ParentID,
		IsModified
	}
	/// <summary>
	/// Description of tvwBookmarks.
	/// </summary>
	public class tvwBookmarks : Gtk.TreeView
	{
		private Gtk.TreeStore _ts = new Gtk.TreeStore(
															typeof(string),
															typeof(string),
															typeof(string),
															typeof(string),
															typeof(string),
															typeof(string),
															typeof(bool)
														);
		private Hashtable hshParentIters = new Hashtable();
		public tvwBookmarks()
		{
			// Create a column for the File ID
			Gtk.TreeViewColumn colBookmarkID = new Gtk.TreeViewColumn ();
			colBookmarkID.Visible = false;
			colBookmarkID.Title = "BookmarkID";
			
			// Create a column for the File Name
			Gtk.TreeViewColumn colName = new Gtk.TreeViewColumn ();
			colName.Alignment = 0.0f;
			colName.Resizable = true;
			colName.MinWidth = 100;
			colName.Title = "Name";
			
			// Create a column for the File Desc
			Gtk.TreeViewColumn colURL = new Gtk.TreeViewColumn ();
			colURL.Alignment = 0.0f;
			colURL.Resizable = true;
			colURL.MinWidth = 150;
			colURL.Title = "URL";
			
			Gtk.TreeViewColumn colIsFolder = new Gtk.TreeViewColumn ();
			colIsFolder.Visible = false;
			colIsFolder.Title = "IsFolder";
			
			// Create a column for the File ID
			Gtk.TreeViewColumn colParentID = new Gtk.TreeViewColumn ();
			colParentID.Visible = false;
			colParentID.Title = "ParentID";
			
			// Add the columns to the TreeView
			this.AppendColumn(colBookmarkID);
			this.AppendColumn(colName);
			this.AppendColumn(colURL);
			this.AppendColumn(colIsFolder);
			this.AppendColumn(colParentID);
			
			// set up the columns
			Gtk.CellRendererText cellBookmarkID = new Gtk.CellRendererText ();
			cellBookmarkID.Visible = false;
			colBookmarkID.PackStart (cellBookmarkID, true);
			
			Gtk.CellRendererText cellName = new Gtk.CellRendererText ();
			cellName.Xalign = 0.0f;
			cellName.Width = 15;
			cellName.Editable = false;
			colName.PackStart (cellName, true);
			
			Gtk.CellRendererText cellURL = new Gtk.CellRendererText ();
			cellURL.Xalign = 0.0f;
			cellURL.Width = 15;
			cellURL.Editable = false;
			colURL.PackStart (cellURL, true);
			
			Gtk.CellRendererText cellIsFolder = new Gtk.CellRendererText ();
			cellIsFolder.Visible = false;
			colIsFolder.PackStart (cellIsFolder, true);
			
			Gtk.CellRendererText cellParentID = new Gtk.CellRendererText ();
			cellParentID.Visible = false;
			colParentID.PackStart (cellParentID, true);
			
			// Tell the Cell Renderers which items in the model to display
			colBookmarkID.AddAttribute (cellBookmarkID, "text", 0);
			colName.AddAttribute (cellName, "text", 1);
			colURL.AddAttribute (cellURL, "text", 2);
			colIsFolder.AddAttribute(cellIsFolder, "text", 3);
			colParentID.AddAttribute(cellParentID, "text", 4);
			this.Reorderable = true;
			//this._ts.RowChanged += delegate(object o, RowChangedArgs args) { System.Diagnostics.Debug.WriteLine(args.Path.ToString() + " Row changed"); };
			this.Model = tsBookmarks;
			LoadBookmarks();
		}
		
		public void LoadBookmarks()
		{
			try
			{
				_ts.Clear();
				Gtk.TreeIter iter;
				if(MainClass.dtBookmarks != null)
				{
					foreach(DataRow dr in MainClass.dtBookmarks.Rows)
					{ 
						if(dr["PathDepth"].ToString() == "0")
						{
							iter = _ts.AppendValues(dr["BookmarkID"].ToString(), dr["Title"].ToString(),dr["URL"].ToString(),dr["IsFolder"].ToString(),dr["ParentID"].ToString());
						}
						else
						{
							iter = _ts.AppendValues((Gtk.TreeIter)GetParentIter(dr["ParentID"].ToString()), dr["BookmarkID"].ToString(), dr["Title"].ToString(),dr["URL"].ToString(),dr["IsFolder"].ToString(),dr["ParentID"].ToString());
						}
						AddParentIter(dr["BookmarkID"].ToString(), iter);
					}
					hshParentIters.Clear();
				}
			}
			catch(Exception ex)
			{
				Common.LogError(ex.ToString());
			}
		}
		
		public Gtk.TreeStore tsBookmarks
		{
			get{ return _ts;}
			set{ _ts = value;}
		}
		
		private void AddParentIter(string strID, Gtk.TreeIter iter)
		{
			if(hshParentIters[strID] == null)
				hshParentIters.Add(strID, iter);
		}
		
		private Gtk.TreeIter GetParentIter(string strID)
		{
			if(hshParentIters[strID] != null)
				return (Gtk.TreeIter)hshParentIters[strID];
			else
				return Gtk.TreeIter.Zero;
		}
		
		public void SaveChanges()
		{
			_ts.Foreach(new TreeModelForeachFunc (ForeachBookmark));
		}
		
		private bool ForeachBookmark (TreeModel model, TreePath path, TreeIter iter)
		{
//			Gtk.TreeIter ParentIter;
//			DataRow dr = MainClass.dtBookmarks.Rows.Find( model.GetValue(iter, 0).ToString());
//			dr["Title"] = model.GetValue(iter, 1).ToString();
//			dr["URL"] = model.GetValue(iter,2).ToString();
//			dr["IsFolder"] = model.GetValue(iter,3).ToString();
//			if(path.Depth > 0)
//			{
//				model.IterParent(out ParentIter, iter);
//				dr["ParentID"] = model.GetValue(ParentIter,0);
//			}
//			dr["Path"] = path.ToString();
//			dr["PathDepth"] = path.Depth.ToString();
			return false;
		}
	}
}
