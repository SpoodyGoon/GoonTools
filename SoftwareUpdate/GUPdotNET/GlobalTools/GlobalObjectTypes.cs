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

    public enum ProcessorBit
    {
        Any,
        x32,
        x64
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

