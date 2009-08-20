<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>

<script language="C#" runat="server">

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

    protected void Page_Load(object sender, EventArgs e)
    {
		#region Input Variables
    	
    	// the operating system for the update 
    	// expected values (Windows, Linux, Mac)
    	private string OS = string.Empty;
    	// the type of install for the update
    	// expected values (Installer,RPM, DEB, BIN, TGZ, SRC)  
    	private string InstallType = string.Empty;
    	
    	#endregion Input Variables
    	
        #region Feedback Variables

		// Major version of the update program
        private int UpdateMajorVersion = 0;
        // Minor version of the update program
        private int UpdateMinorVersion = 2;
        // friendly version string format
        private string LatestVersion = "0.2";
        // http URL of the new program
        private string UpdateFileURL = string.Empty;
        // http URL of the update details if any
        // this is intended for the change log put it could change
        // for starting it will be just a text file.
        private string UpdateDetailsURL = string.Empty;
        // for any UpdateError that may happen
        private string UpdateError = string.Empty;

        #endregion  Feedback Variables
    
		#region Get Input
        	
		if(Request.QueryString["InstallType"] != null)
			InstallType = Request.QueryString["InstallType"].ToString();
		else
			UpdateError += "Missing Install Type - Invalid Request";
			
		if(Request.QueryString["OS"] != null)
			OS = Request.QueryString["OS"].ToString();
		else
			UpdateError += "Missing Operating System - Invalid Request";
			
		#endregion Get Input
	
		switch (OS)
		{
			case "Windows":
				UpdateFileURL = "http://www.brdstudio.net/yahtzeesharp/yathzeesharp.exe";
				UpdateDetailsURL = "http://www.brdstudio.net/yahtzeesharp/yathzeesharp.exe";
				break;
			case "Linux":
				UpdateFileURL = "";
				UpdateDetailsURL = "";
				UpdateError += "Sorry Linux is not currently supported";
				break;
			case "Mac":
				UpdateFileURL = "";
				UpdateDetailsURL = "";
				UpdateError += "Sorry Mac is not currently supported";
				break;
			case "BSD":
				UpdateFileURL = "";
				UpdateDetailsURL = "";
				UpdateError += "Sorry BSD is not currently supported";
				break;
			default:
				UpdateError += "Should not get here";
				break;
		}
		
        Response.Write("<?xml version=\"1.0\"?>");
        Response.Write("<GUPdotNET>");
		Response.Write("<UpdateMajorVersion>" + UpdateMajorVersion.ToString() + "</UpdateMajorVersion>";
		Response.Write("<UpdateMinorVersion>" + UpdateMinorVersion.ToString() + "</UpdateMinorVersion>";
		Response.Write("<LatestVersion>" + LatestVersion + "</LatestVersion>";
		Response.Write("<UpdateFileURL>" + UpdateFileURL + "</UpdateFileURL>";
		Response.Write("<UpdateDetailsURL>" + UpdateDetailsURL + "</UpdateDetailsURL>";
        Response.Write("<UpdateError>" + UpdateError + "</UpdateError>");
        Response.Write("</GUPdotNET>");

   }
</script>

