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
namespace GUPdotNET.UI.Views
{
    using System;
    using System.Reflection;
    using Gtk;
    using GUPdotNET.UI.ComboBox;
    using MonoTools;

    /// <summary>
    /// The root window when the application is not being ran in silent/background mode,
    /// also is the UI for application settings/preferences.
    /// </summary>
    internal partial class MainView : Gtk.Dialog
    {
        /// <summary>
        /// The update check combobox for determining the amount of days between 
        /// silent/background update checks.
        /// </summary>
        private UpdateSchedualComboBox updateCheckCombobox = new UpdateSchedualComboBox();

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.UI.Views.MainView"/> class.
        /// </summary>
        internal MainView()
        {
            this.Build();
            this.Initalize();
        }

        /// <summary>
        /// Event fired when the "Update Check" button is fired, causing a forced 
        /// update check regardless of the time since the last check.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnCheckUpdateButtonClicked(object sender, EventArgs args)
        {
            UpdateCheck updateCheck = new UpdateCheck();
            updateCheck.RunUpdateCheck(true);
        }

        /// <summary>
        /// Event fired when the "Quit" menu button is pressed.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnQuitActionActivated(object sender, EventArgs args)
        {
            this.ApplicationQuit();
        }

        /// <summary>
        /// Event fired when the "About" menu button is pressed,
        /// displayes the basic gtk about dialog window.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnAboutGUPdotNETActionActivated(object sender, EventArgs args)
        {
            // hook delegat to handle default button events in the gtk.about dialog window
            Gtk.AboutDialog.SetUrlHook(delegate(Gtk.AboutDialog dialog, string link)
            {
                ProcessTools.LaunchURL(link);
            });

            try
            {
                Assembly programAssembly = Assembly.GetExecutingAssembly();
                string title = (programAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute).Title;
                string description = (programAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description;
                string copyRight = (programAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)[0] as AssemblyCopyrightAttribute).Copyright;

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
            catch (Exception ex)
            {
                Gtk.MessageDialog errorDialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Ok, false, ex.Message, "An error has occured");
                errorDialog.Run();
                errorDialog.Destroy();
            }
        }

        /// <summary>
        /// Consolidated method for when the application exists when not in silent/background mode.
        /// </summary>
        private void ApplicationQuit()
        {
            GlobalTools.Options.Save();
            Application.Quit();
        }

        /// <summary>
        /// Event fired when the close button is pushed on the window,
        /// or is closed from the OS interface.
        /// Saves the setting/preferences prior to exit.
        /// </summary>
        /// <param name="sender">Object firing the event, parameter is not used.</param>
        /// <param name="args">This parameter is not used.</param>
        private void MainView_DeleteEvent(object sender, DeleteEventArgs args)
        {
            this.ApplicationQuit();
        }

        /// <summary>
        /// Sets up all widgets, properties, events, etc. that are not set up
        /// by the designer in the Build method.
        /// Can be used for some "pre-render" tasks.
        /// </summary>
        private void Initalize()
        {
            this.DeleteEvent += new DeleteEventHandler(this.MainView_DeleteEvent);
            this.updateCheckAlignment.Add(this.updateCheckCombobox);
            this.updateCheckAlignment.ShowAll();
            this.ActionArea.Hide();

            this.feedbackMessageLabel.Text = string.Empty;
            this.feedbackMessageLabel.QueueDraw();
            this.QueueResize();
        }
    }
}