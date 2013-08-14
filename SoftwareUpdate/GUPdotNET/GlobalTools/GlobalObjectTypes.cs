using System;

namespace GUPdotNET
{
	
	public enum RunType
	{
		ManualCheck,
		BackgroundCheck,
		Options
	}

	public enum DownloadStatus
	{
		None,
		Prep,
		InProcess,
		Success,
		Canceled,
		Error
	}

	public enum InstallMethod
	{
		msi,
		exe,
		zip,
		bin,
		rpm,
		deb,
		src
	}
}

