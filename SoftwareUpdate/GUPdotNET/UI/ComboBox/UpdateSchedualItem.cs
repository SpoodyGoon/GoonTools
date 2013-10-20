//
//  UpdateSchedualItem.cs
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
    /// <summary>
    /// The data object that is stored in the list store, provides for access to fields in the object.
    /// </summary>
    internal class UpdateSchedualItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.ComboBox.UpdateSchedualItem"/> class.
        /// </summary>
        /// <param name="value">The value that relates to the text that is being selected.</param>
        /// <param name="text">The text that is being displayed in the combobox for the end user to select.</param>
        internal UpdateSchedualItem(int value, string text)
        {
            this.DisplayValue = value;
            this.DisplayText = text;
        }

        /// <summary>
        /// Gets or sets the display value which relates to the text that is being selected.
        /// </summary>
        internal int DisplayValue { get; set; }

        /// <summary>
        /// Gets or sets the display text which is being displayed in the combobox for the end user to select.
        /// </summary>
        internal string DisplayText { get; set; }
    }
}