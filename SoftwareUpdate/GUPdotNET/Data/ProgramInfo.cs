

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
        /// This is the actual name of the program <example>MyProgram.exe</example>.
        /// </summary>
        internal string ProgramName { get; private set; }

        /// <summary>
        ///  The freindly name of the application
        /// </summary>
        internal string ProgramTitle { get; private set; }

        /// <summary>
        /// Gets or sets the program description.
        /// </summary>
        internal string ProgramDescription { get; private set; }

        /// <summary>
        /// The current version of the program GUPdotNET is supporting,
        /// gotten from the settings file if present, otherwise gotten from the 
        /// calling assebly.
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
        /// This is the Operating System info gotten from
        /// the settings file if it is available, otherwise gotten from
        /// System.Enviroment methods.
        /// </summary>
        internal string OS { get; private set; }

        /// <summary>
        /// The type of installer that is being supported by GUPdotNET.
        /// </summary>
        internal InstallMethod InstallType { get; private set; }

        internal ProcessorBit ProcessorType { get; private set; }

        /// <summary>
        ///  The URL for the config file containing the update information.
        /// </summary>
        internal string UpdatePackageURL { get; private set; }

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
