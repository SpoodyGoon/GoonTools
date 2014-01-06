// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalSystemTools.cs" company="Andy York">
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

namespace GUPdotNET.IO
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// A helper class to reference and work with the local file system.
    /// </summary>
    internal class LocalSystemTools
    {
        /// <summary>
        /// The name of the user data folder.
        /// </summary>
        private const string UserDataFolderName = "GUPdotNET";

        /// <summary>
        /// The name of the debug folder.
        /// </summary>
        private const string DebugFolderName = "DebugData";

        /// <summary>
        /// The full path to a temporary directory for working with files locally.
        /// </summary>
        private string tempPackagePath = string.Empty;

        /// <summary>
        /// Gets the directory that the application is running in.
        /// </summary>
        internal string AppPath { get; private set; }

        /// <summary>
        /// Gets the full path to where user data like settings,
        /// preferences and logs are kept.
        /// </summary>
        internal string UserDataPath { get; private set; }

        /// <summary>
        /// Gets the operating system that the application is currently running on.
        /// </summary>
        internal string OS { get; private set; }

        /// <summary>
        /// Gets full path to a temporary directory for working with files locally.
        /// If the value is null then a new temporary directory is created
        /// </summary>
        internal string TempPackagePath
        { 
            get
            {
                if (string.IsNullOrEmpty(this.tempPackagePath))
                {
                    this.BuildTempPath();
                }

                return this.tempPackagePath;
            }
        }

        /// <summary>
        /// The main method for initializing data being used while working
        /// with the local file system. 
        /// </summary>
        internal void Initalize()
        {
            // get OS information
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                case PlatformID.WinCE:
                    this.OS = "Windows";
                break;
                case PlatformID.Unix:
                    this.OS = "Linux";
                break;
                case PlatformID.MacOSX:
                    this.OS = "Mac";
                break;
            }

            // Get commonly used path information
            this.AppPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;

            // if the application is in debug mode store the user data 
            // relative to the AppPath, otherwise use the users local application data path
            if (Properties.Settings.Default.DebugMode)
            {
                this.UserDataPath = Path.Combine(this.AppPath, DebugFolderName, UserDataFolderName, GlobalTools.UpdateProgramName);
            }
            else
            {
                this.UserDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), UserDataFolderName, GlobalTools.UpdateProgramName);
            }

            // if the user data path does not exist create it.
            if (!Directory.Exists(this.UserDataPath))
            {
                Directory.CreateDirectory(this.UserDataPath);
            }
        }

        /// <summary>
        /// Creates a temporary file path for downloading files 
        /// to a local folder to work with.
        /// </summary>
        internal void BuildTempPath()
        {
            this.tempPackagePath = Path.Combine(Path.GetTempPath(), UserDataFolderName, Path.GetRandomFileName());
            if (Directory.Exists(this.tempPackagePath))
            {
                throw new Exception("Unable to create temporary package working folder, folder already exist");
            }

            Directory.CreateDirectory(this.tempPackagePath);
        }

        /// <summary>
        /// A method to clean up temporary files used during
        /// the update process, however if it fails simply let the 
        /// operating system take care of it when it gets around to it.
        /// </summary>
        internal void RemoveTempPath()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.tempPackagePath) && Directory.Exists(this.tempPackagePath))
                {
                    Directory.Delete(this.tempPackagePath, true);
                }
            }
            catch (IOException error)
            {
                /*
                    Because removing the temporary directory is not critical 
                    to the operation of the application or it's parent application
                    there is no need to alert the user of IO error when cleaning up.
                    The operating system will most likely clean up the temporary files
                    at a later time, notifying the user would take away from fun game play.
                */
                if (Properties.Settings.Default.DebugMode)
                {
                    GlobalTools.WriteDebug(error.ToString());
                }
            }
        }

        /// <summary>
        /// A method to clean up all temporary file from the
        /// current instance as well as previous instances.
        /// </summary>
        internal void CleanTempPaths()
        {
            foreach (var directory in Path.Combine(Path.GetTempPath(), UserDataFolderName))
            {
                this.RemoveTempPath();
            }
        }
    }
}