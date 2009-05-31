using System;
using Gtk;

namespace ThudSharp
{

	public partial class MainWindow: Gtk.Window
	{	
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
			//BuildGameBoard();			
			this.ShowAll();
		}
		
		private void BuildGameBoard()
		{
			// add the back ground
			ThudGameBoard tg = new ThudGameBoard();			
			fixGameArea.Add(tg);
			(((Gtk.Fixed.FixedChild)(this.fixGameArea[tg]))).X = 0;
			(((Gtk.Fixed.FixedChild)(this.fixGameArea[tg]))).Y = 0;
			
			Gtk.Table tb = new Gtk.Table((uint)15, (uint)15, true);
			
			tb.Attach(new StaticBoardPiece(), (uint)5, (uint)6, (uint)0, (uint)1); 
			fixGameArea.Add(tb);
			
			//StaticBoardPiece sp = new StaticBoardPiece(StaticPieceType.Dark, 0, 0);
			//fixGameArea.Add(sp);
			//Gtk.Fixed.FixedChild fc2 = ((Gtk.Fixed.FixedChild)(this.fixGameArea[sp]));
            //fc2.X = 50;
            //fc2.Y = 50;	
		}
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	
		protected virtual void OnNewActionActivated (object sender, System.EventArgs e)
		{
		}
	
		protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			Application.Quit();
		}
	
		protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
		{
		}
	}
}