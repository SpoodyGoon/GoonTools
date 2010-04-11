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
	public class QuickDate2 : Gtk.DrawingArea
	{
		
        private Gdk.Pixbuf display_pixbuf;
		private int _MinWidth;
		private int _MinHeight;
        private int y_offset = 4, x_offset = 4;
		private Gdk.Rectangle _BaseArea = new Gdk.Rectangle(0,0, 165, 26);
		private Gdk.Rectangle _TestArea = new Gdk.Rectangle(2,3, 125, 20);
		private Gdk.Rectangle _ShowButtonArea = new Gdk.Rectangle(126,0, 20, 20);
		private Gdk.Rectangle _ClearButtonArea = new Gdk.Rectangle(0,0, 125, 20);
		private Pango.Layout _BaseMessage;
		public QuickDate2 ()
		{
			_BaseMessage = GetLayout ("Select Date");
		}

		private Pango.Layout GetLayout (string text)
		{
			Pango.Layout layout = new Pango.Layout (this.PangoContext);
			layout.FontDescription = Pango.FontDescription.FromString ("Arial 8");
			layout.SetMarkup ("<span color=\"#000000\"><b>" + text + "</b></span>");
			return layout;
		}


		[GLib.ConnectBefore()]
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			Gdk.Window win = evnt.Window;
			Gdk.Rectangle area = evnt.Area;
			this.HeightRequest = _BaseArea.Height + 2;
			this.WidthRequest = _BaseArea.Width + 2;
            int y_mid = (Allocation.Height - this.Allocation.Height) / 2;
			//Gdk.Pixbuf display_pixbuf = Gdk.Pixbuf.LoadFromResource("QuickDate.png");
            GdkWindow.DrawRectangle(Style.BaseGC(StateType.Normal), true, 0, y_mid - y_offset, this.Allocation.Width, this.Allocation.Height + (y_offset * 2));

            Gtk.Style.PaintShadow(Style, GdkWindow, StateType.Normal, ShadowType.In, evnt.Area, this, "entry", 0, y_mid - y_offset, Allocation.Width, this.Allocation.Height + (y_offset * 2));

            GdkWindow.DrawPixbuf(Style.BackgroundGC(StateType.Normal), display_pixbuf, 0, 0, x_offset, y_mid, this.Allocation.Width, this.Allocation.Height, Gdk.RgbDither.None, 0, 0);

//			// draw the contols frame
//			win.DrawRectangle (Style.BlackGC, false, new Gdk.Rectangle(_BaseArea.X , _BaseArea.Y, _BaseArea.Width, _BaseArea.Height));
//			
//			
//			
//			// draw the text box
//			win.DrawRectangle (Style.BlackGC, true, _TestArea);
//			win.DrawRectangle (Style.BaseGC(StateType.Prelight), true, new Gdk.Rectangle(_TestArea.X + 2, _TestArea.Y + 2, _TestArea.Width - 4, _TestArea.Height - 4));
//			int TextWidth = 0;
//			int TextHeight = 0;
//			_BaseMessage.GetPixelSize(out TextWidth, out TextHeight);
//			win.DrawLayout (Style.BlackGC, Convert.ToInt32((_TestArea.Width/2) - (TextWidth/2)), Convert.ToInt32((_TestArea.Height/2) -  (TextHeight/2)), _BaseMessage);
//			
//			// add the show calander button
//			win.DrawRectangle(Style.BackgroundGC(StateType.Normal), true, _ShowButtonArea);
//			
//			Gdk.Drawable d = this;
//			p.RenderToDrawable(d, Style.WhiteGC, 0,0,0,0, 25, 25, Gdk.RgbDither.None, 0,0);
//			Gdk.GC gc = new Gdk.GC(d);
//			win.DrawPixbuf(gc ,p , 25,25,  _ShowButtonArea.X, _ShowButtonArea.Y, _ShowButtonArea.Width, _ShowButtonArea.Height, Gdk.RgbDither.None, 0,0);
			((Gtk.Widget)this.Parent).HeightRequest = _BaseArea.Height;
			((Gtk.Widget)this.Parent).WidthRequest = _BaseArea.Width;
			((Gtk.Widget)this.Parent).QueueDraw();
			((Gtk.Widget)this.Parent).ShowAll();
			this.ParentWindow.Show();
			
			
			return true;
		}
	}
}