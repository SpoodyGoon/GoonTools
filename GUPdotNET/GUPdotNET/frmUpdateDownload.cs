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
using System.Threading;
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	
	
	public partial class frmUpdateDownload : Gtk.Dialog
	{
		
		private UpdateCheck _GUPdotNET;
		private long _FileSize = 0;
		private long _Downloaded = 0;
		private bool _ThreadActive = true;
		public frmUpdateDownload(UpdateCheck gdn)
		{
			this.Build();
			_GUPdotNET = gdn;
			try
			{
				
				this.progressbar1.DoubleBuffered= true;
				this.Title =_GUPdotNET.ProgramName;
				this.lblProgramTitle.Text = "<span size=\"xx-large\"><b>" + _GUPdotNET.ProgramName + "</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "Downloading the update for " + _GUPdotNET.ProgramName + ".\r\nPlease be patient.";
				this.ShowNow();
				//bool blnTestWrite = TestReadWriteFile();
				//GLib.Timeout.Add(10, new GLib.TimeoutHandler(UpdateProgress));			
				System.Threading.Thread.Sleep(1000);
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
			Thread firstRunner = new Thread (new ThreadStart (this.GetUpdateFile));
			
			// Starting our two threads. Thread.Sleep(10) gives the first Thread
			// 10 miliseconds more time.
			firstRunner.Start ();
			Thread.Sleep (100);

			
		}
		
		private void GetUpdateFile()
		{
			try
			{
				string strLocation = _GUPdotNET.UpdateFileURL;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strLocation);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
				string strFilePath = System.IO.Path.GetTempPath() + System.IO.Path.PathSeparator.ToString() + strLocation.Substring(strLocation.LastIndexOf("/") + 1, strLocation.Length - (strLocation.LastIndexOf("/") +1));
				Console.WriteLine("got here " + strFilePath + " upload file loc " + strLocation);
				_FileSize = wsp.ContentLength;
				FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);
				long lgFileProgress = 0;
				
				byte[] b = new byte[2048];
		         while (true)
		         {
		            int n = s.Read(b, 0, b.Length);
		            _Downloaded = lgFileProgress += b.Length;
					UpdateProgressFraction((float)_Downloaded/_FileSize);
		            //Console.WriteLine("Downloaded " + _Downloaded.ToString() + " File Size " + this._FileSize.ToString());
		            if (n > 0)
		            {
		               fs.Write(b, 0, n);
		            }
		            else
		               break;
		         }
		         s.Close();
		         fs.Close();
				System.Diagnostics.Process.Start(strFilePath);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
	      
		}
		
		void UpdateProgressFraction(float f) {
		    Application.Invoke(delegate {
		        progressbar1.Fraction = f;
	    });
		
		private bool TestReadWriteFile()
		{
			bool blnCanWrite = true;
			try
			{
				byte[] info = new System.Text.UTF8Encoding(true).GetBytes("Test File");
				System.IO.FileStream fs = new FileStream(_GUPdotNET.ProgramFullPath.Substring(0, _GUPdotNET.ProgramFullPath.LastIndexOf(@"\")), FileMode.OpenOrCreate);
				fs.Write(info, 0, info.Length);
				fs.Close();
				fs.Dispose();
				File.Delete(_GUPdotNET.ProgramFullPath);
			}
			catch(Exception ex)
			{
				blnCanWrite = false;
			}
			return blnCanWrite;
		}

	}
}
