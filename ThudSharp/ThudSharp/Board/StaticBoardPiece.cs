
using System;
using Gtk;
using System.ComponentModel; 

namespace ThudSharp
{	
	public enum StaticPieceType
	{
		Light,
		Dark
	}
	
	[System.ComponentModel.ToolboxItem(true)]
	public class StaticBoardPiece : Gtk.DrawingArea 
	{
		private StaticPieceType _PieceType;
		private int _Left = 0;
		private int _Top = 0;
		private Gdk.Pixbuf _BoardPiece;
		private string Test = "";
		private bool _IsAltPiece =false;
		public StaticBoardPiece(StaticPieceType pt)
		{
			_PieceType = pt;
			
			// Insert initialization code here.
		}
		
		public StaticBoardPiece()
		{
			_PieceType = StaticPieceType.Dark;
			
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
		
		public ThudSharp.StaticPieceType PieceType
		{
			get{return _PieceType;}
			set{_PieceType = value;}
		}
		
		[GLib.ConnectBeforeAttribute()]
		[GLib.DefaultSignalHandlerAttribute()]
		protected override bool OnEnterNotifyEvent(Gdk.EventCrossing evnt)
		{
			evnt.Window.DrawRectangle(Style.WhiteGC, true, this.Allocation);
			this.QueueDraw();
			this.ShowAll();
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "got here");
				md.Run();
				md.Destroy();
			return base.OnEnterNotifyEvent(evnt);
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
			
			if(_PieceType == StaticPieceType.Dark)
				_BoardPiece = GoonTools.Common.BoardPieceDark;
			else
				_BoardPiece = GoonTools.Common.BoardPieceLight;
			
			this.WidthRequest = _BoardPiece.Width;
			this.HeightRequest = _BoardPiece.Height;
			win.DrawPixbuf(Style.ForegroundGC(Gtk.StateType.Normal),_BoardPiece, 0,0, _Left, _Top,_BoardPiece.Width, _BoardPiece.Height, Gdk.RgbDither.Normal, 0,0);
			
			
			base.OnExposeEvent(args);
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
			requisition.Height = 45;
			requisition.Width = 45;
		}
	}
}
