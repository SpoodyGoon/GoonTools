//
//  UpdateSettings.cs
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
namespace GUPdotNET.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
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
        private const string FileNameFormat = "UpdateSettings.config";

        /// <summary>
        /// Full path to the xml file that contains the application settings.
        /// </summary>
        private string filePath = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.Data.AppSettings"/> class.
        /// </summary>
        internal AppSettings()
        {
            this.filePath = Path.Combine(GlobalTools.LocalSystem.AppPath, FileNameFormat);
            this.AutoUpdate = true;
            this.LastUpdateCheck = DateTime.Now.AddDays(-1);
            this.UpdateSchedule = new TimeSpan(1, 0, 0, 0);
            this.SettingsVersion = new System.Version(1, 0);
        }

        /// <summary>
        /// Gets or sets the version of the application setting file format,
        /// if the version number changes there may be more or less data 
        /// in the format of the file.
        /// </summary>
        internal System.Version SettingsVersion { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether GUPdotNET will check for updates automatically.
        /// </summary>
        internal bool AutoUpdate { get; set; }

        /// <summary>
        /// Gets or sets the last date and time that GUPdotNET checked for an update.
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
            if (File.Exists(this.filePath))
            {
                XDocument configDocument = XDocument.Load(this.filePath);
                XElement configRoot = configDocument.Element("GUPdotNET");
                var settingsInfo = (from e in configRoot.Descendants("UpdateSettings")
                                    select new
                                    {
                                        SettingsVersion = e.Attribute("SettingsVersion").Value,
                                        AutoUpdate = e.Element("AutoUpdate").Value,
                                        LastUpdateCheck = e.Element("LastUpdateCheck").Value,
                                        UpdateSchedule = e.Element("UpdateSchedule").Value
                                    }).SingleOrDefault();

                if (settingsInfo == null)
                {
                    throw new Exception("Unable to load GUPdotNET setting for program " + GlobalTools.UpdateProgramName);
                }

                this.SettingsVersion = System.Version.Parse(settingsInfo.SettingsVersion);
                this.AutoUpdate = Convert.ToBoolean(settingsInfo.AutoUpdate);
                this.LastUpdateCheck = Convert.ToDateTime(settingsInfo.LastUpdateCheck);
                this.UpdateSchedule = new TimeSpan(Convert.ToInt32(settingsInfo.UpdateSchedule), 0, 0, 0);
            }
            else
            {
                this.Save();
            }
        }

        /// <summary>
        /// Method to save the application settings file.
        /// </summary>
        internal void Save()
        {
            XDocument settingsDocument = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XComment(string.Format(CommentFormat, GlobalTools.UpdateProgramName)), new XElement("GUPdotNET", new XElement("UpdateSettings", new XAttribute("ProgramName", GlobalTools.UpdateProgramName), new XAttribute("SettingsVersion", "1.0"), new XElement("AutoUpdate", this.AutoUpdate.ToString()), new XElement("LastUpdateCheck", this.LastUpdateCheck.ToString()), new XElement("UpdateSchedule", this.UpdateSchedule.Days.ToString()))));
            settingsDocument.Save(this.filePath);
        }
    }
}
