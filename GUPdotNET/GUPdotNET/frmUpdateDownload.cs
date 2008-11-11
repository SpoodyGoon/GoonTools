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
using System.Configuration;
using Gtk;

namespace GUPdotNET
{
	
	
	public partial class frmUpdateDownload : Gtk.Dialog
	{
		
		public frmUpdateDownload()
		{
			this.Build();
			try
			{
				this.progressbar1.DoubleBuffered= true;
				this.Title = ConfigurationManager.AppSettings["MessageBoxTitle"].ToString();
				this.lblProgramTitle.Text = "<span size=\"xx-large\"><b>" + ConfigurationManager.AppSettings["MessageBoxTitle"].ToString() + "</b></span>";
				this.lblProgramTitle.UseMarkup = true;
				this.lblUpdateMessage.Text = "Downloading the update for " + ConfigurationManager.AppSettings["ProgramName"].ToString() + ".\r\nPlease be patient.";
				this.ShowNow();
				System.Threading.Thread.Sleep(1000);
				GetUpdateFile();
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		} 
		
		private void GetUpdateFile()
		{
			try
			{
				string strLocation = GUPdotNET.GetOption("Location");
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strLocation);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				string strFilePath = System.Environment.GetEnvironmentVariable("TEMP") + @"\" + strLocation.Substring(strLocation.LastIndexOf("/") + 1, strLocation.Length - (strLocation.LastIndexOf("/") +1));
				System.Diagnostics.Debug.WriteLine("got here " + strFilePath);
				FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);
				BinaryWriter br = new BinaryWriter(fs);
				long lgFileSize = long.Parse(GUPdotNET.GetOption("FileSize"));
				long lgFileProgress = 0;
				
				byte[] b = new byte[2048];
		         while (true)
		         {
		            int n = s.Read(b, 0, b.Length);
		            lgFileProgress += b.Length;
		            
		            if (n > 0)
		            {
		               fs.Write(b, 0, n);
		               this.progressbar1.Fraction = (lgFileProgress/wsp.ContentLength);			
		               this.progressbar1.ShowNow();
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
	}
}
