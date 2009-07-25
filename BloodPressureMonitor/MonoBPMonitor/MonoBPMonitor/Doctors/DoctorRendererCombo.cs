/*************************************************************************
 *                      DoctorRendererCombo.cs
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
	
	public class DoctorRendererCombo : Gtk.CellRendererCombo
	{
		
		private Gtk.ListStore lsDoctor = new Gtk.ListStore(typeof(int), typeof(string));
		private int _DoctorID;
		private string _DoctorName;
		private int _SearchDoctorID;
		private string _SearchDoctorName;
		public DoctorRendererCombo()
		{
			Build();
		}	
				
		private void Build()
		{	
			LoadDoctors();
			this.Editable = true;
			this.TextColumn = 1;
			this.HasEntry = false;
			this.Model = lsDoctor;
			Gtk.TreeIter iter;
			
			if(lsDoctor.GetIterFirst(out iter))
				this.Text = lsDoctor.GetValue(iter, 1).ToString();
		}
		
		public void SetText(string strSetText)
		{
			_SearchDoctorName = strSetText;
			lsDoctor.Foreach(new TreeModelForeachFunc(ForeachUserText));
		}
		
		
		public void SetTextByID(int intSetText)
		{
			_SearchDoctorID = intSetText;
			lsDoctor.Foreach(new TreeModelForeachFunc(ForeachDoctorID));
		}
		
		private bool ForeachUserText(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchDoctorName == lsDoctor.GetValue(iter, 1).ToString())
			{
				this.Text = _DoctorName = lsDoctor.GetValue(iter, 1).ToString();
				_DoctorID = Convert.ToInt32(lsDoctor.GetValue(iter, 0));
				return true;
			}
			return false;
		}
		
		private bool ForeachDoctorID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchDoctorID == Convert.ToInt32(lsDoctor.GetValue(iter, 0)))
			{
				this.Text = _DoctorName = lsDoctor.GetValue(iter, 1).ToString();
				_DoctorID = Convert.ToInt32(lsDoctor.GetValue(iter, 0));
				return true;
			}
			return false;
		}
		
		private void LoadDoctors()
		{
			try
			{
				lsDoctor.Clear();
				DataProvider dp = new DataProvider(Common.Option.ConnString);
				DataTable dt = dp.ExecuteDataTable("SELECT DoctorID, DoctorName FROM tb_Doctor");
				foreach(DataRow dr in dt.Rows)
				{
					lsDoctor.AppendValues(Convert.ToInt32(dr["DoctorID"]), dr["DoctorName"].ToString());
				}
				//lsDoctor.AppendValues(-1, "New User...");
				
			}
			catch(Exception ex)
			{
				Common.EnvData.HandleError(ex);
			}
		}
			
		#region Public Properties
			
		public string DoctorName
		{
			get{return _DoctorName;}
			set{SetText(value);}
		}
		
		public int DoctorID
		{
			get{return _DoctorID;}
			set{SetTextByID(value);}
		}
		
		#endregion Public Properties
	}
}
