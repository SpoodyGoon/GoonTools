//
//  LocalSystemTools.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
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
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Gtk;

namespace MonoTools.IO
{
    internal class LocalSystemTools
    {
        private const string UserDataFolderName = "GUPdotNET";
        private const string DebugFolderName = "DebugData";
        internal string AppPath { get; private set; }

        internal string UserDataPath { get; private set; }

        internal string OS { get; private set; }

        /// <summary>
        /// The temporary directory where package files will be 
        /// downloaded/updated to be used.
        /// </summary>
        internal string TempPackagePath { get; set; }

        internal Dictionary<string, string> TempPackagePaths;

        internal void Initalize(bool debugMode)
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
            if (debugMode)
            {
                this.UserDataPath = Path.Combine(this.AppPath, DebugFolderName, UserDataFolderName);
            }
            else
            {
                this.UserDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), UserDataFolderName);
            }

            // if the user data path does not exist create it.
            if (!Directory.Exists(this.UserDataPath))
            {
                Directory.CreateDirectory(this.UserDataPath);
            }

            this.TempPackagePaths = new Dictionary<string, string>();
            this.TempPackagePaths.Add("root", Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));
        }
    }
}

