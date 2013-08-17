using System;
using GUPdotNET.Data;
using GUPdotNET.IO;
using MonoTools.IO;

namespace GUPdotNET
{
	internal static class GlobalTools
	{
		internal static System.Action Initalized;

		internal static UpdateOptions Options{ get; set; }

		internal static RunType UpdateRunType{ get; set; }

		internal static UpdatePackageInfo PackageInfo{ get; set; }

		internal static UpdateProgramInfo ProgramInfo{ get; set; }

		internal static LocalSystemTools LocalSystem{ get; set; }

		internal static void Initalize()
		{
			LocalSystem = new LocalSystemTools();
			LocalSystem.Initalize();
			LocalConfigFile configFile = new LocalConfigFile();
			configFile.ConfigFileRead();
			UpdateProgramInfoReader programInfoReader = new UpdateProgramInfoReader();
			programInfoReader.CallingAssemblyRead();
			Initalized();
		}
	}
}

