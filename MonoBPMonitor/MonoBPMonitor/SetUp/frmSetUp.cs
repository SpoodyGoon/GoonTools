
using System;
using Gtk;
using GoonTools;
using SQLiteDataProvider;

namespace MonoBPMonitor
{	
	public partial class frmSetUp : Gtk.Dialog
	{
		public frmSetUp()
		{
			this.Build();
			
		}
		
		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			
		}
		
		protected virtual void OnBtnBackClicked (object sender, System.EventArgs e)
		{			
			
		}

		protected virtual void OnBtnForwardClicked (object sender, System.EventArgs e)
		{	
			
		}

		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			
		}

		protected virtual void OnBtnDefaultsClicked (object sender, System.EventArgs e)
		{
			this.Respond(Gtk.ResponseType.None);
			this.Hide();
		}
	}
}
