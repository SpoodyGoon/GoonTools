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

	protected virtual void OnBtnClearFilterClicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnBtnRemoveClicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnBtnAddListClicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnCbxOnlyActiveClicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnTxtFilterTextInserted (object o, Gtk.TextInsertedArgs args)
	{
	}

	protected virtual void OnTxtFilterTextDeleted (object o, Gtk.TextDeletedArgs args)
	{
	}
}