<%
 '************************************************************************
 '                     	 GetUpdateInfo.asp                                     
 '                                                                       
 ' 			 Copyright (C) 2009 Andrew York <goontools@brdstudio.net>         
 '                                                                        
 '************************************************************************/
 '
 ' This program is free software: you can redistribute it and/or modify
 ' it under the terms of the GNU General Public License as published by
 ' the Free Software Foundation, either version 3 of the License, or
 ' (at your option) any later version.
 '
 ' This program is distributed in the hope that it will be useful,
 ' but WITHOUT ANY WARRANTY without even the implied warranty of
 ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 ' GNU General Public License for more details.
 '
 ' You should have received a copy of the GNU General Public License
 ' along with this program.  If not, see <http://www.gnu.org/licenses/>
 '************************************************************************/

		' Varable Declaration
    	DIM XMLFileVersion, OS, InstallType, UpdateMajorVersion, UpdateMinorVersion, LatestVersion, UpdateFileURL, CheckSumType, CheckSum, UpdateDetailsURL, UpdateError 
    	
		UpdateMajorVersion = 0
        ' Minor version of the update program
        UpdateMinorVersion = 2
        ' friendly version string format
        LatestVersion = "0.2"       

        '#region Get Input
		
		If Len(Request.QueryString("InstallType")) > 0 Then		
			InstallType = Request.QueryString("InstallType")
		Else
			UpdateError = UpdateError & "Missing Install Type - Invalid Request" & vbNewLine
		End If
		
		If Len(Request.QueryString("XMLFileVersion")) > 0 Then		
			XMLFileVersion = Request.QueryString("XMLFileVersion")
		Else
			XMLFileVersion = "1.0"
		End If
			
		If Len(Request.QueryString("OS")) > 0 Then
			OS = Request.QueryString("OS")
		Else
			UpdateError = UpdateError & "Missing Operating System - Invalid Request" & vbNewLine
		End If
			
		'#endregion Get Input
			
		' get the correct urls per OS and InstallType
		' expected OS values (Windows, Linux, Mac)
		' expected InstallType values (Installer,RPM, DEB, BIN, TGZ, SRC)  
		Select Case OS
			Case "Windows":
				UpdateFileURL = "http://www.brdstudio.net/yahtzeesharp/files/YahtzeeSharp-Mono-Setup.exe"
				UpdateDetailsURL = ""
				CheckSumType = "MD5"
				CheckSum = "69C559942301ACB9CE87C2A39DAFCCE0"
			Case "Linux":
				UpdateFileURL = ""
				UpdateDetailsURL = ""
				CheckSumType = "MD5"
				CheckSum = "69C559942301ACB9CE87C2A39DAFCCE0"
				UpdateError = UpdateError & "Sorry Linux is not currently supported" & vbNewLine
			Case "Mac":
				UpdateFileURL = ""
				UpdateDetailsURL = ""
				CheckSumType = "MD5"
				CheckSum = "69C559942301ACB9CE87C2A39DAFCCE0"
				UpdateError = UpdateError & "Sorry Mac is not currently supported" & vbNewLine
			Case "BSD":
				UpdateFileURL = ""
				UpdateDetailsURL = ""
				CheckSumType = "MD5"
				CheckSum = "69C559942301ACB9CE87C2A39DAFCCE0"
				UpdateError = UpdateError & "Sorry BSD is not currently supported" & vbNewLine
			Case Else
				UpdateError = UpdateError & "Should not get here" & vbNewLine
		End Select

		' write out the resultes
		
        Response.Write("<?xml version=""1.0""?>")
        Response.Write("<GUPdotNET>")
        Response.Write("<XMLFileVersion>" & XMLFileVersion & "</XMLFileVersion>")
		Response.Write("<UpdateMajorVersion>" & UpdateMajorVersion & "</UpdateMajorVersion>")
		Response.Write("<UpdateMinorVersion>" & UpdateMinorVersion & "</UpdateMinorVersion>")
		Response.Write("<LatestVersion>" & LatestVersion & "</LatestVersion>")
		Response.Write("<UpdateFileURL>" & UpdateFileURL & "</UpdateFileURL>")
		Response.Write("<UpdateDetailsURL>" & UpdateDetailsURL & "</UpdateDetailsURL>")
		Response.Write("<CheckSumType>" & CheckSumType & "</CheckSumType>")
		Response.Write("<CheckSum>" & CheckSum & "</CheckSum>")
        Response.Write("<UpdateError>" & UpdateError & "</UpdateError>")
        Response.Write("</GUPdotNET>")

 
%>

