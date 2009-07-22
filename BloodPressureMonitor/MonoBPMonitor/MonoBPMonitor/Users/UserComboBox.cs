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
using Gtk;
using GoonTools;

namespace MonoBPMonitor.Users
{
	
	
	public class UserComboBox : Gtk.ComboBox
	{		
		Gtk.ListStore lsUser = new Gtk.ListStore(typeof(int), typeof(string));
		public UserComboBox()
		{
			
			
		}
		
		private void Build()
		{
			
		}
		
//		private void LoadData()
//		{
//			try
//			{
//				lsUser.Clear();
//				DataProvider dp = new DataProvider(Common.Option.ConnString);
//				DataTable dt = dp.ExecuteDataTable("SELECT UserID, UserName FROM tb_User");
//				foreach(DataRow dr in dt.Rows)
//				{
//					lsUser.AppendValues(Convert.ToInt32(dr["UserID"]), dr["UserName"].ToString());
//				}
//			}
//			catch(Exception ex)
//			{
//				Common.EnvData.HandleError(ex);
//			}
//		}
	}
}
