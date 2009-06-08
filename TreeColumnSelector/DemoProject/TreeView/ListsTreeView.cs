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
	
	public partial class ListsTreeView : Gtk.TreeView
	{
		public ListsTreeView(Gtk.Window parent)
		{
			_Parent = parent;
			Build();
			ls.AppendValues(1, "Develop a Mono application for the XO laptop", "21 Apr 2009", true);
			ls.AppendValues(2, "Custom controls with MonoDevelop and GTK#", "18 May 2008", true);
			ls.AppendValues(3, "A google search application using Gtk#", "14 Jan 2005", false);
			ls.AppendValues(4, "Todolist for Linux", "26 Jan 2008", true);
			ls.AppendValues(5, "Using MySQL from C# and Mono.NET", "3 Jul 2005", false);
			this.ShowAll();
		}		
	}
}
