
using System;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class BoardPiece : Gtk.Bin
	{
		private MovablePieceType _MovablePiece = MovablePieceType.None;
		private NonMovablePieceType _BackGround = NonMovablePieceType.None;
		private bool _Blank = true;
		private int _Row = 0;
		private int _Col = 0;
		public BoardPiece(int row, int col)
		{
			this.Build();
			_Row = row;
			_Col = col;
			
			if((IsEven(_Row) && IsEven(_Col)) || (IsOdd(_Row) && IsOdd(_Col)))
				_BackGround = NonMovablePieceType.Dark;
			else
				_BackGround = NonMovablePieceType.Light;
			
			this.ShowAll();
		}
		
		public MovablePieceType MovablePiece
		{
			get{return _MovablePiece;}
			set{_MovablePiece=value;}
		}
		
		public NonMovablePieceType BackGround
		{
			get{return _BackGround;}
			set{_BackGround=value;}
		}
		
		public bool Blank
		{
			get{return _Blank;}
			set{_Blank=value;}
		}
		
		public int Row
		{
			get{return _Row;}
			set{_Row=value;}
		}
		
		public int Col
		{
			get{return _Col;}
			set{_Col=value;}
		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			try
			{
				if(_Blank == false)
				{
//					if(_BackGround == "Dark")
//					{
//						imgBackground.Pixbuf = GoonTools.Common.BoardPieceDark;
//					}
//					else
//					{
//						imgBackground.Pixbuf = GoonTools.Common.BoardPieceLight;
//					}
				}
				this.ShowAll();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			return base.OnExposeEvent (evnt);
		}
		
		private bool IsEven(int intValue)
		{
			return ((intValue & 1) == 0);
		}

		private bool IsOdd(int intValue)
		{
			return ((intValue & 1) == 1);
		}
	}
}
