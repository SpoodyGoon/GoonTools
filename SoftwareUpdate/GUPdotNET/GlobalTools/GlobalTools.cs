//
//  GlobalTools.cs
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

namespace GUPdotNET
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Security.Cryptography;
    using GUPdotNET.Data;
    using GUPdotNET.IO;

    /// <summary>
    /// A helper class used to centrally locate commonly used methods
    /// and variables that are used across the application.
    /// </summary>
    internal static class GlobalTools
    {
        /// <summary>
        /// Gets the name of the program that is being supported, this 
        /// is used to determine configuration file names for settings and related information.
        /// </summary>
        internal static string UpdateProgramName { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the application is running silently or in manual mode.
        /// </summary>
        internal static RunType UpdateRunType { get; set; }

        /// <summary>
        /// Gets or sets the options for each user loaded from xml configuration files.
        /// </summary>
        internal static AppSettings Options { get; set; }

        /// <summary>
        /// Gets or sets the package information loaded from a xml file gotten from a remote server, 
        /// contains data concerning whether or not there is an update available.
        /// </summary>
        internal static PackageInfo PackageInfo { get; set; }

        /// <summary>
        /// Gets or sets the program information loaded from and xml file stored in the 
        /// same directory as the application is and contains information on the program
        /// that is being supported.
        /// </summary>
        internal static ProgramInfo ProgramInfo { get; set; }

        /// <summary>
        /// Gets the local system, a helper class for working with the local file system.
        /// </summary>
        internal static LocalSystemTools LocalSystem { get; private set; }

        /// <summary>
        /// Method to load object needed for running the application at startup.
        /// </summary>
        internal static void Initalize()
        {
            UpdateProgramName = Properties.Settings.Default.UpdateFileName.Replace(Path.GetExtension(Properties.Settings.Default.UpdateFileName), string.Empty);
            LocalSystem = new LocalSystemTools();
            LocalSystem.Initalize();
            Options = new AppSettings();
            Options.Load();
        }

        /// <summary>
        /// A simple method for displaying error messages.
        /// </summary>
        /// <param name="error">The error to be displayed in the dialog window.</param>
        internal static void HandleError(Exception error)
        {   
            HandleError(null, error);
        }

        /// <summary>
        /// A simple method for displaying error messages.
        /// </summary>
        /// <param name="parentWindow">The parent window for the dialog box if there is any.</param>
        /// <param name="error">The error to be displayed in the dialog window.</param>
        internal static void HandleError(Gtk.Window parentWindow, Exception error)
        {            
            Gtk.MessageDialog errorDialog = new Gtk.MessageDialog(parentWindow, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Ok, false, error.Message, "An error has occured");
            errorDialog.Run();
            errorDialog.Destroy();
        }

        /// <summary>
        /// Simple method for converting remotely located files into local
        /// temporary system file paths.
        /// </summary>
        /// <returns>The full path to local version of a remote file.</returns>
        /// <param name="remoteURL">The URL for a remotely located file.</param>
        internal static string ToLocalFile(string remoteURL)
        {
            return ToLocalFile(new Uri(remoteURL));
        }

        /// <summary>
        /// Simple method for converting remotely located files into local
        /// temporary system file paths.
        /// </summary>
        /// <returns>The full path to local version of a remote file.</returns>
        /// <param name="remoteURL">The URL for a remotely located file.</param>
        internal static string ToLocalFile(Uri remoteURL)
        {
            return Path.Combine(GlobalTools.LocalSystem.TempPackagePath, Path.GetFileName(remoteURL.LocalPath));
        }

        /// <summary>
        /// Creates a checksum for validating a downloaded installer.
        /// </summary>
        /// <param name="filePath">The full file path to the file to have its checksum generated.</param>
        /// <returns>The checksum for the provided file.</returns>
        internal static string FileChecksumGet(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
    }
}