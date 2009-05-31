
using System;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public class ThudGameBoard : Gtk.DrawingArea
	{
		
		public ThudGameBoard()
		{
			// Insert initialization code here.
			
		}
		
		protected override bool OnButtonPressEvent(Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent(ev);
		}
		
		protected override bool OnExposeEvent(Gdk.EventExpose args)
		{
			Gdk.Window win = args.Window;
			Gdk.Rectangle area = args.Area;
			
			// Add the background image
			Gdk.Pixbuf img = Gdk.Pixbuf.LoadFromResource("background.png");
			this.WidthRequest = img.Width;
			this.HeightRequest = img.Height;
			win.DrawPixbuf(Style.BackgroundGC(Gtk.StateType.Normal),img, 0,0, area.X, area.Y,img.Width, img.Height, Gdk.RgbDither.Normal, 0,0);
			
			
			
			base.OnExposeEvent(args);
			// Insert drawing code here.
			return true;
		}
		
		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);
			// Insert layout code here.
		}
		
		protected override void OnSizeRequested(ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 750;
			requisition.Width = 750;
		}
		
		private void DrawStaticPieces()
		{
			
		}
	}
}
