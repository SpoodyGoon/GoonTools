using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	private Gtk.Fixed _Fix = new Gtk.Fixed();
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		frame1.Add(_Fix);
		
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