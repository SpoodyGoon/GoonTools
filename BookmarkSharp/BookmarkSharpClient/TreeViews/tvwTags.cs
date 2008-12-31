/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 8/8/2008
 * Time: 11:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Gtk;
using Global;

namespace BookmarkSharpClient.TreeViews
{
	/// <summary>
	/// Description of tvwTags.
	/// </summary>
	public class tvwTags : Gtk.TreeView
	{
		public tvwTags()
		{
			// Create a column for the File ID
			Gtk.TreeViewColumn colFileID = new Gtk.TreeViewColumn ();
			colFileID.Visible = false;
			colFileID.Title = "ID";
			
			// Create a column for the File Desc
			Gtk.TreeViewColumn colUseTag = new Gtk.TreeViewColumn ();
			colUseTag.Alignment = 0.5f;
			colUseTag.Resizable = true;
			colUseTag.MinWidth = 20;
			colUseTag.Title = "Use";
			
			// Create a column for the Tag Name
			Gtk.TreeViewColumn colTag = new Gtk.TreeViewColumn ();
			colTag.Alignment = 0.0f;
			colTag.Resizable = true;
			colTag.MinWidth = 100;
			colTag.Title = "Tag";
			
			// Add the columns to the TreeView
			this.AppendColumn(colFileID);
			this.AppendColumn(colUseTag);
			this.AppendColumn (colTag);
			
			// set up the columns
			Gtk.CellRendererText cellFileID = new Gtk.CellRendererText ();
			cellFileID.Xalign = 0.5f;
			cellFileID.Width = 15;
			colFileID.PackStart (cellFileID, true);
			
			Gtk.CellRendererToggle cellUseTag = new Gtk.CellRendererToggle ();
			cellUseTag.Xalign = 0.5f;
			cellUseTag.Width = 15;
			colUseTag.PackStart (cellUseTag, true);
			
			Gtk.CellRendererText cellTag = new Gtk.CellRendererText ();
			cellTag.Xalign = 0.0f;
			cellTag.Width = 15;
			cellTag.Editable = false;
			colTag.PackStart (cellTag, true);
			
			// Tell the Cell Renderers which item(frmMain)s in the model to display
			colFileID.AddAttribute (cellFileID, "text", 0);
			colUseTag.AddAttribute (cellUseTag, "active", 1);
			colTag.AddAttribute (cellTag, "text", 2);
			this.Model = lsTags();
		}
		
		private Gtk.ListStore lsTags()
		{
			Gtk.ListStore ls = new ListStore(typeof(string), typeof(bool), typeof(string));
			try
			{
				DataSets.dsTags ds = new DataSets.dsTags();
				ds.LoadTags();
				if(ds.Tables["dtTags"] != null)
				{
					foreach(DataRow dr in ds.Tables["dtTags"].Rows)
					{
						ls.AppendValues(dr["TagID"].ToString(), Convert.ToBoolean(dr["Use"].ToString()), dr["TagName"].ToString());
					}
				}
			}
			catch(Exception ex)
			{
				MessageDialog md = new MessageDialog(null, DialogFlags.DestroyWithParent, MessageType.Error,  ButtonsType.Ok, ex.ToString(), "ERROR!");
				md.Run();
				md.Destroy();
			}
			return ls;
			
		}
	}
}