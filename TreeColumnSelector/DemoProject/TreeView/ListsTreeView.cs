/*************************************************************************
 *                      ListTreeView.cs
 *
 *	 	Copyright (C) 2009
 *		Andrew York <MonoToDo@brdstudio.net>
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

namespace TaskList
{
	
	
	internal partial class ListsTreeView : Gtk.TreeView
	{
		internal ListsTreeView(Gtk.Window parent)
		{
			_Parent = parent;
			Build();
			ls.AppendValues(1, "Develop a Mono application for the XO laptop", "21 Apr 2009", true);
			ls.AppendValues(2, "Custom controls with MonoDevelop and GTK#", "18 May 2008", true);
			ls.AppendValues(3, "A google search application using Gtk#", "14 Jan 2005", false);
			ls.AppendValues(4, "Todolist for Linux", "26 Jan 2008", true);
			ls.AppendValues(5, "Using MySQL from C# and Mono.NET", "3 Jul 2005", false);
		}
		
		#region Public Properties
		
		internal string FilterText
		{
			set
			{
				_FilterText = value;
				filter.Refilter();
			}
		}
		
		internal bool ShowOnlyActive
		{
			set
			{
				_ShowOnlyActive = value;
				filter.Refilter();
			}
		}
		
		internal bool FilterActive
		{
			set
			{
				_FilterActive = value;
				filter.Refilter();
			}
		}
		
		internal Gtk.Window TreeParent
		{
			get{return _Parent;}
		}
		
		#endregion Public Properties
		
		#region Public Members
		
		public void ToggleColumn(int colIndex, bool IsVis)
		{
			this.Columns[colIndex].Visible = IsVis;	
		}
		
		#endregion Public Members
		
		#region TreeView Sorting
		
		private void Column_Clicked (object sender, EventArgs args)
		{
			Gtk.TreeViewColumn col = (Gtk.TreeViewColumn)sender;
			// the column that manages visiblity does not contain a title
			// so look for the title to make sure we have a data column
			if(col.Title.Length > 0)
			{
				col.SortOrder = SetSortOrder(col);
				col.SortIndicator = true;
				((Gtk.ListStore)filter.ChildModel).SetSortColumnId(GetColumnIndex(col), col.SortOrder);
			}
			else
			{
				ShowColumnSelector();
			}
		}
		
		public SortType SetSortOrder (TreeViewColumn col)
		{
			if (col.SortIndicator)
			{
				if (col.SortOrder == SortType.Ascending)
					return SortType.Descending;
				else return SortType.Ascending;
			}
			else return SortType.Ascending;
		}
		
		private int GetColumnIndex(Gtk.TreeViewColumn col)
		{
			// TODO: modify this to work with the layout manager
			switch(col.Title)
			{
				case "ID":
					return 0;
				case "List Name":
					return 1;
				case "Date":
					return 2;
				case "Active":
					return 3;
				default:
					throw new Exception("Invalid Column Title During Sort");
			}
		}
		
		#endregion TreeView Sorting
		
		#region TreeView Filter
		
		private void cellIsActive_Toggled (object o, ToggledArgs args)
		{
			try
			{
//				Gtk.TreeIter iter;
//				DataProvider dp = new DataProvider(Common.Option.ConnString);
//				if (this.filter.Model.GetIterFromString (out iter, args.Path))
//				{
//					bool blnActive = Convert.ToBoolean((bool)this.filter.Model.GetValue (iter, (int)ListColumns.IsActive) ? false:true);
//					dp.ExecuteNonQuery("UPDATE tb_Lists SET IsActive = '" + blnActive.ToString() + "' WHERE ListID = " + this.filter.Model.GetValue (iter, (int)ListColumns.ListID).ToString() + ";");
//					filter.Model.SetValue(iter, (int)ListColumns.IsActive, Convert.ToBoolean(blnActive));
//					filter.Refilter();
//				}
//				dp.Dispose();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void cellListName_Edited(object o, Gtk.EditedArgs args)
		{
//			try
//			{
//				Gtk.TreeIter iter;
//				DataProvider dp = new DataProvider(Common.Option.ConnString);
//				if (filter.Model.GetIterFromString (out iter, args.Path))
//				{
//					dp.ExecuteNonQuery("UPDATE tb_Lists SET ListName = '" + args.NewText + "' WHERE ListID = " + filter.Model.GetValue (iter, 0).ToString() + ";");
//					filter.Model.SetValue(iter, 1, args.NewText);
//				}
//				dp.Dispose();
//				filter.Refilter();
//			}
//			catch(Exception doh)
//			{
//				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
//				md.Run();
//				md.Destroy();
//			}
		}
		
		protected virtual bool filter_VisibleFunc (Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			if(!_FilterActive)
				return true;
			if(_FilterText.Length > 0 && !filter.Model.GetValue (iter, 1).ToString().ToLower().StartsWith(_FilterText.ToLower()))
				return false;
			if (_ShowOnlyActive == true &&  Convert.ToBoolean(filter.Model.GetValue (iter, 3).ToString().ToLower()) == false)
				return false;
			
			return true;
		}
		
		#endregion  TreeView Filter
		
		private void ShowColumnSelector()
		{
//			int x, y, width = 150, height = 200;
//			this.ParentWindow.GetPosition( out x, out y );	
//			x += this.Allocation.Right;
//			y += this.Allocation.Top + 20; // plus the header hight
//			if(width > this.Allocation.Right - this.Allocation.Left)
//				width = this.Allocation.Right - this.Allocation.Left - 5; // 5 is just a padding buffer
//			if(height > this.Allocation.Bottom - this.Allocation.Top - 30)
//				height = this.Allocation.Bottom - this.Allocation.Top - 30;// 35 is the header heigh plus just a padding buffer
//			
//			CustomWidgets.ColumnSelector cs = new CustomWidgets.ColumnSelector(this, x, y, width, height);
//			for(int i = 0; i < this.Columns.Length; i++)
//			{
//				if(this.Columns[i].Title != "")
//					cs.AddColumn(i, this.Columns[i].Visible, this.Columns[i].Title);	
//			}
//			cs.ShowPopUp();
		}
	}
}
