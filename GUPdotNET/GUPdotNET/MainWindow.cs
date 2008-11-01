// MainWindow.cs created with MonoDevelop
// User: spoodygoon at 7:28 PM 6/1/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Configuration;
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
}
