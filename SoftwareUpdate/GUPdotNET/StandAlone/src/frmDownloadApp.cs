/*************************************************************************
 *                      frmDownloadApp.cs
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
	
	public class frmDownloadApp : Gtk.Dialog
	{
		private UpdateInfo _UpdateInfo;	
		#region GUI Widgets
		private Gtk.Button btnCancel = new Gtk.Button(Stock.Cancel);
		private Gtk.ProgressBar pgbDownload = new Gtk.ProgressBar();
		private Gtk.Fixed fx1 = new Gtk.Fixed();
		#endregion GUI Widgets
		private long _FileSize = 0;
		private long _Downloaded = 0;
		private bool _ThreadActive = true;
		private Thread firstRunner;
		public frmDownloadApp(UpdateInfo updateinfo)
		{
			_UpdateInfo = updateinfo;
			
			
		}
		
		protected override void OnShown ()
		{
			try
			{
				this.ModifyBg(Gtk.StateType.Normal, new Gdk.Color(0, 0,0));
				this.HeightRequest = 200;
				this.WidthRequest= 450;
				this.Move(350, 10);
				
				
				fx1.BorderWidth = 6;
				fx1.ModifyBg(Gtk.StateType.Normal, new Gdk.Color(190, 195,235));
				pgbDownload.Text = "Downloading";
				pgbDownload.DoubleBuffered = true;
				pgbDownload.WidthRequest = 120;
				pgbDownload.HeightRequest=30;
				fx1.Put(pgbDownload, 100, 10);
				fx1.Put(btnCancel, 100, 150);
				this.VBox.Add(fx1);
				this.QueueDraw();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, ex);
			}
			base.OnShown ();
		}

		
		private string GetUniqueFileName(string updatefileurl)
		{
			// see if the file has a uniqe name in the systems temp directory
			// if so return it
			if(!File.Exists(System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileName(updatefileurl))))
				return System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileName(updatefileurl));
			
			// if we get here we need to get a unique file name for the temperary file
			int FileCount = 1; // incremented to until it + file name is unique
			string tmpDir = System.IO.Path.GetTempPath();
			string tmpFileName = System.IO.Path.GetFileNameWithoutExtension(updatefileurl);
			string tmpExtention = System.IO.Path.GetExtension(updatefileurl);
			// loop through until it's a unique name
			while(File.Exists(System.IO.Path.Combine(tmpDir, tmpFileName + FileCount.ToString() + tmpExtention)))
			{
				FileCount++;
			}
			return System.IO.Path.Combine(tmpDir, tmpFileName + FileCount.ToString() + tmpExtention);
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
				float fltTemp = 0.0f;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(_UpdateInfo.UpdateFileURL);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
				_FileSize = wsp.ContentLength;
				FileStream fs = new FileStream(_UpdateInfo.TempInstallerPath, FileMode.Create, FileAccess.Write);
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
					this.Respond(Gtk.ResponseType.Ok);
					this.Present();
					this.GrabFocus();
					this.Visible = false;
					this.ShowAll();
					this.Hide();
					
				}
			}
			catch(WebException e)
			{
				Common.HandleError(this, new Exception("Unable to connect to the update web site - " + System.Environment.NewLine + e.Message));
				this.Respond(Gtk.ResponseType.Cancel);
				this.Hide();
			}
			catch(Exception ex)
			{
				Common.HandleError(this, new Exception("Non Web Response error downloading update " + System.Environment.NewLine + ex.Message));
				this.Respond(Gtk.ResponseType.Cancel);
				this.Hide();
			}
		}
		
		private void UpdateProgressFraction(float f)
		{
			Application.Invoke(delegate {
			                   	pgbDownload.Text = f.ToString("p");
			                   	pgbDownload.Fraction = f;
			                   	
			                   });
		}
		
		protected virtual void OnBtnHideClicked (object sender, System.EventArgs e)
		{
			// TODO: add method to iconify this dialog
		}
		
		protected virtual void OnBtnCancelClicked (object sender, System.EventArgs e)
		{
			this.pgbDownload.Text = "Canceling Download";
			this.pgbDownload.ShowNow();
			_ThreadActive = false;
		}
	}
}
