using System;
using GUPdotNET.Data;
using MonoTools.IO;
using System.Configuration;

namespace GUPdotNET
{
	internal static class GlobalTools
    {
        internal static string UpdateProgramName { get; private set; }

        internal static RunType UpdateRunType { get; set; }

        internal static bool DebugMode { get; private set; }

        internal static AppSettings Options { get; set; }

		internal static PackageInfo PackageInfo{ get; set; }

		internal static ProgramInfo ProgramInfo{ get; set; }

        internal static LocalSystemTools LocalSystem { get; private set; }

		internal static void Initalize()
		{
            UpdateProgramName = ConfigurationManager.AppSettings["UpdateProgramName"].ToString();
            DebugMode = Convert.ToBoolean(ConfigurationManager.AppSettings["DebugMode"]);
			LocalSystem = new LocalSystemTools();
            LocalSystem.Initalize(DebugMode);
            Options = new AppSettings();
            Options.Load();
		}
	}
}

