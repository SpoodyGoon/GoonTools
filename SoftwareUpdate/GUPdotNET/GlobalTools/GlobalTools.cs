using System;
using GUPdotNET.Data;
using GUPdotNET.IO;
using MonoTools.IO;
using System.Configuration;

namespace GUPdotNET
{
	internal static class GlobalTools
    {
        internal static string UpdateProgramName { get; private set; }

        internal static RunType UpdateRunType { get; set; }

        internal static UpdateSettings Options { get; set; }

		internal static UpdatePackageInfo PackageInfo{ get; set; }

		internal static UpdateProgramInfo ProgramInfo{ get; set; }

        internal static LocalSystemTools LocalSystem { get; private set; }

		internal static void Initalize()
		{
            UpdateProgramName = ConfigurationManager.AppSettings["UpdateProgramName"].ToString();
			LocalSystem = new LocalSystemTools();
			LocalSystem.Initalize();
            Options = new UpdateSettings();
            Options.Load();
		}
	}
}

