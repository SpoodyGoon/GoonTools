//
//  UpdateSchedualComboBox.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GUPdotNET.UI.ComboBox
{
    using System;
    using Gtk;

    /// <summary>
    /// A combobox for selecting how often auto update should check for updates.
    /// </summary>
    internal class UpdateSchedualComboBox : Gtk.ComboBox
    {
        /// <summary>
        /// The data store for displaying values in the combobox.
        /// </summary>
        private ListStore updateSchedualListStore = new ListStore(typeof(UpdateSchedualItem));

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.ComboBox.UpdateSchedualComboBox"/> class.
        /// </summary>
        internal UpdateSchedualComboBox()
        {
            this.Build();
        }

        /// <summary>
        /// Gets or sets the number of days between when the auto update checks for update.
        /// </summary>
        public int UpdateDays
        {
            get
            {
                Gtk.TreeIter iter = Gtk.TreeIter.Zero;
                if (this.GetActiveIter(out iter))
                {
                    return (this.Model.GetValue(iter, 0) as UpdateSchedualItem).DisplayValue;
                }
                else
                {
                    return 1;
                }
            }

            set
            {
                this.Model.Foreach(delegate(TreeModel model, TreePath path, TreeIter iter)
                {  
                    if ((this.Model.GetValue(iter, 0) as UpdateSchedualItem).DisplayValue.Equals(value))
                    {
                        this.SetActiveIter(iter);
                        return true;
                    }

                    return false;
                });
            }
        }

        /// <summary>
        /// Loads predefined data into the data store into the list store for use in the combobox.
        /// </summary>
        private void LoadListStore()
        {
            this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(1, "Daily"));
            this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(7, "Weekly"));
            this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(14, "Bi-Weekly"));
            this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(30, "Monthly"));
            this.updateSchedualListStore.AppendValues(new UpdateSchedualItem(-1, "Never"));
        }

        /// <summary>
        /// Constructs and sets the default values that pertains to this widget.
        /// </summary>
        private void Build()
        {
            // create a new cell renderer which is resposible for
            // displaying the data on the screen
            Gtk.CellRendererText cellDisplayText = new Gtk.CellRendererText();
            cellDisplayText.Alignment = Pango.Alignment.Right;
            cellDisplayText.IsExpander = true;
            cellDisplayText.Xpad = 4;
            this.PackStart(cellDisplayText, true);
            this.SetCellDataFunc(cellDisplayText, new Gtk.CellLayoutDataFunc(this.RenderDisplayText));
            this.LoadListStore();

            // Sets the list store as the place to get data to display
            this.Model = (Gtk.TreeModel)this.updateSchedualListStore;
            Gtk.TreeIter iter = Gtk.TreeIter.Zero;
            if (this.Model.GetIterFirst(out iter))
            {
                this.SetActiveIter(iter);
            }

            this.QueueDraw();
        }

        /// <summary>
        /// Populates the data from the list store on to the specific display object.
        /// </summary>
        /// <param name="celllayout">Defines the layout for the display cell.</param>
        /// <param name="cell">A reference to the cell that renders the data.</param>
        /// <param name="model">A reference to the list store that holds the data.</param>
        /// <param name="iter">An internal pointer that points to the specific display object being worked on.</param>
        private void RenderDisplayText(Gtk.CellLayout celllayout, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter)
        {
            UpdateSchedualItem item = (UpdateSchedualItem)model.GetValue(iter, 0);
            (cell as CellRendererText).Markup = item.DisplayText;
        }
    }
}