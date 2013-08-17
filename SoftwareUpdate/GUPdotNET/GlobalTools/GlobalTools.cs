using System;
using GUPdotNET.Data;
using GUPdotNET.IO;
using MonoTools.IO;

namespace GUPdotNET
{
	internal static class GlobalTools
	{
		internal static UpdateSettings Options{ get; set; }

		internal static RunType UpdateRunType{ get; set; }

		internal static UpdatePackageInfo PackageInfo{ get; set; }

		internal static UpdateProgramInfo ProgramInfo{ get; set; }

		internal static LocalSystemTools LocalSystem{ get; private set; }

		internal static void Initalize()
		{
			LocalSystem = new LocalSystemTools();
			LocalSystem.Initalize();
            ProgramInfo = new UpdateProgramInfo();
            ProgramInfo.Load();
            Options = new UpdateSettings();
            Options.Load();
		}
	}
}

