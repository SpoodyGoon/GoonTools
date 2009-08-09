<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>

<script runat="server">

/*************************************************************************
 *                      GetUpdateInfo.aspx                                     
 *                                                                       
 *  Copyright (C) 2009 Andrew York <goontools@brdstudio.net>         
 *                                                                        
 *************************************************************************/
/*
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>
 */

    void Page_Load()
    {
        #region "Feedback Variables"

        int _UpdateMajorVersion = 0;
        int _UpdateMinorVersion = 2;
        int _FileSize = 18722816;
        string _LatestVersion = "0.2";
        string _UpdateFileURL = "";
        string _Error = "";

        #endregion  "Feedback Variables"
		
		try
        {
            #region "Install Files URL"

            string _WindowsFile = "http://www.brdstudio.net/yahtzeesharp/yathzeesharp.exe";
            string _LinuxFile_rpm = "";
            string _LinuxFile_bin = "";
            string _LinuxFile_src = "";

            #endregion "Install Files URL"
			
			if(Request.QueryString["InstallType"] != null)
			{
				switch (Request.QueryString["InstallType"].ToString())
				{
					case "Win32":
						_UpdateFileURL = _WindowsFile;
						break;
					case "Linux_rpm":
						_UpdateFileURL = _LinuxFile_rpm;
						break;
					case "Linux_bin":
						_UpdateFileURL = _LinuxFile_bin;
						break;
					case "Linux_src":
						_UpdateFileURL = _LinuxFile_src;
						break;
					default:
						// default is windows
						_UpdateFileURL = _WindowsFile;
						break;
				}
			}
			else
			{
				_Error = "InstallType Not Set";
			}
		}
		catch (Exception Ex)
		{
			_Error = Ex.ToString();
		}

        Response.Write("<?xml version=\"1.0\"?>");
        Response.Write("<GUPdotNET>");
        Response.Write("<UpdateFileURL>" + _UpdateFileURL + "</UpdateFileURL>");
        Response.Write("<UpdateMajorVersion>" + _UpdateMajorVersion.ToString() + "</UpdateMajorVersion>");
        Response.Write("<UpdateMinorVersion>" + _UpdateMinorVersion.ToString() + "</UpdateMinorVersion>");
        Response.Write("<LatestVersion>" + _LatestVersion + "</LatestVersion>");
        Response.Write("<Error>" + _Error + "</Error>");
        Response.Write("</GUPdotNET>");

    }
</script>

