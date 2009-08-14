/*************************************************************************
 *                      MainWindow.cs
 *
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>
 *
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

using System;
using System.Reflection;
using System.Configuration;
using GUPdotNET;
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

	protected virtual void OnBtnQuitClicked (object sender, System.EventArgs e)
	{
		Gtk.Application.Quit();
	}
	
	protected virtual void OnBtnTestClicked (object sender, System.EventArgs e)
	{
		try
		{
			System.Reflection.Assembly assm = System.Reflection.Assembly.GetExecutingAssembly();
			UpdateCheck up = new UpdateCheck();
			up.InstallType = cboInstallType.ActiveText;
			up.ProgramTitle =  txtProgramTitle.Text;
			up.ProgramName =  txtProgramName.Text;
			// this is the full path to the program i.e. C:/MyDocuments/MyProgramFolder/
			up.ProgramFullPath = assm.GetName().CodeBase;
			// this is the actual name of the program i.e. MyProgram.exe
			up.UpdateInfoURL =  ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
			up.CurrentMajorVersion = spnMajor.ValueAsInt;
			up.CurrentMinorVersion = spnMinorVersion.ValueAsInt;;
			up.SilentCheck = (bool)cbxSilent.Active;
			up.RunUpdateCheck();
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString() ,"Error");
			md.Run();
			md.Destroy();
		}
	}
}