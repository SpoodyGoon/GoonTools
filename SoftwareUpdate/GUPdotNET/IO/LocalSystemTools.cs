//
//  LocalSystemTools.cs
//
//  Author:
//       Andy York <andy@brdstudio.net>
//
//  Copyright (c) 2013 Andy York 2012
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using System.Configuration;
using System.Reflection;
using Gtk;

namespace MonoTools.IO
{
	public class LocalSystemTools
	{
		public string AppPath { get; set; }

		public string UserDataPath { get; set; }

		public string OS { get; set; }

		public bool DebugMode { get; set; }

		public string UpdatePackageURL{ get; set; }

		public string TempFilePath{ get; set;}

		public void Initalize()
		{
			// get OS information
			switch(Environment.OSVersion.Platform)
			{
			case PlatformID.Win32NT:
			case PlatformID.Win32S:
			case PlatformID.Win32Windows:
			case PlatformID.WinCE:
				this.OS = "Windows";
			break;
			case PlatformID.Unix:
				this.OS = "Linux";
			break;
			case PlatformID.MacOSX:
				this.OS = "Mac";
			break;
			}

			// Get commonly used path information
			Assembly asm = Assembly.GetExecutingAssembly();
			this.AppPath = new FileInfo(asm.Location).Directory.FullName;
			this.DebugMode = Convert.ToBoolean(ConfigurationManager.AppSettings["DebugMode"]);
			this.UpdatePackageURL = ConfigurationManager.AppSettings["UpdatePackageURL"].ToString();

			// if the application is in debug mode store the user data under the apppath
			// otherwise use the users local application data path
			if(this.DebugMode)
			{
				this.UserDataPath = Path.Combine(this.AppPath, "DebugData", "GUPdotNET");            
			}
			else
			{                
				this.UserDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GUPdotNet"); 
			}

			if(!Directory.Exists(this.UserDataPath))
			{
				Directory.CreateDirectory(this.UserDataPath);
			}
		}
	}
}

