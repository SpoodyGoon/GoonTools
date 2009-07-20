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

	protected virtual void OnBtnTestAssemblyClicked (object sender, System.EventArgs e)
	{
		Assembly assm= Assembly.GetExecutingAssembly();
		GUPdotNET.GUPdotNET.CallingApplication = assm.GetName().FullName;
		GUPdotNET.GUPdotNET.ProgramFullPath = Assembly.GetEntryAssembly().CodeBase;
		GUPdotNET.GUPdotNET.CurrentMajorVersion = 0;
		GUPdotNET.GUPdotNET.CurrentMinorVersion = 1;
		GUPdotNET.GUPdotNET.InstallType = "Win32";
		GUPdotNET.GUPdotNET.ProgramName = "GUPdotNET Testing";
		GUPdotNET.GUPdotNET.UpdateInfoURL = @"http://brdstudio.net/gupdotnet/GetUpdateInfo.aspx";
		UpdateCheck up = new UpdateCheck();
		up.RunCheck();
	}

	protected virtual void OnBtnTestProcWithArgsClicked (object sender, System.EventArgs e)
	{
	}

	protected virtual void OnBtnTestProcNoArgsClicked (object sender, System.EventArgs e)
	{
		Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Got Here");
		md.Run();
		md.Destroy();
		System.Diagnostics.Process.Start(Assembly.GetEntryAssembly().CodeBase + System.IO.Path.DirectorySeparatorChar.ToString() + "GUPdotNET.exe");
	}
}