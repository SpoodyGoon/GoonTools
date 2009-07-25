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
		
		private void LoadData()
		{
			try
			{
				int SumSystolic = 0;
				int SumDiastolic = 0;
				int SumHeartRate = 0;
				int RowCount = 1;
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT EntryID, EntryDate, Systolic, Diastolic, HeartRate FROM tb_Entry WHERE UserID = " + _CurrentUser.ToString() + ";");
				foreach(DataRow dr in dt.Rows)
				{
					SumSystolic += Convert.ToInt32(dr["Systolic"]);
					SumDiastolic += Convert.ToInt32(dr["Diastolic"]);
					SumHeartRate += Convert.ToInt32(dr["HeartRate"]);
					_EntryRptListsStore.AppendValues(
					                                 Convert.ToInt32(dr["EntryID"]), 
					                                 Convert.ToDateTime(dr["EntryDate"].ToString()).ToShortDateString(), 
					                                 dr["Systolic"].ToString() + "/" + dr["Diastolic"].ToString(), 
					                                 dr["HeartRate"].ToString(), 
					                                 (Math.Round((double)SumSystolic/RowCount, 0)).ToString() + "/" + (Math.Round((double)SumDiastolic/RowCount, 0)).ToString(), 
					                                 (Math.Round((double)SumHeartRate/RowCount, 0)).ToString()
					                                 );
					RowCount++;
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
	}
}
