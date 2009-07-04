
using System;
using System.Collections;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GameBoard : Gtk.Bin
	{
		private BoardPiece[,] bps = new BoardPiece[15, 15];
		private BoardPieceCollection _CurrentMoveOptions = new BoardPieceCollection();
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
		
		public void ShowMoveOptions(MovablePiece mp)
		{
			if(mp.PieceType == MovablePieceType.Dwarf)
				ShowDwarfMoves(mp);
			else if(mp.PieceType == MovablePieceType.Troll)
				ShowTrollMoves(mp);
			
		}
		
		public void ClearMoveOptions(MovablePiece mp)
		{
			for(int i = 0; i < _CurrentMoveOptions.Count; i++)
			{
				_CurrentMoveOptions[i].SetSelected(false, false);
			}
			
		}
		
		private void ShowTrollMoves(MovablePiece mp)
		{
			uint tr, tc;
			uint r = mp.CurrentBoardPiece.Row;
			uint c = mp.CurrentBoardPiece.Col;
			_CurrentMoveOptions.Add(mp.CurrentBoardPiece);
			mp.CurrentBoardPiece.SetSelected(true, true);
			
			tr = r -1;
			tc = c-1;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r-1;
			tc = c;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r -1;
			tc = c +1;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r;
			tc = c-1;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r;
			tc = c +1;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r +1;
			tc = c-1;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r+1;
			tc = c;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
			tr = r +1;
			tc = c +1;
			if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
			{
				_CurrentMoveOptions.Add(bps[tr, tc]);
				bps[tr, tc].SetSelected(true, true);
			}
			
		}
		
		private void ShowDwarfMoves(MovablePiece mp)
		{
			
		}
		
		public void StartGame()
		{
			bps[0,5].SetPiece(MovablePieceType.Dwarf, this);
			bps[0,6].SetPiece(MovablePieceType.Dwarf, this);
			bps[0,8].SetPiece(MovablePieceType.Dwarf, this);
			bps[0,9].SetPiece(MovablePieceType.Dwarf, this);
			bps[1,4].SetPiece(MovablePieceType.Dwarf, this);
			bps[1,10].SetPiece(MovablePieceType.Dwarf, this);
			bps[2,3].SetPiece(MovablePieceType.Dwarf, this);
			bps[2,11].SetPiece(MovablePieceType.Dwarf, this);
			bps[3,2].SetPiece(MovablePieceType.Dwarf, this);
			bps[3,12].SetPiece(MovablePieceType.Dwarf, this);			
			bps[4,1].SetPiece(MovablePieceType.Dwarf, this);
			bps[4,13].SetPiece(MovablePieceType.Dwarf, this);
			bps[5,0].SetPiece(MovablePieceType.Dwarf, this);
			bps[5,14].SetPiece(MovablePieceType.Dwarf, this);			
			bps[6,0].SetPiece(MovablePieceType.Dwarf, this);
			bps[6,6].SetPiece(MovablePieceType.Troll, this);
			bps[6,7].SetPiece(MovablePieceType.Troll, this);
			bps[6,8].SetPiece(MovablePieceType.Troll, this);
			bps[6,14].SetPiece(MovablePieceType.Dwarf, this);
			bps[7,6].SetPiece(MovablePieceType.Troll, this);
			bps[7,7].SetPiece(MovablePieceType.Rock, this);
			bps[7,8].SetPiece(MovablePieceType.Troll, this);
			bps[8,0].SetPiece(MovablePieceType.Dwarf, this);
			bps[8,6].SetPiece(MovablePieceType.Troll, this);
			bps[8,7].SetPiece(MovablePieceType.Troll, this);
			bps[8,8].SetPiece(MovablePieceType.Troll, this);
			bps[8,14].SetPiece(MovablePieceType.Dwarf, this);	
			bps[9,0].SetPiece(MovablePieceType.Dwarf, this);
			bps[9,14].SetPiece(MovablePieceType.Dwarf, this);			
			bps[10,1].SetPiece(MovablePieceType.Dwarf, this);
			bps[10,13].SetPiece(MovablePieceType.Dwarf, this);
			bps[11,2].SetPiece(MovablePieceType.Dwarf, this);
			bps[11,12].SetPiece(MovablePieceType.Dwarf, this);
			bps[12,3].SetPiece(MovablePieceType.Dwarf, this);
			bps[12,11].SetPiece(MovablePieceType.Dwarf, this);
			bps[13,4].SetPiece(MovablePieceType.Dwarf, this);
			bps[13,10].SetPiece(MovablePieceType.Dwarf, this);
			bps[14,5].SetPiece(MovablePieceType.Dwarf, this);
			bps[14,6].SetPiece(MovablePieceType.Dwarf, this);
			bps[14,8].SetPiece(MovablePieceType.Dwarf, this);
			bps[14,9].SetPiece(MovablePieceType.Dwarf, this);
			this.ShowAll();
		}
	}
}
