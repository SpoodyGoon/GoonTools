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
    public class UpdatePackageInfo
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
        /// Gets or sets the package file(s) associated with an install package.
        /// </summary>
        internal List<PackageFile> PackageFile { get; set; }

        /// <summary>
        /// The root direcotry used for holding temporary files while being used.
        /// </summary>
        private string tempPackageRoot = string.Empty;

        private const string packageConfigName = "PackageConfig.xml";

        public void Load()
        {
            this.tempPackageRoot = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            if (Directory.Exists(this.tempPackageRoot))
            {
                throw new Exception("Unable to create temporary package working folder, folder already exist");
            }
            Directory.CreateDirectory(this.tempPackageRoot);
            WebClient webClient = new WebClient();
            webClient.DownloadFile(GlobalTools.ProgramInfo.UpdatePackageURL, Path.Combine(this.tempPackageRoot, packageConfigName));

            XDocument configDocument = XDocument.Load(Path.Combine(this.tempPackageRoot, packageConfigName));

            this.FileVersion = System.Version.Parse(configDocument.Root.Attribute("FileVersion").Value);
            XElement configRoot = configDocument.Element("GUPdotNET").Element("PackageConfig");
            var packageInfo = (from el in configRoot.Elements("Package")
                               where (string)el.Attribute("OS") == GlobalTools.PackageInfo.OS && (string)el.Attribute("InstallerType") == GlobalTools.PackageInfo.InstallerType.ToString()
                               select new
                               {
                                   OS = el.Attribute("OS").Value,
                                   InstallerType = el.Attribute("InstallerType").Value,
                                   Version = el.Attribute("Version").Value,
                                   FileList = el.Element("Files").Descendants("File")
                               }).SingleOrDefault();
        }
    }
}

