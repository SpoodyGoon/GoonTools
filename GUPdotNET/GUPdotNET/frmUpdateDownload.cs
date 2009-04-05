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
		// return all errors to the main update class
		private string _ErrorMess = null;
		public frmUpdateDownload()
		{
			this.Build();
			try
			{
				this.progressbar1.DoubleBuffered= true;
				this.Title = GUPdotNET.ProgramTitle;
				this.lblProgramTitle.Text = "<span size=\"large\"><b>" + GUPdotNET.ProgramTitle + "</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "Downloading the update for " + GUPdotNET.ProgramTitle + ".\r\nPlease be patient.";
				this.ShowNow();
				StartDownload();
			}
			catch(Exception ex)
			{
				this.Respond(Gtk.ResponseType.Help);
				// if we get a web exception exit the update
				_ErrorMess = "Non Web Response error downloading update " + System.Environment.NewLine + ex.Message;
				this.Hide();
			}
		}
		
        #region Public Properties

		public string TempFilePath
		{
			get{return GUPdotNET.TempInstallerPath;}
		}
		
		public string ErrorMess
		{
			get{return _ErrorMess;}
		}
		
       #endregion Public Properties
		
		private void StartDownload()
		{
			// we don't want to be closing during the download
			// so disable the ok button
			btnOk.Sensitive = false;
			
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
				float fltTemp = 0.0f;
				string strLocation = GUPdotNET.UpdateFileURL;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strLocation);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
				GUPdotNET.TempInstallerPath = System.IO.Path.GetTempPath() + strLocation.Substring(strLocation.LastIndexOf("/") + 1, strLocation.Length - (strLocation.LastIndexOf("/") +1));
				
				_FileSize = wsp.ContentLength;
				FileStream fs = new FileStream(GUPdotNET.TempInstallerPath, FileMode.Create, FileAccess.Write);
				long lgFileProgress = 0;
				
				byte[] b = new byte[2048];
				while (_ThreadActive)
				{
					
					int n = s.Read(b, 0, b.Length);
					_Downloaded = lgFileProgress += n;
						
					if (n > 0)
					{
						fs.Write(b, 0, n);
					}
					else
						break;
					
					// to make sure we don't get any funny filesizes from the web response
					// make sure we don't go over 1.0 for the progress bar
					fltTemp = (float)_Downloaded/_FileSize;
					// Console.WriteLine("fraction " + fltTemp.ToString() + " dowloaded " + _Downloaded.ToString() + " File Size " + _FileSize.ToString());
					if(fltTemp >= 0 && fltTemp <= 1.0) 
					{
						UpdateProgressFraction(fltTemp);
					}
					else if(fltTemp < 1.0)
					{
						UpdateProgressFraction((float)1.0f);
					}
				}
				s.Close();
				fs.Close();
				
				// if the _ThreadActive flag is false that means the users
				// has asked for a cancel close this dialog and return cancel
				if(_ThreadActive == false)
				{
					this.Respond(Gtk.ResponseType.Cancel);
					this.Hide();
				}
				else
				{
					btnOk.Sensitive = true;	
				}
			}
			catch(WebException e)
			{
				this.Respond(Gtk.ResponseType.Help);
				// if we get a web exception exit the update
				_ErrorMess = "Unable to connect to the update web site - " + System.Environment.NewLine + e.Message;
				this.Hide();
			}
			catch(Exception ex)
			{
				this.Respond(Gtk.ResponseType.Help);
				// if we get a web exception exit the update
				_ErrorMess = "Non Web Response error downloading update " + System.Environment.NewLine + ex.Message;
				this.Hide();
			}
			
		}
		
		void UpdateProgressFraction(float f)
		{
			Application.Invoke(delegate {
			                   	progressbar1.Text = f.ToString("p");
			                   	progressbar1.Fraction = f;
			                   	
			                   });
		}

		protected virtual void OnButtonCancelClicked (object sender, System.EventArgs e)
		{
			this.progressbar1.Text = "Canceling Download";
			_ThreadActive = false;
		}

		protected virtual void OnBtnOkClicked (object sender, System.EventArgs e)
		{
			this.Hide();
		}

	}
}
