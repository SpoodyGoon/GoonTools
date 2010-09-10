//  Andy York <andy@brdstudio.net> 
// 
//  Copyright (C) 2010 GoonTools 2009
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
// 
using System;
namespace CMYControls
{
    [System.ComponentModel.ToolboxItem(true)]
    public partial class QuickDate : Gtk.Bin
    {
        
        
           public QuickDate ()
        {
            this.Build ();
        }
           protected virtual void OnBtnClearDateClicked (object sender, System.EventArgs e)
        {
            txtQuickDate.Text = "";
        }
     protected virtual void OnBtnShowCalendarClicked (object sender, System.EventArgs e)
        {
             int x, y;
                        // get the position of the parent window
                        this.ParentWindow.GetPosition( out x, out y );
                        // now find the treeviews allocation
                        x += this.Allocation.X;
                        y += this.Allocation.Y;
                        Gdk.Rectangle rec =  new Gdk.Rectangle(x,y,this.Allocation.Width,this.Allocation.Height);
                        PopupCalendar pc = new PopupCalendar(rec);
                        //pc.ShowPopUp();
        }
        
        
    }
}

