/*************************************************************************
 *                      EntryTreeView.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */
 
using System;
using System.Data;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor.Entrys
{
	/// <summary>
	/// Description of EntryTreeView.
	/// </summary>
	public partial class EntryTreeView : Gtk.TreeView
	{
		public EntryTreeView()
		{
			Build();
			LoadData();
		}
		
		private void LoadData()
		{
			try
			{
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT EntryID, EntryDate, Systolic, Diastolic, HeartRate, Notes, UserID FROM tb_Entry");
				foreach(DataRow dr in dt.Rows)
				{
					Entry e = new Entry(Convert.ToInt32(dr["EntryID"]), Convert.ToDateTime(dr["EntryDate"].ToString()), Convert.ToInt32(dr["Systolic"]), Convert.ToInt32(dr["Diastolic"]), Convert.ToInt32(dr["HeartRate"]), dr["Notes"].ToString(), Convert.ToInt32(dr["UserID"]));
					_EntryListsStore.AppendValues(e);
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public Entry IterTaskList(TreeIter iter)
		{
			return _EntryListsStore.GetValue(iter, 0) as Entry;
		}
		
		private void RenderEntryID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.EntryID.ToString();
		}
		
		private void RenderEntryDate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.EntryDate.ToShortDateString();
		}
		
		private void RenderSystolic (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.Systolic.ToString();
		}
		
		private void RenderDiastolic (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.Diastolic.ToString();
		}
		
		private void RenderHeartRate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.HeartRate.ToString();
		}
		
		private void RenderNotes (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.Notes;
		}
		private void RenderUserID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Entry e = (Entry)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = e.UserID.ToString();
		}
	}
}
