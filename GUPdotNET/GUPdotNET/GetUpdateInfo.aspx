<%@ Page Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>
<script runat="server">
	
	void Page_Load()
	{
		string strLinuxFile_rpm ="http://www.brdstudio.net/ff/FFMod.7z";
		string strLinuxFile_bin = "http://www.brdstudio.net/ff/FFMod.7z";
		string strWindowsFile = "http://www.brdstudio.net/ff/FFMod.7z";
		string OSVersion = null;
		string strLinuxFileType = null;
		double dblLastestVersion = 1.0;
		string strLatestVersion = "1.0";
		string strFileSize = "269357";
		if(Request.QueryString["OSVersion"] != null)
			OSVersion = Request.QueryString["OSVersion"].ToString();
		double dblCurrentVersioin = double.Parse(Request.QueryString["Version"].ToString());
		
		if(dblCurrentVersioin < dblLastestVersion)
		{
			Response.Write("<?xml version=\"1.0\"?>");
			Response.Write("<GUPdotNET>");
			Response.Write("<NeedToBeUpdated>yes</NeedToBeUpdated>");
			Response.Write("<Version>" + strLatestVersion + "</Version>");
			Response.Write("<FileSize>" + strFileSize + "</FileSize>");
			
			if(OSVersion == "Linux")
				Response.Write("<Location>" + strLinuxFile_rpm + "</Location>");
			else
				Response.Write("<Location>" + strWindowsFile + "</Location>");
			Response.Write("<LinuxFileType>" + strLinuxFileType + "</LinuxFileType>");
			Response.Write("</GUPdotNET>");
		}
		else
		{
			Response.Write("<?xml version=\"1.0\"?>");
			Response.Write("<GUPdotNET>");
			Response.Write("<NeedToBeUpdated>no</NeedToBeUpdated>");
			Response.Write("<Version></Version>");
			Response.Write("<Location></Location>");
			Response.Write("<LinuxFileType></LinuxFileType>");
			Response.Write("</GUPdotNET>");
			Response.Write("<LinuxFileType></LinuxFileType>");
		}
	}
</script>
