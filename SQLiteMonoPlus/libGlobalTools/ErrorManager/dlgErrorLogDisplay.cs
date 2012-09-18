using System;
using Gtk;

namespace ErrorManager
{
	public partial class dlgErrorLogDisplay : Gtk.Dialog
	{
		public dlgErrorLogDisplay ()
		{
			this.Build ();
			System.IO.FileInfo fi = new System.IO.FileInfo (libGlobalTools.GlobalTools.LocalSystem.ErrorLogFile);
			if (fi.Exists)
			{
				System.IO.StreamReader sr = new System.IO.StreamReader (fi.FullName);
				txtErrorLogDisplay.Buffer.Text = sr.ReadToEnd ();
				sr.Close ();
				sr.Dispose ();
			}
			else
			{
				txtErrorLogDisplay.Buffer.Clear();
			}
		}

		protected void OnBtnCloseWindowClicked (object sender, EventArgs e)
		{
			this.Destroy();
		}

		protected void OnBtnClearErrorLogClicked (object sender, EventArgs e)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(libGlobalTools.GlobalTools.LocalSystem.ErrorLogFile, false);
			sw.Write("");
			sw.Close();
			txtErrorLogDisplay.Buffer.Text = "";
			txtErrorLogDisplay.ShowNow();
		}

		protected void OnBtnSaveErrorLogClicked (object sender, EventArgs e)
		{
			System.IO.FileInfo fi = new System.IO.FileInfo (libGlobalTools.GlobalTools.LocalSystem.ErrorLogFile);
			if (fi.Exists)
			{
				FileChooserDialog dcf = new FileChooserDialog ("Save Error Log", this, FileChooserAction.Save, "Cance", ResponseType.Cancel, "Save", ResponseType.Ok);
				if (dcf.Run () == (int)Gtk.ResponseType.Ok)
				{
					fi.CopyTo(dcf.Filename);
				}
				dcf.Destroy ();
			}
			else
			{
				MessageDialog md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Close, "No Error Log is available to export");
				md.Run();
				md.Destroy();
			}
		}
	}
}

