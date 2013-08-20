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

        internal static bool DebugMode { get; private set; }

        internal static UpdateSettings Options { get; set; }

		internal static UpdatePackageInfo PackageInfo{ get; set; }

		internal static UpdateProgramInfo ProgramInfo{ get; set; }

        internal static LocalSystemTools LocalSystem { get; private set; }

		internal static void Initalize()
		{
            UpdateProgramName = ConfigurationManager.AppSettings["UpdateProgramName"].ToString();
            DebugMode = Convert.ToBoolean(ConfigurationManager.AppSettings["DebugMode"]);
			LocalSystem = new LocalSystemTools();
            LocalSystem.Initalize(DebugMode);
            Options = new UpdateSettings();
            Options.Load();
		}
	}
}

