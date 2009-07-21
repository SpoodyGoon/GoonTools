/*************************************************************************
 *                      DoctorTreeView.cs
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

namespace MonoBPMonitor.Doctors
{
	/// <summary>
	/// Description of DoctorTreeView.
	/// </summary>
	public partial class DoctorTreeView : Gtk.TreeView
	{
		public DoctorTreeView()
		{
			Build();
			LoadData();
		}
		
		private void LoadData()
		{
			try
			{
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT DoctorID, DoctorName, Location, PhoneNum, UserID FROM tb_Doctor");
				foreach(DataRow dr in dt.Rows)
				{
					Doctor d = new Doctor(Convert.ToInt32(dr["DoctorID"]), dr["DoctorName"].ToString(), dr["Location"].ToString(), dr["PhoneNum"].ToString(), Convert.ToInt32(dr["UserID"]));
					_DoctorListsStore.AppendValues(d);
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public Doctor IterTaskList(TreeIter iter)
		{
			return _DoctorListsStore.GetValue(iter, 0) as Doctor;
		}
		
		private void RenderDoctorID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = d.DoctorID.ToString();
		}
		
		private void RenderDoctorName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = d.DoctorName;
		}
		
		private void RenderLocation (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = d.Location;
		}
		
		private void RenderPhoneNum (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = d.PhoneNum;
		}
		private void RenderUserID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Doctor d = (Doctor)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = d.UserID.ToString();
		}
	}
}
