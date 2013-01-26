using System;

namespace libMonoTools.ErrorManager
{
	public abstract class ErrorManagement
	{
		protected string BugTrackingURL = "";
		protected string NewTicketURL = "";
        protected string ErrorLogPath = "";

        public virtual void Initalize()
        {
            ErrorSettings.BugReportSiteURL = BugTrackingURL;
            ErrorSettings.BugSubmitUrl = NewTicketURL;
            ErrorSettings.ErrorLogFile = ErrorLogPath;
        }

        #region Error Handling Methods
        
        public virtual void HandleError(System.Exception ex)
        {
            HandleError(null, ex);          
        }
        
        public virtual void HandleError(Gtk.Window ParentWindow, System.Exception ex)
        {
            ErrorManager.dlgErrorMessage dlg = new ErrorManager.dlgErrorMessage(ParentWindow, ex.ToString());
            dlg.Run();
            dlg.Destroy();
        }
        
        public virtual void HandleError(Gtk.Window ParentWindow, System.Exception ex, params ErrorManager.ErrorManagerFlags[] ErrorFlags)
        {
            ErrorManager.dlgErrorMessage dlg = new ErrorManager.dlgErrorMessage(ParentWindow, ex.ToString());
            dlg.Run();
            dlg.Destroy();
        }

        #endregion Error Handling Methods

        #region Error Log Display Methods
        
        public virtual void ShowErrorLogViewer()
        {
            ShowErrorLogViewer(null);
        }
        
        public virtual void ShowErrorLogViewer(Gtk.Window ParentWindow)
        {
            ErrorManager.dlgErrorLogViewer dlg = new ErrorManager.dlgErrorLogViewer();
            if(ParentWindow != null)
                dlg.ParentWindow = ParentWindow.GdkWindow;
            dlg.Run();
            dlg.Destroy();
        }

        #endregion Error Log Display Methods
	}
}

