// MainWindow.cs created with MonoDevelop
// User: spoodygoon at 5:45 PM 8/13/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnLoadActionActivated (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnQuitActionActivated (object sender, System.EventArgs e)
	{
		Application.Quit ();		
	}

	protected virtual void OnSaveActionActivated (object sender, System.EventArgs e)
	{
	}
}