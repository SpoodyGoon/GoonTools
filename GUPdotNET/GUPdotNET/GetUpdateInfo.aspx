<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>
<script runat="server">

// GetUpdateInfo.aspx
// 
// Copyright (C) 2008 SpoodyGoon
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
	
	void Page_Load()
	{
		string _LinuxFile_rpm ="http://www.brdstudio.net/ff/FFMod.7z";
		string _LinuxFile_bin = "http://www.brdstudio.net/ff/FFMod.7z";
		string _LinuxFile_src = "http://www.brdstudio.net/ff/FFMod.7z";
		string _WindowsFile = "http://www.brdstudio.net/ff/FFMod.7z";
		string _UpdateFileURL = null;
		string _OSVersion = null;
		string _LinuxFileType = null;
		int _UpdateMajorVersion = 0;
		int _UpdateMinorVersion = 1;
		string _LatestVersion = "0.01";
		string _FileSize = null;
		string _Windows_FileSize = "269357";
		string strLinux_src_FileSize = "269357";
		string strLinux_rpm_FileSize = "269357";
		string strLinux_bin_FileSize = "269357";
		
		if(Request.QueryString["OSVersion"] != null)
		{
			_OSVersion = Request.QueryString["OSVersion"].ToString();
			_UpdateFileURL = _WindowsFile;
			_FileSize = _Windows_FileSize;
		}
		else
		{
			OSVersion = "win32"; // Assume Windows 32 bit
		}	

		
			
		double dblCurrentVersioin = double.Parse(Request.QueryString["Version"].ToString());
		
			Response.Write("<?xml version=\"1.0\"?>");
			Response.Write("<GUPdotNET>");
			Response.Write("<UpdateFileURL>" + _UpdateFileURL + "</UpdateFileURL>");
			Response.Write("<UpdateMajorVersion>" + strLatestVersion + "</UpdateMajorVersion>");
			Response.Write("<UpdateMinorVersion>" + strLatestVersion + "</UpdateMinorVersion>");
			Response.Write("<LatestVersion>" + _LatestVersion + "</LatestVersion>");
			Response.Write("<FileSize>" + _FileSize + "</FileSize>");
			
			if(OSVersion == "Linux")
				Response.Write("<Location>" + strLinuxFile_rpm + "</Location>");
			else
				Response.Write("<Location>" + strWindowsFile + "</Location>");
			Response.Write("<LinuxFileType>" + strLinuxFileType + "</LinuxFileType>");
			Response.Write("</GUPdotNET>");
		
	}
</script>
