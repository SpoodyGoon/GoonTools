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
        private const string processRunningTitle = "{0} Needs to Close";
        private const string processRunning = "{0} needs to close to install the new update.";
        private bool installComplete = false;

        internal InstallView()
        {
            this.Build();
            this.Initalize();
            System.Threading.Thread.Sleep(2000);
            this.InstallProcessRun();
        }

        private void Initalize()
        {
            try
            {
                this.Title = string.Format(installWindowTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.titleLabel.LabelProp = string.Format(installTitle, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.processOverviewLabel.LabelProp = string.Format(installMessage, GlobalTools.ProgramInfo.ProgramTitle, GlobalTools.PackageInfo.UpdateVersion.ToString());
                this.installDetailsTextview.Buffer.Text += "Starting Update Process..." + Environment.NewLine;
                this.closeWindowButton.Hide();
                this.cancelInstallButton.Show();
                this.DefaultResponse = Gtk.ResponseType.No;
                this.DeleteEvent += delegate(object o, Gtk.DeleteEventArgs args)
                {
                    this.Respond(Gtk.ResponseType.No);
                    this.Hide();
                };
                this.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        private void InstallProcessRun()
        {
            // TODO: find the application being supported in the process list
            // AND GUPdotNET to see if they are being ran
            try
            {
//                var processes = Process.GetProcesses().Select(p => p.ProcessName.Contains(GlobalTools.ProgramInfo.ProgramFileName)).ToList();
//                if (processes != null)
//                {
//                    Gtk.MessageDialog processDialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, Gtk.ButtonsType.OkCancel, false, string.Format(processRunning, GlobalTools.ProgramInfo.ProgramName), string.Format(processRunningTitle, GlobalTools.ProgramInfo.ProgramName));
//                    processDialog.Run();
//                    processDialog.Destroy();
//                }

                string installerPath = GlobalTools.ToLocalFile(GlobalTools.PackageInfo.InstallerURL);
                // start the installer running
                this.installDetailsTextview.Buffer.Text += "Starting Update Installer..." + Environment.NewLine;
                Process.Start(installerPath);
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        /// <summary>
        /// Raises the close window button clicked event.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnCloseWindowButtonClicked(object sender, EventArgs args)
        {
            if (this.installComplete)
            {
                this.Respond(Gtk.ResponseType.Yes);
                this.Hide();
            }
            else
            {
                this.Respond(Gtk.ResponseType.No);
                this.Hide();
            }
        }

        protected void OnCancelInstallButtonClicked(object sender, EventArgs args)
        {
            this.Respond(Gtk.ResponseType.No);
            this.Hide();
        }

        protected void OnDetailsExpanderActivated(object sender, EventArgs args)
        {
            this.QueueResize();
            this.QueueDraw();
        }
    }
}

