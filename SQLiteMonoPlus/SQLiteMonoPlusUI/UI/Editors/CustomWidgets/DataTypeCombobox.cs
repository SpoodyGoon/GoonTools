
using System;
using Gtk;
using SQLiteMonoPlus;
using libGlobalTools;

namespace SQLiteMonoPlusUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public class DataTypeCombobox : Gtk.ComboBoxEntry
	{
		private Gtk.ListStore _ListStore = new ListStore(typeof(string));
		public DataTypeCombobox ()
		{
			Build ();
			string[] strDataType = Enum.GetNames (typeof(SQLiteDataType));
			_ListStore.AppendValues("");
			for (int i=0; i<strDataType.Length; i++)
			{
				_ListStore.AppendValues(strDataType[i]);
			}
			Gtk.TreeIter iter = Gtk.TreeIter.Zero;
			if (this.Model.GetIterFirst (out iter))
				this.SetActiveIter (iter);
		}    

		private void Build ()
		{
			try
			{
				// set up the sell
				Gtk.CellRendererText cellDataTypeName = new Gtk.CellRendererText ();
				cellDataTypeName.Editable = false;
				cellDataTypeName.Sensitive = true;
				this.PackStart (cellDataTypeName, true);
				this.Model = (Gtk.TreeModel)_ListStore;
				this.QueueDraw ();
			} catch (Exception ex)
			{   
				Common.HandleError (ex);
			}
		}

		private string _SearchDataType = null;
		public string SelectedDataType
		{
			set
			{
				Gtk.TreeIter iter = Gtk.TreeIter.Zero;
				if (this.Model.GetIterFirst (out iter))
					this.SetActiveIter (iter);

				_SearchDataType = value;
				this.Model.Foreach (new TreeModelForeachFunc (ForeachDataTypeName));
			}
			get 
			{
				Gtk.TreeIter iter = Gtk.TreeIter.Zero;
				if(this.GetActiveIter(out iter))
					return this.Model.GetValue(iter, 0).ToString();
				else
					return null;
			}
		}
		
		private bool ForeachDataTypeName (Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if (_SearchDataType == this.Model.GetValue (iter, 0).ToString())
			{
				this.SetActiveIter (iter);
				return true;
			}
			return false;
		}
	}
}

