//
//  MainWindow.cs
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
using System;
using Gtk;
using libMonoTools;

public partial class MainWindow: Gtk.Window
{   
    public MainWindow(): base (Gtk.WindowType.Toplevel)
    {
        Build();
        nbkMain.CurrentPage = 0;
        this.ShowAll();
    }
    
    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnTbrQuitActivated(object sender, EventArgs e)
    {
        Application.Quit();
    }

    protected void OnTbrHelpActivated(object sender, EventArgs e)
    {
        MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, "Not implemented yet", "Not Impletmented");
        md.Run();
        md.Destroy();
    }

    protected void OnTbrPreferencesActivated(object sender, EventArgs e)
    {
        MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, "Not implemented yet", "Not Impletmented");
        md.Run();
        md.Destroy();
    }

    private bool FileChooserExposed = false;
    protected void OnFcUserDataPathExposeEvent(object o, ExposeEventArgs args)
    {
        if(!FileChooserExposed)
        {
            fcUserDataPath.SetCurrentFolder(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            FileChooserExposed = true;
        }
    }

    protected void OnBtnErrorDialogDisplayClicked(object sender, EventArgs e)
    {
        ErrorTools.HandleError(this, new Exception(txtErrorMessage.Text.Trim()));
    }

    protected void OnBtnErrorLogDisplayClicked(object sender, EventArgs e)
    {
        ErrorTools.ShowErrorLogViewer();
    }
}

