/*************************************************************************
 *                      UserTreeView.cs
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

namespace MonoBPMonitor.Users
{
	/// <summary>
	/// Description of UserTreeView.
	/// </summary>
	public partial class UserTreeView : Gtk.TreeView
	{
		public UserTreeView()
		{
			Build();
			LoadData();
		}
		
		private void LoadData()
		{
			try
			{
				_UserListsStore.Clear();
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT UserID, UserName, DateAdded, IsActive FROM tb_User");
				foreach(DataRow dr in dt.Rows)
				{
					User u = new User(Convert.ToInt32(dr["UserID"]), dr["UserName"].ToString(), DateTime.Parse(dr["DateAdded"].ToString()), Convert.ToBoolean(dr["IsActive"]));
					_UserListsStore.AppendValues(u);
				}
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		public void Refresh()
		{
			LoadData();
		}
		
		public User SelectedUser(TreeIter iter)
		{
			return _UserListsStore.GetValue(iter, 0) as User;
		}
		
		#region TreeView Cell Events
		
		private void cellUserName_Edited(object o, Gtk.EditedArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_UserListsStore.GetIterFromString (out iter, args.Path))
				{
					User u = (User)_UserListsStore.GetValue(iter, 0);
					u.UserName = args.NewText;
					u.Update();
				}
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void cellIsActive_Toggled (object o, ToggledArgs args)
		{
			try
			{
				Gtk.TreeIter iter;
				if (_UserListsStore.GetIterFromString (out iter, args.Path))
				{
					User u = (User)_UserListsStore.GetValue(iter, 0);
					u.IsActive = u.IsActive ?  false:true;
					u.Update();
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
		
		#region Cell Render Functions
		
		private void RenderUserID (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			User u = (User)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = u.UserID.ToString();
		}
		
		private void RenderUserName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			User u = (User)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = u.UserName;
		}
		
		private void RenderDateAdded (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			User u = (User)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = u.DateAdded.ToShortDateString();
		}
		
		private void RenderIsActive (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			User u = (User)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererToggle).Active = u.IsActive;
		}
		
		#endregion  Cell Render Functions
		
	}
}
