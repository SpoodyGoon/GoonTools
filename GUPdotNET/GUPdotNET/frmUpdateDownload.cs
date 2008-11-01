// frmUpdateDownload.cs created with MonoDevelop
// User: spoodygoon at 9:53 PM 6/1/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

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
				string strLocation =MainClass.GetOption("Location");
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strLocation);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				string strFilePath = System.Environment.GetEnvironmentVariable("TEMP") + @"\" + strLocation.Substring(strLocation.LastIndexOf("/") + 1, strLocation.Length - (strLocation.LastIndexOf("/") +1));
				System.Diagnostics.Debug.WriteLine("got here " + strFilePath);
				FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);
				BinaryWriter br = new BinaryWriter(fs);
				long lgFileSize = long.Parse(MainClass.GetOption("FileSize"));
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
