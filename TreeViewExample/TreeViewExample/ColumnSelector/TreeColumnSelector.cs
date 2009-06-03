
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	
	public class TreeColumnSelector : Gtk.TreeViewColumn
	{
		
		public TreeColumnSelector()
		{
			GoonTools.ColumnSelector.Header hd = new GoonTools.ColumnSelector.Header();
			
			this.Widget = hd;
			this.MinWidth = 25;
			this.Clickable = true;
			this.Resizable = true;
		}
	}
}
