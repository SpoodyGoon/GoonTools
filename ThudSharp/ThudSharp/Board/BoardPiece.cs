
using System;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class BoardPiece : Gtk.Bin
	{
		private string _MovablePiece = "None";
		private string _BackGround = "None";
		private bool _Blank = true;
		public BoardPiece()
		{
			this.Build();
			
//			MovablePieceType mpt = MovablePieceType.None;
//			if(_MovablePiece=="Troll")
//			{
//				mpt = MovablePieceType.Troll;
//			}
//			else if(_MovablePiece == "Dwarf")
//			{
//				mpt = MovablePieceType.Dwarf;
//			}
//			MovablePiece mp = new MovablePiece(mpt);
//			fxContainer.Add(mp);
//			Gtk.Fixed.FixedChild we6 = ((Gtk.Fixed.FixedChild)(fxContainer[mp]));
//			we6.X = 0;
//			we6.Y = 0;
			this.ShowAll();
		}
		
		public string MovablePiece
		{
			get{return _MovablePiece;}
			set{_MovablePiece=value;}
		}
		
		public string BackGround
		{
			get{return _BackGround;}
			set{_BackGround=value;}
		}
		
		public bool Blank
		{
			get{return _Blank;}
			set{_Blank=value;}
		}
		
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			try
			{
				if(_Blank == false)
				{				
					if(_BackGround == "Dark")
					{
						imgBackground.Pixbuf = GoonTools.Common.BoardPieceDark;
					}
					else
					{
						imgBackground.Pixbuf = GoonTools.Common.BoardPieceLight;
					}
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

		
	}
}
