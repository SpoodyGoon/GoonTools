
using System;

namespace GoonTools
{		
	public enum UpdateDateType
	{
		Day,
		Week,
		Month,
		Year,
		Never
	}
	
	
	public enum OperatingSystem
	{
		Windows,
		Linux,
		Mac,
		BSD,
		None // for initialization
	}
	
	
	public enum InstallType
	{
		Installer, // mostly with Windows and Mac 
		RPM, // Linux Pakage Installer
		DEB, // Linux Package Installer
		BIN, // Linux Binary
		TGZ, // Linux Slackware
		SRC,  // Generic Source
		None // for initialization
	}
}