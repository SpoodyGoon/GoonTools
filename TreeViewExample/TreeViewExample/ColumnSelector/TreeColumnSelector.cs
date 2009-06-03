
using System;
using Gtk;

namespace GoonTools.ColumnSelector
{
	
	
	public class TreeColumnSelector : Gtk.TreeViewColumn
	{
		
		public TreeColumnSelector()
		{
			this.MinWidth = 25;
			this.Clickable = true;
			this.Resizable = true;
			this.Visible = true;
			GoonTools.ColumnSelector.Header h = new GoonTools.ColumnSelector.Header();
			this.Widget=h;
			this.Alignment = 0.01;
		}
	}
}
