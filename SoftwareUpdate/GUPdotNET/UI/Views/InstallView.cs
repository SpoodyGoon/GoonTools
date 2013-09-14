using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace GUPdotNET.UI.Views
{
	internal partial class InstallView : Gtk.Dialog
	{
		private const string installMessage = "Starting Install {0} version {1}.";

		private const string installWindowTitle = "Installing {0} {1}";

		private const string installTitle = "<b><big>Installing {0} {1}</big></b>";

		private bool installComplete = false;

		internal InstallView ()
		{
			this.Build ();
			this.Initalize ();
		}

		private void Initalize ()
		{
			this.Title = string.Format (installWindowTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString ());
			this.titleLabel.Text = string.Format (installTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString ());
			this.processOverviewLabel.Text = string.Format (installMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString ());
			this.installDetailsTextview.Buffer.Text += "Starting Update Process..." + Environment.NewLine;
			this.closeWindowButton.Hide ();
			this.cancelInstallButton.Show ();
			this.DefaultResponse = Gtk.ResponseType.No;
			this.DeleteEvent += delegate(object o, Gtk.DeleteEventArgs args)
			{
				this.Respond(Gtk.ResponseType.No);
				this.Hide();
			};
			this.QueueDraw ();
		}

		private void InstallProcessRun ()
		{
			// install the files in order from the package file list.
			// TODO: much more work on this.
			foreach (var file in GlobalTools.PackageInfo.PackageFiles.Where(f => f.Key.Equals("Installer")).Select(f => f.Value))
			{
				this.installDetailsTextview.Buffer.Text += "Starting " + file.FileType + " " + file.FileName + Environment.NewLine;
				Process.Start(file.FileName);
			}
		}

		protected void OnCloseWindowButtonClicked (object sender, EventArgs e)
		{
			if (this.installComplete)
			{
				this.Respond (Gtk.ResponseType.Yes);
				this.Hide ();
			}
			else
			{
				this.Respond (Gtk.ResponseType.No);
				this.Hide ();
			}
		}

		protected void OnCancelInstallButtonClicked (object sender, EventArgs e)
		{
			this.Respond (Gtk.ResponseType.No);
			this.Hide ();
		}

		protected void OnDetailsExpanderActivated (object sender, EventArgs e)
		{
			this.QueueResize ();
			this.QueueDraw ();
		}

	}
}

