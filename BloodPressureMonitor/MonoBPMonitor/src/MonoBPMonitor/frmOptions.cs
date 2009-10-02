
using System;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmOptions : Gtk.Dialog
	{
		public frmOptions ()
		{
			this.Build();
			try
			{
				btnOk.GrabFocus();
				spnDefaultHistory.Value = (double)GoonTools.Common.Option.HistoryDefaultShow;
				cbxLimitRecords.Active = GoonTools.Common.Option.LimitHistory;
				cbxLogErrors.Active = GoonTools.Common.Option.SaveErrorLog;
				spnDefaultHistory.Sensitive = GoonTools.Common.Option.LimitHistory;
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			this.ShowAll();
		}

		protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
		{
			SaveChanges();
			this.Hide();
		}

		protected virtual void OnDeleteEvent (object o, Gtk.DeleteEventArgs args)
		{
			this.Respond(Gtk.ResponseType.Ok);
			SaveChanges();
		}
		
		private void SaveChanges()
		{
			try
			{
				GoonTools.Common.Option.LimitHistory = cbxLimitRecords.Active;
				GoonTools.Common.Option.HistoryDefaultShow=Convert.ToInt32(spnDefaultHistory.Value);
				GoonTools.Common.Option.SaveErrorLog= cbxLogErrors.Active;
				GoonTools.Common.SaveOptions();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			
		}		
		
		protected virtual void OnCbxLimitRecordsToggled (object sender, System.EventArgs e)
		{
			spnDefaultHistory.Sensitive = cbxLimitRecords.Active;
		}
				protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}
		protected virtual void OnBtnOkClicked (object sender, System.EventArgs e)
		{			
			SaveChanges();
			this.Hide();
		}



	}
}