
using System;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GameBoard : Gtk.Bin
	{
		private BoardPiece[,] bps = new BoardPiece[15, 15];
		private Gtk.Window _ParentWindow;
		public GameBoard()
		{
			this.Build();
			try
			{
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
		
		public void StartGame()
		{
			bps[0,5].SetPiece(MovablePieceType.Dwarf);
			bps[0,6].SetPiece(MovablePieceType.Dwarf);
			bps[0,8].SetPiece(MovablePieceType.Dwarf);
			bps[0,9].SetPiece(MovablePieceType.Dwarf);
			bps[1,4].SetPiece(MovablePieceType.Dwarf);
			bps[1,10].SetPiece(MovablePieceType.Dwarf);
			bps[2,3].SetPiece(MovablePieceType.Dwarf);
			bps[2,11].SetPiece(MovablePieceType.Dwarf);
			bps[3,2].SetPiece(MovablePieceType.Dwarf);
			bps[3,12].SetPiece(MovablePieceType.Dwarf);			
			bps[4,1].SetPiece(MovablePieceType.Dwarf);
			bps[4,13].SetPiece(MovablePieceType.Dwarf);
			bps[5,0].SetPiece(MovablePieceType.Dwarf);
			bps[5,14].SetPiece(MovablePieceType.Dwarf);			
			bps[6,0].SetPiece(MovablePieceType.Dwarf);
			bps[6,6].SetPiece(MovablePieceType.Troll);
			bps[6,7].SetPiece(MovablePieceType.Troll);
			bps[6,8].SetPiece(MovablePieceType.Troll);
			bps[6,14].SetPiece(MovablePieceType.Dwarf);
			bps[7,6].SetPiece(MovablePieceType.Troll);
			bps[7,8].SetPiece(MovablePieceType.Troll);
			bps[8,0].SetPiece(MovablePieceType.Dwarf);
			bps[8,6].SetPiece(MovablePieceType.Troll);
			bps[8,7].SetPiece(MovablePieceType.Troll);
			bps[8,8].SetPiece(MovablePieceType.Troll);
			bps[8,14].SetPiece(MovablePieceType.Dwarf);	
			bps[9,0].SetPiece(MovablePieceType.Dwarf);
			bps[9,14].SetPiece(MovablePieceType.Dwarf);			
			bps[10,1].SetPiece(MovablePieceType.Dwarf);
			bps[10,13].SetPiece(MovablePieceType.Dwarf);
			bps[11,2].SetPiece(MovablePieceType.Dwarf);
			bps[11,12].SetPiece(MovablePieceType.Dwarf);
			bps[12,3].SetPiece(MovablePieceType.Dwarf);
			bps[12,11].SetPiece(MovablePieceType.Dwarf);
			bps[13,4].SetPiece(MovablePieceType.Dwarf);
			bps[13,10].SetPiece(MovablePieceType.Dwarf);
			bps[14,5].SetPiece(MovablePieceType.Dwarf);
			bps[14,6].SetPiece(MovablePieceType.Dwarf);
			bps[14,8].SetPiece(MovablePieceType.Dwarf);
			bps[14,9].SetPiece(MovablePieceType.Dwarf);
			this.ShowAll();
		}
	}
}
