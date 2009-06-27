
using System;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GameBoard : Gtk.Bin
	{
		
		public GameBoard()
		{
			this.Build();
			try
			{
				BoardPiece[,] bps = new BoardPiece[15, 15];
				this.imgBoardBackGround.Pixbuf = GoonTools.Common.BoardBackGround;
				BoardPiece bp;
				Gtk.Table.TableChild tc;
				for(uint i = 0; i < 15; i++)
				{
					for(uint j=0; j < 15; j++)
					{
						// create our new board piece
						bp = new BoardPiece(i, j);
						// add the board piece to our controling array
						bps[i,j] = bp;
						// add the board piece to the table
						GameTable.Add(bp);
						// set the location of the board piece on the table
						tc = ((Gtk.Table.TableChild)(GameTable[bp]));
						tc.LeftAttach = j;
						tc.RightAttach = j + 1;
						tc.TopAttach = i;
						tc.BottomAttach = i + 1;
						tc.XPadding = 0;
						tc.YPadding = 0;
					}
				}
				
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			ShowAll();
			
		}
		
//		public BoardPiece GetBoardPiece(int col, int row)
//		{
//
//		}
	}
}
