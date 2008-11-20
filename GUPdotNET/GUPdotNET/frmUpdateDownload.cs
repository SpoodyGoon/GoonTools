// File: frmUpdateDownload
//
//  Copyright (C) 2008 SpoodyGoon
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 


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
				System.Threading.Thread.Sleep(3000);
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
			Thread secondRunner = new Thread (new ThreadStart (this.UpDateProgressBar));
			
			// Starting our two threads. Thread.Sleep(10) gives the first Thread
			// 10 miliseconds more time.
			firstRunner.Start ();
			Thread.Sleep (100);
			secondRunner.Start ();

			
		}
		
		private void GetUpdateFile()
		{
			try
			{
				string strLocation = _GUPdotNET.UpdateFileURL;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strLocation);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				string strFilePath = System.Environment.GetEnvironmentVariable("TEMP") + @"\" + strLocation.Substring(strLocation.LastIndexOf("/") + 1, strLocation.Length - (strLocation.LastIndexOf("/") +1));
				//System.Diagnostics.Debug.WriteLine("got here " + strFilePath);
				_FileSize = wsp.ContentLength;
				FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);
				long lgFileProgress = 0;
				
				byte[] b = new byte[2048];
		         while (true)
		         {
		            int n = s.Read(b, 0, b.Length);
		            _Downloaded = lgFileProgress += b.Length;
		            
		            if (n > 0)
		            {
		               fs.Write(b, 0, n);
		            }
		            else
		               break;
		         }
		         s.Close();
		         fs.Close();
				this.progressbar1.Text = "Done";
				//System.Diagnostics.Process.Start(strFilePath);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
	      
		}
		
		private void UpDateProgressBar()
		{
			GLib.Timeout.Add(10, new GLib.TimeoutHandler(UpdateProgress));			
		}
		
		private bool UpdateProgress()
		{
			if(_Downloaded > 0 && _FileSize > 0)
			{
				this.progressbar1.Fraction = (_Downloaded/_FileSize);			
		    	this.progressbar1.ShowNow();
			}
		    return _ThreadActive;
		}
	}
}
