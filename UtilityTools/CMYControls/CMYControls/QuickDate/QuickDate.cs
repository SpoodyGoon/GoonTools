//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Gtk;


namespace CMYControls
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class QuickDate : Gtk.Bin
	{
		public QuickDate ()
		{
			this.AppPaintable = true;
			this.Build ();
			this.btnShowCalendar.Clicked += OnBtnShowCalendarClicked;
			this.btnClearDate.Clicked += OnBtnClearCalendarClicked;
			this.ShowAll();
		}
		
		protected virtual void OnBtnShowCalendarClicked (object sender, System.EventArgs e)
		{
			int x, y, width = 120, height = 175;
			// get the position of the parent window
			this.ParentWindow.GetPosition( out x, out y );
			// now find the treeviews allocation
			x += this.Allocation.X;
			y += this.Allocation.Y;
			Gdk.Rectangle rec =  new Gdk.Rectangle(x,y,width,height);
			PopupCalendar pc = new PopupCalendar(rec);
			pc.ShowPopUp();
		}
		
		protected virtual void OnBtnClearCalendarClicked (object sender, System.EventArgs e)
		{
			txtQuickDate.Text = "";
		}
		
	}
}
