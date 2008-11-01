// Main.cs created with MonoDevelop
// User: spoodygoon at 7:28 PM 6/1/2008
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
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
	class MainClass
	{
		private static Hashtable hshOptions = new Hashtable();
		public static void Main (string[] args)
		{
			Application.Init ();
			
			try
			{
				if(File.Exists("gdnFirstRunNo.txt"))
				{
					Application.Quit();
				}
				else
				{
					LoadUpdateInfo();
					if(GetOption("NeedToBeUpdated").ToLower() == "no")
					{
						Gtk.Application.Quit();
					}
					else
					{	
						frmUpdateConfirm fm = new frmUpdateConfirm();
						//MainWindow fm = new MainWindow();
						fm.Show ();
						Application.Run ();
					}
				}
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		public static void LoadUpdateInfo()
		{		
			try
			{
				System.Security.Permissions.EnvironmentPermission ep = new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, System.Environment.CurrentDirectory);
				string strOSVersion = "";
				if(ConfigurationManager.AppSettings["OSVersion"].ToString() != String.Empty)
					strOSVersion = "&OSVersion=" + ConfigurationManager.AppSettings["OSVersion"].ToString();
				string strURI = ConfigurationManager.AppSettings["InfoUrl"].ToString() + "?Version=" + ConfigurationManager.AppSettings["Version"].ToString() + strOSVersion;
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(strURI);
				
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				
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
