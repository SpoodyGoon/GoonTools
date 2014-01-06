// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageInfo.cs" company="Andy York">
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
    using System.Net;
    using System.Xml.Linq;

    /// <summary>
    /// A data class for loading and working with update information
    /// gotten from a remote server to determine if an update is available.
    /// </summary>
    internal class PackageInfo
    {
        /// <summary>
        /// The name of the package config.
        /// </summary>
        private const string PackageConfigName = "PackageConfig.xml";

        /// <summary>
        /// Format for the message to be shown when parsing the settings file fails.
        /// </summary>
        private const string FileLoadErrorMessage = "Unable to load update package data for program: '{0}'";

        /// <summary>
        /// Error message to be displayed when the file path is null or empty.
        /// </summary>
        private const string FilePathEmptyMessage = "The update package file path is missing. Unable to load the update package file for {0}.";

        /// <summary>
        /// Error message format for unsupported URI Schemes
        /// </summary>
        private const string URIUnsupportedMessage = "The provided URI Scheme is not currently supported. URI Scheme: {0}.";

        /// <summary>
        /// Full path to the xml file that contains the application settings.
        /// </summary>
        private string filePath = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.Data.PackageInfo"/> class.
        /// </summary>
        internal PackageInfo()
        {
            this.filePath = Path.Combine(GlobalTools.LocalSystem.TempPackagePath, PackageConfigName);
        }

        /// <summary>
        /// Event fired when a new settings file is created or when
        /// there is a difference in the file versions 
        /// between the options file loaded and the one expected by the application.
        /// </summary>
        internal event System.Action<System.Version> FileVersionChanged;

        /// <summary>
        /// Gets or sets a value indicating the version of the package config file, 
        /// so that future config formats can be identified.
        /// </summary>
        internal System.Version FileVersion { get; set; }

        /// <summary>
        /// Gets or sets the OS as gotten from the update package config file.
        /// </summary>
        internal string OS { get; set; }

        /// <summary>
        /// Gets or sets the version of the newest update.
        /// </summary>
        internal System.Version UpdateVersion { get; set; }

        /// <summary>
        /// Gets or sets the install method used to install the supported program.
        /// </summary>
        internal InstallMethod InstallerType { get; set; }

        /// <summary>
        /// Gets or sets the URL to release notes for the update package.
        /// </summary>
        internal string ReleaseNotesURL { get; set; }

        /// <summary>
        /// Gets or sets the URL to the install file for the update package.
        /// </summary>
        internal string InstallerURL { get; set; }

        /// <summary>
        /// Gets or sets the installer checksum.
        /// </summary>
        internal string InstallerChecksum { get; set; }

        /// <summary>
        /// Gets or sets the URL for the downloads page for this package.
        /// </summary>
        /// <value>The downloads.</value>
        internal string DownloadsURL { get; set; }

        /// <summary>
        /// Gets or sets the update message for the update package.
        /// </summary>
        internal string UpdateMessage{ get; set; }

        /// <summary>
        /// The main method to load the package xml for parsing.
        /// </summary>
        /// <returns>Boolean <c>true</c> if the package file was retrived successfully <c>false</c> if the package file was unaccessable.</returns>
        internal bool Load()
        {
            bool success = true;

            try
            {
                if(!this.MoveFile())
                {
                    throw new Exception("Unable to access package file.");
                }

                // Load the xml document
                XDocument configDocument = XDocument.Load(this.filePath);
                this.FileVersion = System.Version.Parse(configDocument.Element("GUPdotNET").Attribute("FileVersion").Value);
                XElement configRoot = configDocument.Element("GUPdotNET").Element("PackageConfig");
                var packageInfo = (from el in configRoot.Descendants("Package")
                                               where (string)el.Attribute("OS") == GlobalTools.ProgramInfo.OS && (string)el.Attribute("InstallerType") == GlobalTools.ProgramInfo.InstallType.ToString()
                                               select new
                    {
                        UpdateMessage = el.Element("UpdateMessage").Value,
                        OS = el.Attribute("OS").Value,
                        InstallerType = el.Attribute("InstallerType").Value,
                        Version = el.Attribute("Version").Value,
                        ReleaseNotes = el.Element("ReleaseNotes").Value,
                        Installer = el.Element("Installer").Value,
                        Checksum = el.Element("Installer").Attribute("Checksum").Value,
                        Downloads = el.Element("Downloads").Value
                       }).SingleOrDefault();

                this.UpdateMessage = packageInfo.UpdateMessage.ToString().Trim();
                this.OS = packageInfo.OS.ToString();
                this.InstallerType = (InstallMethod)Enum.Parse(typeof(InstallMethod), packageInfo.InstallerType.ToString());
                this.UpdateVersion = System.Version.Parse(packageInfo.Version);
                this.ReleaseNotesURL = packageInfo.ReleaseNotes;
                this.InstallerURL = packageInfo.Installer;
                this.InstallerChecksum = packageInfo.Checksum;
                this.DownloadsURL = packageInfo.Downloads;
            }
            catch (Exception error)
            {
                success = false;
                GlobalTools.HandleError(error);
            }

            return success;
        }

        /// <summary>
        /// Method to determine how to move the update package file.
        /// Possible schemes: <c>file, ftp, gopher, http, https, ldap, mailto, net.pipe, net.tcp, news, nntp, telnet, uuid</c>
        /// TODO: Add support for additional Uri Schemes
        /// </summary>
        /// <returns><c>true</c>, if file was moved, <c>false</c> otherwise.</returns>
        private bool MoveFile()
        {
            bool fileMoveSuccess = true;
            try
            {
                Uri packagePathURI = new Uri(GlobalTools.ProgramInfo.UpdatePackageURL);
                string packageScheme = packagePathURI.Scheme;
                switch (packageScheme)
                {
                    case "http":
                    case "https":
                        using (WebClient webClient = new WebClient())
                        {
                            webClient.DownloadFile(packagePathURI, this.filePath);
                        }

                    break;
                    case "file":
                        File.Copy(packagePathURI.LocalPath, this.filePath);
                    break;
                    default:
                        throw new NotSupportedException(string.Format(URIUnsupportedMessage, packageScheme));
                }
            }
            catch (WebException webError)
            {
                fileMoveSuccess = false;
                if (GlobalTools.UpdateRunType == RunType.ManualCheck)
                {
                    if (webError.Status == WebExceptionStatus.ConnectFailure)
                    {
                        GlobalTools.HandleError(new Exception("Unable to connect to remote web server to get update data file. Please check your internet connection and/or filewall status and try again."));
                    }
                    else
                    {
                        GlobalTools.HandleError(new Exception("Unknown error ocurred while attempting to get update data file."));
                    }
                }
            }
            catch (Exception error)
            {
                fileMoveSuccess = false;
                GlobalTools.HandleError(error);
            }

            return fileMoveSuccess;
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