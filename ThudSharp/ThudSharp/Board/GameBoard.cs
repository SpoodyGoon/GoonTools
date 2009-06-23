
using System;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GameBoard : Gtk.Bin
	{
		
		public GameBoard()
		{
			this.Build();
			this.imgBoardBackGround.Pixbuf = GoonTools.Common.BoardBackGround;
			ShowAll();
		}
		
//		public BoardPiece GetBoardPiece(int col, int row)
//		{
//			
//		}
	}
}
