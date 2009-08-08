/*************************************************************************
 *                      GUPdotNET.cs
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

using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.Configuration;
using System.Security;
using System.Reflection;
using System.Security.Permissions;
using Gtk;

namespace GUPdotNET
{
	public class UpdateCheck
	{
		public string InstallType
		{
			set{GUPdotNET.InstallType=value;}
		}
		
		public string ProgramName
		{
			set{GUPdotNET.ProgramTitle = value;}
		}
		
		public  string ProgramFullPath
		{
			set{GUPdotNET.ProgramFullPath = value;}
		}
		
		public string UpdateInfoURL
		{
			set{GUPdotNET.UpdateInfoURL = value;}
		}
		
		public int CurrentMajorVersion
		{
			set{GUPdotNET.CurrentMajorVersion=value;}
		}
		
		public int CurrentMinorVersion
		{
			set{GUPdotNET.CurrentMinorVersion=value;}
		}
		
		public bool SilentCheck
		{
			set{GUPdotNET.SilentCheck=value;}
		}

		public void RunCheck(bool blnSilentCheck)
		{
			try
			{
				Gtk.ResponseType UpConResp = ResponseType.None;
				Gtk.ResponseType UpDownResp = ResponseType.None;
				
				// load the local data
				LoadLocalInfo(blnSilentCheck);
				
				// load the update info from the web
				LoadUpdateInfo();
				// check if we need an update via the major and minor version
				if(GUPdotNET.UpdateMajorVersion > GUPdotNET.CurrentMajorVersion || (GUPdotNET.UpdateMajorVersion == GUPdotNET.CurrentMajorVersion && GUPdotNET.UpdateMinorVersion > GUPdotNET.CurrentMinorVersion))
				{
					// tell the user there is an update availalbe
					// and ask if they would like to update
					frmUpdateConfirm UpCon = new frmUpdateConfirm();
					UpConResp = (Gtk.ResponseType)UpCon.Run();
					UpCon.Destroy();
					
					// if the user wants an update start the update dialog
					if(UpConResp == Gtk.ResponseType.Yes)
					{
						frmUpdateDownload UpDown = new frmUpdateDownload();
						UpDownResp = (Gtk.ResponseType)UpDown.Run();
						UpDown.Destroy();
					}
					
					// if the download was sucessful then procede with the install
					if(UpDownResp == ResponseType.Ok)
					{
						frmInstallDialog Inst = new frmInstallDialog();
						Inst.Run();
						Inst.Destroy();
					}
				}
				else
				{
					if(GUPdotNET.SilentCheck == false)
					{
						Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "No updates avalable at this time." ,"No updates");
						md.Run();
						md.Destroy();
					}
				}
				
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString() ,"Error");
				md.Run();
				md.Destroy();
			}
		}
		
		private void LoadLocalInfo(bool blnSilentCheck)
		{
			GUPdotNET.SilentCheck = blnSilentCheck;
			GUPdotNET.ProgramFullPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
			GUPdotNET.ProgramName = ConfigurationManager.AppSettings["ProgramName"].ToString();
			GUPdotNET.InstallType = ConfigurationManager.AppSettings["InstallType"].ToString();
			GUPdotNET.ProgramTitle = ConfigurationManager.AppSettings["ProgramTitle"].ToString();
			GUPdotNET.UpdateInfoURL = ConfigurationManager.AppSettings["UpdateInfoURL"].ToString();
			GUPdotNET.CurrentMajorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMajorVersion"].ToString());
			GUPdotNET.CurrentMinorVersion = Convert.ToInt32(ConfigurationManager.AppSettings["CurrentMinorVersion"].ToString());
		}
		
		#region Update Info Web
		
		private void LoadUpdateInfo()
		{
			try
			{
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(ConfigurationManager.AppSettings["UpdateInfoURL"].ToString() + "?InstallType=" + ConfigurationManager.AppSettings["InstallType"].ToString() );
				HttpWebResponse wsp = (HttpWebResponse)wr.GetResponse();
				System.IO.Stream s = wsp.GetResponseStream();
				ParseResponse(s);
			}
			catch(WebException e)
			{
				// if we get a web exception exit the update
				ExitUpdate("Unable to connect to the update web site - " + System.Environment.NewLine + e.Message);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
		}
		
		private void ParseResponse(Stream s)
		{
			try
			{
				// get the xml that defines the update
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(s);
				
				XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				// parse out the GUPdotNET element children
				for (int i = 0; i < nl.Count; i++)
				{
					GUPdotNET.UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText;
					GUPdotNET.UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText);
					GUPdotNET.UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText);
					GUPdotNET.LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText;
					GUPdotNET.Error = nl[i].SelectSingleNode("Error").InnerText;
				}
				// check for an error from the server
				if(GUPdotNET.Error.Length > 2)
					ExitUpdate("Error parsing the update xml file - " + System.Environment.NewLine + GUPdotNET.Error);
			}
			catch(Exception doh)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, doh.ToString());
				md.Run();
				md.Destroy();
			}
			
		}
		
		#endregion Update Info Web
		
		private void ExitUpdate(string strExitMess)
		{
			// if we don't want a silent check tell the user
			// why we can't update
			if(GUPdotNET.SilentCheck == false && strExitMess != null)
			{
				Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, strExitMess, "Exiting Update");
				md.Run();
				md.Destroy();
			}
			
		}
	}
}
