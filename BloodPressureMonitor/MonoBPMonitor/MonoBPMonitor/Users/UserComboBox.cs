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
		private Gtk.ListStore lsUser = new Gtk.ListStore(typeof(int), typeof(string));
		private int _UserID;
		private string _UserName;
		public UserComboBox()
		{
			
		}
		
		private void Build()
		{	
			LoadUsers();
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			this.PackStart(ct, true);
			this.AddAttribute(ct, "text", 1);
			this.Model = lsUser;
			Gtk.TreeIter iter;
			if(lsUser.GetIterFirst(out iter))
				this.SetActiveIter(iter);
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
				//lsUser.AppendValues(-1, "New User...");
				
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnRealized ()
		{
			Build();
			this.WidthRequest = 185;
			base.OnRealized ();
		}

		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnChanged ()
		{
			Gtk.TreeIter iter;
			this.GetActiveIter(out iter);
			_UserID = (int)lsUser.GetValue(iter, 0);
			_UserName =  (string)lsUser.GetValue(iter, 1);
			base.OnChanged ();
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
		
	}
}