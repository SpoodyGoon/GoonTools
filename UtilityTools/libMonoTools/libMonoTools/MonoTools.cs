//
//  MonoTools.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.


namespace libMonoTools
{
    public static class MonoTools
    {
        public static void Load()
        {
        }
    }

    public static class ErrorTools
    {   
        #region Error Handling
        
        public static void HandleError(System.Exception ex)
        {
            HandleError(null, ex);          
        }
        
        public static void HandleError(Gtk.Window ParentWindow, System.Exception ex)
        {
            ErrorManager.dlgErrorMessage dlg = new ErrorManager.dlgErrorMessage(ParentWindow, ex.ToString());
            dlg.Run();
            dlg.Destroy();
        }
        
        public static void HandleError(Gtk.Window ParentWindow, System.Exception ex, params ErrorManager.ErrorManagerFlags[] ErrorFlags)
        {
            ErrorManager.dlgErrorMessage dlg = new ErrorManager.dlgErrorMessage(ParentWindow, ex.ToString());
            dlg.Run();
            dlg.Destroy();
        }
        
        public static void ShowErrorLogViewer()
        {
            ErrorManager.dlgErrorLogViewer dlg = new ErrorManager.dlgErrorLogViewer();
            dlg.Run();
            dlg.Destroy();
        }
        
        public static void ShowErrorLogViewer(Gtk.Window ParentWindow, System.Exception ex)
        {
            ErrorManager.dlgErrorLogViewer dlg = new ErrorManager.dlgErrorLogViewer();
            if(ParentWindow != null)
                dlg.ParentWindow = ParentWindow.GdkWindow;
            dlg.Run();
            dlg.Destroy();
        }
        
        #endregion Error Handling
    }
}

