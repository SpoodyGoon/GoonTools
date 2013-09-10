

namespace GUPdotNET.UI.Views
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using Gtk;
    using io = System.IO;

	internal partial class DownloadView : Gtk.Dialog
	{
		internal DownloadStatus CurrentStatus{ get; private set; }
        private WebClient webClient = new WebClient();
          
		internal DownloadView()
		{
			this.Build();
			this.Initalize();
		}

		private void Initalize ()
		{
			// set the default response to no, only
			// when the download is completed successfully
			// with the response be "Yes" which will keep the
			// update logic flow going.
			this.DefaultResponse = ResponseType.No;
			this.CurrentStatus = DownloadStatus.None;
			this.ActionArea.Hide();
			this.Close += delegate(object sender, EventArgs e)
			{
				this.Respond(ResponseType.No);
				this.Hide();
			};
			this.DeleteEvent += delegate(object o, DeleteEventArgs args)
			{
				this.Respond(ResponseType.No);
				this.Hide();
			};
			this.QueueResize();
			this.QueueDraw();
		}

		protected void OnCancelButtonClicked(object sender, EventArgs e)
		{
            this.webClient.CancelAsync();
		}

		protected void OnHideWindowButtonClicked(object sender, EventArgs e)
		{
            this.Iconify();
		}

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs downloadProgressArgs)
        {
            this.downloadingProgressbar.Fraction = (double)downloadProgressArgs.ProgressPercentage;
            this.downloadingProgressbar.Text = downloadProgressArgs.ProgressPercentage.ToString("P");
            this.downloadingProgressbar.QueueDraw();
        }

        private void DownloadFile()
        {
            this.webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
            this.webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadFileCompleted);
            this.webClient.DownloadFileAsync(new Uri(GlobalTools.PackageInfo.PackageFiles["Installer"].URL), io.Path.Combine(GlobalTools.LocalSystem.TempPackagePath, GlobalTools.PackageInfo.PackageFiles["Installer"].FileName));
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
                this.Respond(ResponseType.No);
				this.Hide();
            }
            else if (asyncCompletedArgs.Error != null)
            {
                this.downloadingProgressbar.Text = "Download Error";
                this.downloadingProgressbar.QueueDraw();
                MessageDialog errorMessage = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, asyncCompletedArgs.Error.Message, "An Error Occured During Download");
                errorMessage.Run();
                errorMessage.Destroy();				
                this.Respond(ResponseType.No);
				this.Hide();
            }
            else
            {
                this.downloadingProgressbar.Fraction = 100.0d;
                this.downloadingProgressbar.Text = "Download Finished";
                this.downloadingProgressbar.QueueDraw();
                System.Threading.Thread.Sleep(1000);
                this.Respond(ResponseType.Yes);
                this.Hide();
            }
        }
	}
}

