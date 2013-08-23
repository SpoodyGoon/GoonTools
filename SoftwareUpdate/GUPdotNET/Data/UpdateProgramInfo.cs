
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Gtk;

namespace GUPdotNET.Data
{
    /// <summary>
    /// Data class containing the information concerning the program
    /// that GUPdotNET is supporting.
    /// </summary>
    public class UpdateProgramInfo
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
        /// Gets or sets a value that indicates whether or not the processor is a 64 bit processor.
        /// </summary>
        internal bool Processor64 { get; private set; }

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
                return Path.Combine(GlobalTools.LocalSystem.AppPath, this.ProgramFileName);
            }
        }

        /// <summary>
        /// Gets the name of the program that is supported by GUPdotNET.
        /// <example>MyApp.exe</example>
        /// </summary>
        internal string ProgramFileName { get; private set; }

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

        /// <summary>
        ///  The URL for the config file containing the update information.
        /// </summary>
        internal string UpdatePackageURL { get; private set; }

        /// <summary>
        /// Gets the value indicating if the install package is required
        /// to have a checksum.
        /// </summary>
        internal bool RequireCheckSum { get; private set; }

        /// <summary>
        /// Gets a value indicating the version of the config file's format.
        /// </summary>
        internal System.Version FileVersion { get; private set; }

        /// <summary>
        /// The full file path to the program config file.
        /// </summary>
        private string configFilePath = string.Empty;

        /// <summary>
        /// The name of the program config file.
        /// </summary>
        private const string FILENAME = "GUPProgram.xml";

        /// <summary>
        /// Data access class for accessing local program infomation
        /// concerning the application that GUPdotNET is supporting.
        /// </summary>
        internal UpdateProgramInfo()
        {
            this.configFilePath = Path.Combine(GlobalTools.LocalSystem.AppPath, FILENAME);
        }

        internal void Load()
        {
            XDocument configDocument = XDocument.Load(this.configFilePath);
            XElement configRoot = configDocument.Element("GUPdotNET");
            var programInfo = (from e in configRoot.Descendants("ProgramConfig")
                               select new
                               {
                                   ProgramName = e.Element("ProgramName").Value,
                                   ProgramTitle = e.Element("ProgramTitle").Value,
                                   ProgramFileName = e.Element("ProgramFileName").Value,
                                   ProgramDescription = e.Element("ProgramDescription").Value,
                                   OS = e.Element("OS").Value,
                                   Processor64 = e.Element("Processor64").Value,
                                   InstallerType = e.Element("InstallerType").Value,
                                   UpdateInfoURL = e.Element("UpdateInfoURL").Value,
                                   ProgramVersion = e.Element("ProgramVersion").Value,
                                   RequireCheckSum = e.Element("RequireCheckSum").Value,
                                   FileVersion = e.Attribute("FileVersion").Value
                               }).SingleOrDefault();

            if (programInfo == null)
            {
                throw new Exception("Unable to parse program information required to process an update check");
            }

            this.ProgramName = programInfo.ProgramName.ToString();
            this.ProgramTitle = programInfo.ProgramTitle.ToString();
            this.ProgramFileName = programInfo.ProgramFileName.ToString();
            this.ProgramDescription = programInfo.ProgramDescription.ToString();
            this.OS = programInfo.OS.ToString();
            this.Processor64 = Convert.ToBoolean(programInfo.Processor64);
            this.UpdatePackageURL = programInfo.UpdateInfoURL.ToString();
            this.ProgramVersion = System.Version.Parse(programInfo.ProgramVersion);
            this.RequireCheckSum = bool.Parse(programInfo.RequireCheckSum);
            this.FileVersion = System.Version.Parse(programInfo.FileVersion);
            InstallMethod installMethodParse;
            if (Enum.TryParse<InstallMethod>(programInfo.InstallerType, out installMethodParse))
            {
                this.InstallType = installMethodParse;
            }
        }
    }
}
