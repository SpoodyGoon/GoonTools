
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
		private uint _Row = 0;
		private uint _Col = 0;
//		private	int [,] Blanks = new int[60,2] {
//			{0,0},{0,1},{0,2},{0,3},{0,4},{0,10},{0,11},{0,12},{0,13},{0,14},
//			{1,0},{1,1},{1,2},{1,3},{1,11},{1,12},{1,13},{1,14},
//			{2,0},{2,1},{2,2},{2,12},{2,13},{2,14},
//			{3,0},{3,1},{3,13},{3,14},
//			{4,0},{4,14},
//			{10,0},{10,14},
//			{11,0},{11,1},{11,13},{11,14},
//			{12,0},{12,1},{12,2},{12,12},{12,13},{12,14},
//			{13,0},{13,1},{13,2},{13,3},{13,11},{13,12},{13,13},{13,14},
//			{14,0},{14,1},{14,2},{14,3},{14,4},{14,10},{14,11},{14,12},{14,13},{14,14}
//		};
		private uint[][] Blanks = new uint[15][];
		public BoardPiece(uint row, uint col)
		{
			this.Build();
			_Row = row;
			_Col = col;
			Blanks[0] = new uint[10]{0,1,2,3,4,10,11,12,13,14};
			Blanks[1] = new uint[8]{0,1,2,3,11,12,13,14};
			Blanks[2] = new uint[6]{0,1,2,12,13,14};
			Blanks[3] = new uint[4]{0,1,13,14};
			Blanks[4] = new uint[2]{0,14};
			Blanks[5] = new uint[0]{};
			Blanks[6] = new uint[0]{};
			Blanks[7] = new uint[0]{};
			Blanks[8] = new uint[0]{};
			Blanks[9] = new uint[0]{};
			Blanks[10] = new uint[2]{0,14};
			Blanks[11] = new uint[4]{0,1,13,14};
			Blanks[12] = new uint[6]{0,1,2,12,13,14};
			Blanks[13] = new uint[8]{0,1,2,3,11,12,13,14};
			Blanks[14] = new uint[10]{0,1,2,3,4,10,11,12,13,14};
			
			if(Array.IndexOf(Blanks[row], col) > -1)
			{
				_BackGround = NonMovablePieceType.None;
				_Blank = true;
			}
			else if((IsEven(_Row) && IsEven(_Col)) || (IsOdd(_Row) && IsOdd(_Col)))
			{
				_BackGround = NonMovablePieceType.Light;
				imgBackground.Pixbuf = GoonTools.Common.BoardPieceLight;
			}
			else
			{
				_BackGround = NonMovablePieceType.Dark;
				imgBackground.Pixbuf = GoonTools.Common.BoardPieceDark;
			}
			
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
		
		public uint Row
		{
			get{return _Row;}
			set{_Row=value;}
		}
		
		public uint Col
		{
			get{return _Col;}
			set{_Col=value;}
		}
		
		private bool IsEven(uint intValue)
		{
			return ((intValue & 1) == 0);
		}

		private bool IsOdd(uint intValue)
		{
			return ((intValue & 1) == 1);
		}
	}
}
