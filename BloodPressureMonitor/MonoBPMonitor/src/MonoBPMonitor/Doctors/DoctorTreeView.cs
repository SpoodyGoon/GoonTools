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
using SQLiteDataHelper;

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
				_DoctorListsStore.Clear();
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				DataTable dt = shp.ExecuteDataTable("SELECT DoctorID, DoctorName, Location, PhoneNum, UserID FROM tb_Doctor");
				foreach(DataRow dr in dt.Rows)
				{
					Doctor d = new Doctor(Convert.ToInt32(dr["DoctorID"]), dr["DoctorName"].ToString(), dr["Location"].ToString(), dr["PhoneNum"].ToString(), Convert.ToInt32(dr["UserID"]));
					_DoctorListsStore.AppendValues(d);
				}
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		public void Refresh()
		{
			this.LoadData();
		}
		
		public Doctor SelectedDoctor(TreeIter iter)
		{
			return _DoctorListsStore.GetValue(iter, 0) as Doctor;
		}
		
		#region TreeView Cell Events
		
		private void cellDoctorName_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_DoctorListsStore.GetIterFromString (out iter, args.Path))
				{
					Doctor d = (Doctor)_DoctorListsStore.GetValue(iter, 0);
					d.DoctorName = args.NewText;
					d.Update();
				}
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void cellLocation_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_DoctorListsStore.GetIterFromString (out iter, args.Path))
				{
					Doctor d = (Doctor)_DoctorListsStore.GetValue(iter, 0);
					d.Location = args.NewText;
					d.Update();
				}
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void cellPhoneNum_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_DoctorListsStore.GetIterFromString (out iter, args.Path))
				{
					Doctor d = (Doctor)_DoctorListsStore.GetValue(iter, 0);
					d.PhoneNum = args.NewText;
					d.Update();
				}
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}

		private void cellUserID_Edited(object sender, EditedArgs args)
		{
			try
			{
				Users.UserRendererCombo urc = (Users.UserRendererCombo)sender;
				Gtk.TreeIter iter;
				if (_DoctorListsStore.GetIterFromString (out iter, args.Path))
				{
					Doctor d = (Doctor)_DoctorListsStore.GetValue(iter, 0);
					urc.SetUser(args.NewText);
					d.UserID = urc.UserID;
					d.Update();
				}
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		#endregion TreeView Cell Events
		
		#region Cell Data Functions
		
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
			(cell as Users.UserRendererCombo).SetUser(d.UserID);
		}
		
		#endregion Cell Data Functions
	}
}
