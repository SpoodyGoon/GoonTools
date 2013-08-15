using System;

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

