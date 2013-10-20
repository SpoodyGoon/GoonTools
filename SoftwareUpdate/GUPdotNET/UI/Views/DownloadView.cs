

namespace GUPdotNET.UI.Views
{
    using System;
    using System.ComponentModel;
    using System.Net;
    using Gtk;
    using io = System.IO;

    internal partial class DownloadView : Gtk.Dialog
    {
        private WebClient webClient = new WebClient();

        internal DownloadView()
        {
            this.Build();
            this.Initalize();
            this.DownloadFile();
        }

        private void Initalize()
        {
            try
            {
                // set the default response to no, only
                // when the download is completed successfully
                // with the response be "Yes" which will keep the
                // update logic flow going.
                this.DefaultResponse = ResponseType.No;
                this.ActionArea.Hide();
                this.Close += delegate(object sender, EventArgs e)
                {
                    this.Respond(ResponseType.No);
                };
                this.DeleteEvent += delegate(object o, DeleteEventArgs args)
                {
                    this.Respond(ResponseType.No);
                };
                this.QueueResize();
                this.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
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
            try
            {
                this.downloadingProgressbar.Fraction = (double)(downloadProgressArgs.ProgressPercentage * 0.01);
                this.downloadingProgressbar.Text = (downloadProgressArgs.ProgressPercentage * 0.01).ToString("P");
                this.downloadingProgressbar.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        private void DownloadFile()
        {
            try
            {
                if (string.IsNullOrEmpty(GlobalTools.PackageInfo.InstallerURL))
                {
                    throw new Exception("URL for the update package is missing.");
                }

                Uri installerUri = new Uri(GlobalTools.PackageInfo.InstallerURL);
                this.webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
                this.webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadFileCompleted);
                this.webClient.DownloadFileAsync(installerUri, GlobalTools.ToLocalFile(installerUri));
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
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
            }
            else if (asyncCompletedArgs.Error != null)
                {
                    this.downloadingProgressbar.Text = "Download Error";
                    this.downloadingProgressbar.QueueDraw();
                    GlobalTools.HandleError(this, asyncCompletedArgs.Error);		
                    this.Respond(ResponseType.No);
                }
                else
                {
                    this.downloadingProgressbar.Fraction = 1.0d;
                    this.downloadingProgressbar.Text = "Download Finished";
                    this.downloadingProgressbar.QueueDraw();
                    System.Threading.Thread.Sleep(1000);
                    webClient.Dispose();
                    this.Respond(ResponseType.Yes);
                }
        }
    }
}

