/*************************************************************************
 *                      DoctorComboBox.cs
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
	[System.ComponentModel.ToolboxItem(true)]
	public class DoctorComboBox : Gtk.ComboBox
	{
		private Gtk.ListStore lsDoctor = new Gtk.ListStore(typeof(int), typeof(string));
		private int _DoctorID;
		private string _DoctorName;
		private int _SearchDoctorID;
		private string _SearchDoctorName;
		private bool _IsLoading = false;
		public DoctorComboBox()
		{
		}
		
		private void Build()
		{
			LoadDoctor();
			Gtk.CellRendererText ct = new Gtk.CellRendererText();
			this.PackStart(ct, true);
			this.AddAttribute(ct, "text", 1);
			this.Model = lsDoctor;
			Gtk.TreeIter iter;
			if(lsDoctor.GetIterFirst(out iter))
				this.SetActiveIter(iter);
		}
		
		private void LoadDoctor()
		{
			try
			{
				_IsLoading = true;
				lsDoctor.Clear();
				SQLiteHelper shp = new SQLiteHelper(Common.Option.DBLocation);
				DataTable dt = shp.ExecuteDataTable("SELECT DoctorID, DoctorName FROM tb_Doctor");
				foreach(DataRow dr in dt.Rows)
				{
					lsDoctor.AppendValues(Convert.ToInt32(dr["DoctorID"]), dr["DoctorName"].ToString());
				}
				lsDoctor.AppendValues(-1, "New User...");
				_IsLoading = false;
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
		}
		
		//[GLib.ConnectBeforeAttribute()]
		protected override void OnRealized ()
		{
			Build();
			this.WidthRequest = 185;
			base.OnRealized ();
		}

		
		//[GLib.ConnectBeforeAttribute()]
		protected override void OnChanged ()
		{try
			{
				if(!_IsLoading)
				{
					Gtk.TreeIter iter;
					this.GetActiveIter(out iter);
					if(Convert.ToInt32(lsDoctor.GetValue(iter, 0)) == -1)
					{
						MonoBPMonitor.QuickDoctor fm = new MonoBPMonitor.QuickDoctor();
						if((Gtk.ResponseType)fm.Run() == Gtk.ResponseType.Ok)
						{
							LoadDoctor();
							SetDoctor(fm.DoctorID);
						}
						else
						{
							// if we don't add a new user then set the
							// combo box back to the prevois selection
							SetDoctor(_DoctorID);
						}
						fm.Destroy();
					}
					else
					{						
						_DoctorID = (int)lsDoctor.GetValue(iter, 0);
						_DoctorName =  (string)lsDoctor.GetValue(iter, 1);
					}
				}
				
				base.OnChanged ();
			}
			catch(Exception ex)
			{
				Common.HandleError(ex);
			}
			base.OnChanged ();
		}

		
		#region Public Properties
		
		public string DoctorName
		{
			get{return _DoctorName;}
		}
		
		public int DoctorID
		{
			get{return _DoctorID;}
		}
		
		#endregion Public Properties
		
		#region Public Methods
		
		public void SetDoctor(string doctorname)
		{
			_SearchDoctorName = doctorname;
			lsDoctor.Foreach(new TreeModelForeachFunc(ForeachDoctorText));
			
		}
		
		public void SetDoctor(int doctorid)
		{
			_SearchDoctorID = doctorid;
			lsDoctor.Foreach(new TreeModelForeachFunc(ForeachDoctorID));
		}
		
		#endregion Public Methods
		
		private bool ForeachDoctorText(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchDoctorName == lsDoctor.GetValue(iter, 1).ToString())
			{
				_DoctorName = lsDoctor.GetValue(iter, 1).ToString();
				_DoctorID = Convert.ToInt32(lsDoctor.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
		
		private bool ForeachDoctorID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchDoctorID == Convert.ToInt32(lsDoctor.GetValue(iter, 0)))
			{
				_DoctorName = lsDoctor.GetValue(iter, 1).ToString();
				_DoctorID = Convert.ToInt32(lsDoctor.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
	}
}
