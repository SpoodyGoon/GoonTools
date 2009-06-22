
using System;
using Gtk;

namespace ThudSharp
{
	
	
	[System.ComponentModel.ToolboxItem(true)]
	public partial class BoardPiece : Gtk.Bin
	{
		private string _MovablePiece = "None";
		private bool _AltBackGround = false;
		public BoardPiece()
		{
			this.Build();
			this.eventbox1.EnterNotifyEvent += HandleEnterNotifyEvent;
		}

		void HandleEnterNotifyEvent(object o, EnterNotifyEventArgs args)
		{
			Console.WriteLine("Enter Event");
		}
		
		
		public string MovablePiece
		{
			get{return _MovablePiece;}
			set{_MovablePiece=value;}
		}
		
		public bool AltBackGround
		{
			get{return _AltBackGround;}
			set{_AltBackGround=value;}
		}
		
		
		protected override bool OnExposeEvent (Gdk.EventExpose evnt)
		{
			try
			{
				if(_MovablePiece=="Troll")
				{
					imgMovable.Pixbuf = GoonTools.Common.Troll;
				}
				else if(_MovablePiece == "Dwarf")
				{
					imgMovable.Pixbuf = GoonTools.Common.Dwarf;					
				}
				
				if(_AltBackGround == false)
				{
					imgBackground.Pixbuf = GoonTools.Common.BoardPieceDark;
				}
				else
				{
					imgBackground.Pixbuf = GoonTools.Common.BoardPieceLight;
				}
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
