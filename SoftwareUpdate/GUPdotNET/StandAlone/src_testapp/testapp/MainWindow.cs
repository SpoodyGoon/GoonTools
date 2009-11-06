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
using so = System.IO;
using System.Reflection;
using System.Configuration;
using Gtk;
public partial class MainWindow: Gtk.Window
{
	private string _TempSaveFile = string.Empty;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly ();
		System.IO.FileInfo fi = new System.IO.FileInfo(asm.Location);
		_TempSaveFile = so.Path.Combine(fi.Directory.FullName, "ExecFile.txt");
		
		if(so.File.Exists(_TempSaveFile))
		{
			so.StreamReader sr = new so.StreamReader(_TempSaveFile);
			GUPdotNETFile.SetFilename(sr.ReadToEnd());
			sr.Close();
		}
		
		GUPdotNETFile.FileSet += new EventHandler(GUPdotNETFile_FileSet);
	}

	private void GUPdotNETFile_FileSet(object sender, EventArgs e)
	{
		try
		{
			so.StreamWriter sw = new so.StreamWriter(_TempSaveFile, false);
			sw.Write(GUPdotNETFile.Filename);
			sw.Close();
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
		}
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
			if(so.File.Exists(GUPdotNETFile.Filename))
			{
				System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
				si.ErrorDialog = true;
				si.UseShellExecute = false;
				si.FileName = GUPdotNETFile.Filename;
				si.Arguments += "updatecheck";
				System.Diagnostics.Process.Start(si);
			}

		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString() ,"Error");
			md.Run();
			md.Destroy();
		}
	}
	
	
	protected virtual void OnBtnOptionsClicked (object sender, System.EventArgs e)
	{
		try
		{
			System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo();
			si.ErrorDialog = true;
			si.FileName = GUPdotNETFile.Filename;
			si.UseShellExecute = false;
			System.Diagnostics.Process.Start(si);
		}
		catch(Exception ex)
		{
			Gtk.MessageDialog md = new Gtk.MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, ex.ToString(), "An Error Has Occured.");
			md.Run();
			md.Destroy();
		}
	}
}