/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 2/28/2012
 * Time: 4:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Gtk;
using GlobalTools;

namespace SQLiteMonoPlusUI.UI.ObjectExplorer
{
	/// <summary>
	/// Description of SchemaTreeView.
	/// </summary>
	public class SchemaTreeView : Gtk.TreeView
	{
		private Gtk.Window _Parent;
		public SchemaTreeModel _TreeModel = new SchemaTreeModel();
		public SchemaTreeView(Gtk.Window parent)
		{
			_Parent = parent;
			this.Build();
		}
		
		private void Build()
		{
			this.HeadersClickable = false;
			this.HeadersVisible = false;
			this.RulesHint = false;
			this.EnableGridLines = Gtk.TreeViewGridLines.None;
			
			// Create a column for the list name
			Gtk.TreeViewColumn colObjectName = new Gtk.TreeViewColumn ();
			colObjectName.Clickable = true;
			colObjectName.Expand = true;
			colObjectName.Resizable = true;
			colObjectName.Title = "Object Name";
			Gtk.CellRendererText cellObjectName = new Gtk.CellRendererText ();
			cellObjectName.Editable = false;
			cellObjectName.Ellipsize = Pango.EllipsizeMode.End;
			colObjectName.PackStart (cellObjectName, true);
			this.AppendColumn (colObjectName);
			colObjectName.SetCellDataFunc(cellObjectName, new Gtk.TreeCellDataFunc(RenderObjectName));
			this.Model = _TreeModel;
		}
		
		private void RenderObjectName (Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			SchemaDisplay sd = (SchemaDisplay)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = sd.ObjectDisplay;
		}
		
		public void Load()
		{
			_TreeModel.Load();
		}
	}
}
