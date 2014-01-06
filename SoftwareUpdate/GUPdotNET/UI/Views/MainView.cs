// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainView.cs" company="Andy York">
// 
// Copyright (c) 2013 Andy York
// 
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Email: goontools@brdstudio.net
// Author: Andy York 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GUPdotNET.UI.Views
{
    using System;
    using System.Reflection;
    using Gtk;
    using GUPdotNET;
    using GUPdotNET.UI;
    using GUPdotNET.UI.ComboBox;

    /// <summary>
    /// The root window when the application is not being ran in silent/background mode,
    /// also is the UI for application settings/preferences.
    /// </summary>
    internal partial class MainView : Gtk.Dialog
    {
        /// <summary>
        /// Text displayed on the about label button.
        /// </summary>
        private const string AboutButtonLabel = "About GUPdotNET...";

        /// <summary>
		/// Format for the label that appears referring to the 
        /// application that is being updated.
        /// </summary>
        private const string HeaderLabelFormat = "<span size=\"12000\" weight=\"bold\">Update Tools for {0}.</span>";

        /// <summary>
		/// Format for the window title referring to the 
        /// application that is being updated.
        /// </summary>
        private const string WindowTitleFormat = "GUPdotNET (Supporting {0})";

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
            try
            {
                this.Build();
                this.Initalize();
            }
            catch (Exception error)
            {
                GlobalTools.HandleError(this, error);
            }
        }

        /// <summary>
        /// Event fired when the "Update Check" button is fired, causing a forced 
        /// update check regardless of the time since the last check.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
        protected void OnCheckUpdateButtonClicked(object sender, EventArgs args)
        {
            try
            {
                UpdateCheck updateCheck = new UpdateCheck();
                updateCheck.RootWindow = this.GdkWindow;
                this.checkNowLabel.Text = "Checking...";
                this.checkUpdateButton.Sensitive = false;
                this.checkUpdateButton.QueueDraw();
                if (updateCheck.RunUpdateCheck(true))
                {
                    this.ApplicationQuit();
                }

                this.checkNowLabel.Text = "Check Now";
                this.checkUpdateButton.Sensitive = true;
                this.checkUpdateButton.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
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
        /// Event fired when the close button is pushed.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        protected void OnCloseButtonClicked(object sender, EventArgs e)
        {
            this.ApplicationQuit();
        }

        /// <summary>
        /// Event fired when the about GUPdotNET link button is clicked.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        protected void OnAboutLabelButtonClicked(object sender)
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

                Gtk.AboutDialog aboutDialog = new Gtk.AboutDialog();
                aboutDialog.Title = string.Format("About {0}", title);
                aboutDialog.ProgramName = title;
                aboutDialog.Comments = description;
                aboutDialog.License = Properties.Resources.GPL3;
                aboutDialog.Authors = new string[] { "Andy York <goontools@brdstudio.net>" };
                aboutDialog.Version = programAssembly.GetName().Version.ToString(2);
                aboutDialog.Logo = Gdk.Pixbuf.LoadFromResource("GUPdotNET.Resources.Images.update_large.png");
                aboutDialog.Icon = Gdk.Pixbuf.LoadFromResource("GUPdotNET.Resources.Images.update_small.png");
                aboutDialog.AllowShrink = false;
                aboutDialog.AllowGrow = true;
                aboutDialog.Copyright = copyRight;
                aboutDialog.HasSeparator = true;
                aboutDialog.Modal = true;
                aboutDialog.WidthRequest = 500;
                aboutDialog.WebsiteLabel = title;
                aboutDialog.Website = Properties.Settings.Default.ProjectWebSite;
                aboutDialog.WindowPosition = WindowPosition.CenterAlways;
                aboutDialog.Run();
                aboutDialog.Destroy();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }

        /// <summary>
        /// Consolidated method for when the application exists when not in silent/background mode.
        /// </summary>
        private void ApplicationQuit()
        {
            try
            {
                GlobalTools.Options.Save();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }

            Application.Quit();
        }

        /// <summary>
        /// Event fired when the close button is pushed on the window,
        /// or is closed from the OS interface.
        /// Saves the setting/preferences prior to exit.
        /// </summary>
        /// <param name="sender">Object firing the event, parameter is not used.</param>
        /// <param name="args">The parameter is not used.</param>
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
            try
            {
                this.updateTitleLabel.LabelProp = string.Format(HeaderLabelFormat, Properties.Settings.Default.UpdateProgramTitle);
                this.updateTitleLabel.UseMarkup = true;
                this.Title = string.Format(WindowTitleFormat, Properties.Settings.Default.UpdateProgramTitle);
                LabelButton aboutLabelButton = new LabelButton(AboutButtonLabel);
                aboutLabelButton.Clicked += this.OnAboutLabelButtonClicked;
                this.aboutGUPdotNETAlignment.Add(aboutLabelButton);
                this.aboutGUPdotNETAlignment.ShowAll();
                this.DeleteEvent += new DeleteEventHandler(this.MainView_DeleteEvent);
                this.updateCheckAlignment.Add(this.updateCheckCombobox);
                this.updateCheckCombobox.WidthRequest = 125;
                this.updateCheckCombobox.UpdateDays = GlobalTools.Options.UpdateSchedule;
                this.updateCheckCombobox.Changed += delegate
                {
                    GlobalTools.Options.UpdateSchedule = this.updateCheckCombobox.UpdateDays;
                };
                this.updateCheckAlignment.ShowAll();
                this.QueueResize();
                this.QueueDraw();
            }
            catch (Exception ex)
            {
                GlobalTools.HandleError(this, ex);
            }
        }
    }
}