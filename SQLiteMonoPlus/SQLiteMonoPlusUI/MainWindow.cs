using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	#region Application Shutdown

	protected void Quit_Clicked (object sender, System.EventArgs e)
	{
		ShutdownApp();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		ShutdownApp();
		a.RetVal = true;
	}
	
	private void ShutdownApp()
	{
		Application.Quit();
	}
	
	#endregion Application Shutdown
}
