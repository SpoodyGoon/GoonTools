using System;
using GUPdotNET.Data;

namespace GUPdotNET
{
	internal static class GlobalTools
	{
		internal static UpdateOptions Options{ get; set; }

		internal static StartupOptions Startup{ get; set; }


		internal static void Initalize()
		{
			Startup = new StartupOptions();
			Options = new UpdateOptions();
		}
	}
}

