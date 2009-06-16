
using System;
using Gtk;
using System.ComponentModel; 

namespace ThudSharp
{	
	[System.ComponentModel.ToolboxItem(true)]
	public class StaticBoardPiece :  Gtk.DrawingArea
	{
		private NonMovablePieceType _PieceType;
		private int _Left = 0;
		private int _Top = 0;
		private Gdk.Pixbuf _BoardPiece;
		private string Test = "";
		private bool _IsAltPiece =false;
		public StaticBoardPiece(NonMovablePieceType pt)
		{
			_PieceType = pt;
			this.Sensitive = true;
			// Insert initialization code here.
		}
		
		public StaticBoardPiece()
		{
			_PieceType = NonMovablePieceType.Dark;
			
		}	
		
		public string ID
		{
			get{return "";}
			set{Test=value;}
		}
		
		public bool IsAltPiece
		{
			get{return _IsAltPiece;}
			set{_IsAltPiece=value;}
		}
		
		[DesignOnly(true)]
		public NonMovablePieceType PieceType
		{
			get{return _PieceType;}
			set{_PieceType = value;}
		}
		
		[GLib.DefaultSignalHandlerAttribute()]
		protected override void OnSelectionGet(SelectionData selection_data, uint info, uint time_)
		{
			base.OnSelectionGet(selection_data, info, time_);
		}
		
		[GLib.DefaultSignalHandlerAttribute()]
		[GLib.ConnectBeforeAttribute()]
		protected override bool OnEnterNotifyEvent(Gdk.EventCrossing evnt)
		{
			evnt.Window.DrawRectangle(Style.WhiteGC, true, this.Allocation);
			this.QueueDraw();
			this.ShowAll();
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "got here");
				md.Run();
				md.Destroy();
			return true;// base.OnEnterNotifyEvent(evnt);
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override bool OnButtonPressEvent(Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "got here");
				md.Run();
				md.Destroy();
			return base.OnButtonPressEvent(ev);
		}
		
		[GLib.ConnectBeforeAttribute()]
		protected override bool OnExposeEvent(Gdk.EventExpose args)
		{
			base.OnExposeEvent(args);
			Gdk.Window win = args.Window;
			Gdk.Rectangle area = args.Area;
			
			if(_PieceType == NonMovablePieceType.Dark)
				_BoardPiece = GoonTools.Common.BoardPieceDark;
			else
				_BoardPiece = GoonTools.Common.BoardPieceLight;
			
			this.WidthRequest = _BoardPiece.Width;
			this.HeightRequest = _BoardPiece.Height;
			win.DrawPixbuf(Style.ForegroundGC(Gtk.StateType.Normal),_BoardPiece, 0,0, _Left, _Top,_BoardPiece.Width, _BoardPiece.Height, Gdk.RgbDither.Normal, 0,0);
			this.ShowAll();
			return false;
		}

		
		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);
			// Insert layout code here.
		}
		
		protected override void OnSizeRequested(ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 45;
			requisition.Width = 45;
		}
	}
}
