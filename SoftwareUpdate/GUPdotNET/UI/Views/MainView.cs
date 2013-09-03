//
//  MainView.cs
//
//  Author:
//       Andy York <goontools@brdstudio.net>
//
//  Copyright (c) 2013 Andy York
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Reflection;
using MonoTools;
using Gtk;
using GUPdotNET.UI.ComboBox;

namespace GUPdotNET.UI.Views
{
	public partial class MainView : Gtk.Dialog
	{
		private UpdateSchedualComboBox updateCheckCombobox = new UpdateSchedualComboBox();

		public MainView()
		{
			this.Build();
            this.DeleteEvent += new DeleteEventHandler(MainView_DeleteEvent);
			this.updateCheckAlignment.Add(this.updateCheckCombobox);
			this.updateCheckAlignment.ShowAll();
			this.ActionArea.Hide();
			this.feedbackMessageLabel.Text = "";
			this.feedbackMessageLabel.QueueDraw();
			this.QueueResize();
		}

        private void MainView_DeleteEvent(object o, DeleteEventArgs args)
        {
            GlobalTools.Options.Save();
            Application.Quit();
        }

		protected void OnCheckUpdateButtonClicked(object sender, EventArgs e)
		{
            UpdateCheck updateCheck = new UpdateCheck();
            updateCheck.RunUpdateCheck();
		}

		protected void OnQuitActionActivated(object sender, EventArgs e)
		{
            GlobalTools.Options.Save();
			Application.Quit();
		}

		protected void OnAboutGUPdotNETActionActivated(object sender, EventArgs e)
		{
			// hook delegat to handle default button events in the gtk.about dialog window
			Gtk.AboutDialog.SetUrlHook(delegate(Gtk.AboutDialog dialog, string link)
			{
				ProcessTools.LaunchURL(link);
			}
			);

			try
			{
				Assembly programAssembly = Assembly.GetExecutingAssembly();
				string title = (programAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute).Title;
				string description = (programAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description;
				string copyRight = (programAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute).Copyright;
				string company = (programAssembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)[0] as AssemblyCompanyAttribute).Company;
	
				Gtk.AboutDialog ad = new Gtk.AboutDialog();
				ad.Title = "About " + title;
				ad.ProgramName = title;
				ad.Comments = description;
				MonoTools.Tools.LicenseText lic = new MonoTools.Tools.LicenseText();
				ad.License = lic.GPL3.Replace(lic.Copyright, copyRight).Replace(lic.Description, description).Replace(lic.ProgramName, title);
				ad.Authors = new string[] { "Andy York <goontools@brdstudio.net>" };
				ad.Version = programAssembly.GetName().Version.ToString();
				ad.Logo = Gdk.Pixbuf.LoadFromResource("GUPdotNET.Resources.Images.update_large.png");
				ad.Icon = Gdk.Pixbuf.LoadFromResource("GUPdotNET.Resources.Images.update_small.png");
				ad.AllowShrink = false;
				ad.AllowGrow = true;
				ad.Copyright = copyRight;
				ad.HasSeparator = true;
				ad.Modal = true;
                ad.WidthRequest = 425;
				ad.WebsiteLabel = title;
				ad.Website = "https://code.google.com/p/goontools/";
				ad.WindowPosition = WindowPosition.CenterAlways;
				ad.Run();
				ad.Destroy();
			}
			catch(Exception ex)
			{
				Gtk.MessageDialog errorDialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Ok, false, ex.Message, "An error has occured");
				errorDialog.Run();
				errorDialog.Destroy();
			}
		}

		protected void OnDebugDataActionActivated(object sender, EventArgs e)
		{
            Gtk.MessageDialog notImplementedMessage = new Gtk.MessageDialog(this, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, Gtk.ButtonsType.Ok, false, "Not Implemented", "Not Implemented");
            notImplementedMessage.Run();
            notImplementedMessage.Destroy();
		}
	}
}

