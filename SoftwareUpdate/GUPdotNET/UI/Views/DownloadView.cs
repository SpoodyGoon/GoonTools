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
	}
}

