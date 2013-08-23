using System;
using io = System.IO;
using System.Net;
using System.ComponentModel;
using Gtk;

namespace GUPdotNET.UI.Views
{
	public partial class DownloadView : Gtk.Dialog
	{
		public DownloadStatus CurrentStatus{ get; private set; }
		public DownloadView()
		{
			this.Build();
			this.CurrentStatus = DownloadStatus.None;
		}

        private void DownloadFile()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadFileCompleted);
            webClient.DownloadFileAsync(new Uri(GlobalTools.PackageInfo.PackageFiles["Installer"].URL), io.Path.Combine(GlobalTools.LocalSystem.TempPackagePath, GlobalTools.PackageInfo.PackageFiles["Installer"].FileName));
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs asyncCompletedArgs)
        {
            if (asyncCompletedArgs.Cancelled)
            {
                this.downloadingProgressbar.Text = "Download Canceled";
                this.downloadingProgressbar.QueueDraw();
                MessageDialog errorMessage = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, Gtk.ButtonsType.Ok, false, "Download Canceled", "Download Canceled");
                errorMessage.Run();
                errorMessage.Destroy();
            }
            else if (asyncCompletedArgs.Error != null)
            {
                this.downloadingProgressbar.Text = "Download Error";
                this.downloadingProgressbar.QueueDraw();
                MessageDialog errorMessage = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, asyncCompletedArgs.Error.Message, "An Error Occured During Download");
                errorMessage.Run();
                errorMessage.Destroy();
            }
            else
            {
                this.downloadingProgressbar.Fraction = 100.0d;
                this.downloadingProgressbar.Text = "Download Finished";
                this.downloadingProgressbar.QueueDraw();
                System.Threading.Thread.Sleep(1000);
                this.Respond(ResponseType.Ok);
                this.Hide();
            }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressArgs)
        {
            this.downloadingProgressbar.Fraction = (double)downloadProgressArgs.ProgressPercentage;
            this.downloadingProgressbar.Text = downloadProgressArgs.ProgressPercentage.ToString("P");
            this.downloadingProgressbar.QueueDraw();
        }

		protected void OnCancelButtonClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void OnHideWindowButtonClicked(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}

