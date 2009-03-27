/*************************************************************************
 *                      frmUpdateDownload.cs
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
using System.IO;
using System.Net;
using System.Security.Permissions;
using System.Diagnostics;
using System.Threading;
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	
	public partial class frmUpdateDownload : Gtk.Dialog
	{
		
		private long _FileSize = 0;
		private long _Downloaded = 0;
		private bool _ThreadActive = true;
		private Thread firstRunner;
		private string _AdminPass = null;
		public frmUpdateDownload()
		{
			this.Build();
			try
			{
				
				this.progressbar1.DoubleBuffered= true;
				this.Title = GUPdotNET.ProgramName;
				this.lblProgramTitle.Text = "<span size=\"large\"><b>" + GUPdotNET.ProgramName + "</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "Downloading the update for " + GUPdotNET.ProgramName + ".\r\nPlease be patient.";
				this.ShowNow();
				StartDownload();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void StartDownload()
		{
			// Creating our two threads. The ThreadStart delegate is points to
			// the method being run in a new thread.
			firstRunner = new Thread (new ThreadStart (this.GetUpdateFile));
			
			//System.Diagnostics.Debug.WriteLine("start download");
			// Starting our two threads. Thread.Sleep(10) gives the first Thread
			// 10 miliseconds more time.
			firstRunner.Start ();
			
		}
		
		private void GetUpdateFile()
		{
			try
			{
				string strLocation = GUPdotNET.UpdateFileURL;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strLocation);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
				string strFilePath = System.IO.Path.GetTempPath() + strLocation.Substring(strLocation.LastIndexOf("/") + 1, strLocation.Length - (strLocation.LastIndexOf("/") +1));
				System.Diagnostics.Debug.WriteLine("download " + strFilePath);
				
				_FileSize = wsp.ContentLength;
				FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);
				long lgFileProgress = 0;
				
				byte[] b = new byte[2048];
				while (_ThreadActive)
				{
					
					int n = s.Read(b, 0, b.Length);
					_Downloaded = lgFileProgress += b.Length;
					UpdateProgressFraction((float)_Downloaded/_FileSize);
					if (n > 0)
					{
						fs.Write(b, 0, n);
					}
					else
						break;
				}
				s.Close();
				fs.Close();
				
				if(_ThreadActive == true)
					StartInstallWin32(System.IO.Path.GetFullPath(strFilePath));
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		void UpdateProgressFraction(float f)
		{
			Application.Invoke(delegate {
			                   	//progressbar1.Text = f.ToString("P");
			                   	System.Diagnostics.Debug.WriteLine("update download");
			                   	
			                   	progressbar1.Fraction = f;
			                   	
			                   });
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			_ThreadActive = false;
		}
		
		private void StartInstallWin32(string strFile)
		{
			bool blnProgramOpen = FindWindow(GUPdotNET.CallingApplication);
			while(blnProgramOpen == true)
			{
				// ask the user to save changes and close calling application
				string strRequest = "To continue the install please save open files and close " + GUPdotNET.ProgramName + " before we continue";
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.OkCancel, false, strRequest);
				md.Run();
				md.Destroy();
				
				blnProgramOpen = FindWindow(GUPdotNET.CallingApplication);				
			}
			
			
			if(HasAccess(GUPdotNET.ProgramFullPath) == false)
			{
				frmSuPass fm = new frmSuPass();
				Gtk.ResponseType rsp = (Gtk.ResponseType)fm.Run();
				if(rsp == ResponseType.Ok)
				{
					_AdminPass = fm.AdminPass;
					frmInstallDialog fm2 = new frmInstallDialog(_AdminPass, strFile);
					fm2.Run();
					fm2.Destroy();
				}
				else
				{
					// TODO: find a path out of the program
				}
				fm.Destroy();
			}
			System.Diagnostics.Process.Start(strFile);
		}
		
		private bool HasAccess(string strPath)
		{
			// assume the user has access
			bool blnHasAccess = true;
			
			FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.AllAccess, strPath);
			try
			{
				f2.Demand();
			}
			catch (System.Security.SecurityException s)
			{
				blnHasAccess = false;
				Console.WriteLine(s.Message);
			}
			return blnHasAccess;
		}
		
		private bool FindWindow(string strProcessName)
		{
			bool blnReturn = false;
			Process[] processes = Process.GetProcessesByName(strProcessName);
			foreach (Process p in processes)
			{
				//IntPtr pFoundWindow = p.MainWindowHandle;
				// Do something with the handle...
				
				// if we get here the process is still running
				blnReturn = true;
			}
			return blnReturn;
		}

	}
}
