/*
 * Created by SharpDevelop.
 * User: ayork
 * Date: 4/20/2010
 * Time: 3:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CMYControls
{
	/// <summary>
	/// Description of PopupCalendar.
	/// </summary>
	public class PopupCalendar : Gtk.Window
	{
		private Gtk.Calendar _Calendar = new Gtk.Calendar();
		private Gdk.Rectangle _PopUpRec;
		public PopupCalendar(Gdk.Rectangle rec)  : base(Gtk.WindowType.Popup)
		{
			Build();
			_PopUpRec = rec;
//			this.WidthRequest = rec.Width;
//			this.HeightRequest = rec.Height;
			this.ShowAll();
		}
		
		
		
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			base.OnExposeEvent (evnt);
			int winWidth, winHeight;
			this.GetSize (out winWidth, out winHeight);	
			this.Move(_PopUpRec.Left, _PopUpRec.Bottom);		
			this.GdkWindow.DrawRectangle (this.Style.ForegroundGC (Gtk.StateType.Insensitive), false, 0, 0, winWidth-1, winHeight-1);
			return false;
		}
		
		private void Build()
		{
			this.CanFocus = true;
			this.BorderWidth = 2;
			this.AllowGrow = true;
			this.AllowShrink = false;
			this.DestroyWithParent = true;
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			this.AppPaintable = true;
			// initialize the window with it not being visible
			// we'll set it to visible after the treeview has been populated
			this.Visible = false;
			Gtk.Frame frame1 = new Gtk.Frame();
			frame1.BorderWidth = 1;
			Gtk.Alignment GtkAlignment1 = new Gtk.Alignment(0F, 0F, 1F, 1F);
			// add the calendar to the window
			_Calendar.Date = DateTime.Now.Date;
			GtkAlignment1.Add(_Calendar);			
			frame1.Add(GtkAlignment1);
			this.Add(frame1);
			this.ModifyBg(Gtk.StateType.Normal, new Gdk.Color(0, 0,0));
		}
		
		
		
		internal void ShowPopUp()
		{
			this.Visible = true;
			GrabUtil.GrabWindow(this);
			this.ShowAll();
		}

		private void Close()
		{
			GrabUtil.RemoveGrab(this);
			this.Destroy();
		}

		/// <summary>
		///  this event lets us close the popup window
		///  and release the grab we got through the HollyLibrary
		///  without this event getting the focus back from this window
		///  in a Linux/Gnome enviroment is very hard. lol
		/// </summary>
		/// <param name="evnt"></param>
		/// <returns></returns>
		[GLib.DefaultSignalHandlerAttribute()]
		protected override bool OnButtonPressEvent(Gdk.EventButton evnt)
		{
			this.Close();
			return base.OnButtonPressEvent(evnt);
		}
	}
}
