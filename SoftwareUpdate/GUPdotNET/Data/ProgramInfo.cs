//
//  ProgramInfo.cs
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
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Gtk;

    /// <summary>
    /// Data class containing the information concerning the program
    /// that GUPdotNET is supporting.
    /// </summary>
    internal class ProgramInfo
    {
        /// <summary>
        /// Gets the actual name of the program <example>MyProgram.exe</example>.
        /// </summary>
        internal string ProgramName { get; private set; }

        /// <summary>
        ///  Gets the friendly name of the application.
        /// </summary>
        internal string ProgramTitle { get; private set; }

        /// <summary>
        /// Gets the program description.
        /// </summary>
        internal string ProgramDescription { get; private set; }

        /// <summary>
        /// Gets the current version of the program GUPdotNET is supporting,
        /// gotten from the settings file if present, otherwise gotten from the 
        /// calling assembly.
        /// </summary>
        internal System.Version ProgramVersion { get; private set; }

        /// <summary>
        /// Gets the full path to the application we are updating,
        /// should be the same directory that GUPdotNET is in.
        /// </summary>
        internal string ProgramFullPath
        {
            get
            {
                return Path.Combine(GlobalTools.LocalSystem.AppPath, Properties.Settings.Default.UpdateFileName);
            }
        }

        /// <summary>
        /// Gets the Operating System info gotten from
        /// the settings file if it is available.
        /// </summary>
        internal string OS { get; private set; }

        /// <summary>
        /// Gets the type of installer that is being supported by GUPdotNET.
        /// </summary>
        internal InstallMethod InstallType { get; private set; }

        /// <summary>
        /// Gets the type of the processor whether the installer is for 64 bit, 32 bit or 'Any'.
        /// </summary>
        /// <value>The type of the processor.</value>
        internal ProcessorBit ProcessorType { get; private set; }

        /// <summary>
        ///  Gets the URL for the config file containing the update information.
        /// </summary>
        internal string UpdatePackageURL { get; private set; }

        /// <summary>
        /// A method for loading program information into the data object.
        /// </summary>
        internal void Load()
        {
            Assembly updateAssembly = Assembly.LoadFrom(this.ProgramFullPath);
            this.ProgramName = (updateAssembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0] as AssemblyProductAttribute).Product;
            this.ProgramTitle = (updateAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0] as AssemblyTitleAttribute).Title;
            this.ProgramDescription = (updateAssembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0] as AssemblyDescriptionAttribute).Description;
            this.ProgramVersion = System.Version.Parse((updateAssembly.GetCustomAttributes(typeof(AssemblyVersionAttribute), false)[0] as AssemblyVersionAttribute).Version);
            this.OS = GlobalTools.LocalSystem.OS;
            this.InstallType = (InstallMethod)Enum.Parse(typeof(InstallMethod), Properties.Settings.Default.InstallerType);
            this.ProcessorType = (ProcessorBit)Enum.Parse(typeof(ProcessorBit), Properties.Settings.Default.ProcessorType);
            this.UpdatePackageURL = Properties.Settings.Default.UpdatePackageURL;
        }
    }
}
