/*************************************************************************
*                      frmAbout.cs                                       
*                                                                        
* 		Copyright (C) Date: 4/25/2009 - Time: 9:06 PM
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

namespace GoonTools
{
	/// <summary>
	/// Description of ColumnSelectorTreeView.
	/// </summary>
	public partial class ColumnSelectorTreeView : Gtk.TreeView
	{
		public ColumnSelectorTreeView(Gtk.Window parent)
		{
			//this.Build();
			//_Parent = parent;
		}
		
		private void cellIsVisible_Toggled (object sender, ToggledArgs args)
		{
//			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got here before");
//				md.Run();
//				md.Destroy();
//			Gtk.TreeIter iter;
//			
//			if(_ColumnStore.GetIterFromString (out iter, args.Path))
//			{
//				bool blnIsChecked = Convert.ToBoolean(_ColumnStore.GetValue(iter, 1)) ? false:true;
//				Gtk.MessageDialog md2 = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got here " + blnIsChecked.ToString());
//				md2.Run();
//				md2.Destroy();
//				_CallingTreeView.Columns[Convert.ToInt16(_ColumnStore.GetValue(iter, 0))].Visible = blnIsChecked;
//				_ColumnStore.SetValue(iter, 1, blnIsChecked);
//			}
			
		}
		
		

		private void ColumnSelectorTreeView_CursorChanged(object sender, EventArgs e)
		{
//			Gtk.TreeIter iter;
//			if(this.Selection.GetSelected(out iter))
//			{
//				bool blnIsChecked = Convert.ToBoolean(_ColumnStore.GetValue(iter, 1)) ? false:true;
//				((MonoToDo.CustomWidgets.ColumnSelector)_Parent).ParentTree.Columns[Convert.ToInt16(_ColumnStore.GetValue(iter, 0))].Visible = blnIsChecked;
//				_ColumnStore.SetValue(iter, 1, blnIsChecked);
//			}
		}
	}
}
