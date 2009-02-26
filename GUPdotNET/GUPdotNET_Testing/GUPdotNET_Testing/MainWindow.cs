// MainWindow.cs
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using GUPdotNET;
using Gtk;
using System.Threading;

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

	protected virtual void OnBtnTestClicked (object sender, System.EventArgs e)
	{
//		MonoToDo.SaveThread.clsSaveTasks sv = new MonoToDo.SaveThread.clsSaveTasks((DataSet)_DataSource, _ToDoPage.CurrTimeTaskID);
//				Thread thrSave = new Thread(new ThreadStart(sv.SaveAll) );
//				thrSave.Start();
		//Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess()..ProcessName.ToString());
//		UpdateCheck gdn = new UpdateCheck();
//		gdn.MyInstallType = InstallType.Windows;
//		gdn.CurrentMajorVersion = 0;
//		gdn.CurrentMinorVersion = 1;
//		gdn.ProgramName = "GUPdotNet Test";
//		gdn.UpdateInfoURL = "http://brdstudio.net/gupdotnet/GetUpdateInfo.aspx";
//		gdn.CallingProcess = System.Diagnostics.Process.GetCurrentProcess();
		//System.Diagnostics.Process proc = new System.Diagnostics.Process();
		
		//System.Diagnostics.Process.Start(gdn.RunCheck());
	}
}