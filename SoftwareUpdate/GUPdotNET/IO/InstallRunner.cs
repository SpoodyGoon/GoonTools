// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstallRunner.cs" company="Andy York">
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
    using System.Collections.Generic;
    using System.Diagnostics;    
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Mono.Unix.Native;

    /// <summary>
    /// A class to manage the running of the install package.
    /// </summary>
    internal class InstallRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GUPdotNET.IO.InstallRunner"/> class.
        /// </summary>
        /// <param name='supportedApplication'>The file path to the application that is being supported.</param>
        /// <param name='installerPath'>The full path to the installer or update program.</param>
        /// <param name='installerType'>The type of the installer to perform the updates.</param>
        internal InstallRunner(string supportedApplication, string installerPath, InstallMethod installerType)
        {
            this.SupportedAppFilePath = supportedApplication;
            this.InstallerFilePath = installerPath;
            this.InstallerType = installerType;
        }
        
        /// <summary>
        /// Gets the file path to the application that is being supported.
        /// </summary>
        internal string SupportedAppFilePath { get; private set; }

        /// <summary>
        /// Gets the full path to the installer or update program.
        /// </summary>
        internal string InstallerFilePath { get; private set; }

        /// <summary>
        /// Gets the type of the installer to perform the updates.
        /// </summary>
        internal InstallMethod InstallerType { get; private set; }

        /// <summary>
        /// Method to start the update process.
        /// </summary>
        internal void Start()
        {
            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.WindowStyle = ProcessWindowStyle.Normal;
            procInfo.UseShellExecute = false;
            procInfo.Verb = " ";

            switch (this.InstallerType)
            {
                case InstallMethod.msi:
                case InstallMethod.exe:
                    procInfo.FileName = this.InstallerFilePath;
                    procInfo.Arguments = " ";
                break;
                case InstallMethod.bin:
                case InstallMethod.run:
                    Syscall.chmod(this.InstallerFilePath, FilePermissions.ACCESSPERMS);
                    procInfo.FileName = this.InstallerFilePath;
                    procInfo.Arguments = " ";
                break;
                case InstallMethod.rpm:
                    procInfo.FileName = "rpm";
                    procInfo.Arguments = " -U " + this.InstallerFilePath;
                break;
                case InstallMethod.deb:
                    procInfo.FileName = "sudo dpkg";
                    procInfo.Arguments = " -i " + this.InstallerFilePath;
                break;
                case InstallMethod.zip:
                    throw new NotImplementedException("Zip updates are not currently implemented.");
                case InstallMethod.src:
                    throw new NotImplementedException("Source build updates are not currently implemented.");
                default:
                    throw new IndexOutOfRangeException("Unexpected installer type found while attempting to execute the installer." + this.InstallerType.ToString());
            }

            Process.Start(procInfo);
        }
    }
}