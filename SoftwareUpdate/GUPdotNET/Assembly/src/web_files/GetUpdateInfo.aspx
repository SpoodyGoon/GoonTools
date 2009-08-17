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

    protected virtual void Page_Load()
    {
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
        // this is intended for the change log put it could change
        // for starting it will be just a text file.
        string _UpdateDetailsURL = string.Empty;
        // for any error that may happen
        string _Error = string.Empty;

        #endregion  Feedback Variables
		System.Text.StringBuilder sbResponse = new System.Text.StringBuilder();
    
    	
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
        	
        	// start our xml string
        	sbResponse.Append("<UpdateMajorVersion>" + _UpdateMajorVersion.ToString() + "</UpdateMajorVersion>");
	        sbResponse.Append("<UpdateMinorVersion>" + _UpdateMinorVersion.ToString() + "</UpdateMinorVersion>");
	        sbResponse.Append("<LatestVersion>" + _LatestVersion + "</LatestVersion>");
        
            switch (_OS)
			{
				case "Windows":
					sbResponse.Append("<UpdateFileURL>http://www.brdstudio.net/yahtzeesharp/yathzeesharp.exe</UpdateFileURL>");
					sbResponse.Append("<UpdateDetailsURL>http://www.brdstudio.net/yahtzeesharp/yathzeesharp.exe</UpdateDetailsURL>");
					break;
				case "Linux":
					sbResponse.Append("<UpdateFileURL></UpdateFileURL>");
					sbResponse.Append("<UpdateDetailsURL></UpdateDetailsURL>");
					_Error = "Sorry Linux is not currently supported";
					break;
				case "Mac":
					sbResponse.Append("<UpdateFileURL></UpdateFileURL>");
					sbResponse.Append("<UpdateDetailsURL></UpdateDetailsURL>");
					_Error = "Sorry Mac is not currently supported";
					break;
				case "BSD":
					sbResponse.Append("<UpdateFileURL></UpdateFileURL>");
					sbResponse.Append("<UpdateDetailsURL></UpdateDetailsURL>");
					_Error = "Sorry BSD is not currently supported";
					break;
				default:
					_Error = "Should not get here";
					break;
			}
		}
		catch (Exception Ex)
		{
			_Error = Ex.ToString();
		}

        Response.Write("<?xml version=\"1.0\"?>");
        Response.Write("<GUPdotNET>");
        Response.Write(sbResponse.ToString());
        Response.Write("<Error>" + _Error + "</Error>");
        Response.Write("</GUPdotNET>");

    }
</script>

