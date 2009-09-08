
using System;

namespace MonoBPMonitor
{
	
	
	public partial class frmOptions : Gtk.Dialog
	{

		public frmOptions()
		{
			// TODO: add checkbox to not have any sort at all.
			this.Build();
			spnDefaultHistory.Value = (double)GoonTools.Common.Option.HistoryDefaultShow;
			cbxLogErrors.Active = GoonTools.Common.Option.SaveErrorLog;
				
		}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			SaveChanges(); 
			this.Hide();
		}
		
		protected virtual void OnClose (object sender, System.EventArgs e)
		{
			SaveChanges();
		}

		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			SaveChanges();
		}
		
		private void SaveChanges()
		{
			// no matter what happens just save the changes 
			// when we close
			GoonTools.Common.Option.HistoryDefaultShow=Convert.ToInt32(spnDefaultHistory.Value);
			GoonTools.Common.Option.SaveErrorLog= cbxLogErrors.Active;
			GoonTools.Common.SaveOptions();
				
				
		}
	}
}
