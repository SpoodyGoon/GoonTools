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

namespace MonoBPMonitor.Reports
{
	/// <summary>
	/// Description of EntryTreeView.
	/// </summary>
	public partial class EntryRptTreeView : Gtk.TreeView
	{
		private int _SearchEntryID =  -1;
		public EntryRptTreeView()
		{
			Build();
		}
		
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
			set
			{
				_SearchEntryID = value;
				this.Model.Foreach(new TreeModelForeachFunc(ForeachEntryID));
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
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				DataTable dt = shp.ExecuteDataTable("SELECT EntryID, EntryDateTime, Systolic, Diastolic, HeartRate FROM tb_Entry WHERE UserID = " + _CurrentUser.ToString() + " ORDER BY EntryDateTime LIMIT " + Common.Option.HistoryDefaultShow.ToString() + " ;");
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
		
		#region Right Mouse Click Menu
		
		[GLib.ConnectBefore]
		private void EntryRptTreeView_ButtonPress (object o, Gtk.ButtonPressEventArgs args)
		{
			Gtk.TreeIter iter;
			Gtk.TreePath path;
			Gtk.TreeViewColumn tvc;
			// set the cursor to the row under the mouse
			if (this.GetPathAtPos ((int)Math.Round (args.Event.X, 0), (int)Math.Round (args.Event.Y, 0), out path, out tvc))
			{
				this.SetCursor (path, tvc, false);
				if ((int)args.Event.Button == 3 && this.Selection.GetSelected (out iter))
				{
					
					MonoBPMonitor.MainWindow mw = (MonoBPMonitor.MainWindow)this.Toplevel;
					Gtk.Menu popupMenu = new Menu ();
					popupMenu.BorderWidth = 5;
					popupMenu.AppPaintable = true;
					Gdk.Color clrDarkBlue = new Gdk.Color ();
					Gdk.Color.Parse ("#8FA8C0", ref clrDarkBlue);
					popupMenu.ModifyBg (Gtk.StateType.Normal, clrDarkBlue);
					Gdk.Color clrWhite = new Gdk.Color ();
					Gdk.Color.Parse ("#FFFFFF", ref clrWhite);
					popupMenu.ModifyText (Gtk.StateType.Normal, clrWhite);
					ImageMenuItem mmuAdd = new ImageMenuItem ("Add");
					Gtk.Image imgAdd = new Gtk.Image (Gdk.Pixbuf.LoadFromResource ("edit_add.png").ScaleSimple (16, 16, Gdk.InterpType.Nearest));
					mmuAdd.Image = imgAdd;
					popupMenu.Add (mmuAdd);
					mmuAdd.Activated += mw.OnBtnAddEntryClicked;
				
					ImageMenuItem mmuRemove = new ImageMenuItem ("Remove");
					Gtk.Image imgRemove = new Gtk.Image (Gdk.Pixbuf.LoadFromResource ("edit_remove.png").ScaleSimple (16, 16, Gdk.InterpType.Nearest));
					mmuRemove.Image = imgRemove;
					popupMenu.Add (mmuRemove);
					mmuRemove.Activated += mw.OnBtnRemoveEntryClicked;
				
					ImageMenuItem mmuEdit = new ImageMenuItem ("Edit");
					Gtk.Image imgEdit = new Gtk.Image (Gdk.Pixbuf.LoadFromResource ("edit.png").ScaleSimple (16, 16, Gdk.InterpType.Nearest));
					mmuEdit.Image = imgEdit;
					popupMenu.Add (mmuEdit);
					mmuEdit.Activated += mw.OnBtnEditEntryClicked;
				
				popupMenu.ShowAll ();
					popupMenu.Popup ();
				}
			}

		}
		
		#endregion Right Mouse Click Menu
		
		private bool ForeachEntryID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			MainBPReport e = (MainBPReport)_EntryRptListsStore.GetValue(iter, 0);
			if(_SearchEntryID == e.EntryID)
			{
				this.SetCursor(path, null, false);
				return true;
			}
			return false;
		}
	}
}
