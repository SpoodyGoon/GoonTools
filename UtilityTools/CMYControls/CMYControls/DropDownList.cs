/*************************************************************************
 *                      DropDownList.cs
 *
 * 		Copyright (C) Date: 3/9/2010 - Time: 8:02 PM
 *		User: Andy - <goontools@brdstudio.net>
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

namespace CMYControls
{
	[System.ComponentModel.ToolboxItem(true)]
	public class DropDownList : Gtk.ComboBox
	{
		//public event EventHandler OnChanged = this.OnChanged;
		private Gtk.ListStore _GenericListStore = new Gtk.ListStore(typeof(string), typeof(string));
		private object _DataSource = null;
		private string _DataMember = string.Empty;
		private string _DataValueField = string.Empty;
		private string _DataTextField = string.Empty;
		private string _SearchText = string.Empty;
		private string _SearchValue = string.Empty;
		private string _CurrentText = string.Empty;
		private string _CurrentValue = string.Empty;
		private int _SelectedIndex = -1;
		private bool _IsLoading = false;
		public DropDownList()
		{
		}
		
		#region Public Properties
		
		public object DataSource
		{
			get { return _DataSource; }
			set { 
				if(_DataSource.GetType() == typeof(System.Data.DataTable) || _DataSource.GetType() == typeof(System.Data.DataSet)){ 
					_DataSource = value;
					return;
				}
				throw new ArgumentException("Invalid DataSource Type");
			}
		}
		
		public string DataMember
		{
			set{_DataMember=value;}
			get{return _DataMember;}
		}
		
		public string DataValueField
		{
			set{_DataValueField=value;}
			get{return _DataValueField;}
		}
		
		public string DataTextField
		{
			set{_DataTextField=value;}
			get{return _DataTextField;}
		}
		
		public int SelectedIndex
		{
			get{return _SelectedIndex;}
		}
		
		public string SelectedText
		{
			set{SetSelectedText(value);}
			get{return _CurrentText;}
		}
		
		public string SelectedValue
		{
			set{SetSelectedValue(value);}
			get{return _CurrentValue;}
		}
		
		public string Text
		{
			set{SetSelectedText(value);}
			get{return _CurrentText;}
		}
		
		public bool Enabled
		{
			set{this.Sensitive = value;}
			get{return this.Sensitive;}
		}
		
		#endregion Public Properties
		
		#region Control Events
		
		[GLib.ConnectBeforeAttribute()]
		protected override void OnChanged ()
		{
			try
			{
				if(!_IsLoading)
				{
					Gtk.TreeIter iter;
					this.GetActiveIter(out iter);
					_CurrentValue = _GenericListStore.GetValue(iter, 0).ToString();
					_CurrentText =  _GenericListStore.GetValue(iter, 1).ToString();
				}
				
				base.OnChanged ();
			}
			catch(Exception ex)
			{
				throw new SystemException(ex.Message);
			}
		}
		
		#endregion Control Events
		
		#region Private Methods
		
		private void PerformDataBind(System.Data.DataTable dt)
		{
			_GenericListStore.Clear();
			_IsLoading = true;
			for(int i = 0;i < dt.Rows.Count; i ++)
			{
				_GenericListStore.AppendValues(dt.Rows[i][_DataValueField].ToString(), dt.Rows[i][_DataTextField].ToString());
			}
			_IsLoading = false;
		}
		
		#endregion Private Methods
		
		#region Public Methods
		
		public void DataBind()
		{
			if(_DataSource == null)
				throw new ArgumentNullException("Missing DataSource during DataBinding", "Missing DataSouce");
			if(_DataSource.GetType() != typeof(System.Data.DataTable) || _DataSource.GetType() != typeof(System.Data.DataSet))
				throw new InvalidCastException("Invalid DataType for DataSource, must type DataType of System.Data.DataSet or System.Data.DataTable");
			
			if(_DataSource.GetType() == typeof(System.Data.DataSet))
			{
				System.Data.DataSet ds = (System.Data.DataSet)_DataSource;
				if(ds.Tables.Count == 0)
					throw new ArgumentNullException("Missing Binding Data during DataBinding", "Missing Data");
				
				if(_DataMember != string.Empty)
					PerformDataBind(ds.Tables[_DataMember]);
				else
					PerformDataBind(ds.Tables[0]); // if a data memeber is not specified then assume the first table
			}
			else if(_DataSource.GetType() == typeof(System.Data.DataTable))
			{
				PerformDataBind((System.Data.DataTable)_DataSource);
			}
			// we should not get here the exceptions should clean out any unexpected situations	
		}
		
		public void SetSelectedText(string selecttext)
		{
			try
			{
				_SearchText = selecttext;
				_GenericListStore.Foreach(new TreeModelForeachFunc(ForeachText));
			}
			catch(Exception ex)
			{
				throw new  SystemException(ex.Message);
			}
			
		}
		
		public void SetSelectedValue(string selectval)
		{
			try
			{
				_SearchValue = selectval;
				_GenericListStore.Foreach(new TreeModelForeachFunc(ForeachValue));
			}
			catch(Exception ex)
			{
				throw new SystemException(ex.Message);
			}
		}
		
		public void ClearAll()
		{
			_GenericListStore.Clear();
			this.QueueDraw();
		}
		
		public void RemoveSelection()
		{
			Gtk.TreeIter iter;
			if(this.GetActiveIter(out iter))
				_GenericListStore.Remove(ref iter);
		}
		
		#endregion Public Methods
		
		#region Setting Values
		
		private bool ForeachText(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchText == _GenericListStore.GetValue(iter, 1).ToString())
			{
				_CurrentText = _GenericListStore.GetValue(iter, 1).ToString();
				_CurrentValue = _GenericListStore.GetValue(iter, 0).ToString();
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
		
		private bool ForeachValue(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if(_SearchValue ==  _GenericListStore.GetValue(iter, 0).ToString())
			{
				_CurrentText = _GenericListStore.GetValue(iter, 1).ToString();
				_CurrentValue = _GenericListStore.GetValue(iter, 0).ToString();
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}
		
		#endregion Setting Values
	}
}
