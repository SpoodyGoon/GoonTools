
using System;
using Gtk;
using GoonTools;

namespace MonoBPMonitor
{
	
	
	public partial class frmOptions : Gtk.Dialog
	{
		public frmOptions ()
		{
			// TODO: add checkbox to not have any sort at all.
			this.Build();
			
			spnDefaultHistory.Value = (double)GoonTools.Common.Option.HistoryDefaultShow;
			cbxLimitRecords.Active = GoonTools.Common.Option.LimitHistory;
			cbxLogErrors.Active = GoonTools.Common.Option.SaveErrorLog;
			spnDefaultHistory.Sensitive = GoonTools.Common.Option.LimitHistory;
			btnApply.Clicked += new EventHandler(btnApply_Clicked);
			btnOk.Clicked += new EventHandler(btnOk_Clicked);
			this.ShowAll();
		}

		protected virtual void btnOk_Clicked (object sender, System.EventArgs e)
		{
			SaveChanges();
			this.Hide();
		}

		protected void btnApply_Clicked(object sender, EventArgs e)
		{
			SaveChanges();
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
			GoonTools.Common.Option.LimitHistory = cbxLimitRecords.Active;
			GoonTools.Common.Option.HistoryDefaultShow=Convert.ToInt32(spnDefaultHistory.Value);
			GoonTools.Common.Option.SaveErrorLog= cbxLogErrors.Active;
			GoonTools.Common.SaveOptions();
			
		}
		
		
		protected virtual void OnCbxLimitRecordsToggled (object sender, System.EventArgs e)
		{
			spnDefaultHistory.Sensitive = cbxLimitRecords.Active;
		}
	}
}