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
			set{GUPdotNET.ProgramName = value;}
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
		
		public string CallingApplication
		{
			set{GUPdotNET.CallingApplication = value;}
		}

		public void RunCheck()
		{
			try
			{
				LoadUpdateInfo();
				if(GUPdotNET.UpdateMajorVersion > GUPdotNET.CurrentMajorVersion || (GUPdotNET.UpdateMajorVersion == GUPdotNET.CurrentMajorVersion && GUPdotNET.UpdateMinorVersion > GUPdotNET.CurrentMinorVersion))
				{
					frmUpdateConfirm fm = new frmUpdateConfirm();
					fm.Show ();
					Application.Run ();
				}
				else
				{
					if(GUPdotNET.SilentCheck == false)
					{
						Gtk.MessageDialog md = new Gtk.MessageDialog(null, DialogFlags.Modal, MessageType.Error, Gtk.ButtonsType.Ok, false, "Not updates avalable at this time." ,"No updates");
						md.Run();
						md.Destroy();
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
		
		 private void LoadUpdateInfo()
		{
			try
			{
				HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create(GUPdotNET.UpdateInfoURL + "?InstallType=" + GUPdotNET.InstallType);
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
		
		 private void ParseResponse(Stream s)
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(s);
				
				XmlNodeList nl = xmlDoc.SelectNodes("GUPdotNET");
				for (int i = 0; i < nl.Count; i++)
				{
					GUPdotNET.UpdateFileURL = nl[i].SelectSingleNode("UpdateFileURL").InnerText;
					GUPdotNET.UpdateMajorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMajorVersion").InnerText);
					GUPdotNET.UpdateMinorVersion = int.Parse(nl[i].SelectSingleNode("UpdateMinorVersion").InnerText);
					GUPdotNET.LatestVersion = nl[i].SelectSingleNode("LatestVersion").InnerText;
					GUPdotNET.Error = nl[i].SelectSingleNode("Error").InnerText;
				}
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
