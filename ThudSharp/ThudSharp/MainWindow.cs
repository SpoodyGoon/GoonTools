using System;
using Gtk;

namespace ThudSharp
{

	public partial class MainWindow: Gtk.Window
	{	
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();	
			
			this.ShowAll();
		}
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;
		}
	
		protected virtual void OnNewActionActivated (object sender, System.EventArgs e)
		{
			gameboard1.StartGame();
			this.ShowAll();
		}
	
		protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
		{
			Application.Quit();
		}
	
		protected virtual void OnAboutActionActivated (object sender, System.EventArgs e)
		{
		}
		
		public void SelectNotify(MovablePieceType mpt, uint row, uint col)
		{
			Console.WriteLine("Active notify");
		}
	}
}