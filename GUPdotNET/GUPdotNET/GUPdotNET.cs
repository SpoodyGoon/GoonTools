// GUPdotNET.cs
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

using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Security;
using System.Security.Permissions;
using Gtk;

namespace GUPdotNET
{
	
	
	public static class GUPdotNET
	{
		
		private static Hashtable hshOptions = new Hashtable();		
		public static bool CheckUpdate()
		{
			bool blnSuccess = true;
			try
			{
				LoadUpdateInfo();
				if(GetOption("NeedToBeUpdated").ToLower() == "no")
				{
					Gtk.Application.Quit();
				}
				else
				{	
					frmUpdateConfirm fm = new frmUpdateConfirm();
					fm.Show ();
					Application.Run ();
				}
				
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			return blnSuccess;
		}
		
		
		
		public static void LoadUpdateInfo()
		{		
			try
			{
				Console.WriteLine("version " + ConfigurationManager.AppSettings["MajorVersion"].ToString());
				//System.Security.Permissions.EnvironmentPermission ep = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, System.Environment.CurrentDirectory);
				string strOSVersion = "";
				if(ConfigurationManager.AppSettings["OSVersion"].ToString() != String.Empty)
					strOSVersion = "&OSVersion=" + ConfigurationManager.AppSettings["OSVersion"].ToString();
				string strURI = ConfigurationManager.AppSettings["InfoUrl"].ToString() + 
								"?MajorVersion=" + ConfigurationManager.AppSettings["MajorVersion"].ToString() + 
								"?MinorVersion=" + ConfigurationManager.AppSettings["MinorVersion"].ToString() + 
								strOSVersion;
				
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strURI);
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				// Parse out the xml that has been returned
				ParseResponse(s);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
			
		public static void ParseResponse(Stream s)
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
		        xmlDoc.Load(s);
				
		        XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				for (int i = 0; i < nl.Count; i++)
		        {
					SetOption("NeedToBeUpdated", nl[i].SelectSingleNode("NeedToBeUpdated").InnerText);
					SetOption("Version", nl[i].SelectSingleNode("Version").InnerText);
					SetOption("Location", nl[i].SelectSingleNode("Location").InnerText);
					SetOption("FileSize", nl[i].SelectSingleNode("FileSize").InnerText);
					SetOption("LinuxFileType", nl[i].SelectSingleNode("LinuxFileType").InnerText);
				}
			}
			
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		public static string GetOption(string strKey)
        {
			if(hshOptions.ContainsKey(strKey))
                return (string)hshOptions[strKey];
            else
                return null;
        }

        public static void SetOption(string strKey, string strValue)
        {
			try
			{
	            if(!hshOptions.ContainsKey(strKey))
	                hshOptions.Add(strKey, strValue);
				else
					hshOptions[strKey] = strValue;
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
        }
	}
}