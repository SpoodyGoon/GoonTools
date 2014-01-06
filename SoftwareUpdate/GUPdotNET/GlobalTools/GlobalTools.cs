// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalTools.cs" company="Andy York">
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

namespace GUPdotNET
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using GUPdotNET.Data;
    using GUPdotNET.IO;
    using MonoTools.ErrorManager;

    /// <summary>
    /// A helper class used to centrally locate commonly used methods
    /// and variables that are used across the application.
    /// </summary>
    internal static class GlobalTools
    {
        /// <summary>
        /// Message format used for the splash screen.
        /// </summary>
        private const string InitializeMessageFormat = "Initalizing {0}";

        /// <summary>
        /// File name used for error logging.
        /// </summary>
        private const string ErrorLogFileName = "UpdateErrorLog.txt";

        /// <summary>
        /// The message displayed on the splash screen showing the
        /// progress of initializing the application.
        /// </summary>
        private static string initalizingMessage = "Started";

        /// <summary>
        /// The event that fires every time the initialization message changes.
        /// </summary>
        public static event System.Action<string> InitializeMessageChanged;

        /// <summary>
        /// The event that fires when the global tools has finish 
        /// initializing the resource needed to start the application.
        /// </summary>
        public static event System.Action InitializationComplete;

        /// <summary>
        /// The event that occurs when there has been an error during 
        /// the initialization of global tools.
        /// The first argument is the error that occurred passed on without 
        /// alteration, the second argument is the current initialization step.
        /// </summary>
        public static event System.Action<Exception, string> InitializateError;

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
        /// Gets the initializing errorMessage, used when loading 
        /// the application to display information on the splash screen.
        /// </summary>
        internal static string InitalizingMessage
        {
            get
            {
                return initalizingMessage;
            }

            private set
            {
                initalizingMessage = value;
                if (InitializeMessageChanged != null)
                {
                    InitializeMessageChanged(string.Format(InitializeMessageFormat, initalizingMessage));
                }
            }
        }

        /// <summary>
        /// Method to load object needed for running the application at startup.
        /// </summary>
        /// <returns>Boolean <c>true</c> if initialization was successful <c>false</c> if an error occurred.</returns>
        internal static bool Initalize()
        {
            bool initializeSuccess = true;
            try
            {
                UpdateProgramName = Properties.Settings.Default.UpdateProgramTitle;
                InitalizingMessage = "Local System Resources";
                LocalSystem = new LocalSystemTools();
                LocalSystem.Initalize();
                InitalizingMessage = "Update Settings";
                Options = new AppSettings();
                Options.FileVersionChanged += delegate(System.Version fileVersion)
                {
                    if (fileVersion == null)
                    {
                        Options.SetDefaults();
                        Options.Save();
                    }
                    else
                    {
                        /*
                        If the file version is different there may be other events that need to occur, 
                        for version 1.0 it will be the same as if the file was new.
                        */
                        Options.SetDefaults();
                        Options.Save();
                    }
                };
                Options.Load();

                // update the loading errorMessage.
                InitalizingMessage = "Completed";

                InitializationComplete();
            }
            catch (Exception error)
            {
                initializeSuccess = false;
                InitializateError(error, initalizingMessage);
            }

            return initializeSuccess;
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
            if (Properties.Settings.Default.UseErrorLog)
            {
                ErrorLogWriter.WriteLog(Path.Combine(GlobalTools.LocalSystem.UserDataPath, ErrorLogFileName), error);
            }

            if (GlobalTools.UpdateRunType != RunType.BackgroundCheck)
            {
                Gtk.MessageDialog errorDialog = new Gtk.MessageDialog(parentWindow, Gtk.DialogFlags.Modal, Gtk.MessageType.Error, Gtk.ButtonsType.Ok, false, error.Message, "An error has occured");
                errorDialog.ResizeMode = Gtk.ResizeMode.Immediate;
                errorDialog.Run();
                errorDialog.Destroy();
            }
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
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                }
            }
        }

        /// <summary>
        /// Method to write debug messages, used during development
        /// to test and debug the application.
        /// </summary>
        /// <param name="text">The text to be written out.</param>
        internal static void WriteDebug(string text)
        {
            Console.WriteLine(text);
            System.Diagnostics.Debug.WriteLine(text);
        }
    }
}