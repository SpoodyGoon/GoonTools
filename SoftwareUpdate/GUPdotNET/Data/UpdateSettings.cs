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
using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;

namespace GUPdotNET.Data
{
    public class UpdateSettings
    {
        private string filePath = string.Empty;

        internal event System.Action SettingsLoaded;
        internal event System.Action SettingsSaved;
        private const string COMMENT_FORMAT = "GUPdotNET update setting for supporting {0}";
        private const string FILENAME_FORMAT = "{0}Update.config";
        internal bool AutoUpdate { get; set; }
        internal DateTime LastUpdateCheck { get; set; }
        internal TimeSpan UpdateSchedule { get; set; }
        internal System.Version SettingsVersion { get; set; }

        internal UpdateSettings()
        {
            this.filePath = Path.Combine(GlobalTools.LocalSystem.AppPath, string.Format(FILENAME_FORMAT, GlobalTools.ProgramInfo.ProgramName));
            this.AutoUpdate = true;
            this.LastUpdateCheck = DateTime.Now.AddDays(-1);
            this.UpdateSchedule = new TimeSpan(1, 0, 0, 0);
            this.SettingsVersion = new System.Version(1, 0);
        }

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
                    throw new Exception("Unable to load GUPdotNET setting for program " + GlobalTools.ProgramInfo.ProgramName);
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

            if (this.SettingsLoaded != null)
            {
                this.SettingsLoaded();
            }
        }

        internal void Save()
        {
            XDocument settingsDocument =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment(string.Format(COMMENT_FORMAT, GlobalTools.ProgramInfo.ProgramName)),
                    new XElement("GUPdotNET",
                        new XElement("UpdateSettings", new XAttribute("ProgramName", GlobalTools.ProgramInfo.ProgramName), new XAttribute("SettingsVersion", "1.0"),
                            new XElement("AutoUpdate", this.AutoUpdate.ToString()),
                            new XElement("LastUpdateCheck", this.LastUpdateCheck.ToString()),
                            new XElement("UpdateSchedule", this.UpdateSchedule.Days.ToString())
                        )
                    )
                );
            settingsDocument.Save(this.filePath);

            if (this.SettingsSaved != null)
            {
                this.SettingsSaved();
            }
        }
    }
}

