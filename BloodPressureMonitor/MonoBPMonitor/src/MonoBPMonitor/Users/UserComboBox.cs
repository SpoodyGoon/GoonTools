/*************************************************************************
 *                      UserComboBox.cs
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
	[System.ComponentModel.ToolboxItem(true)]
	public class UserComboBox : Gtk.ComboBox
	{
		//public event EventHandler OnChanged = this.OnChanged;
		private Gtk.ListStore lsUser = new Gtk.ListStore(typeof(int), typeof(string));
		private int _UserID;
		private string _UserName;
		private int _SearchUserID;
		private string _SearchUserName;
		private bool _IsLoading = false;
		public UserComboBox()
		{
			Build();
			SetUser(LastUserGet());
		}
		
		public UserComboBox(int userid)
		{
			Build();
			SetUser(userid);
		}
		
		public UserComboBox(bool LoadLastUser)
		{
			Build();
			SetUser(LastUserGet());
		}
		
		private void Build()
		{
			try
			{
				Gtk.CellRendererText ct = new Gtk.CellRendererText();
				this.PackStart(ct, true);
				this.AddAttribute(ct, "text", 1);
				this.Model = lsUser;
				
				LoadUsers();
				
				Gtk.TreeIter iter;
				if(lsUser.GetIterFirst(out iter))
					this.SetActiveIter(iter);
				
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private void LoadUsers()
		{
			try
			{
				_IsLoading = true;
				lsUser.Clear();
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT UserID, UserName FROM tb_User");
				foreach(DataRow dr in dt.Rows)
				{
					lsUser.AppendValues(Convert.ToInt32(dr["UserID"]), dr["UserName"].ToString());
				}
				lsUser.AppendValues(-1, "New User...");
				_IsLoading = false;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		private int LastUserGet()
		{
			int intReturn = -1;
			try
			{
				// use the person how last had an entry if there is an entry
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				System.Collections.ArrayList ar = dp.ExecuteArrayListRow("SELECT UserID FROM tb_Entry ORDER BY DATETIME(EntryDateTime, 'localtime') DESC LIMIT 1;");
				if(ar.Count > 0)
				{
					intReturn = Convert.ToInt32(ar[0]);
				}
				else
				{
					// use the last person who was added as a user
					System.Collections.ArrayList ar2 = dp.ExecuteArrayListRow("SELECT UserID FROM tb_User WHERE UserName NOT LIKE 'Default' ORDER BY DateAdded DESC LIMIT 1; ");
					if(ar2.Count > 0)
					{
						intReturn = Convert.ToInt32(ar2[0]);
					}
					else
					{
						// no non-default users ask for a name
						QuickUser qu = new QuickUser();
						if(qu.Run() == (int)Gtk.ResponseType.Ok)
						{
							intReturn = qu.UserID;
							LoadUsers();
						}
						qu.Destroy();
					}
					
				}
				dp.Dispose();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			return intReturn;
		}
		
		
//		[GLib.ConnectBeforeAttribute()]
//		protected override void OnRealized ()
//		{
//			Build();
//			int i = this.WidthRequest;
//			this.WidthRequest = 185;
//			base.OnRealized ();
//		}

		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnChanged ()
		{
			try
			{
				if(!_IsLoading)
				{
					Gtk.TreeIter iter;
					this.GetActiveIter(out iter);
					if(Convert.ToInt32(lsUser.GetValue(iter, 0)) == -1)
					{
						MonoBPMonitor.QuickUser fm = new MonoBPMonitor.QuickUser();
						if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
						{
							LoadUsers();
							SetUser(fm.UserID);
						}
						else
						{
							// if we don't add a new user then set the
							// combo box back to the prevois selection
							SetUser(_UserID);
						}
						fm.Destroy();
					}
					else
					{
						_UserID = (int)lsUser.GetValue(iter, 0);
						_UserName =  (string)lsUser.GetValue(iter, 1);
					}
				}
				
				base.OnChanged ();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}

		
		#region Public Properties
		
		public string UserName
		{
			get{return _UserName;}
		}
		
		public int UserID
		{
			get{return _UserID;}
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
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
		
		#endregion Public Methods
		
		private bool ForeachUserText(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchUserName == lsUser.GetValue(iter, 1).ToString())
			{
				_UserName = lsUser.GetValue(iter, 1).ToString();
				_UserID = Convert.ToInt32(lsUser.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
		
		private bool ForeachUserID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchUserID == Convert.ToInt32(lsUser.GetValue(iter, 0)))
			{
				_UserName = lsUser.GetValue(iter, 1).ToString();
				_UserID = Convert.ToInt32(lsUser.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
	}
}
