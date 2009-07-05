
using System;
using System.Collections;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GameBoard : Gtk.Bin
	{
		private BoardPiece[,] bps = new BoardPiece[15, 15];
		private MovablePiece[] mpDwarf = new MovablePiece[32];
		private MovablePiece[] mpTrolls = new MovablePiece[8];
		private MovablePiece[] mpRock = new MovablePiece[1];
		private BoardPieceCollection _CurrentMoveOptions = new BoardPieceCollection();
		public GameBoard()
		{
			this.Build();
			try
			{
				this.imgBoardBackGround.Pixbuf = GoonTools.Common.BoardBackGround;
				 SetUpBoard();
				
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			ShowAll();
			
		}
		
		private void SetUpBoard()
		{
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
		
		public void ShowMoveOptions(MovablePiece mp)
		{
			try
			{
				if(mp.PieceType == MovablePieceType.Dwarf)
					ShowDwarfMoves(mp);
				else if(mp.PieceType == MovablePieceType.Troll)
					ShowTrollMoves(mp);
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		public void ClearMoveOptions()
		{
			try
			{
				for(int i = 0; i < _CurrentMoveOptions.Count; i++)
				{
					_CurrentMoveOptions[i].SetSelected(false, false);
				}
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		private void ShowTrollMoves(MovablePiece mp)
		{
			try
			{
				// troll movements moving one square in any direction (forwards, backwards, sideways and diagonally)
				// provided it is not currently occupied
				
				// start by clearing any previous selected pieces
				ClearMoveOptions();
				
				uint tr, tc;
				uint r = mp.CurrentBoardPiece.Row;
				uint c = mp.CurrentBoardPiece.Col;
				
				// select current square
				_CurrentMoveOptions.Add(mp.CurrentBoardPiece);
				mp.CurrentBoardPiece.SetSelected(true, true);
				
				// select top/left
				tr = r -1;
				tc = c-1;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select top/center
				tr = r-1;
				tc = c;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select top/right
				tr = r -1;
				tc = c +1;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select left
				tr = r;
				tc = c-1;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select right
				tr = r;
				tc = c +1;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select bottom/left
				tr = r +1;
				tc = c-1;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select bottom/center
				tr = r+1;
				tc = c;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
				
				// select bottom/right
				tr = r +1;
				tc = c +1;
				if(bps[tr,tc].MovablePiece == MovablePieceType.None && bps[tr,tc].Blank != true)
				{
					_CurrentMoveOptions.Add(bps[tr, tc]);
					bps[tr, tc].SetSelected(true, true);
				}
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		private void ShowDwarfMoves(MovablePiece mp)
		{
			try
			{
				// Dwarf movements: any distance in a straight line (forwards, backwards, sideways and diagonally)
				// provided it is not currently occupied
				
				// start by clearing any previous selected pieces
				ClearMoveOptions();
				
				uint tr, tc;
				BoardPiece tp;
				uint r = mp.CurrentBoardPiece.Row;
				uint c = mp.CurrentBoardPiece.Col;
				
				// select current square
				tp = mp.CurrentBoardPiece;
				_CurrentMoveOptions.Add(tp);
				tp.SetSelected(true, true);
				
				if(r > 0)
				{
					// get all options to the left
					tr = r - 1;
					tc = c;
					tp = bps[tr, tc];
					while(tr >= 0 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tr--;
						tp = bps[tr, tc];
					}
				}
				
				if(r < 14)
				{
					// get all options to the right
					tr = r + 1;
					tc = c;
					tp = bps[tr, tc];
					while(tr <= 14 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tr++;
						tp = bps[tr, tc];
					}
				}
				
				if(c > 0)
				{
					// get all options above
					tr = r;
					tc = c - 1;
					tp = bps[tr, tc];
					while(tc >= 0 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tc--;
						tp = bps[tr, tc];
					}
				}
				
				if(c < 14)
				{
					// get all options below
					tr = r;
					tc = c + 1;
					tp = bps[tr, tc];
					while(tc <= 14 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tc++;
						tp = bps[tr, tc];
					}
				}
				
				if(r > 0 && c > 0 )
				{
					// get all options to the left and above (diagonally)
					tr = r - 1;
					tc = c - 1;
					tp = bps[tr, tc];
					while(tr >= 0 && tc >= 0 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tr--;
						tc--;
						tp = bps[tr, tc];
					}
				}
				
				if(r < 14 && c > 0 )
				{
					// get all options to the left and below (diagonally)
					tr = r + 1;
					tc = c - 1;
					tp = bps[tr, tc];
					while(tr <= 14 && tc >= 0  && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tr++;
						tc--;
						tp = bps[tr, tc];
					}
				}
				
				if(r > 0 && c < 14)
				{
					// get all options to the right and above (diagonally)
					tr = r - 1;
					tc = c + 1;
					tp = bps[tr, tc];
					while(tr >= 0 && tc <= 14 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tr--;
						tc++;
						tp = bps[tr, tc];
					}
				}
				
				if(r < 14 && c < 14)
				{
					// get all options to the right and below (diagonally)
					tr = r + 1;
					tc = c + 1;
					tp = bps[tr, tc];
					while(tr <= 14 && tc <= 14 && tp.Blank != true && tp.MovablePiece == MovablePieceType.None)
					{
						_CurrentMoveOptions.Add(bps[tr, tc]);
						bps[tr, tc].SetSelected(true, true);
						tr++;
						tc++;
						tp = bps[tr, tc];
					}
				}
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		public void StartGame()
		{
			try
			{
				// 32 dwarfs 8 trolls 1 rock
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
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString());
				md.Run();
				md.Destroy();
			}
			this.ShowAll();
		}
	}
}
