using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gtk;

namespace GUPdotNET.UI.ComboBox
{
	[System.ComponentModel.ToolboxItem(true)]
	internal class UpdateSchedualComboBox : Gtk.ComboBox
	{
		private ListStore updateSchedualListStore = new ListStore(typeof(UpdateSchedualItem));

		internal UpdateSchedualComboBox()
		{
			this.Build();
		}

		private void LoadListStore()
		{
			this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(1, "Daily"));
			this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(7, "Weekly"));
			this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(14, "Bi-Weekly"));
			this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(30, "Monthly"));
			this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(-1, "Never"));
		}

		private void Build()
		{
			Gtk.CellRendererText cellDisplayText = new Gtk.CellRendererText();
			cellDisplayText.Alignment = Pango.Alignment.Right;
			cellDisplayText.IsExpander = true;
			cellDisplayText.Xpad = 4;
			this.PackStart(cellDisplayText, true);
			this.SetCellDataFunc(cellDisplayText, new Gtk.CellLayoutDataFunc(this.RenderDisplayText));
			this.LoadListStore();
			this.Model = (Gtk.TreeModel)this.updateSchedualListStore;
			Gtk.TreeIter iter = Gtk.TreeIter.Zero;
			if(this.Model.GetIterFirst(out iter))
			{
				this.SetActiveIter(iter);
			}
			this.QueueDraw();
		}

		private void RenderDisplayText(Gtk.CellLayout celllayout, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			UpdateSchedualItem item = (UpdateSchedualItem)model.GetValue(iter, 0);
			(cell as CellRendererText).Markup = item.DisplayText;
		}

		public int UpdateDays {
			get {
				Gtk.TreeIter iter = Gtk.TreeIter.Zero;
				if(this.GetActiveIter(out iter))
				{
					return (this.Model.GetValue(iter, 0) as UpdateSchedualItem).DisplayValue;
				}
				else
				{
					return 1;
				}
			}
			set {
				this.Model.Foreach(delegate (TreeModel model, TreePath path, TreeIter iter)
				{  
					if((this.Model.GetValue(iter, 0) as UpdateSchedualItem).DisplayValue.Equals(value))
					{
						this.SetActiveIter(iter);
						return true;
					}
					return false;
				});
			}
		}
	}

	internal class UpdateSchedualItem
	{
		internal UpdateSchedualItem(int value, string text)
		{
			this.DisplayValue = value;
			this.DisplayText = text;
		}

		internal int DisplayValue { get; set; }

		internal string DisplayText { get; set; }
	}
}
