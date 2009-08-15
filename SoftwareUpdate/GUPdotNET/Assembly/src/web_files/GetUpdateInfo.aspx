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
    	System.Text.StringBuilder sbResponse = new System.Text.StringBuilder();
    
    	#region Input Variables
    	
    	// the operating system for the update 
    	// expected values (Windows, Linux, Mac, BSD)
    	private string _OS = string.Empty;
    	// the type of install for the update
    	// expected values (Installer,RPM, DEB, BIN, TGZ, SRC)  
    	private string _InstallType = string.Empty;
    	
    	#endregion Input Variables
    	
        #region Feedback Variables

		// Major version of the update program
        int _UpdateMajorVersion = 0;
        // Minor version of the update program
        int _UpdateMinorVersion = 2;
        // friendly version string format
        string _LatestVersion = "0.2";
        // http URL of the new program
        string _UpdateFileURL = string.Empty;
        // http URL of the update details if any
        string _UpdateDetailsURL = string.Empty;
        // for any error that may happen
        string _Error = string.Empty;

        #endregion  Feedback Variables
		
		try
        {
        
        	#region Get Input
        	
        	if(Request.QueryString["InstallType"] != null)
        		_InstallType = Request.QueryString["InstallType"].ToString();
        	else
        		throw new Exception("Missing Install Type - Invalid Request");
        		
        	if(Request.QueryString["OS"] != null)
        		_OS = Request.QueryString["OS"].ToString();
        	else
        		throw new Exception("Missing Operating System - Invalid Request");
        		
        	
        	
        	#endregion Get Input
        	
            #region "Install Files URL"

            string _WindowsFile = "http://www.brdstudio.net/yahtzeesharp/yathzeesharp.exe";
            string _LinuxFile_rpm = "";
            string _LinuxFile_bin = "";
            string _LinuxFile_src = "";

            #endregion "Install Files URL"
			
			switch (Request.QueryString["InstallType"].ToString())
			{
				case "Windows":
					_UpdateFileURL = _WindowsFile;
					break;
				case "Linux":
					_UpdateFileURL = _LinuxFile_rpm;
					break;
				case "Mac":
					_UpdateFileURL = _LinuxFile_src;
					break;
				case "BSD":
					_UpdateFileURL = _LinuxFile_bin;
					break;
				default:
					// default is windows
					_UpdateFileURL = _WindowsFile;
					break;
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
        Response.Write("<UpdateMajorVersion>" + _UpdateMajorVersion.ToString() + "</UpdateMajorVersion>");
        Response.Write("<UpdateMinorVersion>" + _UpdateMinorVersion.ToString() + "</UpdateMinorVersion>");
        Response.Write("<LatestVersion>" + _LatestVersion + "</LatestVersion>");
        Response.Write("<UpdateFileURL>" + _UpdateFileURL + "</UpdateFileURL>");
        Response.Write("<UpdateDetailsURL>" + _UpdateDetailsURL + "</UpdateDetailsURL>");
        Response.Write("<Error>" + _Error + "</Error>");
        Response.Write("</GUPdotNET>");

    }
</script>

