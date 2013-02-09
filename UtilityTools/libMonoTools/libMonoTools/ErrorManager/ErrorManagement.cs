using System;

namespace libMonoTools
{
    public static class ErrorTools
    {
        internal static ErrorSettings ErrorToolSettings;

        public static void Initalize (ErrorSettings settings)
        {
           ErrorToolSettings = settings;
        }
        
        public static void Initalize (params string[] settings)
        {
            try
            {
                if(settings.Length < 3)
                    throw new IndexOutOfRangeException("Settings paramaters not suffecent length to carry the required info");

                ErrorToolSettings = new ErrorSettings(settings[0], settings[1], settings[2]);
            }
            catch(Exception err)
            {  
                FailsafeErrorDialog(err);
            }
        }

        #region Error Handling Methods
        
        public static void HandleError (System.Exception ex)
        {
            HandleError(null, ex);          
        }
        
        public static void HandleError (Gtk.Window ParentWindow, System.Exception ex)
        {
            try
            {
                ErrorManager.dlgErrorMessage dlg = new ErrorManager.dlgErrorMessage(ParentWindow, ex.ToString());
                dlg.Run();
                dlg.Destroy();
            }
            catch(Exception err)
            {  
                FailsafeErrorDialog(ParentWindow, err);
            }
        }
        
        public static void HandleError (Gtk.Window ParentWindow, System.Exception ex, params ErrorManager.ErrorManagerFlags[] ErrorFlags)
        {
            try
            {
                ErrorManager.dlgErrorMessage dlg = new ErrorManager.dlgErrorMessage(ParentWindow, ex.ToString());
                dlg.Run();
                dlg.Destroy();
            }
            catch(Exception err)
            {  
                FailsafeErrorDialog(ParentWindow, err);
            }
        }

        #endregion Error Handling Methods

        #region Error Log Display Methods
        
        public static void ShowErrorLogViewer ()
        {
            ShowErrorLogViewer(null);
        }
        
        public static void ShowErrorLogViewer (Gtk.Window ParentWindow)
        {
            try
            {
                ErrorManager.dlgErrorLogViewer dlg = new ErrorManager.dlgErrorLogViewer();
                if(ParentWindow != null)
                    dlg.ParentWindow = ParentWindow.GdkWindow;
                dlg.Run();
                dlg.Destroy();
            }
            catch(Exception ex)
            {  
                FailsafeErrorDialog(ParentWindow, ex);
            }
        }

        #endregion Error Log Display Methods

        #region Failsafe Error Dialog

        internal static void FailsafeErrorDialog (Gtk.Window ParentWindow, System.Exception ex)
        {              
            Gtk.MessageDialog md = new Gtk.MessageDialog(ParentWindow, Gtk.DialogFlags.Modal | Gtk.DialogFlags.DestroyWithParent, Gtk.MessageType.Error, Gtk.ButtonsType.Ok, false, "An Error has occured in the Error Manager, how ironic is that." + Environment.NewLine + Environment.NewLine + ex.ToString(), "An Error Has Occured.");
            md.Run();
            md.Destroy();
        }
        
        internal static void FailsafeErrorDialog (System.Exception ex)
        {              
            FailsafeErrorDialog(null, ex);
        }
        
        internal static void FailsafeErrorDialog (string ErrorMessage)
        {              
            FailsafeErrorDialog(null, new System.Exception(ErrorMessage));
        }

        #endregion Failsafe Error Dialog
    }
}

