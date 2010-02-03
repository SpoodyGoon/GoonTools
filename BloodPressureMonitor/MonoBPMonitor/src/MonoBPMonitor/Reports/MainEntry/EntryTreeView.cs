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

namespace MonoBPMonitor.Reports
{
	/// <summary>
	/// Description of EntryTreeView.
	/// </summary>
	public partial class EntryRptTreeView : Gtk.TreeView
	{
		public EntryRptTreeView(int userid)
		{
			_CurrentUser = userid;
			Build();
			LoadData();
			
		}
		
		#region public properties
		
		public MonoBPMonitor.Entry SelectedEntry
		{
			get
			{
				Gtk.TreeModel model;
				Gtk.TreeIter iter;
				if(this.Selection.GetSelected(out model, out iter))
				{
					MainBPReport tmp = (MainBPReport)model.GetValue(iter, 0);
					MonoBPMonitor.Entry tmpEntry = new MonoBPMonitor.Entry(tmp.EntryID);
					return tmpEntry;
				}
				else
				{
					return null;
				}
			}
		}
		
		public int SelectedEntryID
		{
			get
			{
				Gtk.TreeModel model;
				Gtk.TreeIter iter;
				if(this.Selection.GetSelected(out model, out iter))
				{
					MainBPReport tmp = (MainBPReport)model.GetValue(iter, 0);
					return tmp.EntryID;
				}
				else
				{
					return -1;
				}
			}
		}
		
		#endregion public properties
		
		#region private methods
		
		private void LoadData()
		{
			try
			{
				_CurrentHistoryLimit = Common.Option.HistoryDefaultShow;
				_EntryRptListsStore.Clear();
				int SumSystolic = 0;
				int SumDiastolic = 0;
				int SumHeartRate = 0;
				int RowCount = 1;
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT EntryID, EntryDateTime, Systolic, Diastolic, HeartRate FROM tb_Entry WHERE UserID = " + _CurrentUser.ToString() + " ORDER BY EntryDateTime LIMIT " + Common.Option.HistoryDefaultShow.ToString() + " ;");
				foreach(DataRow dr in dt.Rows)
				{
					SumSystolic += Convert.ToInt32(dr["Systolic"]);
					SumDiastolic += Convert.ToInt32(dr["Diastolic"]);
					SumHeartRate += Convert.ToInt32(dr["HeartRate"]);
					MainBPReport MnR = new MainBPReport(Convert.ToInt32(dr["EntryID"]),Convert.ToDateTime(dr["EntryDateTime"]), Convert.ToInt32(dr["Systolic"]), Convert.ToInt32(dr["Diastolic"]),Convert.ToInt32(dr["HeartRate"]),  SumSystolic, SumDiastolic, SumHeartRate, RowCount);
					_EntryRptListsStore.AppendValues(MnR);
					RowCount++;
				}
				this.ShowAll();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private void EntryRptTreeView_RowActivated(object sender, Gtk.RowActivatedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if(this.Selection.GetSelected(out iter))
				{
					MainBPReport mb = (MainBPReport)_EntryRptListsStore.GetValue(iter, 0);
					frmEntry fm  = new frmEntry(mb.EntryID);
					if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
					{
						LoadData();
					}
					fm.Destroy();
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		#endregion private methods
		
		#region public methods
		
		public void Refresh()
		{
			LoadData();
		}
		
		public void Refresh(int userid)
		{
			_CurrentUser = userid;
			LoadData();
		}
		
		public void Refresh(bool CheckOptionChange)
		{
			if(_CurrentHistoryLimit != Common.Option.HistoryDefaultShow)
				LoadData();
		}
		
		#endregion public methods
		
		#region Cell Render Functions
		
		private void RenderEntryID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			MainBPReport m = (MainBPReport)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.EntryID.ToString();
		}
		
		private void RenderEntryDate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			MainBPReport m = (MainBPReport)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.EntryDateTime.ToString();
		}
		
		private void RenderBPReading (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			MainBPReport m = (MainBPReport)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.Systolic.ToString() + "/" + m.Diastolic.ToString();
		}
		
		private void RenderHeartRate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			MainBPReport m = (MainBPReport)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.HeartRate.ToString();
		}
		
		private void RenderAvgBPReading (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			MainBPReport m = (MainBPReport)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.SystolicAvg.ToString() + "/" + m.DiastolicAvg.ToString();
		}
		
		private void RenderAvgHeartRate (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			MainBPReport m = (MainBPReport)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = m.HeartRateAvg.ToString();
		}
		
		#endregion Cell Render Functions
	}
}
