using System;
using Gtk;
using SQLiteMonoPlusUI.Schema;

namespace SQLiteMonoPlusUI.UI.ObjectExplorer
{
	/// <summary>
	/// Description of SchemaTreeModel.
	/// </summary>
	public class SchemaTreeModel : Gtk.TreeStore, Gtk.TreeModel
	{
		public SchemaTreeModel() : base(typeof(SchemaDisplay))
		{
		}
	}
	
	public struct SchemaDisplay
	{
		DBObjectType ObjectType;
		string ObjectName;
		public SchemaDisplay(DBObjectType type, string name)
		{
			ObjectType = type;
			ObjectName = name;
		}
	}
}
