
using System;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GameBoard : Gtk.Bin
	{
		
		public GameBoard()
		{
			this.Build();
			BoardPiece[,] bps = new BoardPiece[15, 15];
			this.imgBoardBackGround.Pixbuf = GoonTools.Common.BoardBackGround;
			BoardPiece bp;
			for(int i = 0; i < 15; i++)
			{
				for(int j=0; j < 15; j++)
				{
					bp = new BoardPiece(i, j);
				}
			}
			//int[][] BlankArray= new int[][]{new int[0,0], new int[0,1], new int[0,2], new int[0,3], new int[0,4], new int[0,5,]};
			ShowAll();
			
		}
		
//		public BoardPiece GetBoardPiece(int col, int row)
//		{
//
//		}
	}
}
