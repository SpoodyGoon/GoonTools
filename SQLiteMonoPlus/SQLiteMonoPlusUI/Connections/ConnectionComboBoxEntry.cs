
using System;
using Gtk;
using SQLiteMonoPlusUI.GlobalTools;

namespace SQLiteMonoPlusUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public class ConnectionComboBoxEntry : Gtk.ComboBoxEntry
	{
		private int _ConnectionID;
		private string _ConnectionName;
		private int _SearchConnectionID;
		private string _SearchConnectionName;
		private DateTime _LastLoad = DateTime.Now;
		public ConnectionComboBoxEntry()
		{
			Build();
		}


		private void Build()
		{
			try
			{
				// set up the sell
				Gtk.CellRendererText cellConnectionName = new Gtk.CellRendererText();
				cellConnectionName.Editable = false;
				this.PackStart(cellConnectionName, true);
				this.SetCellDataFunc(cellConnectionName, new Gtk.CellLayoutDataFunc(RenderConnectionName));
                this.Model = (Gtk.TreeModel)GlobalData.StoreModels.Connections;
				_LastLoad = DateTime.Now;
				this.QueueDraw();
			}
			catch (Exception ex)
			{   
				Common.HandleError(ex);
			}
		}

		#region Cell Data Functions

		private void RenderConnectionName(Gtk.CellLayout celllayout, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			Connection s = (Connection)model.GetValue(iter, 0);
			(cell as Gtk.CellRendererText).Text = s.ConnectionName;
		}

		#endregion Cell Data Functions

		#region Public Properties

        public string ConnectionName
        {
            set
            {
                _SearchConnectionName = value;
                this.Model.Foreach(new TreeModelForeachFunc(ForeachConnectionName));
            }
            get { return _ConnectionName; }
        }

        public int ConnectionID
        {
            set
            {
                _SearchConnectionID = value;
                this.Model.Foreach(new TreeModelForeachFunc(ForeachConnectionID));
            }
            get { return _ConnectionID; }
        }

		#endregion Public Properties

		#region Search Functions Related To Value Setting

		private bool ForeachConnectionName(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if (_SearchConnectionName == this.Model.GetValue(iter, 1).ToString())
			{
				_ConnectionName = this.Model.GetValue(iter, 1).ToString();
				_ConnectionID = Convert.ToInt32(this.Model.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}

		private bool ForeachConnectionID(Gtk.TreeModel model, Gtk.TreePath path, Gtk.TreeIter iter)
		{
			if (_SearchConnectionID == Convert.ToInt32(this.Model.GetValue(iter, 0)))
			{
				_ConnectionName = this.Model.GetValue(iter, 1).ToString();
				_ConnectionID = Convert.ToInt32(this.Model.GetValue(iter, 0));
				this.SetActiveIter(iter);
				return true;
			}
			return false;
		}

		#endregion Search Functions Related To Value Setting
	}
}

