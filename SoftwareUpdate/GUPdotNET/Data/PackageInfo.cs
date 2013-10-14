//
//  UpdateFileInfo.cs
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
    using System.Net;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    internal class PackageInfo
    {
        /// <summary>
        /// This is the version of the package config file, so that future
        /// config formats can be itentified.
        /// </summary>
        internal System.Version FileVersion { get; set; }

        /// <summary>
        /// Gets or sets the OS as gotten from the GUPdotNET update package config file.
        /// </summary>
        /// <value>The O.</value>
        internal string OS { get; set; }

        /// <summary>
        /// This is the version of the newest update.
        /// </summary>
        internal System.Version UpdateVersion { get; set; }

        /// <summary>
        /// The install method used to install the supported program.
        /// </summary>
        internal InstallMethod InstallerType { get; set; }

        /// <summary>
        /// Gets or sets the URL to release notes for the update package.
        /// </summary>
        internal string ReleaseNotesURL{ get; set;}

        /// <summary>
        /// Gets or sets the URL to the install file for the update package.
        /// </summary>
        internal string InstallerURL{ get; set;}

        /// <summary>
        /// Gets or sets the installer checksum.
        /// </summary>
        internal string InstallerChecksum{ get; set;}

        /// <summary>
        /// Gets or sets the URL for the downloads page for this package.
        /// </summary>
        /// <value>The downloads.</value>
        internal string DownloadsURL{ get; set;}

        /// <summary>
        /// The root direcotry used for holding temporary files while being used.
        /// </summary>
        private string tempPackageRoot = string.Empty;

        /// <summary>
        /// The name of the package config.
        /// </summary>
        private const string packageConfigName = "PackageConfig.xml";

        /// <summary>
        /// The main method to load the package xml for parsing.
        /// </summary>
        internal void Load()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GlobalTools.ProgramInfo.UpdatePackageURL, Path.Combine(GlobalTools.LocalSystem.TempPackagePath, packageConfigName));

            XDocument configDocument = XDocument.Load(Path.Combine(GlobalTools.LocalSystem.TempPackagePath, packageConfigName));

            this.FileVersion = System.Version.Parse(configDocument.Element("GUPdotNET").Element("PackageConfig").Attribute("FileVersion").Value);
            XElement configRoot = configDocument.Element("GUPdotNET").Element("PackageConfig");
            var packageInfo = (from el in configRoot.Descendants("Package")
                               where (string)el.Attribute("OS") == GlobalTools.ProgramInfo.OS && (string)el.Attribute("InstallerType") == GlobalTools.ProgramInfo.InstallType.ToString()
                               select new
                               {
                                    OS = el.Attribute("OS").Value,
                                    InstallerType = el.Attribute("InstallerType").Value,
                                    Version = el.Attribute("Version").Value,
                                    ReleaseNotes = el.Element("ReleaseNotes").Value,
                                    Installer = el.Element("Installer").Value,
                                    Checksum = el.Element("Installer").Attribute("Checksum").Value,
                                    Downloads = el.Element("Downloads").Value
                               }).SingleOrDefault();

            this.OS = packageInfo.OS.ToString();
            this.InstallerType = (InstallMethod)Enum.Parse(typeof(InstallMethod), packageInfo.InstallerType.ToString());
            this.UpdateVersion = System.Version.Parse(packageInfo.Version);
            this.ReleaseNotesURL = packageInfo.ReleaseNotes;
            this.InstallerURL = packageInfo.Installer;
            this.InstallerChecksum = packageInfo.Checksum;
            this.DownloadsURL = packageInfo.Downloads;
        }
    }
}

