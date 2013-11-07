// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppSettings.cs" company="Andy York">
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

namespace GUPdotNET.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Data class for saving the settings that pertain to GUPdotNET,
    /// as it relates to a specific program it is supporting.
    /// </summary>
    internal class AppSettings
    {
        /// <summary>
        /// A string for formatting the comment stored in the application settings file.
        /// </summary>
        private const string CommentFormat = "GUPdotNET update setting for supporting {0}";

        /// <summary>
        /// A string for formatting the file name of the application settings file.
        /// </summary>
        private const string FileNameFormat = "{0}.UpdateSettings.config";

        /// <summary>
        /// Format for the message to be shown when parsing the settings file fails.
        /// </summary>
        private const string FileLoadErrorMessage = "Unable to load GUPdotNET setting for program {0}";

        /// <summary>
        /// Error message to be displayed when the file path is null or empty.
        /// </summary>
        private const string FilePathEmptyMessage = "File path cannot be empty, missing file path. Unable to {0} user settings file.";

        /// <summary>
        /// Full path to the xml file that contains the application settings.
        /// </summary>
        private string filePath = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.Data.AppSettings"/> class.
        /// </summary>
        internal AppSettings()
        {
            this.filePath = Path.Combine(GlobalTools.LocalSystem.AppPath, string.Format(FileNameFormat, GlobalTools.UpdateProgramName));
        }

        /// <summary>
        /// Event fired when a new settings file is created or when
        /// there is a difference in the file versions 
        /// between the options file loaded and the one expected by the application.
        /// </summary>
        public event System.Action<System.Version> FileVersionChanged;

        /// <summary>
        /// Gets or sets the version of the application setting file format,
        /// if the version number changes there may be more or less data 
        /// in the format of the file.
        /// </summary>
        internal System.Version FileVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether GUPdotNET will check for updates automatically.
        /// </summary>
        internal bool AutoUpdate { get; set; }

        /// <summary>
        /// Gets or sets the last date/time that GUPdotNET checked for an update.
        /// </summary>
        internal DateTime LastUpdateCheck { get; set; }

        /// <summary>
        /// Gets or sets the time span in days between the times GUPdotNET checks for updates.
        /// </summary>
        internal TimeSpan UpdateSchedule { get; set; }

        /// <summary>
        /// Method to load the application settings file if it exists.
        /// </summary>
        internal void Load()
        {
            try
            {
                // call the method to validate the file version and to see if there has been any changes.
                if (this.FileVersionLoad())
                {
                    XDocument configDocument = XDocument.Load(this.filePath);
                    XElement configRoot = configDocument.Element("GUPdotNET");
                    var settingsInfo = (from e in configRoot.Descendants("UpdateSettings")
                                        select new
                                        {
                                            AutoUpdate = e.Element("AutoUpdate").Value,
                                            LastUpdateCheck = e.Element("LastUpdateCheck").Value,
                                            UpdateSchedule = e.Element("UpdateSchedule").Value
                                        }).SingleOrDefault();

                    if (settingsInfo == null)
                    {
                        throw new FileLoadException(string.Format(FileLoadErrorMessage, GlobalTools.UpdateProgramName), this.filePath);
                    }

                    this.AutoUpdate = Convert.ToBoolean(settingsInfo.AutoUpdate);
                    this.LastUpdateCheck = Convert.ToDateTime(settingsInfo.LastUpdateCheck);
                    this.UpdateSchedule = new TimeSpan(Convert.ToInt32(settingsInfo.UpdateSchedule), 0, 0, 0);
                }
                else
                {
                    this.Save();
                }
            }
            catch (Exception error)
            {
                GlobalTools.HandleError(error);
            }
        }

        /// <summary>
        /// Method to save the application settings file.
        /// </summary>
        internal void Save()
        {
            try
            {
                if (string.IsNullOrEmpty(this.filePath))
                {
                    throw new FileNotFoundException(string.Format(FilePathEmptyMessage, "save"));
                }

                XDocument settingsDocument = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment(string.Format(CommentFormat, GlobalTools.UpdateProgramName)),
                    new XElement(
                        "GUPdotNET",
                        new XElement(
                            "UpdateSettings",
                            new XAttribute("ProgramName", GlobalTools.UpdateProgramName),
                            new XElement("AutoUpdate", this.AutoUpdate.ToString()),
                            new XElement("LastUpdateCheck", this.LastUpdateCheck.ToString()),
                            new XElement("UpdateSchedule", this.UpdateSchedule.Days.ToString()))));
                
                // set the file version value at the root element as an attribute
                settingsDocument.Root.Attribute("FileVersion").Value = this.FileVersion.ToString(2);
                settingsDocument.Save(this.filePath);
            }
            catch (Exception error)
            {
                GlobalTools.HandleError(error);
            }
        }

        /// <summary>
        /// Method set the application settings values to their defaults.
        /// </summary>
        internal void SetDefaults()
        {
            this.AutoUpdate = true;
            this.LastUpdateCheck = DateTime.Now.AddDays(-2);
            this.UpdateSchedule = TimeSpan.FromDays(1);
            this.FileVersion = System.Version.Parse(Properties.Settings.Default.SettingsFileVersion);
        }

        /// <summary>
        /// Gets the file version from the root element of the xml document
        /// and sets it to the current file version for validation to see if any changes have
        /// occurred in the file version.
        /// </summary>
        /// <returns>Boolean <c>true</c> if the file should still be loaded from the user data path <c>false</c> if there should be no attempt made to load the file.</returns>
        private bool FileVersionLoad()
        {
            bool loadFile = true;
            try
            {
                if (string.IsNullOrEmpty(this.filePath))
                {
                    throw new FileNotFoundException(string.Format(FilePathEmptyMessage, "load"));
                }

                if (File.Exists(this.filePath))
                {
                    XDocument settingsDocument = XDocument.Load(this.filePath);
                    var fileVersionAttribute = settingsDocument.Root.Attribute("FileVersion");
                    if (fileVersionAttribute != null)
                    {
                        this.FileVersion = System.Version.Parse(fileVersionAttribute.Value);
                    }
                }

                if (this.FileVersion == null || !this.FileVersion.Equals(System.Version.Parse(Properties.Settings.Default.SettingsFileVersion)))
                {
                    loadFile = false;
                    if (this.FileVersionChanged != null)
                    {
                        this.FileVersionChanged(this.FileVersion);
                    }
                }
            }
            catch (Exception error)
            {
                GlobalTools.HandleError(error);
            }

            return loadFile;
        }
    }
}
