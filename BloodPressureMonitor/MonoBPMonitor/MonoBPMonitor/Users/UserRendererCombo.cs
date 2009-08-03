/*************************************************************************
 *                      UserRendererCombo.cs
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
	/// Description of UserRendererCombo.
	/// </summary>
	public class UserRendererCombo : Gtk.CellRendererCombo
	{
		private Gtk.ListStore lsUser = new Gtk.ListStore(typeof(int), typeof(string));
		private int _UserID;
		private string _UserName;
		private int _SearchUserID;
		private string _SearchUserName;
		public UserRendererCombo()
		{
			Build();
		}	
				
		private void Build()
		{	
			LoadUsers();
			this.Editable = true;
			this.TextColumn = 1;
			this.HasEntry = false;
			this.Model = lsUser;
			Gtk.TreeIter iter;
			
			if(lsUser.GetIterFirst(out iter))
				this.Text = lsUser.GetValue(iter, 1).ToString();
		}
		
		public void SetUser(string username)
		{
			_SearchUserName = username;
			lsUser.Foreach(new TreeModelForeachFunc(ForeachUserText));
		}
		
		
		public void SetUser(int userid)
		{
			_SearchUserID = userid;
			lsUser.Foreach(new TreeModelForeachFunc(ForeachUserID));
		}
		
		private bool ForeachUserText(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchUserName == lsUser.GetValue(iter, 1).ToString())
			{
				this.Text = _UserName = lsUser.GetValue(iter, 1).ToString();
				_UserID = Convert.ToInt32(lsUser.GetValue(iter, 0));
				return true;
			}
			return false;
		}
		
		private bool ForeachUserID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchUserID == Convert.ToInt32(lsUser.GetValue(iter, 0)))
			{
				this.Text = _UserName = lsUser.GetValue(iter, 1).ToString();
				_UserID = Convert.ToInt32(lsUser.GetValue(iter, 0));
				return true;
			}
			return false;
		}
		
		private void LoadUsers()
		{
			try
			{
				lsUser.Clear();
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT UserID, UserName FROM tb_User");
				foreach(DataRow dr in dt.Rows)
				{
					lsUser.AppendValues(Convert.ToInt32(dr["UserID"]), dr["UserName"].ToString());
				}
				lsUser.AppendValues(-1, "New User...");
				
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
			
		#region Public Properties
			
		public string UserName
		{
			get{return _UserName;}
			set{SetUser(value);}
		}
		
		public int UserID
		{
			get{return _UserID;}
			set{SetUser(value);}
		}
		
		#endregion Public Properties
	}
}
