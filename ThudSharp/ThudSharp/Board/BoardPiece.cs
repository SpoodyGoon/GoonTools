
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
		private bool _IsActive = false;
		private bool _IsSelected = false;
		// this an array of board pieces that will be blank
		// and show no image and won't be active
		private uint[][] Blanks = new uint[15][];
		public BoardPiece(uint row, uint col)
		{
			this.Build();
			
//			imgHighLight.Pixbuf = GoonTools.Common.HighLight;
//			imgHighLight.Visible = false;
//			imgHighLight.DoubleBuffered = true;
			
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
			
			// determine what image to show or if the piece is blank
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
		
		#region Public Properties
		
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
		
		public bool IsSelected
		{
			get{return _IsSelected;}
			set{_IsSelected=value;}
		}
		
		public bool IsActive
		{
			get{return _IsActive;}
			set{_IsActive=value;}
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
		
		#endregion Public Properites
		
		#region Public Methods
		
		public void SetPiece(MovablePieceType mpt)
		{
			MovablePiece mp = new MovablePiece(mpt);
			fxContainer.Add(mp);
			Gtk.Fixed.FixedChild fxc = ((Gtk.Fixed.FixedChild)(fxContainer[mp]));
            fxc.X = 0;
            fxc.Y = 0;
            this.ShowAll();
			
		}
		
		public void SetSelected(bool blnIsSelected, bool blnIsActive)
		{
			_IsSelected = blnIsSelected;
			_IsActive = blnIsActive;
			
			imgBackground.Mask.DrawRectangle (Style.LightGC(StateType.Active), true, 0, 0,45, 45);
			this.ShowAll();
			Console.WriteLine("Set Selected");
		}
		
		#endregion Public Methods
		
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
